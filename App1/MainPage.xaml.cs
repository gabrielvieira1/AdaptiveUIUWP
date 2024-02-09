using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App1
{
  /// <summary>
  /// An empty page that can be used on its own or navigated to within a Frame.
  /// </summary>
  public sealed partial class MainPage : Page
  {
    public MainPage()
    {
      this.InitializeComponent();
      Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().SetPreferredMinSize(new Size(320, 320));
      //Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().VisibleBoundsChanged += MainPage_VisibleBoundsChanged;
    }

    //private void MainPage_VisibleBoundsChanged(Windows.UI.ViewManagement.ApplicationView sender, object args)
    //{
    //  var Width = Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().VisibleBounds.Width;
    //  if (Width >= 720)
    //  {
    //    //SView.DisplayMode = SplitViewDisplayMode.CompactInline;
    //    //SView.IsPaneOpen = true;

    //    VisualStateManager.GoToState(this, "Width720", false);

    //  }
    //  else if (Width >= 360)
    //  {
    //    //SView.DisplayMode = SplitViewDisplayMode.CompactOverlay;
    //    //SView.IsPaneOpen = false;

    //    VisualStateManager.GoToState(this, "Width360", false);

    //  }
    //  else
    //  {
    //    //SView.DisplayMode = SplitViewDisplayMode.Overlay;
    //    //SView.IsPaneOpen = false;

    //    VisualStateManager.GoToState(this, "Width0", false);

    //  }
    //}

    private void Button_CLick(object sender, RoutedEventArgs e)
    {
      SView.IsPaneOpen = !SView.IsPaneOpen;
    }
  }
  public class WindowWidthAdaptiveTrigger : StateTriggerBase
  {
    public WindowWidthAdaptiveTrigger()
    {
      var CoreWindow = Windows.UI.Core.CoreWindow.GetForCurrentThread();
      if (CoreWindow == null)
        return;

      CoreWindow.SizeChanged += (s, e) => AssessTrigger(e.Size);
    }

    private double _MinWindowWidth;

    public double MinWindowWidth
    {
      get { return _MinWindowWidth; }
      set
      {
        if (_MinWindowWidth == value)
          return;
        _MinWindowWidth = value;

        var CoreWindow = Windows.UI.Core.CoreWindow.GetForCurrentThread();
        if (CoreWindow == null)
          return;
        var Bounds = CoreWindow.Bounds;
        AssessTrigger(new Size(Bounds.Right - Bounds.Left, Bounds.Bottom - Bounds.Top));
      }
    }

    bool _IsActive = false;
    private void AssessTrigger(Size s)
    {
      var IsActive = s.Width >= _MinWindowWidth;
      if (_IsActive != IsActive)
      {
        _IsActive = IsActive;
        base.SetActive(IsActive);
      }
    }
  }
}
