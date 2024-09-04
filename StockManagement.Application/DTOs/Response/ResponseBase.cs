using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json.Serialization;

namespace StockManagement.Application.DTOs.Response
{
    public class ResponseBase
    {
        [Display(Name = "Validacoes")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ValidationResponse? Validations { get; set; }

        [Display(Name = "OperacaoId")]
        public Guid OperationId { get; set; } = Guid.NewGuid();

        [Display(Name = "Mensagem")]
        public string Mensagem { get; set; } = string.Empty;

        [Display(Name = "CodigoStatus")]
        public HttpStatusCode StatusCode { get; set; }
    }
}
