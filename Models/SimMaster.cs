using System;
using System.ComponentModel.DataAnnotations;

namespace Consistrack.Models
{
    public class SimMaster
    {[Key]
        public int Id { get; set; }
        public string ATSN { get; set; }
        [Required]
        public string OperatorName { get; set; }
        [Required]
        public string MobileNo { get; set; }
        [Required]
        public string SimNo { get; set; }
        public string Apn { get; set; }
        public string Plan { get; set; }
        public string AccountNo { get; set; }
         [Required]
        public string Status { get; set; }
        public string Remark { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDT { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDT { get; set; }
        public bool IsActive{get;set;}
        
    }
}