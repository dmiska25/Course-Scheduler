using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Class_Scheduler.Objects
{
    /// <summary>
    /// The Course Container class is used to contain information about the class that is relevent during
    /// the scheduling process. It has access to the relevent course information and retains a priority value
    /// to prioritize its scheduling. It also contains not only a hashset of the courses dependents but also
    /// dependees to help minimize computation.
    /// </summary>
    public class CourseContainer : IComparable<CourseContainer>
    {
        // fields
        private Course _course;
        private int _dependeeCount;
        private int? _dependeeDepth;
        private HashSet<CourseContainer> _dependees;
        private HashSet<CourseContainer> _dependents;
        private HashSet<CourseContainer> _copendents;
        private HashSet<CourseContainer> _copendees;

        // properties
        public Course Course { get { return _course; } }
        public int TotalPendees { get { return _dependeeCount; } set { _dependeeCount = value; } }
        public HashSet<CourseContainer> Dependees { get { return _dependees; } }
        public HashSet<CourseContainer> Dependents { get { return _dependents; } }
        public HashSet<CourseContainer> Copendents { get { return _copendents; } }
        public HashSet<CourseContainer> Copendees { get { return _copendees; } }
        public int? PendeeDepth { get { return _dependeeDepth; } set { _dependeeDepth = value; } }

        //Constructors
        public CourseContainer(Course course)
        {
            _course = course;
            _dependeeCount = 0;
            _dependees = new HashSet<CourseContainer>();
            _dependents = new HashSet<CourseContainer>();
            _copendents = new HashSet<CourseContainer>();
            _copendees = new HashSet<CourseContainer>();
        }

        // methods
        public HashSet<CourseContainer> getCoursePendencyList()
        {
            // retrieve all the course dependencies recursivly
            HashSet<CourseContainer> depenList = new HashSet<CourseContainer>();
            getCoursePendencyListRecurse(depenList, this);
            return depenList;
        } 

        private static void getCoursePendencyListRecurse
            (HashSet<CourseContainer> allDependentsList, CourseContainer course)
        {
            // skip if course is already in list
            if (allDependentsList.Contains(course)) return;

            // add this course to list
            allDependentsList.Add(course);

            // recurse for every dependency
            foreach(CourseContainer dependent in course.Dependents)
            {
                getCoursePendencyListRecurse(allDependentsList, dependent);
            }

            // recurse for every copendency
            foreach(CourseContainer copendent in course.Copendents)
            {
                getCoursePendencyListRecurse(allDependentsList, copendent);
            }
        }

        public HashSet<CourseContainer> getAllCourseDependeeList()
        {
            // retrieve all the course dependees recursivly
            HashSet<CourseContainer> dependeeList = new HashSet<CourseContainer>();
            getAllCourseDependeeListRecurse(dependeeList, this);
            return dependeeList;
        }

        private static void getAllCourseDependeeListRecurse
            (HashSet<CourseContainer> allDependeeList, CourseContainer course)
        {
            // skip if course is already in list
            if (allDependeeList.Contains(course)) return;

            // add this course to list
            allDependeeList.Add(course);

            // recurse for ever dependee
            foreach(CourseContainer dependee in course.Dependees)
            {
                getAllCourseDependeeListRecurse(allDependeeList, dependee);
            }

            // recurse for every copendee
            foreach(CourseContainer copendee in course.Copendees)
            {
                getAllCourseDependeeListRecurse(allDependeeList, copendee);
            }
        }

        //tostring
        public override string ToString()
        {
            String dependents = "";
            String dependees = "";
            String copendents = "";

            foreach (CourseContainer dependent in _dependents) { dependents += dependent._course.courseReference + ','; }
            dependents = dependents.Trim(',');
            foreach (CourseContainer dependee in _dependees) { dependees += dependee._course.courseReference + ','; }
            dependees = dependees.Trim(',');
            foreach (CourseContainer copendent in _copendents) { copendents += copendent._course.courseReference + ','; }
            copendents = copendents.Trim(',');

            return "<" + _course.ToString() + ">" + "Total Dependees:" + _dependeeCount +
                " Dependents: (" + dependents + ") Dependees: (" + dependees +
                ") Copendents: (" + copendents + ")";
        }


        //default compare methods
        public int CompareTo(CourseContainer other)
        {
            //compare the course container

            //handle uncalculated dependee depth
            if (this.PendeeDepth == null || other.PendeeDepth == null)
                throw new Exception("Uncalculated dependee depth!");

            //begin compare (Dependee Depth > Valid Terms > Total Dependees
            if (this.PendeeDepth.Value.CompareTo(other.PendeeDepth.Value) != 0)
                return -this.PendeeDepth.Value.CompareTo(other.PendeeDepth.Value);
            else if (compareTerms(other) != 0)
                return compareTerms(other);
            else if (this.TotalPendees.CompareTo(other.TotalPendees) != 0)
                return -this.TotalPendees.CompareTo(other.TotalPendees);

            // if graduate class, delay
            else if (this.Course.courseDetails.GraduateLevel.
                CompareTo(other.Course.courseDetails.GraduateLevel) != 0)
                return this.Course.courseDetails.GraduateLevel
                    .CompareTo(other.Course.courseDetails.GraduateLevel);


            else
                //if they are truly equivelent, give way to other course
                return 1;

        }

        private int compareTerms(CourseContainer otherCourse)
        {
            switch (this.Course.validTerms.Count) 
            {
                case 3:
                    switch (otherCourse.Course.validTerms.Count)
                    {
                        case 3:
                            return 0;
                        case 2:
                            return 1;
                        case 1:
                            return 1;
                    }
                    break;
                case 2:
                    switch (otherCourse.Course.validTerms.Count)
                    {
                        case 3:
                            return -1;
                        case 2:
                            if (this.Course.validTerms.Contains(TermEnums.SUMMER) &&
                                otherCourse.Course.validTerms.Contains(TermEnums.SUMMER))
                                return 0;
                            else if (!this.Course.validTerms.Contains(TermEnums.SUMMER) &&
                                !otherCourse.Course.validTerms.Contains(TermEnums.SUMMER))
                                return 0;
                            else
                            {
                                if (this.Course.validTerms.Contains(TermEnums.SUMMER))
                                    return -1;
                                else
                                    return 1;
                            }
                        case 1:
                            return 1;
                    }
                    break;
                case 1:
                    switch (otherCourse.Course.validTerms.Count)
                    {
                        case 3:
                            return -1;
                        case 2:
                            return -1;
                        case 1:
                            return 0;
                    }
                    break;
            }
            throw new Exception("Term violation!");
        }
    }
}
