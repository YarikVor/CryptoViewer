using CryptingUp;
using Methods;
using System;
using System.Linq;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace CryptoViewer {

  public sealed partial class AssetViewer : Page {
    public AssetViewModel asset;

    public AssetViewer() {
      this.InitializeComponent();
      this.Loaded += AssetViewer_Loaded;
    }

    protected override void OnNavigatedTo(NavigationEventArgs e) {
      string assesId = e.Parameter as string;
      asset = (AssetViewModel)Asset.GetById(assesId);
      AddExchanges();
      if (asset == null) {
        Frame.GoBack();
      }
      try {
        link.NavigateUri = new Uri(asset.website);
      }
      catch { }
    }

    private void AssetViewer_Loaded(object sender, RoutedEventArgs e) {
      SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
    }

    private void AddExchanges() {
      var exchanges = Market.GetByAssetId(asset.assetId);

      foreach (var exchange in exchanges.DistinctBy(e => e.exchange_id).Select(e => (PartialMarketViewModel)e)) {
        gridExchanges.RowDefinitions.Add(new RowDefinition());
        int count = gridExchanges.RowDefinitions.Count - 1;

        var textExchangeId = new TextBlock { Text = exchange.exchangeId };
        var textSymbol = new TextBlock { Text = exchange.symbol };
        var textPrice = new TextBlock { Text = exchange.price.ToString() };

        var textBlocks = new TextBlock[] { textExchangeId, textSymbol, textPrice };
        int i = 0;
        foreach (var textBlock in textBlocks) {
          Grid.SetRow(textBlock, count);
          Grid.SetColumn(textBlock, i++);
          gridExchanges.Children.Add(textBlock);
        }
      }
    }
  }
}