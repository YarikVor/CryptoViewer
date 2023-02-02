using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace CryptingUp.Tests {

  [TestClass]
  public class BaseTests {

    public void QuoteAsset_IsValid() {
      var actual = Asset.GetAll().Skip(3).First();
      Assert.IsNotNull(actual.quotes);

      var dict = actual.quotes;
      Assert.AreNotEqual(0, dict.Count());

      var entity = dict.First();

      Assert.AreNotEqual(null, entity.currency);
      Assert.AreNotEqual(null, entity.volume_24h);

      Assert.AreNotEqual(0, entity.price);

      Assert.AreNotEqual(0, entity.market_cap);
      Assert.AreNotEqual(0, entity.fully_diluted_market_cap);
    }

    public void QuoteMarket_IsValid() {
      var actual = Market.GetAll().Skip(3).First();
      Assert.IsNotNull(actual.quotes);

      var dict = actual.quotes;
      Assert.AreNotEqual(0, dict.Count());

      var entity = dict.First();

      Assert.AreNotEqual(null, entity.currency);
      Assert.AreNotEqual(null, entity.volume_24h);

      Assert.AreNotEqual(0, entity.price);
    }

    public void QuoteExchange_IsValid() {
      var actual = Exchange.GetAllAsArray().Skip(3).First();
      Assert.IsNotNull(actual.Quotes);

      var dict = actual.Quotes;
      Assert.AreNotEqual(0, dict.Count());

      var entity = dict.First();

      Assert.AreNotEqual(null, entity.currency);
      Assert.AreNotEqual(null, entity.volume_24h);
    }
  }
}