using Class_Scheduler.Comparers;
using Class_Scheduler.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Scheduler.StaticClasses
{
    public static class ScheduleOptimizer
    {

        public static void checkOverflow(List<Semester> semesterList)
        {
            Console.WriteLine("Begining Optimization algorithm");

            //ensure order of semesters
            SortedList<Semester, Semester> sortedSemesterList = new SortedList<Semester, Semester>(new SemesterCompare());
            foreach(Semester semester in semesterList)
            {
                sortedSemesterList.Add(semester, semester);
            }


            //find final semester
            bool found = false;
            int counter = sortedSemesterList.Values.Count-1;
            Semester finalSemester;
            while(true)
            {
                //if semester has zero credits, keep searching
                if (sortedSemesterList.Values[counter].TotalCredits == 0)
                {
                    counter--;
                    continue;
                }
                //if a semester is found that is not equal to zero, this is the final semester
                else if (sortedSemesterList.Values[counter].TotalCredits != 0)
                {
                    finalSemester = sortedSemesterList.Values[counter];
                    break;
                }
                //if reach 0, final semester is the last semester(only possible with empty semesters!)
                else if (counter == 0)
                {
                    finalSemester = sortedSemesterList.Values[sortedSemesterList.Values.Count - 1];
                }
                else
                    throw new Exception("Error while attempting to find final semester in sortedSemesterList!");
            }

            Console.WriteLine("Phase 1: Pass");


            // attempt to push courses back via overflow to shorten graduation time
            // if fail, will revert all overflow. only used if successfully shortens
            // graduation time.
            bool failed = false;
            while (!failed)
            {
                // find first semester that contains dependency for every course in final semester
                // and add the course and the semester to a dicitionary.
                Dictionary<CourseContainer, Semester> moveTo = new Dictionary<CourseContainer, Semester>();
                foreach (CourseContainer course in finalSemester.Courses)
                {
                    //if the course contains no dependents, set its first dependency to the first semester
                    if(course.Dependents.Count == 0 && course.Copendents.Count == 0)
                    {
                        moveTo.Add(course, sortedSemesterList.Values[0]);
                        continue;
                    }


                    //begin looking through each semester to find a semester that contains a dependenet of the course
                    found = false;
                    counter = sortedSemesterList.Values.IndexOf(finalSemester) - 1;
                    while (!found && 0 < counter)
                    {
                        //look through every dependent for the given course in the given semester and determine if it contains a course dependent.
                        bool SemContainsPendent = false;
                        foreach (CourseContainer dependentCheck in course.Dependents.Union(course.Copendents))
                        {
                            if (sortedSemesterList.Values[counter].Courses.Contains(dependentCheck))
                            {
                                SemContainsPendent = true;
                                break;
                            }
                        }
                        if (SemContainsPendent)
                        {
                            moveTo.Add(course, sortedSemesterList.Values[counter + 1]);
                            break;
                        }

                        //reduce counter by 1
                        counter--;
                    }

                }

                Console.WriteLine("Phase 2: Pass");



                //check to ensure all courses from final semester can be
                //moved back, else failure

                //-order the courses by their reference semester index
                SortedList<int, CourseContainer> sortedCourses = 
                    new SortedList<int, CourseContainer>(new CourseIntCompare());
                foreach(CourseContainer course in finalSemester.Courses)
                {
                    Semester semester;
                    moveTo.TryGetValue(course, out semester);
                    int index = sortedSemesterList.Values.IndexOf(semester);
                    sortedCourses.Add(index, course);
                }

                Console.WriteLine("Phase 3: Pass");

                //-ensure sufficient overflow space for every course
                HashSet<Semester> scheduledToMove = new HashSet<Semester>();
                Semester startingSemester;
                int minimumIndex = 0;
                for(int i=0;i<finalSemester.Courses.Count;i++)
                {
                    //ensure the course can be added to its respective semester,
                    //if not, move it forward until sufficient
                    int index = sortedCourses.Keys[i];
                    startingSemester = sortedSemesterList.Values[index];
                    bool validToPlace = false;
                    while(!validToPlace && !sortedSemesterList.Values[index].Equals(finalSemester))
                    {
                        if(sortedSemesterList.Values[index].IsOverloadable &&
                            sortedSemesterList.Values[index].OverflowCourses.Count==0 &&
                            minimumIndex<=index &&
                            !scheduledToMove.Contains(sortedSemesterList.Values[index]))
                        {
                            validToPlace = true;
                            scheduledToMove.Add(sortedSemesterList.Values[index]);
                        }  
                        else
                        {
                            moveTo[sortedCourses.Values[i]] = sortedSemesterList.Values[++index];
                            minimumIndex = Math.Max(minimumIndex, index);
                        }
                    }
                    if(sortedSemesterList.Values[index].Equals(finalSemester))
                    {
                        failed = true;
                        break;
                    }




                    //count number of valid overflow semesters including
                    //the semester the course should be moved to.
                    int validOverflowSemesters = 0;
                    for(int j=index;j<sortedSemesterList.Values.IndexOf(finalSemester)-1;j++)
                    {
                        if (sortedSemesterList.Values[j].IsOverloadable &&
                            sortedSemesterList.Values[j].OverflowCourses.Count == 0 &&
                            !scheduledToMove.Contains(sortedSemesterList.Values[j]))
                            validOverflowSemesters++;
                    }
                    // check to ensure sufficient space
                    if(finalSemester.Courses.Count-i > validOverflowSemesters)
                    {
                        failed = true;
                        break;
                    }

                }

                Console.WriteLine("Phase 4: Pass");

                if (failed)
                    break;

                //if no failure, move courses back
                Console.WriteLine("overflow attempt results: ");
                for(int i=0;i<moveTo.Values.Count;i++)
                {
                    Semester moveToSemester;
                    moveTo.TryGetValue(sortedCourses.Values[i], out moveToSemester);

                    //debug
                    Console.WriteLine("Moving " + sortedCourses.Values[i].ToString() + " to "
                        + moveToSemester.ToString());

                    //move the course
                    finalSemester.removeCourse(sortedCourses.Values[i]);
                    moveToSemester.addOverflowCourse(sortedCourses.Values[i]);
                }




                //move final semester back one
                finalSemester = 
                    sortedSemesterList.Values[sortedSemesterList.Values.IndexOf(finalSemester) - 1];

            }













        }
    }
}
