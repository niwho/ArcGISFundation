
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
        m_menu.AddItem(new MapZoomin(), -1, index++, false, esriCommandStyles.esriCommandStyleTextOnly);
        m_menu.AddItem(new MapZoomout(), -1, index++, false, esriCommandStyles.esriCommandStyleTextOnly);
        m_menu.AddItem(new MapZoominFixed(), -1, index++, false, esriCommandStyles.esriCommandStyleTextOnly);
        m_menu.AddItem(new MapZoomoutFixed(), -1, index++, false, esriCommandStyles.esriCommandStyleTextOnly);
        m_menu.AddItem(new MapZoompan(), -1, index++, true, esriCommandStyles.esriCommandStyleTextOnly);
        m_menu.AddItem(new MapZoomToLastExtentBack(), -1, index++, true, esriCommandStyles.esriCommandStyleTextOnly);
        m_menu.AddItem(new MapZoomToLastExtentFoward(), -1, index++, false, esriCommandStyles.esriCommandStyleTextOnly);
        m_menu.AddItem(new MapZoomfullextent(), -1, index++, true, esriCommandStyles.esriCommandStyleTextOnly);
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
