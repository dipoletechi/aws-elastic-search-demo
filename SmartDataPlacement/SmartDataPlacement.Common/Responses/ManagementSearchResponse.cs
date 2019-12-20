namespace SmartDataPlacement.Common.Responses
{
    public class ManagementData
    {
        public Management Mgmt { get; set; }
    }

    public class Management
    {
        public int MgmtID { get; set; }
        public string Name { get; set; }       
        public string Market { get; set; }
        public string State { get; set; }        
    }
}
