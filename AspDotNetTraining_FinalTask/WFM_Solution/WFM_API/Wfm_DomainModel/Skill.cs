using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WFM_API.Wfm_DomainModel
{
    public class Skill
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column("skillId")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }

        public ICollection<SkillMap> SkillMaps { get; set; }
    }
}
