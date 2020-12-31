using Class_Scheduler.Comparers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Class_Scheduler.Objects.Course;

namespace Class_Scheduler.Objects
{
    /// <summary>
    /// The Schedule Generator static class takes a list of Semesters and Courses to create
    /// the optimal schedule based on time of graduation.
    /// </summary>
    public static class ScheduleGenerator
    {
        /// <summary>
        /// coursePriority takes in a course list and attempts to prioritise the courses based on dependencies.
        /// It returns a HashSet of prioritised CourseContainer objects that wrap around the course objects.
        /// </summary>
        /// <param name="coursesIn"></param>
        /// <returns></returns>
        public static HashSet<CourseContainer> genCourseContainers(List<Course> coursesIn)
        {
            //define variables
            HashSet<Course> courses = new HashSet<Course>(coursesIn);
            HashSet<CourseContainer> processedContainers = new HashSet<CourseContainer>();
            Dictionary<Course, CourseContainer> courseLookup = new Dictionary<Course, CourseContainer>();

            // repeatedly look through remaining courses finding the dependencies that have been processed
            // each time adding the course as an dependee
            Boolean skip;
            while (courses.Count != 0)
            {
                foreach (Course course in courses.ToList())
                {
                    //verify each pendent has been processed
                    skip = false;
                    foreach (Course dependent in course.dependencies)
                    {
                        if (!courseLookup.ContainsKey(dependent))
                        {
                            skip = true;
                            continue;
                        } 
                    }
                    // skip course if pendents have not been processed yet
                    if (skip) { continue; }
                    foreach (Course copendent in course.copendencies)
                    {
                        if (!courseLookup.ContainsKey(copendent))
                        {
                            skip = true;
                            continue;
                        }                     
                    }
                    // skip course if pendents have not been processed yet
                    if (skip) { continue; }


                    //skip after inintial code if course has no pendents
                    if (course.dependencies.Count == 0 && course.copendencies.Count == 0) 
                        { skip = true; } else { skip = false; }

                    //create the course container
                    CourseContainer courseCon = new CourseContainer(course);
                    //move independent courses to processed
                    processedContainers.Add(courseCon);
                    courses.Remove(course);

                    //attempt to add the course to the dictionary
                    if (!courseLookup.ContainsKey(course))
                    {
                        courseLookup.Add(course, courseCon);
                    }

                    if (skip) { continue; }

                    //add course as a de/co pendee to dependent coursecontainers and add de/co pendents to coursecontainer
                    foreach (Course dependent in course.dependencies)
                    {
                        //get Container of dependent
                        CourseContainer dependentCon;
                        courseLookup.TryGetValue(dependent, out dependentCon);
                        //add dependee
                        if (dependentCon != null) { dependentCon.Dependees.Add(courseCon); }
                        else { throw new Exception("Course dependent has not been added yet!"); }
                        //add dependent to course
                        courseCon.Dependents.Add(dependentCon);
                    }

                    foreach (Course copendent in course.copendencies)
                    {
                        //Get Container of copendent
                        CourseContainer copendentCon;
                        courseLookup.TryGetValue(copendent, out copendentCon);
                        //add copendee
                        if (copendentCon != null) { copendentCon.Copendees.Add(courseCon); }
                        else { throw new Exception("Course copendent has not been added yet!"); }
                        //add copendent to course
                        courseCon.Copendents.Add(copendentCon);
                    }
                }
            }


            //calculate course pendee TotalSize by recursion
            foreach (CourseContainer course in processedContainers)
            {
                calcTotalPendees(course);
            }

            //return the Course Container set
            return processedContainers;
        }



        public static bool scheduleSemesters(List<CourseContainer> courseList, List<Semester> semesters,
            Dictionary<Semester, List<Course>> manualAddDictIn, CustumCoursePriority priority,
            List<Course> previouslyCompletedCourses)
        {
            try
            {
                // variables
                List<CourseContainer> futureCourses = new List<CourseContainer>(courseList);
                List<CourseContainer> currentCourses = new List<CourseContainer>();
                SortedList<CourseContainer, CourseContainer> courseLineup =
                    new SortedList<CourseContainer, CourseContainer>(priority);
                HashSet<CourseContainer> scheduledCourses = new HashSet<CourseContainer>();
                HashSet<CourseContainer> dependeesToCheck = new HashSet<CourseContainer>();
                HashSet<CourseContainer> copendeesToCheck = new HashSet<CourseContainer>();
                Dictionary<Semester, List<CourseContainer>> manualAddDict =
                    new Dictionary<Semester, List<CourseContainer>>();
                

                //convert the dictionary, and remove all manual add courses from future courses
                foreach(Semester sem in manualAddDictIn.Keys)
                {
                    List<Course> semList = new List<Course>();
                    manualAddDictIn.TryGetValue(sem, out semList);
                    List<CourseContainer> output = new List<CourseContainer>();
                    foreach(Course course in semList)
                    {
                        CourseContainer courseCont = getCourseContainer(course, courseList);
                        output.Add(courseCont);
                        futureCourses.Remove(courseCont);
                    }
                    manualAddDict.Add(sem, output);
                }


                // remove all previously Completed Courses from future courses and move them to
                // scheduled courses list. Additionally check if the courses de/copendees can
                // be added.
                List<CourseContainer> temp = new List<CourseContainer>();
                foreach(CourseContainer course in futureCourses)
                {
                    if(previouslyCompletedCourses.Contains(course.Course))
                    {
                        temp.Add(course);
                        scheduledCourses.Add(course);

                        foreach (CourseContainer dependee in course.Dependees)
                            dependeesToCheck.Add(dependee);
                        foreach (CourseContainer copendee in course.Copendees)
                            copendeesToCheck.Add(copendee);
                    }
                }
                // remove courses from future courses (neccessary to avoid modifying collection)
                foreach (CourseContainer course in temp)
                    futureCourses.Remove(course);
                // set temp to null
                temp = null;



                // initialize by adding all courses that can be scheduled to current courses list
                // and ensuring the semester list is sorted.
                foreach (CourseContainer course in futureCourses.ToList())
                {
                    //debug: checking initial adding of courses
                    Console.WriteLine("Initial course add: " + course.Course.courseReference + ", " +
                        (course.Dependents.Count == 0 && course.Copendents.Count == 0));
                    if(course.Copendents.Count != 0)
                    {
                        Console.WriteLine(Course.CourseListString("Copendents: ", course.Copendents));
                    }

                    if (course.Dependents.Count == 0 && course.Copendents.Count == 0)
                    {
                        // add the course to the schedulable currentCourses list/remove from unschedulable
                        currentCourses.Add(course);
                        futureCourses.Remove(course);

                        foreach (CourseContainer copendee in course.Copendees)
                        {
                            copendeesToCheck.Add(copendee);
                        }
                    }
                }

                // not implemented: ensure sort of semester!

                //debug: print future Courses
                Console.WriteLine(Course.CourseListString("Future Courses: ", futureCourses));
                //debug: pring initial current courses
                Console.WriteLine(Course.CourseListString("Initial Current Courses: ", currentCourses));
                Console.WriteLine("-------------------------");

                // Main loop to schedule courses for each semester
                foreach (Semester semester in semesters)
                {
                    // check and add potentially schedulable courses from dependeesToCheck/copendeesToCheck
                    foreach (CourseContainer dependee in dependeesToCheck)
                    {
                        if (!futureCourses.Contains(dependee)) continue;
                        if (requirementsMet(dependee, scheduledCourses, currentCourses))
                        {
                            currentCourses.Add(dependee);
                            futureCourses.Remove(dependee);
                        }
                    }
                    // copendees are done seperate to allow for the possibility of a copendee depending on a dependee above
                    foreach (CourseContainer copendee in copendeesToCheck)
                    {
                        if (!futureCourses.Contains(copendee)) continue;
                        if (requirementsMet(copendee, scheduledCourses, currentCourses))
                        {
                            currentCourses.Add(copendee);
                            futureCourses.Remove(copendee);
                        }
                    }



                    //ensure there are remaining courses to schedule
                    if (currentCourses.Count == 0 && futureCourses.Count == 0) { break; }

                    //null all course current and future course dependee depths
                    foreach (CourseContainer course in currentCourses) { course.PendeeDepth = null; }
                    foreach (CourseContainer course in futureCourses) { course.PendeeDepth = null; }
                    //clear courseLineup
                    courseLineup.Clear();
                    // clear the check lists
                    dependeesToCheck.Clear();
                    copendeesToCheck.Clear();
                



                    //calculate each current course's pendee depth
                    foreach (CourseContainer course in currentCourses)
                    {
                        pendeeDepth(course, semester, semesters);
                    }

                    // Add valid current courses to courseLineup
                    // ie: Ensure the course coresponds to the correct term and year
                    foreach (CourseContainer course in currentCourses)
                    {
                        // Get course details
                        CourseDetails details = course.Course.courseDetails;
                        int yearRemainder;
                        bool valid = true;

                        // calculate year 
                        if (details.YearBase.HasValue)
                        {
                            yearRemainder = semester.Year - details.YearBase.Value;
                            if (yearRemainder % details.YearMultiple != 0)
                                valid = false;
                        }

                        if (course.Course.validTerms.Contains(semester.Term) && valid)
                        {
                            courseLineup.Add(course, course);
                        }
                    }

                    //debug: print semester reference
                    Console.WriteLine("Adding courses for " + semester.SemesterReference);

                    //debug: print current current courses
                    Console.WriteLine(Course.CourseListString("Current Courses: ", currentCourses));

                    //debug: print course lineup
                    System.Console.WriteLine(Course.CourseListString("pre add list: ", courseLineup.Values));

                    //get the manual add list for the semester
                    List<CourseContainer> semesterManualAdd = new List<CourseContainer>();

                    //get manual add list for the semester
                    manualAddDict.TryGetValue(semester, out semesterManualAdd);


                    // add manualy scheduled courses
                    while (semesterManualAdd.Count != 0)
                    {
                        CourseContainer course = semesterManualAdd[0];

                        semester.addCourse(course); //add the manual course
                        scheduledCourses.Add(course); // add course to list of scheduled courses
                        semesterManualAdd.RemoveAt(0); //remove the course from the manual add list

                        // add the courses dependees and their copendees to HashSets respectivly. This is done to check if these courses
                        // requirements are satisfied and such be added to currentCourses list.
                        foreach (CourseContainer dependee in course.Dependees)
                        {
                            dependeesToCheck.Add(dependee);     //add the dependee
                            foreach (CourseContainer copendee in dependee.Copendees)
                            {
                                copendeesToCheck.Add(copendee);     //add the copendee
                            }
                        }
                    }




                    // Attempt to add courses to the current semester
                    while (semester.TotalCredits < semester.MaxCredits && courseLineup.Count != 0)
                    {
                        CourseContainer course;

                        //get next course from upcoming courses
                        course = courseLineup.First().Value;

                        //if there are free credits in the semester add the next priority course
                        if (semester.TotalCredits + course.Course.credits <= semester.MaxCredits)
                        {
                            semester.addCourse(course);     // schedule course in current semester
                            scheduledCourses.Add(course);       // add course to list of scheduled courses
                            currentCourses.Remove(course);      // remove course from current Courses to schedule

                            // add the courses dependees and their copendees to HashSets respectivly. This is done to check if these courses
                            // requirements are satisfied and such be added to currentCourses list.
                            foreach (CourseContainer dependee in course.Dependees)
                            {
                                dependeesToCheck.Add(dependee);     //add the dependee
                                foreach (CourseContainer copendee in dependee.Copendees)
                                {
                                    copendeesToCheck.Add(copendee);     //add the copendee
                                }
                            }
                        }

                        //regardless, remove the course from the lineup
                        courseLineup.RemoveAt(0);
                    }


                    //debug: print course Lineup after
                    System.Console.WriteLine(Course.CourseListString("post add list: ", courseLineup.Values));
                    //debug: print scheduled courses
                    System.Console.WriteLine(Course.CourseListString("Semester courses: ", semester.Courses));

                    Console.WriteLine("-----------------------------------");
                }

                //check if all courses have been scheduled
                if (!(futureCourses.Count == 0 && currentCourses.Count == 0))
                {
                    //debug
                    Console.WriteLine(Course.CourseListString("Courses unable to be scheduled: ", futureCourses, currentCourses));
                    throw new Exception("Not Enough Semesters to schedule all courses!");
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }



        //helper methods

        private static int pendeeDepth(CourseContainer course, Semester startingSemester, List<Semester> semesters)
        {
            //variables
            List<int> depths = new List<int>();
            int? returnInt;

            // if course already has value, return value
            if (course.PendeeDepth != null) { return (int)course.PendeeDepth; }
          
            // if course has no dependees/codepedees it has no depth
            if (course.Dependees.Count == 0 && course.Copendees.Count == 0)
            {
                course.PendeeDepth = 0;
                return 0;
            }

            //  check if starting semester is a valid semester for the course, if not, pass to next semester
            if (!course.Course.validTerms.Contains(startingSemester.Term))
            {
                returnInt = pendeeDepth(course, nextSemester(startingSemester, semesters), semesters) + 1;
                course.PendeeDepth = returnInt;
                return (int)returnInt;
            }

            // if so, recurse each dependee/copendee and store their depths in list
            else
            {
                // recurse dependees
                foreach (CourseContainer dependee in course.Dependees)
                {
                    depths.Add(pendeeDepth(dependee, nextSemester(startingSemester, semesters), semesters));
                }
                // recurse copendees
                foreach (CourseContainer copendee in course.Copendees)
                {
                    depths.Add(pendeeDepth(copendee, startingSemester, semesters));
                }
            }

            returnInt = depths.Max()+1;
            course.PendeeDepth = returnInt;
            return (int)returnInt;
        }

        private static int calcTotalPendees(CourseContainer course)
        {
            //variables
            HashSet<CourseContainer> counted = new HashSet<CourseContainer>();  //used to prevent duplicate counts
            return calcTotalPendees(course, counted);
        }

        private static int calcTotalPendees(CourseContainer course, HashSet<CourseContainer> counted)
        {
            // return value if value already exists
            if (course.TotalPendees != 0)
            {
                return course.TotalPendees;
            }
            else if (counted.Contains(course))
            {
                return -1;
            }
            // return 0 if both are empty
            else if (course.Dependees.Count == 0 && course.Copendees.Count == 0)
            {
                counted.Add(course);
                return 0;
            }
            // else, recurse
            else
            {
                int count = 0;
                foreach (CourseContainer dependee in course.Dependees)
                {
                    count += calcTotalPendees(dependee, counted) + 1;
                }
                foreach (CourseContainer copendee in course.Copendees)
                {
                    count += calcTotalPendees(copendee, counted) + 1;
                }

                //set and return value
                course.TotalPendees = count;
                return count;
            }
        }

        private static Semester nextSemester(Semester startingSemester, List<Semester> semList)
        {
            // Warning!!! should also ensure semesters are sorted
            //return next semester
            try
            {
                return semList[semList.IndexOf(startingSemester) + 1];
            }
            catch (ArgumentOutOfRangeException ex)
            {
                throw new Exception("Reached end of semester list!!!");
            }
        }

        private static bool requirementsMet(CourseContainer course, IEnumerable<CourseContainer> scheduledCourses,
            IEnumerable<CourseContainer> currentCourses)
        {
            //check dependents
            foreach (CourseContainer dependent in course.Dependents)
            {
                if (!scheduledCourses.Contains(dependent))
                    return false;
            }

            // check copendents
            foreach (CourseContainer copendent in course.Copendents)
            {
                if (!scheduledCourses.Contains(copendent) && !currentCourses.Contains(copendent))
                    return false;
            }

            // check addtional details
            CourseDetails details = course.Course.courseDetails;

            // sum previously scheduled courses
            int total = 0;
            foreach (CourseContainer scheduledCourse in scheduledCourses)
            {
                total += scheduledCourse.Course.credits;
            }

            // check to ensure credit requirment or standing requirement
            if (details.CreditsRequired < total)
                return false;

            //if requrirements met, return true
            return true;
        }

        public static CourseContainer getCourseContainer(Course course, List<CourseContainer> containerList)
        {

            foreach (CourseContainer cont in containerList)
            {
                if (cont.Course.Equals(course))
                    return cont;
            }
            return null;

        }

    }
}
