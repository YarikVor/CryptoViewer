using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace CryptingUp {

  public class BaseAsset {
    public const string JSON_PROPERTY_NAME = "assets";

    public string asset_id { get; set; }
    public string name { get; set; }

    public Asset GetAsset() {
      if (this is Asset a)
        return a;
      return Asset.GetById(asset_id);
    }

    public static BaseAsset GetById(string asset_id) {
      return GetAllAsArray().FirstOrDefault(e => e.asset_id == asset_id);
    }



    public static BaseAsset[] GetAllAsArray() {
      string res = CryptingUpMethods.SendGetRequest($"assetsoverview");

      var jObject = JObject.Parse(res);
      var entities = jObject[JSON_PROPERTY_NAME].ToObject<BaseAsset[]>();

      return entities;
    }
  }
}