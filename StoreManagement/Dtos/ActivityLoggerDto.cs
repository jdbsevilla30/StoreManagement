namespace StoreManagement.Dtos
{
    public class ActivityLoggerDto
    {
        public string? User { get; set; }
        public DateTime Date { get; set; }
        public string Activity { get; set; }
        public string Module { get; set; }
    }
}
