﻿using Microsoft.AspNetCore.Http;

namespace Services.Helpers
{
   // public class HttpContextHelpers
    //{
    //    public static IHttpContextAccessor Accessor { get; set; }
    //    public static HttpContext HttpContext => Accessor?.HttpContext;
    //    public static int? UserId => GetUserId();
    //    public static string UserRole => HttpContext?.User.FindFirst("Role")?.Value;

    //    public static int? GetUserId()
    //    {
    //        string value = HttpContext?.User?.Claims.FirstOrDefault(p => p.Type == "Id")?.Value;

    //        bool canParse = int.TryParse(value, out int id);

    //        return canParse ? id : null;
    //    }
    //}
}
