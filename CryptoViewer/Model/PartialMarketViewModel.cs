using CryptingUp;

namespace CryptoViewer {

  public class PartialMarketViewModel {
    public string exchangeId;

    public string symbol;

    public string price;

    public static explicit operator PartialMarketViewModel(Market asset) {
      if (asset == null) return null;
      var res = new PartialMarketViewModel() {
        exchangeId = asset.exchange_id,
        symbol = asset.symbol,
        price = asset.price.ToLocalSiString()
      };
      return res;
    }
  }
}