namespace Sunday.Nuget.Core.Exceptions
{
    public class ErrorCode
    {
        public const int NoError = 0;
        public const int DuplicatedObject = 0x7ffffffc;
        public const int HttpStatusError = 0x7ffffffd;
        public const int InvalidParameters = 0x7ffffffe;
        public const int UnknownError = 0x7fffffff;
    }
}