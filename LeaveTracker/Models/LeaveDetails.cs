
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveTracker.Models
{
    [Table("Leave_Details")]
    public class LeaveDetails
    {
        [Key]
        public int LeaveId { get; set; }
        [Required]
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        public DateTime DateApplied { get; set; }
        public DateTime DateApproved { get; set; }
        [Required]
        public bool IsPlanned { get; set; }
        public string Reason { get; set; }
        public bool IsApproved { get; set; }
        public int ApprovedById { get; set; }
        public string Comments { get; set; }
    }
}
