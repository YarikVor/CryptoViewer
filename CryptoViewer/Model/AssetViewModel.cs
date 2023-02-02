using CryptingUp;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CryptoViewer {

  public class AssetViewModel {
    public IEnumerable<QuoteAsset> quotes;

    public string name;
    public string assetId;
    public string description;
    public string website;
    public string ethereumContractAddress;
    public string pegged;
    public string price;
    public string volume24h;
    public string change1h;
    public string deltaChange1h;
    public string change24h;
    public string deltaChange24h;
    public string change7d;
    public string deltaChange7d;
    public string totalSupply;
    public string maxSupply;
    public string marcetCap;
    public string lastUpdate;
    public string status;

    public static explicit operator AssetViewModel(Asset asset) {
      if (asset == null) return null;
      var si = ResourseMethods.GetSi().ToArray();
      var res = new AssetViewModel() {
        quotes = asset.quotes,
        name = asset.name,
        assetId = asset.asset_id,
        description = asset.description,
        website = asset.website,
        ethereumContractAddress = asset.ethereum_contract_address,
        pegged = asset.pegged,
        price = $" (${asset.price.ToLocalSiString()})",
        volume24h = asset.volume_24h.ToLocalSiString(),
        change1h = "$" + asset.change_1h.ToLocalSiString(),
        deltaChange1h = ( asset.change_1h / asset.price ).ToString("P"),
        change24h = "$" + asset.change_24h.ToLocalSiString(),
        deltaChange24h = ( asset.change_24h / asset.price ).ToString("P"),
        change7d = "$" + asset.change_7d.ToLocalSiString(),
        deltaChange7d = ( asset.change_7d / asset.price ).ToString("P"),
        totalSupply = asset.total_supply.ToLocalSiString(),
        maxSupply = asset.max_supply.ToLocalSiString(),
        marcetCap = asset.market_cap.ToLocalSiString(),
        lastUpdate = ( DateTime.Now - asset.updated_at ).ToString("%d' днів '%h' год. '%m' хв. назад'"),
        status = asset.GetStatus() == StatusAsset.Stale ? "(ЗАСТАРІЛИЙ)" : ""
      };
      return res;
    }
  }
}