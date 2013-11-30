using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.ADF;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Display;


namespace ArcGISFoundation
{
    public struct Pasture
    {
        public string                   strPasture;
        public string                   strMapDoc;
    };

    public struct GrassFamily
    {
        public string                   strFamily;
        public List<Pasture>            pastures;
    };

    public class DataSource
    {
        protected IMapControl3          m_mapcontrol;
        protected TreeView              m_tree;

        protected string                m_rootDir;
        protected List<GrassFamily>     m_grassFamilys = new List<GrassFamily>();
        protected Pasture               m_activepasture;

        public void Init(string rootDir, IMapControl3 mapcontrol, TreeView datatree)
        {
            m_rootDir = rootDir;
            m_mapcontrol = mapcontrol;
            m_tree = datatree;
        }

        public void Refresh()
        {
            DirectoryInfo   rootDir = new DirectoryInfo(m_rootDir);
            DirectoryInfo[] familyDirs = rootDir.GetDirectories();

            string          strRootNode = @"所有牧草";

            m_tree.BeginUpdate();
            m_tree.Nodes.Clear();

            TreeNode rootnode = new TreeNode(strRootNode);
            m_tree.Nodes.Add(rootnode);

            foreach (DirectoryInfo fdir in familyDirs)
            {
                DirectoryInfo[] pdirs = fdir.GetDirectories();

                GrassFamily family = new GrassFamily();

                family.strFamily = fdir.Name;
                family.pastures = new List<Pasture>();

                TreeNode familynode = rootnode.Nodes.Add(family.strFamily);

                foreach (DirectoryInfo dir in pdirs)
                {
                    FileInfo[] files = dir.GetFiles("*.mxd");
                    if (files.Length == 1)
                    {
                        FileInfo file = files[0];
                        Pasture pasture = new Pasture();
                        pasture.strPasture = dir.Name;
                        pasture.strMapDoc = file.FullName;
                        family.pastures.Add(pasture);

                        familynode.Nodes.Add(pasture.strPasture);
                    }
                }

                m_grassFamilys.Add(family);
            }

            m_tree.EndUpdate();

            //
            //m_activepasture = m_grassFamilys[0].pastures[0];     
        }

        public Pasture GetActivePasture()
        {
            return m_activepasture;
        }

        public Pasture GetPastureByName(string strName)
        {
            foreach (GrassFamily family in m_grassFamilys)
            {
                foreach (Pasture pasture in family.pastures)
                {
                    if (pasture.strPasture == strName)
                    {
                        return pasture;
                    }
                }
            }

            return new Pasture();
        }

        public bool Switch(string strName)
        {
            m_activepasture = GetPastureByName(strName);
            if (m_activepasture.strPasture == string.Empty)
                return false;
           
            IMapDocument mapDoc = new MapDocumentClass();
            if (mapDoc.get_IsPresent(m_activepasture.strMapDoc) &&
                !mapDoc.get_IsPasswordProtected(m_activepasture.strMapDoc))
            {
                mapDoc.Open(m_activepasture.strMapDoc, string.Empty);

                // set the first map as the active view
                IMap map = mapDoc.get_Map(0);
                mapDoc.SetActiveView((IActiveView)map);

                //assign the opened map to the MapControl
                m_mapcontrol.DocumentFilename = m_activepasture.strMapDoc;
                m_mapcontrol.Map = map;

                mapDoc.Close();

                //////////////////////////////////////////////////////////////////////////
                Queue<TreeNode> vistor_queue = new Queue<TreeNode>();
                vistor_queue.Enqueue(m_tree.Nodes[0]);
                while (vistor_queue.Count > 0)
                {
                    TreeNode node = vistor_queue.Dequeue();
                    if (node.Text == strName)
                        node.ForeColor = Color.BlueViolet;
                    else
                        node.ForeColor = Color.Black;

                    TreeNode child = node.FirstNode;
                    while (null != child)
                    {
                        vistor_queue.Enqueue(child);
                        child = child.NextNode;
                    }
                }
        
                return true;
            }

            return false;
        }
    };
}
