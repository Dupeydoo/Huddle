using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Huddle.Enums
{
    /*
     * A handy little enum to make standard numbers in the paging buffer system 
     * look more human readable.
     * 
     * @author  James
     * @version 1.0.0
    */
    public enum PagingEnum
    {
        PageLength = 10,                  // A page is 10 posts long
        PagerBuffer = 100,                // A single page buffer unit allows for 10 pages more space
        PagerBufferMultiplier = 90        // The multiplier used to see when the buffer should be expanded is 9 pages long
    }
}