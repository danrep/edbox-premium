using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdBoxPremium.Data.InterchangeModels
{
    public class StudentCompleteData
    {
        public Student_ProfileData StudentProfileData { get; set; }
        public List<StudentData> StudentData { get; set; }
    }

    public class StudentData
    {
        public Student_RegistrationData StudentRegistrationData { get; set; }
        public List<Student_CourseRegistration> StudentCourseRegistration { get; set; }
    }
}
