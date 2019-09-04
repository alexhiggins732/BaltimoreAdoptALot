using BaltimoreAdoptALot.Models.AddressModels;
using BaltimoreAdoptALot.Models.GeoCodeModels;
using BaltimoreAdoptALot.Models.LotModels;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net;

namespace BaltimoreAdoptALot.Api
{
    public class AddressLookup
    {
        public static AddressResult LookupAddressByLot(string lot)
        {
            var lotLookup = LotLookup.LookupLot(lot.ToUpper().Trim());
            return LookupAddressByLotLookup(lotLookup);

        }

        private static AddressResult LookupAddressByLotLookup(LotLookupResult lotLookup)
        {
            var geo = LotGeoCoder.GetLotGeoCodeResult(lotLookup);
            return LookupAddressByGeoResult(geo);

        }

        private static AddressResult LookupAddressByGeoResult(LotGeoCodeResult geo)
        {
            var geometry = geo.features.First().geometry;

            var geoPayload = new GeoLookupRequest(geo);

            var location = Uri.EscapeUriString(geoPayload.ToJson());
            var url = $@"https://geocode.arcgis.com/arcgis/rest/services/World/GeocodeServer/reverseGeocode?location={location}&distance=1000&f=json";

            using (var client = new WebClient())
            {
                var json = client.DownloadString(url);
                return JsonConvert.DeserializeObject<AddressResult>(json);
            }
        }
    }
}
