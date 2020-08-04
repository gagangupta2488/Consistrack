using System;
using System.ComponentModel.DataAnnotations;
namespace Consistrack.Models
{

    public class GPSMaster
    {
         [Key]
        public int Id { get; set; }
        public string GPSId { get; set; }
        [Required(ErrorMessage = "Please Enter Vendor Name"), MaxLength(255)]
        public string Vender { get; set; }
        public DateTime? DOP { get; set; }
        public string DeviceModel { get; set; }
        [Required(ErrorMessage = "Please Enter AT-Model Name")]
        public string ATModel { get; set; }
        [Required(ErrorMessage = "Please Enter IMEI No")]
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