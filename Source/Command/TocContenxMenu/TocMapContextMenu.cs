
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
  public class TocMapContextMenu
  {
    //class members
    //the underlying toolbarMenu that will be used
    protected IToolbarMenu2 m_menu = null;

    /// <summary>
    /// class constructor
    /// </summary>
    /// <param name="hook"></param>
    public TocMapContextMenu(object hook)
    {
     //Add custom commands to the map menu
      m_menu = new ToolbarMenuClass();
      m_menu.AddItem(new LayerVisibility(), 1, 0, false, esriCommandStyles.esriCommandStyleTextOnly);
      m_menu.AddItem(new LayerVisibility(), 2, 1, false, esriCommandStyles.esriCommandStyleTextOnly);
      //Add pre-defined menu to the map menu as a sub menu 
      m_menu.AddSubMenu("esriControls.ControlsFeatureSelectionMenu", 2, true);

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
