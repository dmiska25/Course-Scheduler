using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Scheduler.Objects
{
    // Standing ENUMS
    public enum Standing { FRESHMAN, SOPHOMORE, JUNIOR, SENIOR }

    //Course Details Struct
    public partial class Course
    {
        public struct CourseDetails
        {

            // fields:
            // requriement details
            private int minimumCreditsTaken;
            private Standing standingRequired;
            private int yearMultiple;
            private int yearBase;
            // Course Type/Details
            private bool undergraduate;
            private bool graduate;
            private bool generalElective;
            private bool degreeElective;
            private bool dualCredit;



            // Properties:
            public int CreditsRequired 
            {
                get { return minimumCreditsTaken; }
                set { minimumCreditsTaken = value; }
            }
            public Standing RequiredStanding 
            {
                get { return standingRequired; }
                set 
                {
                    standingRequired = value;
                    switch(value)
                    {
                        case Standing.FRESHMAN:
                            CreditsRequired = 15;
                            break;
                        case Standing.SOPHOMORE:
                            CreditsRequired = 30;
                            break;
                        case Standing.JUNIOR:
                            CreditsRequired = 60;
                            break;
                        case Standing.SENIOR:
                            CreditsRequired = 90;
                            break;
                        default:
                            throw new Exception("Illegal case in standing set!");

                    }
                }
            }

            public int YearBase => yearBase;
            public int YearMultiple => yearMultiple;
            public bool UndergraduateLevel => undergraduate;
            public bool GraduateLevel => graduate;
            public bool GeneralElective => generalElective;
            public bool DegreeElective => degreeElective;
            public bool DualCredit => dualCredit;

            //String properties
            public String StrCreditsRequired
            {
                set { int.TryParse(value, out minimumCreditsTaken); }
            }
            public String StrRequiredStanding
            {
                set
                {
                    switch(value)
                    {
                        case "FRESHMAN":
                            standingRequired = Standing.FRESHMAN;
                            CreditsRequired = 15;
                            break;
                        case "SOPHOMORE":
                            standingRequired = Standing.SOPHOMORE;
                            CreditsRequired = 30;
                            break;
                        case "JUNIOR":
                            standingRequired = Standing.JUNIOR;
                            CreditsRequired = 60;
                            break;
                        case "SENIOR":
                            standingRequired = Standing.SENIOR;
                            CreditsRequired = 90;
                            break;
                        default:
                            throw new Exception("Illegal case in Standing set!");
                    }
                }
            }
            public String StrYearBase { set { int.TryParse(value, out yearBase); } }
            public String StrYearMultiple { set { int.TryParse(value, out yearMultiple); } }
            public String StrUndergraduateLevel { set { bool.TryParse(value, out undergraduate); } }
            public String StrGraduateLevel { set { bool.TryParse(value, out graduate); } }
            public String StrGeneralElective { set { bool.TryParse(value, out generalElective); } }
            public String StrDegreeElective { set { bool.TryParse(value, out degreeElective); } }
            public String StrDualCredit { set { bool.TryParse(value, out dualCredit); } }
        }
    }
}
