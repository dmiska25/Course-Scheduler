using Class_Scheduler.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Scheduler.Comparers
{
    class SemesterViewCompare : Comparer<Semester>
    {
        public override int Compare(Semester x, Semester y)
        {
            if (x.Year.CompareTo(y.Year) != 0)
            {
                return x.Year.CompareTo(y.Year);
            }
            else if (x.SemesterReference != y.SemesterReference)
            {
                switch (x.Term)
                {
                    case TermEnums.FALL:
                        return 1;
                    case TermEnums.SUMMER:
                        if (y.Term == TermEnums.FALL) return -1;
                        else return 1;
                    case TermEnums.SPRING:
                        return -1;
                    default:
                        throw new Exception("Illegal State!");
                }
            }
            else
            {
                throw new Exception("Duplicate semester, Illegal State!");
            }
        }
    }
}
