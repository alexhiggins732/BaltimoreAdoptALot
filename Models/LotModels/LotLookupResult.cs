namespace BaltimoreAdoptALot.Models.LotModels
{
    public class LotLookupResult
    {
        public string displayFieldName { get; set; }
        public FieldAliases fieldAliases { get; set; }
        public Field[] fields { get; set; }
        public Feature[] features { get; set; }
    }
}
