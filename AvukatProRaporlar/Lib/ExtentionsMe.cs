using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AvukatProRaporlar.Lib
{
    public static class ExtentionsMe
    {
        /// <summary>
        /// Dolu ise true döner
        /// </summary>
        /// <typeparam name="t"></typeparam>
        /// <param name="me"></param>
        /// <returns></returns>
        public static bool Dolumu(this IList me)
        {
            if (me.Count > 0) return true;
            else return false;
        }

        public static bool Dolumu<t>(this IEnumerable<t> me)
        {
            if (me.Count() > 0)
            {
                return true;
            }
            else return false;
        }
    }
}