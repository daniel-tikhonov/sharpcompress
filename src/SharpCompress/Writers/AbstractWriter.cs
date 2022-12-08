#nullable disable

using System;
using System.IO;
using System.Reflection;
using SharpCompress.Archives;
using SharpCompress.Common;
using SharpCompress.Readers;

namespace SharpCompress.Writers
{
    public abstract class AbstractWriter : IWriter, IWriterCompressionListener
    {
        private bool _isDisposed;

        protected AbstractWriter(ArchiveType type, WriterOptions writerOptions)
        {
            WriterType = type;
            WriterOptions = writerOptions;
        }

        protected void InitalizeStream(Stream stream)
        {
            OutputStream = stream;
        }
        public event EventHandler<WriterCompressionEventArgs> EntryCompressionProgress;
        public event EventHandler<WriterCompressionEntryBegin> EntryCompressionBegin;
        public event EventHandler<WriterCompressionEntryEnd> EntryCompressionEnd;

        protected Stream OutputStream { get; private set; }

        public ArchiveType WriterType { get; }

        protected WriterOptions WriterOptions { get; }

        public void WriteEntry(string filename, Stream source, FileInfo entry)
        {
            EntryCompressionBegin?.Invoke(this, new WriterCompressionEntryBegin(filename)
            {
                Size = source.Length
            });
            Write(filename, source, entry?.LastWriteTime);
            EntryCompressionEnd?.Invoke(this, new WriterCompressionEntryEnd(filename)
            {
                Size = source.Length
            });
        }
        public void WriteEntry(string filename, Stream source, IArchiveEntry entry)
        {
            EntryCompressionBegin?.Invoke(this, new WriterCompressionEntryBegin(filename)
            {
                Size = source.Length
            });
            Write(filename, source, entry?.LastModifiedTime);
            EntryCompressionEnd?.Invoke(this, new WriterCompressionEntryEnd(filename)
            {
                Size = source.Length
            });
        }

        public abstract void Write(string filename, Stream source, DateTime? modificationTime);

        protected virtual void Dispose(bool isDisposing)
        {
            if (isDisposing)
            {
                OutputStream.Dispose();
            }
        }

        public void Dispose()
        {
            if (!_isDisposed)
            {
                GC.SuppressFinalize(this);
                Dispose(true);
                _isDisposed = true;
            }
        }

        public void FireEntryCompressionProgress(string key, long sizeTransferred, int iterations)
        {
            EntryCompressionProgress?.Invoke(this, new WriterCompressionEventArgs(key, sizeTransferred, iterations));
        }

        ~AbstractWriter()
        {
            if (!_isDisposed)
            {
                Dispose(false);
                _isDisposed = true;
            }
        }
    }
}
