using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BlueLicense.Core.Extensions
{
    public static class BinaryWriterExtension
    {
        public static void WriteNormalized(this BinaryWriter writerInstance, string value)
        {
            writerInstance.Write(value.ToLowerInvariant().Trim());
        }
    }
}
