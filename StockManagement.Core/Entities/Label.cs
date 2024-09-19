namespace StockManagement.Domain.Entities
{
    public class Label
    {
        public Guid Id { get; set; }
        public string SystemName { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
        public Language Language { get; set; }
    }

    public enum Language
    {
        Portugues = 1,
        English = 2,
        Espanol = 3
    }
}
