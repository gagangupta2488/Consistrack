using System;
using System.ComponentModel.DataAnnotations;
namespace Consistrack.Models
{

    public class SensorMaster
    {
         [Key]
        public int Id { get; set; }
        public string SensorId{get; set;}
        public string Vender { get; set; }
        public DateTime? DOP { get; set; }
        public string DeviceModel { get; set; }
        [Required]
        public string ATModel { get; set; }
        [Required]
        public string MAC_No { get; set; }
        public string Serial_No { get; set; }
        public string Device_Id { get; set; }
        public string Length { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string Remark { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDT { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDT { get; set; }
        public bool IsActive{get;set;}
    
    }
}