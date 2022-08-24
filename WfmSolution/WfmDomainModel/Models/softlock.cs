using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WfmDomainModel.Models
{
    public class softlock
    {
        public int Employee_id { get; set; }
        public string Manager { get; set; }
        public DateTime ReqDate { get; set; }
        public string Status { get; set; }
        public DateTime Lastupdated { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int LockId { get; set; }
        public string RequestMessage { get; set; }
        public string WfmRemark { get; set; }
        public string ManagerStatus { get; set; } = "awaiting_approval";
        public string MgrStatusComment { get; set; }
        public DateTime MgrLastUpdate { get; set; }
        public virtual employees employees { get; set; }

    }
}
