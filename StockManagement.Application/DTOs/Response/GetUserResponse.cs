namespace StockManagement.Application.DTOs.Response
{
    public class GetUserResponse : ResponseBase
    {
        public UserDTO? User { get; set; }
    }
}
