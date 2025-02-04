﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Entities
{
    [Table("WDLComputedData")]
    public class WdlcompleteDataEntity
    {
        [Key]  // Indicates that ID is the primary key
        public long ID { get; set; }

        public string? EmployeeID { get; set; }

        public string? SkillID { get; set; }

        public DateTimeOffset? StartDate { get; set; }

        public DateTimeOffset? EndDate { get; set; }

        public string? UsagePercentage { get; set; }

        public string? SourceSystem { get; set; }

        public string? CourseID { get; set; }

        public string? CourseName { get; set; }

        public DateTimeOffset? CreatedDateTime { get; set; }

        public DateTimeOffset? ProcessedDateTime { get; set; }

        public bool? IsProcessed { get; set; }

    }
}
