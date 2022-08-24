using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WfmDomainModel.Models
{
    public class skillmap
    {
        public decimal Skillid { get; set; }
        public int Employee_id { get; set; }
        public employees employees { get; set; }
        public skills skills { get; set; }
    }
}
