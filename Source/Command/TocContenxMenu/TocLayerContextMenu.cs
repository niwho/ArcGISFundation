
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
        int index = 0;
        m_menu = new ToolbarMenuClass();
        m_menu.AddItem(new LayerThresholds(), 1, index++, false, esriCommandStyles.esriCommandStyleTextOnly);
        m_menu.AddItem(new LayerThresholds(), 2, index++, false, esriCommandStyles.esriCommandStyleTextOnly);
        m_menu.AddItem(new LayerThresholds(), 3, index++, false, esriCommandStyles.esriCommandStyleTextOnly);
        m_menu.AddItem(new LayerSelectable(), 1, index++, true, esriCommandStyles.esriCommandStyleTextOnly);
        m_menu.AddItem(new LayerSelectable(), 2, index++, false, esriCommandStyles.esriCommandStyleTextOnly);
        m_menu.AddItem(new LayerZoomTo()    ,-1, index++, true, esriCommandStyles.esriCommandStyleTextOnly);
        m_menu.AddItem(new LayerAnnotation(), 1, index++, true, esriCommandStyles.esriCommandStyleTextOnly);
        m_menu.AddItem(new LayerAnnotation(), 2, index++, true, esriCommandStyles.esriCommandStyleTextOnly);

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
