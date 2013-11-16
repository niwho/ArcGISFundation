﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;

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
    public struct DataNode
    {
        public string strName;
        public string strMapDoc;
    };

    public class DataSource
    {
        protected IMapControl3  m_mapcontrol;
        protected TreeView      m_tree;
        protected string        m_rootDir;
        protected List<DataNode> m_dataNodes = new List<DataNode>();

        public void Init(string rootDir, IMapControl3 mapcontrol, TreeView datatree)
        {
            m_rootDir = rootDir;
            m_mapcontrol = mapcontrol;
            m_tree = datatree;
        }

        public void Refresh()
        {
            DirectoryInfo   rootDir = new DirectoryInfo(m_rootDir);
            DirectoryInfo[] childDirs = rootDir.GetDirectories();

            string          strRootNode = @"所有牧草";

            m_tree.BeginUpdate();

            m_tree.Nodes.Clear();

            TreeNode rootnode = new TreeNode(strRootNode);
            m_tree.Nodes.Add(rootnode);
            foreach (DirectoryInfo dir in childDirs)
            {
                FileInfo[] files = dir.GetFiles("*.mxd");
                if (files.Length == 1)
                {
                    FileInfo file = files[0];
                    DataNode  datanode = new DataNode();
                    datanode.strName = dir.Name;
                    datanode.strMapDoc = file.FullName;
                    m_dataNodes.Add(datanode);

                    rootnode.Nodes.Add(datanode.strName);
                }
            }

            m_tree.EndUpdate();

            Switch(m_dataNodes[0].strName);
        }

        public DataNode GetNodeByName(string strName)
        {
            bool find = false;
            foreach (DataNode node in m_dataNodes)
            {
                if (node.strName == strName)
                {
                    return node;
                }
            }

            return new DataNode();
        }

        public bool Switch(string strName)
        {
            DataNode datanode= GetNodeByName(strName);
            if (datanode.strName == string.Empty)
                return false;
           
            IMapDocument mapDoc = new MapDocumentClass();
            if (mapDoc.get_IsPresent(datanode.strMapDoc) &&
                !mapDoc.get_IsPasswordProtected(datanode.strMapDoc))
            {
                mapDoc.Open(datanode.strMapDoc, string.Empty);

                // set the first map as the active view
                IMap map = mapDoc.get_Map(0);
                mapDoc.SetActiveView((IActiveView)map);

                //assign the opened map to the MapControl
                m_mapcontrol.DocumentFilename = datanode.strMapDoc;
                m_mapcontrol.Map = map;

                mapDoc.Close();
                return true;
            }

            return false;
        }
    };
}