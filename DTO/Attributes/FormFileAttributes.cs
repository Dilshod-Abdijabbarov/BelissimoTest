using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Attributes
{
    public class FormFileAttributes : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value,ValidationContext validationContext)
        {
            var path =(string)value;
            if (!File.Exists(path))
                return new ValidationResult("File not fount.");
            string[] extensions =new string[] {".png",".jpg",".ico"};
            var extension = Path.GetExtension(path);

            if (!extensions.Contains(extension))
                return new ValidationResult("This photo extension is not allowed! Allowed extensions in png,jpg,ico");

            return ValidationResult.Success;

        }
    }
}
