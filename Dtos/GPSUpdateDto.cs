using System;
using System.ComponentModel.DataAnnotations;
namespace Consistrack.Dtos
{

    public class GPSUpdateDto
    {
         [Key]
        public int Id { get; set; }
        public string Vender { get; set; }
        public DateTime? DOP { get; set; }
        public string DeviceModel { get; set; }
        [Required]
        public string ATModel { get; set; }
        [Required]
        public string IMEINo { get; set; }
        public string Status { get; set; }
        public string Remark { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDT { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDT { get; set; }
        public bool IsActive{get;set;}
    
    }
}