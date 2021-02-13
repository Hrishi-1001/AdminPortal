using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPortal.Web.Models
{
    public class Alert
    {
        [Display(Name = "AlertId")]
        public int ID { get; set; }
        [Display(Name = "Message")]
        public string Text { get; set; }
        public Asset Asset { get; set; }
        [Display(Name = "On Asset")]
        public int AssetID { get; set; }
    }
}
