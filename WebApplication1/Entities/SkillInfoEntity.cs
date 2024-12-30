using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Entities
{
    [Table("SkillInfo")]
    public class SkillInfoEntity
    {
        public string? ref_SourceID { get; set; }
        public string? SourceID { get; set; }
        public string? SkillID { get; set; }
    }
}
