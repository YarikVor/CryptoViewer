using CryptingUp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CryptingUp.Tests {
  [TestClass]
  public class BaseAssetTests {
    [TestMethod]
    public void GetAll_IsValidGet() {
      var values = BaseAsset.GetAllAsArray().Skip(3).First();
      Assert.IsNotNull(values);
      Assert.IsTrue(values is BaseAsset);

      Assert.IsNotNull(values.asset_id);
      Assert.IsNotNull(values.name);
    }


    [TestMethod]
    public void GetById_IsValidGet() {
      var expected = BaseAsset.GetAllAsArray().Skip(3).First();

      var result = BaseAsset.GetById(expected.asset_id);

      Assert.IsNotNull(result);
      Assert.AreEqual(expected.asset_id, result.asset_id);
      Assert.AreEqual(expected.name, expected.name);
    }


    [TestMethod]
    public void GetAsset_GetSelf() {
      var expected = Asset.GetAllAsArray().Skip(3).First();

      var actual = expected.GetAsset();


      Assert.IsNotNull(actual);

      Assert.IsInstanceOfType(actual, typeof(Asset));
      Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void GetAsset_IsValidGetting() {
      var baseExpected = BaseAsset.GetAllAsArray().Skip(3).First();
      var expected = Asset.GetAll().Skip(3).First();

      
      var actual = baseExpected.GetAsset();

      Assert.IsNotNull(actual);

      Assert.IsInstanceOfType(actual, typeof(Asset));

      Assert.AreEqual(expected.ethereum_contract_address, actual.ethereum_contract_address);
    }

    [TestMethod]
    public void GetById_IsCorrectGetting(){
      var expected = Asset.GetAll().First();

      var result = Asset.GetById(expected.asset_id);

      Assert.IsNotNull(result);
      Assert.AreEqual(expected.asset_id, result.asset_id);
      Assert.AreEqual(expected.ethereum_contract_address, expected.ethereum_contract_address);
    }

    [TestMethod]
    public void GetAllAsArray_IsCorrectGetting() {
      var actual = BaseAsset.GetAllAsArray();

      var expected = Asset.GetAllAsArray();
      var expectedName = expected[3].name;

      Assert.IsNotNull(actual);
      Assert.AreEqual(expected.Length, actual.Length);

      Assert.IsTrue(actual.Any(e => e.name == expectedName));
    }

  }
}
