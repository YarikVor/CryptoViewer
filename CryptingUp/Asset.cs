using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CryptingUp {

  [JsonObject]
  public class Asset : BaseAsset {
    public const string JSON_PROPERTY_NAME = "assets";
    public Dictionary<string, QuoteAsset> quote { get; set; }

    public IEnumerable<QuoteAsset> quotes {
      get {
        foreach (var pair in quote) {
          pair.Value.currency = pair.Key;
          yield return pair.Value;
        }
      }
    }

    public string description { get; set; }
    public string website { get; set; }
    public string ethereum_contract_address { get; set; }
    public string pegged { get; set; }
    public decimal price { get; set; }
    public decimal volume_24h { get; set; }
    public float change_1h { get; set; }
    public float change_24h { get; set; }
    public float change_7d { get; set; }
    public float total_supply { get; set; }
    public float circulating_supply { get; set; }
    public long max_supply { get; set; }
    public decimal market_cap { get; set; }
    public decimal fully_diluted_market_cap { get; set; }
    public string status { get; set; }
    public DateTime created_at { get; set; }
    public DateTime updated_at { get; set; }

    public static Asset GetById(string asset_id) {
      return GetAll().FirstOrDefault(e => e.asset_id == asset_id);
    }

    public new static IEnumerable<Asset> GetAll() {
      string start = "";
      while (true) {
        string res = CryptingUpMethods.SendGetRequest($"assets?size=16&start={start}");

        var jObject = JObject.Parse(res);
        var entities = jObject[JSON_PROPERTY_NAME].ToObject<Asset[]>();
        foreach (var e in entities) {
          yield return e;
        }
        start = jObject[CryptingUpMethods.JSON_NEXT_PROPERTY].ToObject<string>();
        if (string.IsNullOrEmpty(start) || start == "0") yield break;
      }
    }

    public new static Asset[] GetAllAsArray() {
      string res = CryptingUpMethods.SendGetRequest($"assets?size=0");

      var jObject = JObject.Parse(res);
      var entities = jObject[JSON_PROPERTY_NAME].ToObject<Asset[]>();

      return entities;
    }
  }
}