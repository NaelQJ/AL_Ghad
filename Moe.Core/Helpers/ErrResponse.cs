using System.Text.Json;
using Moe.Core.Translations;

namespace Moe.Core.Null;

public class ErrResponseException : Exception
{
    public int StatusCode { get; set; }
    public string MsgKey { get; set; }
    
    public ErrResponseException(string msgKey, int statusCode)
    {
        MsgKey = msgKey;
        StatusCode = statusCode;
    }


    public string ToJson(HttpContext context)
    {
        var lang = context.Request.Headers["Accept-Language"].ToString().ToLowerInvariant();
        
        return JsonSerializer.Serialize(new
        {
            statusCode = StatusCode,
            msg = Localizer.Translate(MsgKey, lang)
        });
    }
}

public static class ErrResponseThrower
{
    public static void BadRequest(string msgKey = null)
    {
        throw new ErrResponseException(msgKey ?? "BAD_REQUEST", 400);
    }
    public static void Unauthorized(string msgKey = null)
    {
        throw new ErrResponseException(msgKey ?? "UNAUTHORIZED", 401);
    }
    public static void Forbidden(string msgKey = null)
    {
        throw new ErrResponseException(msgKey ?? "FORBIDDEN", 403);
    }
    public static void NotFound(string msgKey = null)
    {
        throw new ErrResponseException(msgKey ?? "NOT_FOUND", 404);
    }
    public static void Conflict(string msgKey = null)
    {
        throw new ErrResponseException(msgKey ?? "CONFLICT", 409);
    }

    public static void InternalServerErr(string msgKey = null)
    {
        throw new ErrResponseException(msgKey ?? "INTERNAL_SERVER_ERROR", 500);
    }
}