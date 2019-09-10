using System.IO;
using Spk.Common.Helpers.Guard;

namespace Spk.Common.Helpers.String
{
    public static class StreamExtensions
    {
        public static MemoryStream ToMemoryStream(this string source)
        {
            source.GuardIsNotNull(nameof(source));

            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(source);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }
    }
}
