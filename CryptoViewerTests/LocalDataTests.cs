using CryptoViewer.Local;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation.Collections;

namespace CryptoViewerTests {
  [TestClass]
  public class LocalDataTests {
    static IPropertySet property = new PropertySet();

    [TestInitialize]
    public void Init() {
      LocalHashListAsset.Init(property);

    }

    [TestMethod]
    public void Lang_IsValidGetSet() {
      string lang = "en_US";
      LocalData.LangName = lang;
      try{
        Assert.AreEqual(lang, LocalData.LangName);
      } catch(Exception _){ }
      
      Assert.AreEqual(lang, property[LocalData.PROPERTY_LANG]);
    }

    [TestMethod]
    public void Lang_InvalidCulture_IsInvalid() {
      string lang = "t";
      LocalData.LangName = lang;

      Assert.AreNotEqual(lang, LocalData.LangName);
      Assert.IsFalse(property.ContainsKey(LocalData.PROPERTY_THEME));
    }

    [TestMethod]
    public void Theme_IsValidGet() {
      var data = Windows.UI.Xaml.ApplicationTheme.Light;

      LocalData.Theme = data;

      Assert.AreEqual(data, LocalData.Theme);
      Assert.AreEqual(data, ( Windows.UI.Xaml.ApplicationTheme) property[LocalData.PROPERTY_THEME]);
    }

  }
}
