using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stores.Core.Convertor
{
    public class FixEmails
    {
        public static string FixEmail(string Email)
        {
            return Email.Trim().ToLower();
        }
    }
}
