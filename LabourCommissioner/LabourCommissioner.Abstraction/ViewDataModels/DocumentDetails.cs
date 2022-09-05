using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabourCommissioner.Abstraction.ViewDataModels
{
    public class DocumentDetails
    {

        public class DocumentViewModel
        {
            public IList<DocumentFileDetails> documentFileDetails { get; set; }
        }
        public class DocumentFileDetails
        {
            public string? DocumentNameGuj { get; set; }
            public long ServiceId { get; set; }
            public int TabSequenceNo { get; set; }
            public string? ServiceDocumentType { get; set; }
            public string? DocumentTypeIds { get; set; }
            public int IsCompulsary { get; set; }
            public string? IsNumberInput { get; set; }
            public string? IsActive { get; set; }

            //DocumentDetails Master : Start


            public long ApplicationId { get; set; }
            public long DocumentMasterId { get; set; }
            public string? DocumentName { get; set; }
            public string? FileName { get; set; }
            //[Required(ErrorMessage = "Please enter DocumentNumber.")]
            public string? DocumentNumber { get; set; }
            public bool IsDeleted { get; set; }
            public DateTime CreatedDate { get; set; }
            public long CreatedBy { get; set; }
            public long? ModifiedBy { get; set; }
            public DateTime? ModifiedDate { get; set; }
            public string? IpAddress { get; set; }
            public string? HostName { get; set; }
            public string? CouchDBDocId { get; set; }

            //[DataType(DataType.Upload)]
            //[MaxFileSize(5 * 1024 * 1024, ErrorMessage = "This photo extension is not allowed!")]
            //[AllowedExtensions(new string[] { ".jpg", ".png" }, ErrorMessage = "This photo extension is not allowed!")]

            //[Required(ErrorMessage = "Please select a file.")]
            public FormFileWrapper IdImage { get; set; }
            public int SequenceNo { get; set; }
            public string  isuploaded { get; set; }
        }
        public class FormFileWrapper
        {

            //[DataType(DataType.Upload)]
            //[MaxFileSize(5 * 1024 * 1024, ErrorMessage = "This photo extension is not allowed!")]
            //[AllowedExtensions(new string[] { ".jpg", ".png" }, ErrorMessage = "This photo extension is not allowed!")]

            //[Required(ErrorMessage = "Please select a file.")]
            public IFormFile File { get; set; }
        }
        public class MaxFileSizeAttribute : ValidationAttribute
        {
            private readonly int _maxFileSize;
            public MaxFileSizeAttribute(int maxFileSize)
            {
                _maxFileSize = maxFileSize;
            }

            protected override ValidationResult IsValid(
            object value, ValidationContext validationContext)
            {
                var file = value as IFormFile;
                if (file != null)
                {
                    if (file.Length > _maxFileSize)
                    {
                        return new ValidationResult(GetErrorMessage());
                    }
                }

                return ValidationResult.Success;
            }

            public string GetErrorMessage()
            {
                return $"Maximum allowed file size is {_maxFileSize} bytes.";
            }
        }
        public class AllowedExtensionsAttribute : ValidationAttribute
        {
            private readonly string[] _extensions;
            public AllowedExtensionsAttribute(string[] extensions)
            {
                _extensions = extensions;
            }

            protected override ValidationResult IsValid(
            object value, ValidationContext validationContext)
            {
                var file = value as IFormFile;
                if (file != null)
                {
                    var extension = Path.GetExtension(file.FileName);
                    if (!_extensions.Contains(extension.ToLower()))
                    {
                        return new ValidationResult(GetErrorMessage());
                    }
                }

                return ValidationResult.Success;
            }

            public string GetErrorMessage()
            {
                return $"This photo extension is not allowed!";
            }
        }

    }

}
