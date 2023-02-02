
using System;
using System.Collections.Generic;
using System.Linq;
using CryptoViewer;
using CryptoViewer.Local;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Windows.Foundation.Collections;

namespace CryptoViewerTests {
  [TestClass]
  public class LocalHashListAssetTests {
    public IPropertySet property = new PropertySet();
    [TestInitialize]
    [TestMethod]
    public void Init_IsInitialization() {
      LocalHashListAsset.Init(property);

      Assert.AreEqual(property, LocalHashListAsset.Values);
    }

    [DataTestMethod]
    [DataRow("", false)]
    [DataRow((string)null, false)]
    [DataRow("t", true)]
    public void Add_IsAdded(string value, bool expected){
      LocalHashListAsset.Clear();
      Assert.AreEqual(expected, LocalHashListAsset.Add(value));
      if(expected){
        Assert.AreEqual(value, LocalHashListAsset.Current.FirstOrDefault());
      }

    }

    [TestMethod]
    public void Add_RepeadAddValue_IsNotAdd() {
      LocalHashListAsset.Clear();

      string textAdd = "textAdd";

      Assert.IsTrue(LocalHashListAsset.Add(textAdd));
      Assert.IsFalse(LocalHashListAsset.Add(textAdd));
    }

    [TestMethod]
    public void Add_CountAddOne() {
      LocalHashListAsset.Clear();

      string textAdd = "textAdd";
      int lastLength = LocalHashListAsset.Count;

      LocalHashListAsset.Add(textAdd);

      Assert.AreEqual(lastLength + 1, LocalHashListAsset.Count);
    }

    [TestMethod]
    public void Remove_IsRemoved() {
      LocalHashListAsset.Clear();

      string textAdd = "textAdd";

      LocalHashListAsset.Add(textAdd);

      Assert.IsTrue(LocalHashListAsset.Remove(textAdd));
      Assert.AreEqual(0, LocalHashListAsset.Count);
    }

    [TestMethod]
    public void Remove_RemoveDisableElem_IsNotRemoved() {
      LocalHashListAsset.Clear();

      string textAdd = "textAdd";
      string textRem = "text";

      LocalHashListAsset.Add(textAdd);

      Assert.IsFalse(LocalHashListAsset.Remove(textRem));
      Assert.AreEqual(1, LocalHashListAsset.Count);
    }

    [TestMethod]
    public void Save_IsSaved(){
      LocalHashListAsset.Clear();
      LocalHashListAsset.Save();

      string[] strs = this.property[LocalHashListAsset.PROPERTY_NAME] as string[];
      Assert.IsNotNull(strs);
      Assert.AreEqual(1, strs.Length);
      Assert.AreEqual("", strs[0]);

    }

    [TestMethod]
    public void Contains_IsValidGet(){
      LocalHashListAsset.Clear();

      string value = "2";
      LocalHashListAsset.Add(value);

      Assert.IsTrue(LocalHashListAsset.Contains(value));
      LocalHashListAsset.Remove(value);
      Assert.IsFalse(LocalHashListAsset.Contains(value));
    }
  }
}
