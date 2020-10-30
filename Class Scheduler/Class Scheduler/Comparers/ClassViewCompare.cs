using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Scheduler.Objects
{
    class ClassViewCompare : Comparer<Course>
    {
        public override int Compare(Course x, Course y)
        {
            if (x.coursePrefix.CompareTo(y.coursePrefix) != 0)
            {
                return x.coursePrefix.CompareTo(y.coursePrefix);
            }
            else if (x.courseReference.CompareTo(y.courseReference) != 0)
            {
                return x.courseReference.CompareTo(y.courseReference);
            }
            else
            {
                throw new Exception("Course duplicate, Illegal state!");
            }
        }
    }
}
