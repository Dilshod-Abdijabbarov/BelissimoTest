using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Helpers
{
    public static class EnveronmentHelper
    {
        public static string WebRootPath { get; set; }
        public static string FilePath => Path.Combine(WebRootPath, "image");
    }
}
