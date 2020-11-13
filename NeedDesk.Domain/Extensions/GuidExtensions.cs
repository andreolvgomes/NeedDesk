using System;
using System.Collections.Generic;
using System.Text;

namespace System
{
    public static class GuidExtensions
    {
        public static bool IsEmpty(this Guid guid)
        {
            return guid == Guid.Empty;
        }

        public static bool Valid(this Guid guid)
        {
            return guid.IsEmpty() == false;
        }
    }
}