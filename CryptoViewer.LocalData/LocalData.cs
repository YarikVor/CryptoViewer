using System.Globalization;
using Windows.UI.Xaml;

namespace CryptoViewer.Local {

  public static class LocalData {
    public const string PROPERTY_LANG = "lang";
    public const string PROPERTY_THEME = "theme";
    public static readonly CultureInfo CultureDefault = new CultureInfo("en-US");
    public const ApplicationTheme DefaultTheme = ApplicationTheme.Light;

    public static string LangName {
      get {
        if (LocalHashListAsset.Values.TryGetValue(PROPERTY_LANG, out object value) && value is string sr && !string.IsNullOrEmpty(sr)) {
          return sr;
        }
        return "";
      }
      set {
        if (value == "en-US" || value == "uk-UA") {
          LocalHashListAsset.Values[PROPERTY_LANG] = value;
        }
      }
    }

    public static ApplicationTheme Theme {
      get {
        if (LocalHashListAsset.Values.TryGetValue(PROPERTY_THEME, out object value) && value is int sr) {
          return (ApplicationTheme)sr;
        }
        return DefaultTheme;
      }
      set {
        LocalHashListAsset.Values[PROPERTY_THEME] = (int)value;
      }
    }

    public static int IndexSelectTheme {
      get {
        switch (Theme) {
          case ApplicationTheme.Light: return 0;
          case ApplicationTheme.Dark: return 1;
        }
        return -1;
      }
    }

    public static int IndexSelectLang {
      get {
        switch (LangName) {
          case "uk-UA": return 0;
          case "en-US": return 1;
        }
        return -1;
      }
      set {
        switch (value) {
          case 1:
            LangName = "en-US";
            break;

          case 0:
            LangName = "uk-UA";
            break;
        }
      }
    }
  }
}