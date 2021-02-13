# Course Scheduler

Course schedule is a c# utility used to schedule college curriculums over the course of several years. It has an array of features that can help estimate
a time table for graduation well in advance. This could be useful in a wide variety of situations such as when changing majors, transfering credits from
high school, estimating the viability of adding majors/minors, or any instance when a curiculum will diverge from a standard track. It takes into account
a variety of course requirements such as course prerequisites, standing requirements, or offered semesters. This can be valuable to get an accurate
estimate of when a student can expect to graduate within the constraints from the various courses and program standards.

## Installation

The program is a C# executable. It can be placed in any folder and stored with Course/Semester lists.

## Usage

### Overview

The Program is made up of several panels including the toolbar, the course list, the semester list, and the options pane. When the 'Generate' button at
the bottom right is pressed the program will attempt to fit the courses in the Course List to the Semesters in the Semester List given the parameters
selected in the Options pane. Users can interact with the list views in several ways including Adding, Removing, Loading, Saving, or Auto Generating 
items. 

### Adding Courses

Users can add courses to the Course list via the toolbar 'Add... -> Course'. This is the primary function to add courses from a given college program 
to the course list in order to be scheduled. The add form is made up of several attributes such as 'Course Name', 'Course Prefix', 'Course ID', ect. These
make up the characteristics of each course. Information about each attribute can be found by hovering over items on the form. The form also contains
another area accessed via the 'Advanced Details' button. This is an area to set less common attributes for a course such as course constraints or 
defining the type of course. 

### Adding Semesters

Users can add semesters to the Semester list via the toolbar 'Add... -> Semester'. This is the primary function to add semesters to the semester list.
The semester list defines which semesters the user would like courses to be added to. The add form is made up of several attributes such as 'Year',
'Term', ect. More information can be found on each attribute via tooltips. These attributes help define what courses can be added to which semester.

### Course Options Menu

Users can right click a course or semester element to access a set of options including Viewing, Editing, Removing; Courses can also be set as
completed/uncompleted. 
- Viewing an element will open a view window showing the attributed specified for the given element.
- Editing will open a editing window that allows for the modifying of a course/semester's attributes.
- Removing will remove a course/semester from the list. If the selected course is depended on by other courses a warning will be displayed.
- Marking Completed/Uncompleted for a course will mark a course respectivly. If a course is marked as completed, it will not be scheduled, but instead, will
  marked in a pre list that allows furthur courses to be added to the course list.

### Loading/Saving

Course and Semester Listings can be loaded and saved to files via the toolbar 'Save...' and 'Load...' options. Saving will open a dialog to save the
respective list to a local location while loading will do the reverse. Note that loading will override any items already in the respective list.
Loading/Saving Semesters will not contain previously scheduled information. This is only accessible from the results view.

### Auto Generating items

The 'Generate...' option on the toolbar allows users to generate a collection of semesters or electives that can be added to their respective lists.
The 'Autogen Semesters' form allows users to specify attributes simmilar to the 'Add Semester' form. It will generate a incremental list of semesters
starting with a given year/term. ie. generating 3 semesters starting at 2021 fall will result in adding 3 semesters including (2021 fall, 2022 spring,
2022 summer). The 'Autogen Electives' form allows users to specify attributes simmilar to the 'Add Course' form. However, this is a truncated version
that allows consecutive generation of general or major elective placeholders. ie. generating 3 general electives will generate (GENR 101, GENR 102, 
GENR 103) These will represent general courses that the student may not have decided on yet.

### Options Pane

The 'options pane' allows users to select a variety of preferences for the scheduling algorithm. These options are not gurenteed to be applied as the
algorithm will place graduation time at a higher weight, however, they will be applied as a preference afterwards. These options are as follows:
-'Dalay Graduate Level Courses': This option will put a preference on moving graduate courses furthur down in a combined curriculum of gruaduate and
  undergraduate studies.
-'Prioritize Prefixes': This option will allow for courses with specific prefixes to be scheduled before others. i.e. if 'Math' Prefix is prioritized
  (MATH 166 will be scheduled before CHEM 101) All other constraints considered equal.
-'Prioritize Lower Level Courses': This option will allow for courses with lower level courses id's to be scheduled first. i.e. (MATH 165 Will be 
  scheduled before MATH 311) Assuming all other constraqints considered equal.
-'Prioritize Lab Pair Grouping': The option will  allow for courses that have been labeled as lab pairs (CHEM 101 and CHEM 101L) to be scheduled 
  together in the same semester. If overloading is enabled for the given semester this will also the algorithm to push the lab to the semester even
  when the given semester is at max credit limit.
-'Enable Semester Overloading': This option will allow a seperate optimization algorithm to attempt to push courses back from the final scheduled
  semester. i.e. if the final scheduled semester contains (GENR 101 and GENR 102) these courses will be moved to earlier semesters that are already
  at max credit limit attempting to allow for a faster graduation. WARNING: This option will overload specified semester credit limits. This could
  result in a overworked schedule.

### Generating Schedules

The Generate option at the bottom right of the screen will initiate the scheduling algorithm. The algorithm will attempt to fit the given courses
list to the given Semester List. If it is not possible to fit all of the courses to the given Semester List an error will be displayed specifying
so. If successful, a results view pane will be opened displaying the generated schedule. The form is organized by semester, expanding a semester
tab will display the scheduled courses retaining to the semester. 

### Scheduling Algorithm Notes

The Scheduling Algorithm works via a recursive approach to schedule the courses to optimize for graduation time. It will take all constraints into
account and schedule acordingly. The prioritization works as follows: Course Dependee Depth > Respective Terms > Dependee Count > Options Pane.
- Course Dependee depth is a depiction of how deep the dependence tree for a given course is. This means if a scheduling order for a math course is
  MATH 165 -> MATH 166 -> MATH 265 -> MATH 266 the dependee depth for MATH 165 is 3 because a minimum of 3 semesters will need to be scheduled after
  MATH 165 is scheduled.
- Respective Terms is the number of valid terms a course has. i.e. If MATH 165 can be scheduled durring fall, spring, or summer it will be considered
  a lower priority than say CHEM 330 that can only be scheduled durring fall.
- Course Dependee Count is the number of dependees that will be scheduled after the given course. This is symilar to Dependee depth but slightly
  different because it is the total amount of dependees instead of only the depth. i.e. if MATH 165 has a  scheduling order of MATH 165 -> MATH 166
  and CSCI 160 has a scheduling order of CSCI 160 -> CSCI 161 and CSCI 160 -> CSCI 222; Both CSCI 160 and MATH 165 will have the same dependee
  depth. However, CSCI 160 will have a Dependee count of 2 while MATH 165 will have a dependee count of 1 placing it at a lower priority.
  

## Future Efforts

The project is primarly functional. It will schedule courses in an optimal order to allow graduation in a timly manner. The project is feature complete
but current commits are being given to the optimazation algorithm to allow balancing of a schedule based on course load instead of credit count. In other words
The program will schedule courses that allows for the fastest graduation possible but does not consider course difficulty. The optimization algoithm
should take this into account and correct for it while retaining the fastest graduation possible.
