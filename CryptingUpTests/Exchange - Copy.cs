using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptingUp.Tests {
  [TestClass]
  public class MarketTests {
    [TestMethod]
    public void GetAll_IsValidGet() {
      var values = Market.GetAll().Skip(3).First();
      Assert.IsNotNull(values);
      Assert.IsTrue(values is Market);

      Assert.IsNotNull(values.exchange_id);
      Assert.IsNotNull(values.status);
    }


    [TestMethod]
    public void GetAllAsArray_IsCorrectGetting() {
      var expected = Market.GetAll();
      var result = Market.GetAllAsArray();

      Assert.IsNotNull(result);
      Assert.AreEqual(expected.Skip(3).First().status, result.Skip(3).First().status);
    }

    [TestMethod]
    public void GetExchange_IsValid() {
      var market = Market.GetAll().Skip(3).First();

      
      var expected = Exchange.GetById(market.exchange_id);

      var actual = market.GetExchange();

      Assert.IsNotNull(actual);
      Assert.AreEqual(expected.exchange_id, actual.exchange_id);
    }

    [TestMethod]
    public void GetBaseAsset_IsValid() {
      var market = Market.GetAll().Skip(3).First();


      var expected = Asset.GetById(market.base_asset);

      var actual = market.GetBaseAsset();

      Assert.IsNotNull(actual);
      Assert.AreEqual(expected.asset_id, actual.asset_id);
    }


    [TestMethod]
    public void GetQuoteAsset_IsValid() {
      var market = Market.GetAll().Skip(3).First();

      var expected = Asset.GetById(market.quote_asset);

      var actual = market.GetQuoteAsset();

      Assert.IsNotNull(actual);
      Assert.AreEqual(expected.asset_id, actual.asset_id);
    }

    [TestMethod]
    public void GetByExchangeId_IsValid() {
      var market = Market.GetAll().Skip(3).First();

      var actual = market.GetByExchangeId();

      Assert.IsNotNull(actual);
      Assert.IsTrue(actual.All(e => e.exchange_id == market.exchange_id));
    }


  }
}
