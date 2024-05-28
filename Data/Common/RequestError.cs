namespace Data.Common
{
    public class RequestError
    {
        public RequestError(string eror)
        {
            error = error;
        }

        public string error { get; }

        public override string ToString()
        {
            return error;
        }
    }
}
