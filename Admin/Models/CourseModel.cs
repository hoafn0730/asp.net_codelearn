using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class CourseModel
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Level { get; set; }
        public int Price { get; set; }
        public string Slug { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? DeletedAt { get; set; }
        public int CategoryId { get; set; }
        public int TeacherId { get; set; }
        public List<LessonModel> list_json_Lessons { get; set; }


    }
}
