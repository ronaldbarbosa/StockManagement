namespace StockManagement.Domain
{
    public static class Configuration
    {
        public const int DefaultPageNumber = 1;
        public const int DefaultPageCount = 10;
        public static string ApiUrl { get; set; } = "http://localhost:5205";
        public static string WebUrl { get; set; } = "";
    }
}
