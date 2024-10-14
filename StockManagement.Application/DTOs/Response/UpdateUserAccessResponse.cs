namespace StockManagement.Application.DTOs.Response
{
    public class UpdateUserAccessResponse
    {
        public Dictionary<string, List<string>> Errors { get; set; } = [];

        public bool IsSucceded()
        {
            return Errors.Count == 0;
        }
    }
}
