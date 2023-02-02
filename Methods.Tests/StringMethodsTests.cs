using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using Methods;

namespace MethodsTests {
  [TestClass]
  public class StringMethodsTests {

    [DataTestMethod]
    [DataRow("BITCOIN", "cost", 2)]
    [DataRow("BITCOIN", "bit", 3)]
    [DataRow("BITCOIN", "rak", 0)]
    [DataRow("BITCOIN", "IN", 2)]
    public void SubstringSize_IsValid(string text, string sub, int exp) {
      int actual = text.SubstringSize(sub);

      Assert.AreEqual(exp, actual);
    }



  }
}
