using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Class_Scheduler.Objects
{
    [Serializable()]
    public class Semester : ISerializable
    {
        //fields
        private int _year;
        private TermEnums _term;
        private HashSet<CourseContainer> _courses;
        private int _maxCredits;
        private int _minCredits;
        private int _currentCreditsTotal;

        //properties
        public int Year { get { return _year; } }
        public TermEnums Term { get { return _term; } }
        public HashSet<CourseContainer> Courses { get { return new HashSet<CourseContainer>(_courses); } }
        public String SemesterReference { get { return Year.ToString() + ' ' + Term.ToString(); } }
        public int MaxCredits { get { return _maxCredits; } set { _maxCredits = value; } }
        public int MinCredits { get { return _minCredits; } set { _minCredits = value; } }
        public int TotalCredits { get { return _currentCreditsTotal; } }

        //constructors
        public Semester(int year, TermEnums term)
        {
            _year = year;
            _term = term;
            _courses = new HashSet<CourseContainer>();
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
            if (_currentCreditsTotal + course.Course.credits > MaxCredits) 
            { throw new Exception("Max credits exceaded!"); }
            
            _courses.Add(course);
            _currentCreditsTotal += course.Course.credits;
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
            return false;
        }

        public void removeAllCourses()
        {
            _courses.Clear();
            _currentCreditsTotal = 0;
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
        }

        public Semester(SerializationInfo info, StreamingContext context)
        {
            _year = info.GetInt32("Year");
            _term = (TermEnums)info.GetValue("Term", typeof(TermEnums));
            _courses = new HashSet<CourseContainer>();
            _maxCredits = info.GetInt32("MaxCredits");
            _minCredits = info.GetInt32("MinCredits");
        }
    }
}
