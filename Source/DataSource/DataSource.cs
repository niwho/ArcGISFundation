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
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.DataSourcesRaster;
using ESRI.ArcGIS.Display;


namespace ArcGISFoundation
{
    public struct Pasture
    {
        public string                   strPasture;
        public string                   strMapDoc;
        public string                   strRasLyr;
        public string                   strDataDir;
    };

    public struct GrassFamily
    {
        public string                   strFamily;
        public List<Pasture>            pastures;
    };

    public class DataSource
    {
        //Pasture
        protected string                m_pastureDir;
        protected List<GrassFamily>     m_grassFamilys = new List<GrassFamily>();
        protected Pasture               m_activePasture;
        protected IMap                  m_pastureMap;
        protected TreeView              m_tree;

        //admin
        protected IMapControl3          m_mapcontrol;
        protected string                m_adminDir;
        protected IMap                  m_adminMap;

        public void Init(string adminDir, string pastureDir, IMapControl3 mapcontrol, TreeView datatree)
        {
            m_pastureDir = pastureDir;
            m_mapcontrol = mapcontrol;
            m_tree = datatree;
            m_adminDir = adminDir;
        }
        #region Administrative
        public void RefreshAdministrative()
        {
            m_adminMap = new Map();

            m_adminMap.Name = @"行政图";

            IWorkspaceFactory workspaceFactory = new ShapefileWorkspaceFactoryClass();
            IFeatureWorkspace workspace = 
                (IFeatureWorkspace)workspaceFactory.OpenFromFile(m_adminDir, 
                                                            m_mapcontrol.hWnd);

            bool bInitShow = false;

            DirectoryInfo adminDir = new DirectoryInfo(m_adminDir);
            FileInfo[] files = adminDir.GetFiles("*.shp");
            foreach (FileInfo file in files)
            {
               
                IFeatureLayer featureLayer = new FeatureLayerClass();
                featureLayer.Name = file.Name;
                featureLayer.Visible = !bInitShow;
                featureLayer.FeatureClass = workspace.OpenFeatureClass(file.Name);

                ILayerEffects layereffect = featureLayer as ILayerEffects;
                layereffect.Transparency = 60;

                m_adminMap.AddLayer(featureLayer);

                if (!bInitShow)
                    bInitShow = true;
            }

            m_mapcontrol.Map = m_adminMap;
        }

        public IMap GetAdministrativeMap()
        {
            return m_adminMap;
        }

        #endregion
        #region Pasture
        public void RefreshPasture()
        {
            DirectoryInfo   pastureDir = new DirectoryInfo(m_pastureDir);
            DirectoryInfo[] familyDirs = pastureDir.GetDirectories();

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
                    Pasture pasture = new Pasture();
                    pasture.strPasture = dir.Name;
                    pasture.strDataDir = dir.FullName;
                    pasture.strMapDoc = string.Empty;
                    pasture.strRasLyr = string.Empty;
<<<<<<< HEAD
=======

>>>>>>> 82ee1ba18020cdcdfcb58dcfe49f1c422c9d0426

                    FileInfo[] mxdfiles = dir.GetFiles("*.mxd");
                    if (mxdfiles.Length == 1)
                    {
                        FileInfo mxdfile = mxdfiles[0];   
                        pasture.strMapDoc = mxdfile.FullName;
                    }

                    FileInfo[] rasfiles = dir.GetFiles("*.aux");
                    if (rasfiles.Length == 1)
                    {
                        FileInfo rasfile = rasfiles[0];   
                        pasture.strRasLyr = rasfile.Name;
                        pasture.strRasLyr = pasture.strRasLyr.Substring(0, pasture.strRasLyr.Length - 4);
                    }

                    family.pastures.Add(pasture);
                    familynode.Nodes.Add(pasture.strPasture);
                }

                m_grassFamilys.Add(family);
            }

            m_tree.EndUpdate();

            //
            //m_activePasture = m_grassFamilys[0].pastures[0];     
        }

        public Pasture GetActivePasture()
        {
            return m_activePasture;
        }

        public IMap GetActivePastureMap()
        {
            return m_pastureMap;
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

        public bool SwitchPasture(string strName)
        {
            m_activePasture = GetPastureByName(strName);
            if (m_activePasture.strPasture == string.Empty)
                return false;

            //
            m_pastureMap = new Map();
            m_pastureMap.Name = m_activePasture.strPasture;

            IWorkspaceFactory workspaceFactory = new ShapefileWorkspaceFactoryClass();
            IFeatureWorkspace workspace = 
                (IFeatureWorkspace)workspaceFactory.OpenFromFile(m_activePasture.strDataDir,0);
            
            DirectoryInfo pastureDir = new DirectoryInfo(m_activePasture.strDataDir);
            FileInfo[] files = pastureDir.GetFiles("*.shp");
            foreach (FileInfo file in files)
            {
                IFeatureLayer featureLayer = new FeatureLayerClass();
                featureLayer.Name = file.Name;
                featureLayer.Visible = true;
                featureLayer.FeatureClass = workspace.OpenFeatureClass(file.Name);

                m_pastureMap.AddLayer(featureLayer);
            }

            //////////////////////////////////////////////////////////////////////////
            if (m_activePasture.strRasLyr != string.Empty)
            {
                IWorkspaceFactory rasWksFactory = new RasterWorkspaceFactory();
                IRasterWorkspace rasWks = rasWksFactory.OpenFromFile(m_activePasture.strDataDir, 0) as IRasterWorkspace;
                IRasterDataset rasDataset = rasWks.OpenRasterDataset(m_activePasture.strRasLyr);

                IRasterLayer rasLyr = new RasterLayerClass();
                rasLyr.CreateFromDataset(rasDataset);

                if (m_adminMap.LayerCount == 3)
                {
                    m_adminMap.AddLayer(rasLyr);
                    m_adminMap.MoveLayer(rasLyr,3);
                }
                else if(m_adminMap.LayerCount == 4)
                {
                    ILayer lyr = m_adminMap.get_Layer(3);
                    if (null != lyr)
                        m_adminMap.DeleteLayer(lyr);

                    m_adminMap.AddLayer(rasLyr);
                    m_adminMap.MoveLayer(rasLyr,3);
                }
            }
            
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

                return true;
            }
        
            return false;
        }
        #endregion
        #region Helper
        protected void OpenAdministrativeMapDoc(string adminMapDoc)
        {
            IMapDocument mapDoc = new MapDocumentClass();
            if (mapDoc.get_IsPresent(adminMapDoc) &&
                !mapDoc.get_IsPasswordProtected(adminMapDoc))
            {
                mapDoc.Open(adminMapDoc, string.Empty);

                // set the first map as the active view
                m_adminMap = mapDoc.get_Map(0);
                mapDoc.SetActiveView((IActiveView)m_adminMap);
                mapDoc.Close();

                m_mapcontrol.Map = m_adminMap;
            }
        }

        protected void OpenPastureMapDoc(Pasture pasture)
        {
            IMapDocument mapDoc = new MapDocumentClass();
            if (mapDoc.get_IsPresent(pasture.strMapDoc) &&
                !mapDoc.get_IsPasswordProtected(pasture.strMapDoc))
            {
                mapDoc.Open(pasture.strMapDoc, string.Empty);

                // set the first map as the active view
                m_pastureMap = mapDoc.get_Map(0);
                mapDoc.SetActiveView((IActiveView)m_pastureMap);
                mapDoc.Close();
            }
        }
        #endregion
    };
}
