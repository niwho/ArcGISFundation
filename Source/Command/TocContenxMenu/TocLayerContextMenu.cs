
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
  public class TocLayerContextMenu
  {
    //class members
    //the underlying toolbarMenu that will be used
    protected IToolbarMenu2 m_menu = null;

    /// <summary>
    /// class constructor
    /// </summary>
    /// <param name="hook"></param>
    public TocLayerContextMenu(object hook)
    {
        m_menu = new ToolbarMenuClass();
        m_menu.AddItem(new RemoveLayer()    ,-1, 0, false, esriCommandStyles.esriCommandStyleTextOnly);
        m_menu.AddItem(new ScaleThresholds(), 1, 1, true, esriCommandStyles.esriCommandStyleTextOnly);
        m_menu.AddItem(new ScaleThresholds(), 2, 2, false, esriCommandStyles.esriCommandStyleTextOnly);
        m_menu.AddItem(new ScaleThresholds(), 3, 3, false, esriCommandStyles.esriCommandStyleTextOnly);
        m_menu.AddItem(new LayerSelectable(), 1, 4, true, esriCommandStyles.esriCommandStyleTextOnly);
        m_menu.AddItem(new LayerSelectable(), 2, 5, false, esriCommandStyles.esriCommandStyleTextOnly);
        m_menu.AddItem(new ZoomToLayer()    ,-1, 6, true, esriCommandStyles.esriCommandStyleTextOnly);

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
