using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace CryptingUp.Tests {

  [TestClass]
  public class AssetTests {
    private static Asset asset;

    [TestMethod]
    public void GetAll_IsGettingValue() {
      var values = Asset.GetAll().Take(3).ToArray();
      Assert.IsNotNull(values);
      Assert.IsTrue(values is IEnumerable<Asset>);
      Assert.AreNotEqual(0, values.Length);

      var entity = values[0];
      Assert.IsNotNull(entity);
      Assert.IsInstanceOfType(entity, typeof(Asset));

      Assert.IsNotNull(entity.description);
      Assert.IsNotNull(entity.name);

      asset = entity;
    }

    [TestMethod]
    public void GetById_IsCorrectGetting() {
      var expected = Asset.GetAll().First();

      var result = Asset.GetById(expected.asset_id);

      Assert.IsNotNull(result);
      Assert.AreEqual(expected.asset_id, result.asset_id);
      Assert.AreEqual(expected.ethereum_contract_address, expected.ethereum_contract_address);
    }

    [TestMethod]
    public void GetAllAsArray_IsCorrectGetting() {
      var expected = Asset.GetAll();
      var result = Asset.GetAllAsArray();

      Assert.IsNotNull(result);
      Assert.AreEqual(expected.Skip(3).First().ethereum_contract_address, result.Skip(3).First().ethereum_contract_address);
    }

    [TestMethod]
    public void GetStatus_IsValid(){
      var asset = Asset.GetAll().First();
      Assert.AreEqual(asset.status, asset.GetStatus().ToString(), true);

      asset = Asset.GetAll().Skip(1).First();
      Assert.AreEqual(asset.status, asset.GetStatus().ToString(), true);
    }

    [TestMethod]
    public void GetBarketsByAssetId_IsValid() {
      var asset = Asset.GetAll().First();
      var market = asset.GetMarkets().First();

      Assert.IsTrue(market.quote_asset == asset.asset_id || market.base_asset == asset.asset_id, $"'{asset.asset_id}' is not equal '{market.base_asset}' or {market.quote_asset}");
    }
  }
}