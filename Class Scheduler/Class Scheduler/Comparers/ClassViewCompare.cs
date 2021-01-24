using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Scheduler.Objects
{
    class ClassViewCompare : Comparer<Course>
    {
        private readonly List<Course> _completedList;


        public ClassViewCompare(List<Course> completedList)
        {
            _completedList = completedList;
        }


        public override int Compare(Course x, Course y)
        {
            // if course has been completed, move to bottom of list
            if(_completedList.Contains(x) ^ _completedList.Contains(y))
                return _completedList.Contains(x).CompareTo(_completedList.Contains(y));

            // sort courses alphebeticaly by course prefix/reference
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
