namespace StockManagement.Domain.Entities.Responses
{
    public static class ResponseMessages
    {
        public const string Ok = "Registro(s) retornado(s) com sucesso.";
        public const string Created = "Registro criado com sucesso.";
        public const string Updated = "Registro atualizado com sucesso.";
        public const string Deleted = "Registro excluído com sucesso.";

        public const string RequestError = "Houve um erro durante a requisição, revise o corpo da requisição.";
        public const string Unauthorized = "Você não tem permissão para acessar esse recurso.";
        public const string ServerError = "Ocorreu um erro com a solicitação, tente mais tarde.";
        public const string NotFound = "Registro não encontrado.";
    }
}
