﻿using System.Text.RegularExpressions;

namespace TestAPI.Helpers
{
    public class ConfigureApiUrlName : IOutboundParameterTransformer
    {
        public string? TransformOutbound(object? value)
        {
            // Slugify value
            return value == null ? null : Regex.Replace(value.ToString(), "([a-z])([A-Z])", "$1-$2").ToLower();
        }
    }
}
