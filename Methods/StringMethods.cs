namespace Methods {

  public static class StringMethods {

    public static int SubstringSize(this string text, string sub) {
      text = text.ToLower();
      sub = sub.ToLower();
      if (sub.Length > text.Length) return 0;
      int res = 0;
      int preRes = 0;
      for (int i = 0, len = text.Length, subLen = sub.Length; i < len - res; i++) {
        int j = 0;
        for (; j < subLen && i + j < len; j++) {
          if (text[i + j] != sub[j]) {
            break;
          }
          preRes++;
        }
        if (preRes > res) {
          res = preRes;
          preRes = 0;
        }
      }
      return res;
    }
  }
}