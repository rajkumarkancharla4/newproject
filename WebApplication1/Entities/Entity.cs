using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Entities
{

    [Table("learningtable")]
    public class Entity
    { 

        [Key]
        public long SubscriberID { get; set; }
        public string? TranscriptID { get; set; }
        public string? LearnerID { get; set; }
        public int? PeopleKey { get; set; }
        public string? CourseID { get; set; }
        public string? SessionID { get; set; }
        public string? Status { get; set; }
        public DateTimeOffset? CompletionDate { get; set; }
        public int? SourceID { get; set; }
        public string? SourceName { get; set; }
        public DateTimeOffset? SubscribedDateTime { get; set; }
        public string? Payload { get; set; }
        public bool IsProcessed { get; set; }
    }
}
