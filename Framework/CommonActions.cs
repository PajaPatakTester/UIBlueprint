using System;

namespace Framework
{
    public static class CommonActions
    {
        public static string CurrentTime() => DateTime.UtcNow.ToLocalTime().ToString("dd-MM-yy_HH-mm-ss");

    }
}
