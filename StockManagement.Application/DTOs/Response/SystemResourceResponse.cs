namespace StockManagement.Application.DTOs.Response
{
    public class SystemResourceResponse : ResponseBase
    {
        public List<SystemResourceDTO> Menu { get; set; } = [];
    }
}
