using CryptoViewer.Local;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace CryptoViewer {

  public sealed partial class SettingSelect : UserControl {

    public SettingSelect() {
      this.InitializeComponent();
      selectLang.SelectedIndex = LocalData.IndexSelectLang;
      selectTheme.SelectedIndex = LocalData.IndexSelectTheme;
      selectLang.SelectionChanged += selectLang_SelectionChanged;
      selectTheme.SelectionChanged += selectTheme_SelectionChanged;
    }

    private void selectTheme_SelectionChanged(object sender, SelectionChangedEventArgs e) {
      if (!( sender is ComboBox comboBox )) return;

      ApplicationTheme res;
      switch (comboBox.SelectedIndex) {
        case 0: {
          res = ApplicationTheme.Light;
          break;
        }
        case 1: {
          res = ApplicationTheme.Dark;
          break;
        }
        default: return;
      }

      LocalData.Theme = res;
    }

    private void selectLang_SelectionChanged(object sender, SelectionChangedEventArgs e) {
      if (!( sender is ComboBox comboBox )) return;
      LocalData.IndexSelectLang = comboBox.SelectedIndex;
    }
  }
}