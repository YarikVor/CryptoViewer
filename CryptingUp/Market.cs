using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace CryptingUp {

  public class Market {
    public const string JSON_PROPERTY_NAME = "markets";

    public Dictionary<string, QuoteMarket> quote { get; set; }

    public IEnumerable<QuoteMarket> quotes {
      get {
        foreach (var pair in quote) {
          pair.Value.currency = pair.Key;
          yield return pair.Value;
        }
      }
    }

    public string exchange_id { get; set; }
    public string symbol { get; set; }
    public string base_asset { get; set; }
    public string quote_asset { get; set; }
    public float price_unconverted { get; set; }
    public float price { get; set; }
    public float change_24h { get; set; }
    public float spread { get; set; }
    public float volume_24h { get; set; }
    public string status { get; set; }
    public DateTime created_at { get; set; }
    public DateTime updated_at { get; set; }

    public Exchange GetExchange() {
      return Exchange.GetById(exchange_id);
    }

    public Asset GetBaseAsset() {
      return Asset.GetById(base_asset);
    }

    public Asset GetQuoteAsset() {
      return Asset.GetById(quote_asset);
    }

    public IEnumerable<Market> GetByExchangeId() {
      return GetByExchangeId(exchange_id);
    }
    /// <remarks>Not Valid works when data is received partially. Apply the function <see cref="GetAllAsArray"/></remarks>
    public static IEnumerable<Market> GetByExchangeId(string exchange_id) {
      string start = "";
      while (true) {
        string res = CryptingUpMethods.SendGetRequest($"exchanges/{exchange_id}/markets?size=16&start={start}");

        var jObject = JObject.Parse(res);
        var entities = jObject[JSON_PROPERTY_NAME].ToObject<Market[]>();
        foreach (var e in entities) {
          yield return e;
        }
        start = jObject["next"].ToObject<string>();
        if (string.IsNullOrEmpty(start) || start == "0") yield break;
      }
    }

    public static IEnumerable<Market> GetAll() {
      string start = "";
      while (true) {
        string res = CryptingUpMethods.SendGetRequest($"markets?size=16&start={start}");

        var jObject = JObject.Parse(res);
        var entities = jObject[JSON_PROPERTY_NAME].ToObject<Market[]>();
        foreach (var e in entities) {
          yield return e;
        }
        start = jObject[CryptingUpMethods.JSON_NEXT_PROPERTY].ToObject<string>();
        if (string.IsNullOrEmpty(start) || start == "0") yield break;
      }
    }

    public static Market[] GetAllAsArray() {
      string res = CryptingUpMethods.SendGetRequest($"markets?size=0");

      var jObject = JObject.Parse(res);
      var entities = jObject[JSON_PROPERTY_NAME].ToObject<Market[]>();

      return entities;
    }


    public static IEnumerable<Market> GetByAssetId(string asset_id) {
      string res = CryptingUpMethods.SendGetRequest($"assets/{asset_id}/markets?size=0");

      var jObject = JObject.Parse(res);
      var entities = jObject[JSON_PROPERTY_NAME].ToObject<Market[]>();

      return entities;
    }
  }
}