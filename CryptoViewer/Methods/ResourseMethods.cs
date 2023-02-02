using Methods;
using System.Collections.Generic;
using System.Linq;
using Windows.ApplicationModel.Resources;

namespace CryptoViewer {

  public static class ResourseMethods {

    public static IEnumerable<string> GetSi() {
      var current = ResourceLoader.GetForCurrentView();
      string[] array = new string[] { "SI-k", "SI-M", "SI-G", "SI-T", "SI-P", "SI-E", "SI-Z", "SI-Y" };
      foreach (string s in array) {
        yield return current.GetString(s);
      }
    }

    public static string ToLocalSiString(this decimal d, string format = null) {
      return NumberMethods.ToStringSI((double)d, GetSi().ToArray(), format);
    }

    public static string ToLocalSiString(this float d, string format = null) {
      return NumberMethods.ToStringSI((double)d, GetSi().ToArray(), format);
    }

    public static string ToLocalSiString(this double d, string format = null) {
      return NumberMethods.ToStringSI(d, GetSi().ToArray(), format);
    }

    public static string ToLocalSiString(this long d, string format = null) {
      return NumberMethods.ToStringSI((double)d, GetSi().ToArray(), format);
    }
  }
}