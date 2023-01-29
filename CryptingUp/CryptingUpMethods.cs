using System.Net.Http;

namespace CryptingUp {

  public static class CryptingUpMethods {
    public const string DOMAIN = "https://cryptingup.com/api/";
    public const string PROPERTY_ASSETS = "assets";
    public const string JSON_NEXT_PROPERTY = "next";

    public static string SendGetRequest(string path) {
      var client = new HttpClient();

      var result = client.GetAsync(DOMAIN + path).Result;
      result.EnsureSuccessStatusCode();

      return result.Content.ReadAsStringAsync().Result;
    }
  }
}