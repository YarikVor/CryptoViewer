using CryptingUp;
using CryptoViewer.Local;
using System.ComponentModel;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace CryptoViewer {

  public sealed partial class StarSelect : UserControl, INotifyPropertyChanged {

    public event PropertyChangedEventHandler PropertyChanged;

    public Visibility OverrideVisibility {
      get => this.Visibility;
      set {
        if (this.Visibility != value) {
          this.Visibility = value;
          OnPropertyChanged(nameof(OverrideVisibility));
        }
      }
    }

    public StarSelect() {
      this.InitializeComponent();
      PropertyChanged += StarSelect_PropertyChanged;
    }

    public static readonly DependencyProperty OverrideVisibilityProperty = DependencyProperty.Register("OverrideVisibility", typeof(Visibility), typeof(StarSelect), new PropertyMetadata(Visibility.Visible));

    public void OnPropertyChanged(string propertyName) {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private void StarSelect_PropertyChanged(object sender, PropertyChangedEventArgs e) {
      if (e.PropertyName != nameof(OverrideVisibility)) {
        return;
      }
      if (this.Visibility == Visibility.Visible) {
        Update();
      }
    }

    public void Update() {
      scrollBody.Children.Clear();

      var assetsId = LocalHashListAsset.Current;

      if (assetsId.Count > 0) {
        var assets = Asset.GetAllAsArray();
        foreach (var asset in assets.Where(e => assetsId.Any(k => k == e.asset_id))) {
          var assetControl = new AssetControl();
          assetControl.TappedTitle += btnSelect_Click;
          assetControl.OnClickSymbolIcon += SymbolIcon_Tapped;
          assetControl.Title = asset.asset_id;
          assetControl.Subtitle = asset.name;
          assetControl.symbolIcon.Symbol = Symbol.SolidStar;
          scrollBody.Children.Add(assetControl);
        }
      } else {
        var textBlock = new TextBlock();
        textBlock.Text = "Натисніть на зірочку, щоб додати сюди у список";
        scrollBody.Children.Add(textBlock);
      }
    }

    private void SymbolIcon_Tapped(object sender, TappedRoutedEventArgs e) {
      if (!( sender is AssetControl assetControl )) return;
      if (!( assetControl.Title is string assetId )) return;

      if (assetControl.symbolIcon.Symbol == Symbol.SolidStar) {
        LocalHashListAsset.Remove(assetId);
        scrollBody.Children.Remove(assetControl);
      }
    }

    private void btnSelect_Click(object sender, RoutedEventArgs e) {
      var frame = Window.Current.Content as Frame;
      frame.Navigate(typeof(AssetViewer), ( sender as AssetControl ).Title);
    }
  }
}