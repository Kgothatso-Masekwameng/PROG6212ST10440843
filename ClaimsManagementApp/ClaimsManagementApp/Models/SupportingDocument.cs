using System.ComponentModel.DataAnnotations;

namespace ClaimsManagementApp.Models
{
    public class SupportingDocument
    {
        public int Id { get; set; }
        public int ClaimId { get; set; }

        [Required]
        public string FileName { get; set; }

        [Required]
        public string StoredFileName { get; set; }

        public string ContentType { get; set; }

        public long FileSize { get; set; }

        public DateTime UploadDate { get; set; } = DateTime.Now;
    }
}