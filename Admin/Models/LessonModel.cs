using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class LessonModel
    {
        public int LessonId { get; set; }
        public string NameLesson { get; set; }
        public string Description { get; set; }
        public string VideoId { get; set; }
        public string Slug { get; set; }
        public string? Image { get; set; }
        public string? Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int CourseId { get; set; }
        public int status { get; set; }
    }
}
