using System.ComponentModel.DataAnnotations;

namespace WfmDomainModel.Models
{
    public class skills
    {
        [Key]
        public decimal Skillid { get; set; }
        public string Name { get; set; }
    }
}