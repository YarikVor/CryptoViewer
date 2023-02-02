
using System;
using System.Collections.Generic;
using CryptoViewer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Windows.Foundation.Collections;

namespace CryptoViewer.Tests {
  [TestClass]
  public class LocalHashListAssetTests {
    public IPropertySet property = new PropertySet();


    [TestMethod]
    public void Init_IsInitialization() {
      LocalHashListAsset.Init(property);

      Assert.AreEqual(property, LocalHashListAsset.Values);
    }

    [DataTestMethod]
    [DataRow("", false)]
    [DataRow(null, false)]
    [DataRow("t", true)]
    [DataRow("t", false)]
    public static void Add_IsAdded(string value, bool expected){
      Assert.AreEqual(expected, LocalHashListAsset.Add(value));
    }
  }
}
