namespace WebApplication1.Middleware
{
    public class AppException : Exception
    {
        public string Code { get; }

        public AppException(string code) : base(code)
        {
            Code = code;
        }
    }

}
