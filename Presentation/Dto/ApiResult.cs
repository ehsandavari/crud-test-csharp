using System.ComponentModel.DataAnnotations;

namespace Presentation.Dto;

public class ApiResult
{
    public ApiResult(bool isSuccess)
    {
        IsSuccess = isSuccess;
    }

    [Required] public bool IsSuccess { get; }
}

public class ApiResultWithData<TData> : ApiResult
{
    public ApiResultWithData(TData data) : base(true)
    {
        Data = data;
    }

    [Required] public TData Data { get; }
}

public class ApiResultWithMetaData : ApiResult
{
    public ApiResultWithMetaData(MetaData metaData) : base(false)
    {
        MetaData = metaData;
    }

    [Required] public MetaData MetaData { get; }
}

public class MetaData
{
    public MetaData(string? exceptionType, int? exceptionCode, object? error)
    {
        ExceptionType = exceptionType;
        ExceptionCode = exceptionCode;
        Error = error;
    }

    [Required] public string? ExceptionType { get; }
    [Required] public int? ExceptionCode { get; }
    [Required] public object? Error { get; }
}