using System;

namespace Methods {

  public static class NumberMethods {

    public static string ToStringSI(this double d, string[] prefixes, string format = null) {
      double num = Math.Abs(d);

      if (d < 1000) {
        return String.Format("{0:0.##}", d);
      }

      int i = 0;
      double basenumber = 1000;
      for (; i < prefixes.Length; i++) {
        basenumber *= 1000;
        if (num < basenumber) {
          break;
        }
      }
      if(i == prefixes.Length){
        i--;
      }

      if (format != null) {
        return String.Format("{0:" + format + "}{1}", d / basenumber * 1000, prefixes[i]);
      } else {
        return String.Format("{0:0.##}{1}", d / basenumber * 1000, prefixes[i]);
      }
    }

    public static string ToStringSi(decimal d, string[] prefixes, string format = null) {
      return ToStringSI((double)d, prefixes, format);
    }
  }
}