namespace Application.DTOs
{
    public class PropertyDto
    {
        public string IdProperty { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string CodeInternal { get; set; } = string.Empty;
        public int Year { get; set; }

        public OwnerDto? Owner { get; set; }
        public ICollection<PropertyImageDto>? Images { get; set; }
        public ICollection<PropertyTraceDto>? Traces { get; set; }
    }
}
