using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LabourCommissioner.Abstraction.ViewDataModels
{
    public class Files
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string? DocumentId { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        public string? Id { get; set; }
        [JsonIgnore]
        public string Rev { get; set; }
        [NotMapped]
        [JsonIgnore]
        [Required(ErrorMessage = "Please select a file.")]
        //public IFormFile File { get; set; }
        //public List<IFormFile> FormFile { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public string FileExtension { get; set; }
        [JsonIgnore]
        public byte[] AttachmentData { get; set; }
        public DateTime CreatedOn { get; internal set; }
    }
}
