using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using Methods;

namespace MethodsTests {
  [TestClass]
  public class NumberMethodsTests {
    static string[] si = new string[]{
      "k", "M", "G"
    };
    [DataTestMethod]
    [DataRow(0.12, "0.12")]
    [DataRow(1.213e3, "1.21k")]
    [DataRow(1.213e9, "1.21G")]
    [DataRow(1.213e12, "1213G")]
    public void ToStringSI_IsValid(double num, string exp) {
      string actual = num.ToStringSI(si);
      Assert.AreEqual(exp, actual);
    }



  }
}
