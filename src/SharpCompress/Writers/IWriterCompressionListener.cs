using SharpCompress.Common;

namespace SharpCompress.Readers
{
    internal interface IWriterCompressionListener
    {
        void FireEntryCompressionProgress(string key, long sizeTransferred, int iterations);
    }
}
