using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework
{
    public static class CommonActions
    {
        public static string CurrentTime() => DateTime.UtcNow.ToLocalTime().ToString("dd-MM-yy_HH-mm-ss");

    }
}
