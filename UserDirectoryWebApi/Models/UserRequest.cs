namespace UserDirectoryWebApi.Models
{
    public class UserRequest
    {
        //public required string[] Users { get; set; }
        public int ID { get; set; }
        public int UserID { get; set; }
        public string? EmployeeID { get; set; }
        public string? SiteName { get; set; }
        public string? BusinessUnitName { get; set; }
        public string? AccountName { get; set; }
        public string? GroupName { get; set; }
        public string? CategoryName { get; set; }
        public string? TypeName { get; set; }
        public DateTime Date { get; set; }
        public string? Duration { get; set; }
        public bool IsProcessed { get; set; }        

    }
}
