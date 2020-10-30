using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Windows.Forms;

namespace Class_Scheduler.Objects
{
    //valid semesters
    public enum TermEnums { FALL, SPRING, SUMMER }

    [Serializable()]
    public partial class Course : ISerializable
    {
        //fields
        private String _courseName;
        private String _courseDescription;
        private CourseDetails _courseDetails;
        private String _coursePrefix;
        private int _courseID;
        private int _credits;
        private HashSet<TermEnums> _validTerms;
        private HashSet<Course> _dependencies;
        private HashSet<Course> _copendencies;

        //valid characters
        public static readonly HashSet<Char> validCharacters = new HashSet<Char>
        {'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R',
         'S','T','U','V','W','X','Y','Z','1','2','3','4','5','6','7','8','9','0',
         ',',':',' '};

        // properties
        public String courseName { get { return _courseName; } }
        public String courseDescription { get { return _courseDescription; } }
        public CourseDetails courseDetails { get { return _courseDetails; } }                       // should be read only!!!
        public String coursePrefix { get { return _coursePrefix; } }
        public int courseID { get { return _courseID; } }
        public int credits { get { return _credits; } }
        public HashSet<TermEnums> validTerms
        { 
            get
            {
                return new HashSet<TermEnums>(_validTerms);
            }
        }
        public HashSet<Course> dependencies
        { get { return _dependencies; } }
        public HashSet<Course> copendencies
        { get { return _copendencies; } }
        public String courseReference
        { get { return coursePrefix + ' ' + courseID; } }


        // Constructors
        private Course(CourseBuilder builder)
        {
            this._courseName = builder.CourseName;
            this._courseDescription = builder.CourseDescription;
            this._coursePrefix = builder.CoursePrefix;
            this._courseID = builder.CourseID;
            this._credits = builder.Credits;
            this._validTerms = new HashSet<TermEnums>();
            foreach(TermEnums term in builder.ValidTerms) { _validTerms.Add(term); }
            this._dependencies = new HashSet<Course>();
            foreach(Course dependent in builder.Dependencies) { _dependencies.Add(dependent); }
            this._copendencies = new HashSet<Course>();
            foreach(Course copendent in builder.Copendencies) { _copendencies.Add(copendent); }
            this._courseDetails = builder.CourseDetails;
        }


        //static methods
        public static Course GetCourseByRef(ICollection<Course> courses, String refString)
        {
            foreach (Course course in courses)
            {
                if (course.courseReference.Equals(refString))
                {
                    return course;
                }
            }
            return null;
        }

        public static Boolean ContainsCourseRef(ICollection<Course> courses, String refString)
        {
            Course course = GetCourseByRef(courses, refString);
            if (course == null)
            {
                return false;
            }
            return true;
        }

        public static String CourseListString(String prefix, params ICollection<CourseContainer>[] courseListings)
        {
            string output = prefix;

            foreach (ICollection<CourseContainer> courseListing in courseListings)
            {
                foreach (CourseContainer course in courseListing)
                {
                    output += course.Course.courseReference + '<' + course.PendeeDepth + '>' + ", ";
                }
            }
            output = output.TrimEnd(',');

            return output;
        }


        //properties
        public override bool Equals(object obj)
        {
            //verify object type
            if (!(obj is Course)) { return false; }

            //cast
            Course cou = (Course)obj;

            //check reference
            if (this.courseReference.Equals(cou.courseReference)) { return true; }

            return false;
        }

        public override string ToString()
        {
            return courseReference;
        }


        // Defining serialization for saving Course objects to data file
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Course Name", _courseName);
            info.AddValue("Course Description", _courseDescription);
            info.AddValue("Course Prefix", _coursePrefix);
            info.AddValue("Course ID", _courseID);
            info.AddValue("Credits", _credits);
            info.AddValue("Valid Terms", _validTerms);
            info.AddValue("Dependencies", _dependencies);
            info.AddValue("Copendencies", _copendencies);
            info.AddValue("Course Details", _courseDetails);
        }

        public Course(SerializationInfo info, StreamingContext context)
        {
            _courseName = info.GetString("Course Name");
            _courseDescription = info.GetString("Course Description");
            _coursePrefix = info.GetString("Course Prefix");
            _courseID = info.GetInt32("Course ID");
            _credits = info.GetInt32("Credits");
            _validTerms = (HashSet<TermEnums>)info.GetValue("Valid Terms", typeof(HashSet<TermEnums>));
            _dependencies = (HashSet<Course>)info.GetValue("Dependencies", typeof(HashSet<Course>));
            _copendencies = (HashSet<Course>)info.GetValue("Copendencies", typeof(HashSet<Course>));
            _courseDetails = (CourseDetails)info.GetValue("Course Details", typeof(CourseDetails));
        }

        // Course Builder
        public class CourseBuilder
        {
            //field
            private ICollection<Course> courseLibrary;
            private String _coursePrefix;
            private int _courseID;
            private int _credits;
            private HashSet<TermEnums> _validTerms = new HashSet<TermEnums>();
            private HashSet<Course> _dependencies = new HashSet<Course>();
            private HashSet<Course> _copendencies = new HashSet<Course>();

            //properties
            public string CourseName { get; set; }
            public string CourseDescription { get; set; }
            public string CoursePrefix { get => _coursePrefix; set => _coursePrefix = value.ToUpper(); }
            public int CourseID
            {
                get => _courseID;
                set
                {
                    if (value <= 0) throw new Exception("Course ID Cannot be less than 0!");
                    _courseID = value;
                }
            }
            public int Credits
            {
                get => _credits;
                set
                {
                    if (value <= 0 || value > 50) throw new Exception("Credits must be between 0 and 50!");
                    _credits = value;
                }
            }
            public ICollection<TermEnums> ValidTerms
            {
                get { return new ReadOnlyCollection<TermEnums>(_validTerms.ToList()); }
                set
                {
                    if (value.Count == 0) throw new Exception("Course must have at least one valid Term!");
                    _validTerms = new HashSet<TermEnums>();
                    foreach(TermEnums term in value.Distinct()) { _validTerms.Add(term); }
                }
            }
            public ICollection<Course> Dependencies
            {
                get { return new ReadOnlyCollection<Course>(_dependencies.ToList()); }
                set 
                {
                    _dependencies = new HashSet<Course>();
                    foreach(Course course in value) { this.addDependency(course); } 
                }
            }
            public ICollection<Course> Copendencies
            {
                get { return new ReadOnlyCollection<Course>(_copendencies.ToList()); }
                set 
                {
                    _copendencies = new HashSet<Course>();
                    foreach (Course course in value) { this.addCopendency(course); } 
                }
            }
            public CourseDetails CourseDetails { get; set; }

            //constructors
            public CourseBuilder(String courseName, String courseDescription, String _coursePrefix, int courseID,
                int credits, ICollection<Course> courseLibrary)
            {
                this.CourseName = courseName;
                this.CourseDescription = courseDescription;
                this.CoursePrefix = _coursePrefix;
                this.CourseID = courseID;
                this.Credits = credits;
                this.courseLibrary = courseLibrary;
            }

            public CourseBuilder(Course editCourse, ICollection<Course> courseLibrary)
            {
                // Assign course library
                this.courseLibrary = courseLibrary;

                //import values
                this.CourseName = editCourse.courseName;
                this.CourseDescription = editCourse.courseDescription;
                this.CoursePrefix = editCourse.coursePrefix;
                this.CourseID = editCourse.courseID;
                this.Credits = editCourse.credits;
                this.ValidTerms = editCourse.validTerms;
                this.Dependencies = editCourse.dependencies;
                this.Copendencies = editCourse.copendencies;
                this.CourseDetails = editCourse.courseDetails;
            }

            //other methods
            public void addDependency(Course course)
            {
                if (!courseLibrary.Contains(course)) throw new Exception("Course: "+course.courseReference+" not found in Library!");
                if (_copendencies.Contains(course)) throw new Exception("Course: " + course.courseReference + " cannot be" +
                    "both a copendency and dependency!");
                if (_dependencies.Contains(course)) return;
                _dependencies.Add(course);
            }
            public void removeDependency(Course course)
            {
                _dependencies.Remove(course);
            }

            public void addCopendency(Course course)
            {
                if (!courseLibrary.Contains(course)) throw new Exception("Course: " + course.courseReference + " not found in Library!");
                if (_dependencies.Contains(course)) throw new Exception("Course: " + course.courseReference + " cannot be" +
                    "both a copendency and dependency!");
                if (_copendencies.Contains(course)) return;
                _copendencies.Add(course);
            }
            public void removeCopendency(Course course)
            {
                _copendencies.Remove(course);
            }

            public Course build()
            {
                return new Course(this);
            }
        }

        // Construct course object from string input
        public class StringCourseBuilder
        {
            //underlying CourseBuilder object
            CourseBuilder builder;
            //pre-initalization variables
            private int _courseID;
            private int _credits;
            private ICollection<Course> _courseLibrary;


            //properties
            public string CourseName
            {
                get { return builder.CourseName; }
                set { builder.CourseName = value; }
            }
            public string CourseDescription
            {
                get { return builder.CourseDescription; }
                set { builder.CourseDescription = value; }
            }
            public string CoursePrefix
            {
                get { return builder.CoursePrefix; }
                set { builder.CoursePrefix = value; }
            }
            public string CourseID
            {
                get { return builder.CourseID.ToString(); }
                set
                {
                    if (!int.TryParse(value, out int input)) throw new Exception("Course ID must be a valid integer!");
                    if (builder != null)
                    {
                        builder.CourseID = input;
                    }
                    else
                    {
                        _courseID = input;
                    }
                }
            }
            public string Credits
            {
                get { return builder.Credits.ToString(); }
                set
                {
                    if (!int.TryParse(value, out int input)) throw new Exception("Credits must be a valid integer!");
                    if (builder != null)
                    {
                        builder.Credits = input;
                    }
                    else
                    {
                        _credits = input;
                    }
                }
            }
            public string ValidTerms
            {
                get { return builder.ValidTerms.ToString(); }
                set
                {
                    builder.ValidTerms = parseTerms(value);
                }
            }
            public string Dependencies
            {
                get { return builder.Dependencies.ToString(); }
                set
                {
                    builder.Dependencies = parsePendencies(value, _courseLibrary, "dependency");
                }
            }
            public string Copendencies
            {
                get { return builder.Copendencies.ToString(); }
                set
                {
                    builder.Copendencies = parsePendencies(value, _courseLibrary, "copendency");
                }
            }
            public CourseDetails CourseDetails 
            {
                get { return builder.CourseDetails; }
                set { builder.CourseDetails = value; }
            }

            //constructor
            public StringCourseBuilder(String courseName, String courseDescription, String coursePrefix, String courseID,
                String credits, ICollection<Course> courseLibrary)
            {
                // verify input and initalize course list
                this.CourseID = courseID;
                this.Credits = credits;
                this._courseLibrary = courseLibrary;

                //initialize underlying builder
                builder = new Course.CourseBuilder(courseName, courseDescription, coursePrefix, _courseID,
                    _credits, courseLibrary);
            }

            //build object
            public Course build()
            {
                return builder.build();
            }

            //helper methods

            private ICollection<Course> parsePendencies(String penString, ICollection<Course> courses, String pendencyType)
            {
                //variables
                List<Course> pendencies = new List<Course>();

                //remove characters from begining and end of string
                penString = penString.Trim(new char[] { ' ', ',', ':' });

                //if null, return empty list
                if (penString == "") { return pendencies; }

                //Capitalize letters
                penString = penString.ToUpper();

                //check valid characters
                foreach (Char character in penString)
                {
                    if (!validCharacters.Contains(character))
                    {
                        throw new Exception("Invalid input in "+pendencyType+" list! " + character);
                    }
                }

                //remove excess spaceing
                while (penString.Contains("  "))
                {
                    penString = penString.Replace("  ", " ");
                }

                //remove space between commas and collons
                penString = penString.Replace(", ", ",");
                penString = penString.Replace(" ,", ",");
                penString = penString.Replace(": ", ":");
                penString = penString.Replace(" :", ":");

                //check unexpected exceptions
                if (penString.Contains(",:") || penString.Contains(":,") ||
                    penString.Contains(",,") || penString.Contains("::"))
                {
                    throw new Exception("Invalid input in " + pendencyType + " list!");
                }

                //split list into course references
                List<string> depenList = penString.Split(',').ToList();
                foreach (String courseRef in depenList)
                {
                    //courses.Contains(GetCourseByRef(courseRef))


                    //verify that dependencies are valid
                    if (!Course.ContainsCourseRef(courses, courseRef))
                    {
                        throw new Exception("The following course " + pendencyType + " was not found: " + courseRef);
                    }
                    else
                    {
                        pendencies.Add(Course.GetCourseByRef(courses, courseRef));
                    }
                }

                return pendencies;
            }

            private ICollection<TermEnums> parseTerms(String semString)
            {
                //variables
                List<TermEnums> valSemList = new List<TermEnums>();

                //remove characters from begining and end of string
                semString = semString.Trim(new char[] { ' ', ',', ':' });

                //if null, return empty list
                if (semString == "") { return valSemList; }

                //Capitalize letters
                semString = semString.ToUpper();

                //check valid characters
                foreach (Char character in semString)
                {
                    if (!validCharacters.Contains(character) || character == ':')
                    {
                        throw new Exception("Invalid input in valid Terms list! " + character);
                    }
                }

                //remove excess spaceing
                while (semString.Contains("  "))
                {
                    semString = semString.Replace("  ", " ");
                }

                //remove space between commas and collons
                semString = semString.Replace(", ", ",");
                semString = semString.Replace(" ,", ",");

                //check unexpected exceptions
                if (semString.Contains(",,"))
                {
                    throw new Exception("Invalid input in valid Terms list!");
                }

                //split list into semester references
                List<string> semList = semString.Split(',').ToList();
                foreach (String term in semList)
                {
                    //verify that semesters are valid
                    switch (term)
                    {
                        case "FALL":
                            valSemList.Add(TermEnums.FALL);
                            break;
                        case "SPRING":
                            valSemList.Add(TermEnums.SPRING);
                            break;
                        case "SUMMER":
                            valSemList.Add(TermEnums.SUMMER);
                            break;
                        default:
                            throw new Exception(term + " is not a valid term!");
                    }
                }

                return valSemList;
            }
        }
    }
}
