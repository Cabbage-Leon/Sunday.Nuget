namespace Sunday.Nuget.Core.Infrastructure
{
    public class ApiResult
    {
        /// <summary>
        /// API 执行是否成功
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// ErrorCode 为 0 表示执行无异常
        /// </summary>
        public object ErrorCode { get; set; }

        /// <summary>
        /// 当API执行有异常时, 对应的错误信息
        /// </summary>
        public string ErrMsg { get; set; }

        public ApiResult()
        {
            IsSuccess = true;
            ErrorCode = 0;
        }
        public ApiResult(object errorCode, string message = null)
        {
            ErrorCode = errorCode;
            ErrMsg = message;
            IsSuccess = false;
        }

    }

    /// <inheritdoc />
    /// <summary>
    ///     Api返回结果
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    public class ApiResult<TResult> : ApiResult
    {
        public ApiResult()
        {
            IsSuccess = true;
        }

        public ApiResult(TResult result)
            : this()
        {
            ResultData = result;
        }

        public ApiResult(object errorCode, string message = null)
            : base(errorCode, message) { }

        /// <summary>
        ///     API 执行返回的结果
        /// </summary>
        public TResult ResultData { get; set; }
    }
}
