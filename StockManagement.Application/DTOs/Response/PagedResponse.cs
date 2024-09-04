using System.ComponentModel.DataAnnotations;

namespace StockManagement.Application.DTOs.Response
{
    public class PagedResponse<TEntity> : ResponseBase
    {
        [Display(Name = "Registros")]
        public List<TEntity> Data { get; set; } = [];

        [Display(Name = "PaginaAtual")]
        public int CurrentPage { get; set; } = 0;

        [Display(Name = "PaginasTotais")]
        public int TotalPages { get; set; } = 0;

        [Display(Name = "QuantidadePagina")]
        public int PageCount { get; set; } = 0;

        [Display(Name = "QuantidadeTotal")]
        public int TotalCount { get; set; } = 0;
    }
}
