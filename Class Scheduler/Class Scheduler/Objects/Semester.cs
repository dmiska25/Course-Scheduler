using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using static Class_Scheduler.Objects.Course;

namespace Class_Scheduler.Objects
{
    [Serializable()]
    public class Semester : ISerializable
    {
        //fields
        private int _year;
        private TermEnums _term;
        private HashSet<CourseContainer> _courses;
        private HashSet<CourseContainer> _overflowCourses;
        private bool _isOverloadable;
        private int _maxCredits;
        private int _minCredits;
        private int _currentCreditsTotal;

        //properties
        public int Year { get { return _year; } }
        public TermEnums Term { get { return _term; } }
        public HashSet<CourseContainer> Courses { get { return new HashSet<CourseContainer>(_courses.Union(_overflowCourses)); } }
        public HashSet<CourseContainer> OverflowCourses { get { return new HashSet<CourseContainer>(_overflowCourses); } }
        public bool IsOverloadable { get => _isOverloadable; set { _isOverloadable = value; } }
        public String SemesterReference { get { return Year.ToString() + ' ' + Term.ToString(); } }
        public int MaxCredits { get { return _maxCredits; } set { _maxCredits = value; } }
        public int MinCredits { get { return _minCredits; } set { _minCredits = value; } }
        public int TotalCredits { get { return _currentCreditsTotal; } }
        public int SemesterWeight
        {
            get
            {
                int semWeight = 0;
                foreach(CourseContainer course in Courses)
                {
                    semWeight += course.Course.CourseWeight;
                }
                return semWeight;
            }
        }

        //constructors
        public Semester(int year, TermEnums term)
        {
            _year = year;
            _term = term;
            _courses = new HashSet<CourseContainer>();
            _overflowCourses = new HashSet<CourseContainer>();
            _isOverloadable = true;
            _minCredits = 12;
            _maxCredits = 15;
        }

        //methods
        /// <summary>
        /// addCourse adds the selected course reference to the list. Throws an exception if total credits exceeds
        /// maximum.
        /// </summary>
        /// <param name="course"></param>
        public void addCourse(CourseContainer course)
        {
            // check course
            if (!adableCourse(course))
                throw new Exception("Course requirements have not been met! Cannot add course!");
            
            _courses.Add(course);
            _currentCreditsTotal += course.Course.credits;
        }


        public void addOverflowCourse(CourseContainer course)
        {
            if (_overflowCourses.Count > 0)
                throw new Exception("Overflow capacity exceeded!");
            else if (!_isOverloadable)
                throw new Exception("Overflow is not allowed for this semester!");

            _overflowCourses.Add(course);
            _currentCreditsTotal += course.Course.credits;
        }

        /// <summary>
        /// Check to ensure requirements are met to add the selected course.
        /// </summary>
        /// <param name="course"></param>
        /// <returns></returns>
        public bool adableCourse(CourseContainer course)
        {
            // check credits count
            if (_currentCreditsTotal + course.Course.credits > MaxCredits)
                return false;

            // check term
            if (!course.Course.validTerms.Contains(Term))
                return false;

            // Get course details
            CourseDetails details = course.Course.courseDetails;
            int yearRemainder;

            // check year multiple
            if (details.YearBase.HasValue)
            {
                yearRemainder = Year - details.YearBase.Value;
                if (yearRemainder % details.YearMultiple != 0)
                    return false;
            }

            return true;
        }







        /// <summary>
        /// removeCourse will accept a course reference and determine if the course is in the listing
        /// if so, it will remove the course from the semester internal list and return true.
        /// if it is not contained in the list, it will return false.
        /// </summary>
        /// <param name="course"></param>
        /// <returns></returns>
        public bool removeCourse(CourseContainer course)
        {
            if (_courses.Contains(course))
            {
                _courses.Remove(course);
                _currentCreditsTotal -= course.Course.credits;
                return true;
            }
            else if(_overflowCourses.Contains(course))
            {
                _overflowCourses.Remove(course);
                _currentCreditsTotal -= course.Course.credits;
                return true;
            }
            return false;
        }

        /// <summary>
        /// remove all courses in both courses list and overflow lists.
        /// </summary>
        public void removeAllCourses()
        {
            _courses.Clear();
            _overflowCourses.Clear();
            _currentCreditsTotal = 0;
        }

        /// <summary>
        /// Get a empty copy of the given semester object.
        /// </summary>
        /// <param name="origSem"></param>
        /// <returns></returns>
        public static Semester copySemester(Semester origSem)
        {
            Semester newSemester = new Semester(origSem.Year, origSem.Term);
            newSemester.MaxCredits = origSem.MaxCredits;
            newSemester.MinCredits = origSem.MinCredits;
            newSemester.IsOverloadable = origSem.IsOverloadable;

            return newSemester;
        }


        public override bool Equals(object obj)
        {
            //verify object type
            if(!(obj is Semester)) { return false; }
            Semester sem = (Semester)obj;

            if(this.SemesterReference.Equals(sem.SemesterReference)) { return true; }
            return false;
        }

        //toString
        public override string ToString()
        {
            String returnString = "";
            returnString += _year + " " + _term + "\nCourse Listing:";
            foreach(CourseContainer course in Courses)
            {
                returnString += "\n--" + course.Course.ToString();
            }
            return returnString;
        }

        // Defining serialization for saving Semester objects to data file
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Year", _year);
            info.AddValue("Term", _term);
            info.AddValue("MaxCredits", _maxCredits);
            info.AddValue("MinCredits", _minCredits);
            info.AddValue("IsOverloadable", _isOverloadable);
        }

        public Semester(SerializationInfo info, StreamingContext context)
        {
            _year = info.GetInt32("Year");
            _term = (TermEnums)info.GetValue("Term", typeof(TermEnums));
            _courses = new HashSet<CourseContainer>();
            _overflowCourses = new HashSet<CourseContainer>();
            _maxCredits = info.GetInt32("MaxCredits");
            _minCredits = info.GetInt32("MinCredits");
            _isOverloadable = info.GetBoolean("IsOverloadable");
        }
    }
}
