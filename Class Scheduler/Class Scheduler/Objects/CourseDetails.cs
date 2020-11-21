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
        [Serializable]
        public struct CourseDetails
        {

            // fields:
            // requriement details
            private int? _minimumCreditsTaken;
            private Standing _standingRequired;
            private int? _yearMultiple;
            private int? _yearBase;
            // Course Type/Details
            private bool _undergraduate;
            private bool _graduate;
            private bool _generalElective;
            private bool _degreeElective;
            private bool _dualCredit;



            // Properties:
            public int? CreditsRequired 
            {
                get { return _minimumCreditsTaken; }
                set { _minimumCreditsTaken = value; }
            }
            public Standing RequiredStanding 
            {
                get { return _standingRequired; }
                set 
                {
                    _standingRequired = value;
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

            public int? YearBase { get => _yearBase; set { _yearBase = value; } }
            public int? YearMultiple { get => _yearMultiple; set { _yearMultiple = value; } }
            public bool UndergraduateLevel { get => _undergraduate; set { _undergraduate = value; } }
            public bool GraduateLevel { get => _graduate; set { _graduate = value; } }
            public bool GeneralElective { get => _generalElective; set { _generalElective = value; } }
            public bool DegreeElective { get => _degreeElective; set { _degreeElective = value; } }
            public bool DualCredit { get => _dualCredit; set { _dualCredit = value; } }

            //String properties
            public String StrCreditsRequired
            { set {
                    int temp;
                    if (!int.TryParse(value, out temp)) throw new Exception("Credits Required string is invalid!");
                    _minimumCreditsTaken = temp;
                } }
            public String StrRequiredStanding
            {
                set
                {
                    switch(value)
                    {
                        case "FRESHMAN":
                            _standingRequired = Standing.FRESHMAN;
                            CreditsRequired = 15;
                            break;
                        case "SOPHOMORE":
                            _standingRequired = Standing.SOPHOMORE;
                            CreditsRequired = 30;
                            break;
                        case "JUNIOR":
                            _standingRequired = Standing.JUNIOR;
                            CreditsRequired = 60;
                            break;
                        case "SENIOR":
                            _standingRequired = Standing.SENIOR;
                            CreditsRequired = 90;
                            break;
                        default:
                            throw new Exception("Illegal case in Standing set!");
                    }
                }
            }
            public String StrYearBase { set {
                    int temp;
                    if (!int.TryParse(value, out temp)) throw new Exception("Year Base string is invalid!"); 
                    _yearBase = temp;
                } }
            public String StrYearMultiple { set {
                    int temp;
                    if (!int.TryParse(value, out temp)) throw new Exception("Year Multiple string is invalid!");
                    _yearMultiple = temp;
                } }
            public String StrUndergraduateLevel { set {
                    bool temp;
                    if (!bool.TryParse(value, out temp)) throw new Exception("Undergraduate string is invalid!");
                    _undergraduate = temp;
                } }
            public String StrGraduateLevel { set {
                    bool temp;
                    if (!bool.TryParse(value, out temp)) throw new Exception("Graduate string is invalid!");
                    _graduate = temp;
                } }
            public String StrGeneralElective { set {
                    bool temp;
                    if (!bool.TryParse(value, out temp)) throw new Exception("General Elective string is invalid!");
                    _generalElective = temp;
                } }
            public String StrDegreeElective { set {
                    bool temp;
                    if (!bool.TryParse(value, out temp)) throw new Exception("Degree Elective string is invalid!");
                    _degreeElective = temp;
                } }
            public String StrDualCredit { set {
                    bool temp;
                    if (!bool.TryParse(value, out temp)) throw new Exception("Dual Credit string is invalid!");
                    _dualCredit = temp;
                } }



            //serializable information






            }
    }
}
