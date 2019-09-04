using System.Linq;
using Newtonsoft.Json;

namespace BaltimoreAdoptALot.Models.GeoCodeModels
{
    public class GeoLookupRequest
    {
        private LotGeoCodeResult geo;

        public GeoLookupRequest(LotGeoCodeResult geo)
        {
            this.geo = geo;
            var rings = geo.features.First().geometry.rings.First();
            this.spatialReference = new SpatialReference
            {
                latestWkid = geo.spatialReference.latestWkid,
                wkid = geo.spatialReference.wkid
            };
            var geoLoc = rings.First();
            this.x = geoLoc[0];
            this.y = geoLoc[1];
        }

        public decimal x { get; set; }
        public decimal y { get; set; }
        public SpatialReference spatialReference { get; set; }

        internal string ToJson()
        {
            var result = JsonConvert.SerializeObject(this);
            return result;
        }
    }
}
