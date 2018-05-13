using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdBoxPremium.Data.InterchangeModels
{
    public class AcademicSetUpData
    {
        public List<AcademicSetUpDatum> AcademicSetUpDatum { get; set; }
    }

    public class AcademicSetUpDatum
    {
        public School_SubSchool SchoolSubSchool { get; set; }
        public List<School_SubSchoolDepartment> SchoolSubSchoolDepartment { get; set; }
    }
}
