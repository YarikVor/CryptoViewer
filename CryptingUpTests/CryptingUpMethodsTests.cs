using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CryptingUp.Tests {

  [TestClass]
  public class CryptingUpMethodsTests {

    [TestMethod]
    public void SendGetRequest_IsJsonResult() {
      string res = CryptingUpMethods.SendGetRequest("markets?size=1");
      Assert.IsTrue(res.StartsWith("{\""), "Text must start with '{\"', but started with '" + res.Substring(0, 25) + "'");
    }
  }
}