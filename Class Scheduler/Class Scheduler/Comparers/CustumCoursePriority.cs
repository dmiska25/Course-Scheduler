﻿using Class_Scheduler.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Scheduler.Comparers
{
    public class CustumCoursePriority : Comparer<CourseContainer>
    {
        // Properties
        bool delayGraduate;
        bool prioritizeLowerLevel;
        bool prioritizePrefixes;
        bool labPairGrouping;
        List<String> prefixes;



        // Constructor
        public CustumCoursePriority(
            bool delayGrad, bool prioritizeLowerLevel,
            bool labPairGrouping, List<String> priorityPrefixes)
        {
            delayGraduate = delayGrad;
            this.prioritizeLowerLevel = prioritizeLowerLevel;
            this.labPairGrouping = labPairGrouping;
            if (priorityPrefixes.Count != 0)
            {
                prioritizePrefixes = true;
                prefixes = new List<string>(priorityPrefixes);
            }
            else
            {
                prioritizePrefixes = false;
            }

        }



        public override int Compare(CourseContainer x, CourseContainer y)
        {
            //compare the course container

            //handle uncalculated dependee depth
            if (x.PendeeDepth == null || y.PendeeDepth == null)
                throw new Exception("Uncalculated dependee depth!");

            //check if labpair course
            if (labPairGrouping &&
                (x.Course.courseDetails.LabPair ||
                y.Course.courseDetails.LabPair) &&
                x.Course.courseDetails.LabPair.CompareTo(
                    y.Course.courseDetails.LabPair) != 0)
            {
                return x.Course.courseDetails.LabPair.CompareTo(
                    y.Course.courseDetails.LabPair);
            }

            //begin compare (Dependee Depth > Valid Terms > Total Dependees
            if (x.PendeeDepth.Value.CompareTo(y.PendeeDepth.Value) != 0)
                return -x.PendeeDepth.Value.CompareTo(y.PendeeDepth.Value);
            else if (compareTerms(x, y) != 0)
            {
                return compareTerms(x, y);
            }  
            else if (x.TotalPendees.CompareTo(y.TotalPendees) != 0)
            {
                return -x.TotalPendees.CompareTo(y.TotalPendees);
            }

            // if graduate class, delay
            else if (delayGraduate &&
                x.Course.courseDetails.GraduateLevel.
                CompareTo(y.Course.courseDetails.GraduateLevel) != 0)
            {
                return x.Course.courseDetails.GraduateLevel
                    .CompareTo(y.Course.courseDetails.GraduateLevel);
            }

            // if prioritize prefixes
            else if (prioritizePrefixes &&
                (prefixes.Contains(x.Course.coursePrefix) ||
                prefixes.Contains(y.Course.coursePrefix)))
            {
                if (prefixes.Contains(x.Course.coursePrefix) &&
                    !prefixes.Contains(y.Course.coursePrefix))
                    return -1;
                else if (prefixes.Contains(y.Course.coursePrefix) &&
                    !prefixes.Contains(x.Course.coursePrefix))
                    return 1;
                else
                {
                    return prefixes.IndexOf(y.Course.coursePrefix) -
                        prefixes.IndexOf(x.Course.coursePrefix);
                }
            }

            // if prioritize lower level
            else if (prioritizeLowerLevel &&
                x.Course.coursePrefix.Equals(y.Course.coursePrefix))
            {
                return x.Course.courseID.CompareTo(y.Course.courseID);
            }

            else
            {
                //if they are truly equivelent, give way to y course
                return 1;
            }
                
        }



        private int compareTerms(CourseContainer x, CourseContainer y)
        {
            switch (x.Course.validTerms.Count)
            {
                case 3:
                    switch (y.Course.validTerms.Count)
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
                    switch (y.Course.validTerms.Count)
                    {
                        case 3:
                            return -1;
                        case 2:
                            if (x.Course.validTerms.Contains(TermEnums.SUMMER) &&
                                y.Course.validTerms.Contains(TermEnums.SUMMER))
                                return 0;
                            else if (!x.Course.validTerms.Contains(TermEnums.SUMMER) &&
                                !y.Course.validTerms.Contains(TermEnums.SUMMER))
                                return 0;
                            else
                            {
                                if (x.Course.validTerms.Contains(TermEnums.SUMMER))
                                    return -1;
                                else
                                    return 1;
                            }
                        case 1:
                            return 1;
                    }
                    break;
                case 1:
                    switch (y.Course.validTerms.Count)
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
