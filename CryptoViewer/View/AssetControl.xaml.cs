using CryptoViewer.Local;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace CryptoViewer {

  public sealed partial class AssetControl : UserControl {

    public event TappedEventHandler OnClickSymbolIcon;

    public event TappedEventHandler TappedTitle;

    public AssetControl() {
      this.InitializeComponent();
      symbolIcon.Tapped += (a, b) => OnClickSymbolIcon?.Invoke(this, b);
      symbolIcon.Symbol = LocalHashListAsset.Contains(Title as string) ? Symbol.SolidStar : Symbol.OutlineStar;
      titlePanel.Tapped += (a, b) => TappedTitle?.Invoke(this, b);
    }

    public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(AssetControl), new PropertyMetadata(""));

    public object Title {
      get { return GetValue(TitleProperty); }
      set { SetValue(TitleProperty, value); }
    }

    public static readonly DependencyProperty SubtitleProperty = DependencyProperty.Register("Subtitle", typeof(string), typeof(AssetControl), new PropertyMetadata(""));

    public object Subtitle {
      get { return GetValue(SubtitleProperty); }
      set { SetValue(SubtitleProperty, value); }
    }

    public static readonly DependencyProperty TypeStarProperty = DependencyProperty.Register("TypeStar", typeof(Symbol), typeof(AssetControl), new PropertyMetadata(null));

    public Symbol TypeStar {
      get { return (Symbol)GetValue(TypeStarProperty); }
      set { SetValue(TypeStarProperty, value); }
    }
  }
}