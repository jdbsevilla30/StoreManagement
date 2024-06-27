namespace StoreManagement.Dtos
{
    public class DataLoggerDto
    {
        public string? User { get; set; }
        public DateTime Date { get; set; }  
        public string ErrorMessage { get; set; }
        public string Module { get; set; }
    }
}
