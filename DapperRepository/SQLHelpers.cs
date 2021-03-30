using System;
using System.Collections.Generic;
using System.Text;

namespace DapperRepository
{
    public static class SQLHelpers
    {
        public static string WrapWithWildCards(this string inputString)
        {
            return $"%{inputString}%";
        }
    }
}
