namespace StoreManagement.Dtos
{
    public class StoreInventoryDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int? CategoryId { get; set; }
        public string? Description {  get; set; }
        public decimal? Price { get; set; }
        public int? Quantity { get; set; }
        public bool? IsAvailable { get; set; }
        public string? Category { get; set; }

    }

    public class StoreViewDto
    {
        public string? ProductName { get; set; }
        public string? CategoryId { get; set; }
        public string? Description { get; set; }
        public string? Price { get; set; }
        public string? Quantity { get; set; }
        public string? IsAvailable { get; set; }
    }

}
