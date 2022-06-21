namespace Exercice.Exercice4.Domain.Entities
{
    public class Response<TObject>
    {
        public List<TObject>? Data { get; set; }
        public ResponseTypeEnum ResponseTypeEnum { get; set; }
        public List<string> Messages { get; set; }

        public Response()
        {
            Data = new();
            Messages = new();
            ResponseTypeEnum = ResponseTypeEnum.Sucess;
        }

        public void AddSystemError(string message)
        {
            Messages.Add(message);
            ResponseTypeEnum = ResponseTypeEnum.SystemError;
        }

        public void AddBusinessError(string message)
        {
            Messages.Add(message);
            ResponseTypeEnum = ResponseTypeEnum.BusinessError;
        }
    }

    public enum ResponseTypeEnum
    {
        Sucess = 0,
        SystemError = 1,
        BusinessError = 2
    }
}