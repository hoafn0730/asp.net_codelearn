using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class ParticipationModel
    {
        public int ParticipationId { get; set; }
        public int CourseId { get; set; }
        public int UserId { get; set; }
        public DateTime RegistrationDate { get; set; }


    }
}
