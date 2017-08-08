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
    }
}
