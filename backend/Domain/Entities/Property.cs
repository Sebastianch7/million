namespace Domain.Entities
{
    public class Property
    {
        public string Id { get; set; } = string.Empty;
        public string IdProperty { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string CodeInternal { get; set; } = string.Empty;
        public int Year { get; set; }
        public string IdOwner { get; set; } = string.Empty;

        // Relaciones
        public Owner? Owner { get; set; }
        public ICollection<PropertyImage>? Images { get; set; }
        public ICollection<PropertyTrace>? Traces { get; set; }
    }
}
