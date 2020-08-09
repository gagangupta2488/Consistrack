using System;
using System.ComponentModel.DataAnnotations;
namespace Consistrack.Models
{
    public class AccessoriesMaster
    {
         [Key]
        public int Id { get; set; }
        [Required(ErrorMessage="Pleae Enter the Name")]
        public string Name { get; set; }
        public string Description { get; set; }
         [Required(ErrorMessage="Pleae Enter the DOP")]
        public DateTime? DOP { get; set; }

         [Required(ErrorMessage="Pleae Enter Quantity")]
        public string Quantity { get; set; }
        public string Remark { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDT { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDT { get; set; }
        public bool IsActive{get;set;}
    
    }
}