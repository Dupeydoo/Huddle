using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huddle.Objects.Common
{
    /*
     * A class for use around Huddle with common methods
     * 
     * @author  James
     * @version 1.0.0
    */
    public static class HuddleCommon
    {
        // The count of categories set in Global to allow it to be read by ViewCategory
        public static int CategoryCount { get; set; }

        /*
         * This method checks to see if integer x is divisible by integer y
         * 
         * @param    x  the first integer
         * @param    y  the second integer
         * @returns  true if x is divisible by y
         * @author   James
         * @version  1.0.0
        */
        public static bool IsDivisible(int x, int y)
        {
            return x % y == 0;
        }

        /*
         * This helper method calculates the current page of a DataPager
         * 
         * @param    maxRows  The max rows per page
         * @param    rowIndex The index of the page start row
         * @returns  The current page
         * @author   James
         * @version  1.0.0
        */
        public static int CalculateCurrentPage(int rowIndex, int maxRows)
        {
            return ((rowIndex) / maxRows) + 1;
        }

    }
}
