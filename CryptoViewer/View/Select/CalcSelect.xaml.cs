using CryptingUp;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace CryptoViewer {

  public sealed partial class CalcSelect : UserControl {
    public Asset assetBefore = null;
    public Asset assetAfter = null;

    public CalcSelect() {
      this.InitializeComponent();

      Loaded += CalcSelect_Loaded;
    }

    private void CalcSelect_Loaded(object sender, RoutedEventArgs e) {
      var assets = Asset.GetAllAsArray();
      foreach (var asset in assets) {
        comboBoxBefore.Items.Add(asset.asset_id);
        comboBoxAfter.Items.Add(asset.asset_id);
      }
    }

    private void comboBoxBefore_SelectionChanged(object sender, SelectionChangedEventArgs e) {
      if (comboBoxBefore.SelectedIndex == -1) return;
      assetBefore = Asset.GetById(comboBoxBefore.SelectedValue as string);
      Checking();
    }

    private void Checking() {
      if (assetBefore == null || assetAfter == null || !decimal.TryParse(inputValue.Text, out decimal res))
        return;

      double coef = (double)assetAfter.price / (double)assetBefore.price;

      textCurse.Text = coef.ToString("N2");

      textResult.Text = ( (double)res * coef ).ToString("N2");
    }

    private void comboBoxAfter_SelectionChanged(object sender, SelectionChangedEventArgs e) {
      if (comboBoxAfter.SelectedIndex == -1) return;
      assetAfter = Asset.GetById(comboBoxAfter.SelectedValue as string);
      Checking();
    }

    private void Button_Click(object sender, RoutedEventArgs e) {
      {
        Asset temp = assetBefore;
        assetBefore = assetAfter;
        assetAfter = temp;
      }

      {
        object temp = comboBoxBefore.SelectedItem;
        comboBoxBefore.SelectedItem = comboBoxAfter.SelectedItem;
        comboBoxAfter.SelectedItem = temp;
      }

      Checking();
    }

    private void inputValue_TextChanged(object sender, TextChangedEventArgs e) {
      Checking();
    }
  }
}