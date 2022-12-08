using System;
using System.IO;
using SharpCompress.Archives;
using SharpCompress.Common;

namespace SharpCompress.Writers
{
    public interface IWriter : IDisposable
    {
        event EventHandler<WriterCompressionEventArgs> EntryCompressionProgress;
        event EventHandler<WriterCompressionEntryBegin> EntryCompressionBegin;
        event EventHandler<WriterCompressionEntryEnd> EntryCompressionEnd;
        ArchiveType WriterType { get; }
        void WriteEntry(string filename, Stream source, FileInfo? entry);
        void WriteEntry(string filename, Stream source, IArchiveEntry? entry);
        void Write(string filename, Stream source, DateTime? modificationTime);
    }
}
