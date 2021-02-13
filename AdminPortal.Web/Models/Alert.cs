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
        public int ID { get; set; }
        public string Text { get; set; }
        public Asset Asset { get; set; }
        public int AssetID { get; set; }
    }
}
