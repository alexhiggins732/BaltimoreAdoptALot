namespace BaltimoreAdoptALot.Models.GeoCodeModels
{
    public class LotGeoCodeResult
    {
        public string displayFieldName { get; set; }
        public FieldAliases fieldAliases { get; set; }
        public string geometryType { get; set; }
        public SpatialReference spatialReference { get; set; }
        public Field[] fields { get; set; }
        public Feature[] features { get; set; }
    }
}
