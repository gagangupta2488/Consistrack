
using System;
using System.ComponentModel.DataAnnotations;
namespace Consistrack.Models
{
    public class UserMaster
    {
        [Key]
        public int UserID { get; set; }
        public string UserCode { get; set; }
        public string UserFName { get; set; }
        public string UserLName { get; set; }
        public string UserFullNameEn { get; set; }
        public string UserFullNameHi { get; set; }
        public string LoginID { get; set; }
        public string Password { get; set; }
        public string RoleID { get; set; }
        public string MobileNo { get; set; }
        public DateTime DOB { get; set; }
        public string ImageURL { get; set; }
        public string Gender { get; set; }
        public string EmailID { get; set; }
        public string Designation { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDT { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDT { get; set; }
        public bool IsActive { get; set; }
    
    }}