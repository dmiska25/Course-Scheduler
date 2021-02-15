using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Scheduler.Tooltips
{
    public static class MainTooltips
    {
        // tool strip
        public static string addSemesterTT = "Add a new semester to Semester List.";
        public static string addCourseTT = "Add a new course to Course List.";
        public static string saveCourseListTT = "Save current Course List to a file.";
        public static string saveSemesterListTT = "Save current Semester List to a file.";
        public static string loadCourseListTT = "Load a Course Listing into Course List from a file.\n" +
                                                    "Warning: This will override Course List's current content!";
        public static string loadSemesterListTT = "Load a Semester collection into Semester List from a file.\n" +
                                                    "Warning: This will override Semester List's current content!";
        public static string generatSemestersTT = "Generate a sequence of semesters in order from a starting year and term.";
        public static string generateElectiveTT = "Generate a sequence of either general or major elective placeholder courses.";


        // Options pane
        public static string delayGradTT = "This will place higher priority to undergraduate level courses as oposed to graduate.";
        public static string prioritizePrefixes = "This will place higher priority to courses with a specific prefix such as CSCI\n" +
            "The order of this prioritization can be modified in priorities window.";
        public static string prioritizeLowerLevelTT = "This will prioritize courses with course ids of lower values ie 101 > 102";
        public static string prioritizeLabPairTT = "This will prioritize a lab pair such as CHEM 101L with CHEM 101";
        public static string overloadableTT = "Enabling Overloading will attempt to push up to one course into each semester\n" +
                "going beyond the set maximum credits set for the semester. This will occur post\n" +
                "schedule creation and can serve to balance the schedule if many simpler courses\n" +
                "have been added to the end of the curiculum. Only valid for overloadable semesters.\n";
        public static string generateTT = "Attempt to schedule Courses in given semesters.";






    }
}
