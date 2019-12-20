namespace SmartDataPlacement.Common.Responses
{
    public class PropertyData
    {
        public Property Property { get; set; }
    }

    public class Property
    {
        public int PropertyID { get; set; }
        public string Name { get; set; }
        public string FormerName { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string Market { get; set; }
        public string State { get; set; }        
    }
}
