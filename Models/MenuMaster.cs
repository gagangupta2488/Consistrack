using System;
using System.ComponentModel.DataAnnotations;
namespace Consistrack.Models
{
    public class MenuMaster
    {
        [Key]
        public int MenuID { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public int ParentID { get; set; }
        public string NavigateUrl { get; set; }
        public int SortOrder { get; set; }
        public string Icon { get; set; }


    }}