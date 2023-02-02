using CryptingUp;
using CryptoViewer.Local;
using Methods;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace CryptoViewer {

  public sealed partial class HomeSelect : UserControl {

    public HomeSelect() {
      this.InitializeComponent();

      Loaded += HomeSelect_Loaded;
    }

    private void HomeSelect_Loaded(object sender, RoutedEventArgs e) {
      var assets = BaseAsset.GetAllAsArray();
      foreach (var asset in assets.Take(10)) {
        var assetControl = new AssetControl();
        assetControl.TappedTitle += btnSelect_Click;
        assetControl.OnClickSymbolIcon += SymbolIcon_Tapped;
        assetControl.Title = asset.asset_id;
        assetControl.Subtitle = asset.name;
        stackPanels.Children.Add(assetControl);
      }
    }

    private void btnSearch_Click(object sender, RoutedEventArgs e) {
      var assets = BaseAsset.GetAllAsArray();

      string input = inputSearch.Text;
      stackPanels.Children.Clear();

      foreach (var asset in assets.OrderByDescending(p => p.asset_id.SubstringSize(input) + p.name.SubstringSize(input)).Take(10)) {
        var assetControl = new AssetControl();
        assetControl.TappedTitle += btnSelect_Click;
        assetControl.OnClickSymbolIcon += SymbolIcon_Tapped;
        assetControl.Title = asset.asset_id;
        assetControl.Subtitle = asset.name;
        assetControl.symbolIcon.Symbol = LocalHashListAsset.Contains(asset.asset_id) ? Symbol.SolidStar : Symbol.OutlineStar;
        stackPanels.Children.Add(assetControl);
      }
    }

    private void SymbolIcon_Tapped(object sender, TappedRoutedEventArgs e) {
      if (!( sender is AssetControl assetControl )) return;
      if (!( assetControl.Title is string assetId )) return;

      if (assetControl.symbolIcon.Symbol == Symbol.SolidStar) {
        LocalHashListAsset.Remove(assetId);
        assetControl.symbolIcon.Symbol = Symbol.OutlineStar;
      } else {
        LocalHashListAsset.Add(assetId);
        assetControl.symbolIcon.Symbol = Symbol.SolidStar;
      }
    }

    private void btnSelect_Click(object sender, RoutedEventArgs e) {
      var frame = Window.Current.Content as Frame;
      frame.Navigate(typeof(AssetViewer), ( sender as AssetControl ).Title);
    }
  }
}