using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
