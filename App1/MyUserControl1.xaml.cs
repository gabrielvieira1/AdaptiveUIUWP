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

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace App1
{
  public sealed partial class MyUserControl1 : UserControl
  {
    public MyUserControl1()
    {
      this.InitializeComponent();
      Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().VisibleBoundsChanged += MyUserControl1_VisibleBoundsChanged;
    }

    private void MyUserControl1_VisibleBoundsChanged(Windows.UI.ViewManagement.ApplicationView sender, object args)
    {
      var Width = Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().VisibleBounds.Width;
      if (Width >= 360)
      {
        //RelativePanel.SetBelow(FavText, null);
        //RelativePanel.SetRightOf(FavText, Stars);

        //RelativePanel.SetAlignVerticalCenterWith(FavText, Stars);
        //RelativePanel.SetAlignVerticalCenterWithPanel(FavText, true);

        VisualStateManager.GoToState(this, "Width360", false);

      }
      else
      {
        //RelativePanel.SetRightOf(FavText, null);
        //RelativePanel.SetBelow(FavText, Stars);

        //RelativePanel.SetAlignVerticalCenterWith(FavText, null);
        //RelativePanel.SetAlignVerticalCenterWithPanel(Stars, false);

        VisualStateManager.GoToState(this, "Width0", false);

      }
    }
  }
}
