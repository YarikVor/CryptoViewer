using System;
using System.Collections.Generic;
using System.Linq;
using Windows.Foundation.Collections;

namespace CryptoViewer.Local {

  public static class LocalHashListAsset {
    private static HashSet<string> current;
    public const string PROPERTY_NAME = "lsAsset";
    public static IPropertySet Values { get; private set; }

    public static IReadOnlyCollection<string> Current => current;
    public static int Count => current.Count;

    public static void Init(IPropertySet values) {
      if (values == null) throw new ArgumentNullException(nameof(values));
      Values = values;
      current = new HashSet<string>();
      if (values.TryGetValue(PROPERTY_NAME, out object obj) && obj is string[] array && array != null) {
        foreach (string s in array) {
          Add(s);
        }
      }
    }

    public static bool Add(string s) {
      if (!string.IsNullOrEmpty(s)) {
        bool res = current.Add(s);
        Save();
        return res;
      }
      return false;
    }

    public static bool Remove(string s) {
      bool res = current.Remove(s);
      Save();
      return res;
    }

    public static void Clear() {
      current.Clear();
    }

    public static void Save() {
      if (current.Count == 0) {
        Values[PROPERTY_NAME] = new string[] { "" };
      } else {
        Values[PROPERTY_NAME] = current.ToArray();
      }
    }

    public static bool Contains(string str) {
      return current.Contains(str);
    }
  }
}