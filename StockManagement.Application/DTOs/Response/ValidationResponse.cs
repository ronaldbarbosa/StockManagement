using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace StockManagement.Application.DTOs.Response
{
    public class ValidationResponse
    {
        [Display(Name = "Erros")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public List<Error> ErrorList { get; private set; } = [];

        public ValidationResponse() { }

        public bool IsValid() => !(ErrorList.Count > 0);

        public void AddError(string property, string message)
        {
            ErrorList.Add(new Error(property, message));
        }
    }
}
