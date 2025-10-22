using System;
using System.ComponentModel.DataAnnotations;

namespace ClaimsManagementApp.Models
{
    public class Claim
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Lecturer name is required")]
        public string LecturerName { get; set; }

        [Required(ErrorMessage = "Hours worked is required")]
        [Range(0.5, 100, ErrorMessage = "Hours worked must be between 0.5 and 100")]
        public decimal HoursWorked { get; set; }

        [Required(ErrorMessage = "Hourly rate is required")]
        [Range(50, 500, ErrorMessage = "Hourly rate must be between 50 and 500")]
        public decimal HourlyRate { get; set; }

        public decimal TotalAmount => HoursWorked * HourlyRate;

        public string AdditionalNotes { get; set; }

        public DateTime SubmissionDate { get; set; } = DateTime.Now;

        public ClaimStatus Status { get; set; } = ClaimStatus.Pending;

        public List<SupportingDocument> Documents { get; set; } = new List<SupportingDocument>();
    }

    public enum ClaimStatus
    {
        Pending,
        ApprovedByCoordinator,
        RejectedByCoordinator,
        ApprovedByManager,
        RejectedByManager,
        Settled
    }
}