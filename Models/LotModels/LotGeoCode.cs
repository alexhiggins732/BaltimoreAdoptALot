using Newtonsoft.Json;
using System.Linq;
using System.Net;
using BaltimoreAdoptALot.Models.GeoCodeModels;
namespace BaltimoreAdoptALot.Models.LotModels
{
    public class LotGeoCoder
    {
        public static LotGeoCodeResult GetLotGeoCodeResult(LotLookupResult lotLookup)
        {
            var atts = lotLookup.features.First().attributes ;
            var objectId = atts.OBJECTID;

            var url = $@"http://geodata.baltimorecity.gov/egis/rest/services/Planning/Property_Ownership/MapServer/0/query?f=json&returnGeometry=true&spatialRel=esriSpatialRelIntersects&maxAllowableOffset=1&objectIds={objectId}&outFields=BLOCKLOT%2CFULLADDR&outSR=102100";
            using (var client = new WebClient())
            {
                var json = client.DownloadString(url);
                return JsonConvert.DeserializeObject<LotGeoCodeResult>(json);
            }
        }
    }  
}
