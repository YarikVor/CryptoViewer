using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace CryptingUp.Tests {

  [TestClass]
  public class ExchangeTests {

    [TestMethod]
    public void GetAllAsArray_IsCorrectGetting() {
      var result = Exchange.GetAllAsArray()[0];

      Assert.IsNotNull(result);
      Assert.AreEqual("Binance", result.name);
    }

    [TestMethod]
    public void GetById_IsValidGet() {
      var expected = Exchange.GetAllAsArray().Skip(3).First();

      var result = Exchange.GetById(expected.exchange_id);

      Assert.IsNotNull(result);
      Assert.AreEqual(expected.exchange_id, result.exchange_id);
      Assert.AreEqual(expected.name, expected.name);
    }

    [TestMethod]
    public void GetMarkets_IsValid() {
      var expected = Exchange.GetAllAsArray().First();
      var market = expected.GetMarkets().First();

      Assert.AreEqual(expected.exchange_id, market.exchange_id, true);
    }
  }
}