using System.Xml.Linq;
using Windows.ApplicationModel.Resources;
using Windows.ApplicationModel.Resources.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CryptoViewer {

  /// <summary>
  /// An empty page that can be used on its own or navigated to within a Frame.
  /// </summary>
  public sealed partial class MainPage : Page {

    public MainPage() {
      this.InitializeComponent();

      Loaded += MainPage_Loaded;
      this.TextTitle.Text = ( ( homeButton.Content as StackPanel ).Children[1] as TextBlock ).Text;

    }

    private void MainPage_Loaded(object sender, RoutedEventArgs e) {
      starSelect.Update();
    }

    private void buttonOpen_Click(object sender, RoutedEventArgs e) {
      splitView.IsPaneOpen = !splitView.IsPaneOpen;
    }

    public void SetRectPos(Button element) {
      var margin = rectSelect.Margin;
      margin.Top = element.TransformToVisual(VisualTreeHelper.GetParent(element) as UIElement).TransformPoint(new Windows.Foundation.Point(0, 0)).Y;
      rectSelect.Margin = margin;

      var selects = new UserControl[] { homeSelect, starSelect, settingSelect, calcSelect };
      foreach (var select in selects) {
        select.Visibility = Visibility.Collapsed;
      }

      this.TextTitle.Text = ( ( element.Content as StackPanel ).Children[1] as TextBlock ).Text;
    }

    private void homeButton_Click(object sender, RoutedEventArgs e) {
      SetRectPos(sender as Button);
      homeSelect.Visibility = Visibility.Visible;
    }

    private void starButton_Click(object sender, RoutedEventArgs e) {
      SetRectPos(sender as Button);
      starSelect.OverrideVisibility = Visibility.Visible;
    }

    private void calcButton_Click(object sender, RoutedEventArgs e) {
      SetRectPos(sender as Button);
      calcSelect.Visibility = Visibility.Visible;
    }

    private void settingButton_Click(object sender, RoutedEventArgs e) {
      SetRectPos(sender as Button);
      settingSelect.Visibility = Visibility.Visible;
    }
  }
}