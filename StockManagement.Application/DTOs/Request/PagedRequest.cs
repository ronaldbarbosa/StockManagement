using StockManagement.Domain;
using System.ComponentModel.DataAnnotations;

namespace StockManagement.Application.DTOs.Request
{
    public class PagedRequest : RequestBase
    {
        [Display(Name = "Quantidade de registros por página.")]
        public int PageCount { get; set; } = Configuration.DefaultPageCount;
        [Display(Name = "Número da página.")]
        public int PageNumber { get; set; } = Configuration.DefaultPageNumber;
    }
}
