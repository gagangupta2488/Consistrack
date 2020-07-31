using System;
using System.ComponentModel.DataAnnotations;
namespace Consistrack.Models
{
    public class UserRole
    {

[Key]
        public int Id { get; set; }
        public string RoleCode { get; set; }
        public string RoleDesc { get; set; }

    }}