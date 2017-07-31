using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huddle.Objects.Common
{
    public static class HuddleCommon
    {
        public static bool IsDivisible(int x, int y)
        {
            return x % y == 0;
        }
    }
}
