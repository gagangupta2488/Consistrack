using System;
using System.ComponentModel.DataAnnotations;
namespace Consistrack.Models
{
    public class MenuRoleMap
    {
        [Key]
        public int Id { get; set; }
        public int RoleID { get; set; }
        public int MenuID { get; set; }

    }}