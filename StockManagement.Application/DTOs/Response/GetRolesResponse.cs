using StockManagement.Shared.IdentityEntities;

namespace StockManagement.Application.DTOs.Response
{
    public class GetRolesResponse : ResponseBase
    {
        public List<RoleDTO> Roles { get; set; } = [];
    }
}
