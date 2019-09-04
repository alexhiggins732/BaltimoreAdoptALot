using BaltimoreAdoptALot.Models.LotModels;
using Newtonsoft.Json;
using System;
using System.Net;

namespace BaltimoreAdoptALot.Api
{
    public class LotLookup
    {
        public static LotLookupResult LookupLot(string lot)
        {
            var encoded = Uri.EscapeUriString($"'%{lot}%'");
            var url = $@"http://geodata.baltimorecity.gov/egis/rest/services/Planning/Property_Ownership/MapServer/0/query?f=json&where=UPPER(BLOCKLOT)%20LIKE%20{encoded}&returnGeometry=false&spatialRel=esriSpatialRelIntersects&outFields=BLOCKLOT%2CFULLADDR%2COBJECTID&outSR=102100&resultRecordCount";

            using (var client = new WebClient())
            {
                var result = client.DownloadString(url);
                return JsonConvert.DeserializeObject<LotLookupResult>(result);
            }
        }
    }
}
