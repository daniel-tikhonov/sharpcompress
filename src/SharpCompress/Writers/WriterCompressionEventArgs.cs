using System;
using SharpCompress.Readers;

namespace SharpCompress.Writers
{
    public sealed class WriterCompressionEventArgs : EventArgs
    {
        internal WriterCompressionEventArgs(string key, long sizeTransferred, int iterations)
        {
            Key = key;
            SizeTransfered = sizeTransferred;
            Iteration = iterations;
        }

        public string Key { get; }

        public long SizeTransfered { get; }
        public int Iteration { get; set; }
    }
}
