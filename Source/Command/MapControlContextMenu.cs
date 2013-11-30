
using System;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Controls;

namespace ArcGISFoundation
{
  
  /// <summary>
  /// Context menu class hosting ArcObject commands
  /// </summary>
  public class MapControlContextMenu
  {
    //class members
    //the underlying toolbarMenu that will be used
    protected IToolbarMenu2 m_menu = null;

    /// <summary>
    /// class constructor
    /// </summary>
    /// <param name="hook"></param>
    public MapControlContextMenu(object hook)
    {
        int index = 0;

        m_menu = new ToolbarMenuClass();

        string progID;
        progID = "esriControls.ControlsMapZoomInTool";
        m_menu.AddItem(progID, -1, -1, true, 0,
            esriCommandStyles.esriCommandStyleIconOnly);

        progID = "esriControls.ControlsMapZoomOutTool";
        m_menu.AddItem(progID, -1, -1, false, 0,
            esriCommandStyles.esriCommandStyleIconOnly);

        progID = "esriControls.ControlsMapPanTool";
        m_menu.AddItem(progID, -1, -1, false, 0,
            esriCommandStyles.esriCommandStyleIconOnly);

        m_menu.AddSubMenu("esriControls.ControlsMapViewMenu", index++, false);
        //m_menu.AddMultiItem("esriControls.ControlsMapPanTool", index++, true);
        //Set the hook of each menu
        m_menu.SetHook(hook);
    }

    /// <summary>
    /// popup the context menu at the given location
    /// </summary>
    /// <param name="X"></param>
    /// <param name="Y"></param>
    /// <param name="hWndParent"></param>
    public void PopupMenu(int X, int Y, int hWndParent)
    {
        m_menu.PopupMenu(X, Y, hWndParent);
    }
  }
}
