using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace CryptingUp {

  public class Exchange {
    public const string JSON_PROPERTY_NAME = "exchanges";

    [JsonProperty(PropertyName = "quotes")]
    private Dictionary<string, QuoteExchange> quotes { get; set; }

    public IEnumerable<QuoteExchange> Quotes {
      get {
        foreach (var q in quotes) {
          q.Value.currency = q.Key;
          yield return q.Value;
        }
      }
    }

    public string exchange_id { get; set; }
    public string name { get; set; }
    public string website { get; set; }
    public decimal volume_24h { get; set; }

    public IEnumerable<Market> GetMarkets() {
      return Market.GetByExchangeId(exchange_id);
    }

    public static Exchange GetById(string exchange_id) {
      return GetAllAsArray().FirstOrDefault(e => e.exchange_id == exchange_id);
    }

    public static Exchange[] GetAllAsArray() {
      string res = CryptingUpMethods.SendGetRequest($"exchanges?size=0");

      var jObject = JObject.Parse(res);
      var entities = jObject[JSON_PROPERTY_NAME].ToObject<Exchange[]>();

      return entities;
    }
  }
}