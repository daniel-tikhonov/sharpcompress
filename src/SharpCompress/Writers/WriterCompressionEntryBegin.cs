using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpCompress.Writers;
public class WriterCompressionEntryBegin
{
    public WriterCompressionEntryBegin(string entry)
    {
        Entry = entry;
    }
    public string Entry { get; set; }
    public long Size { get; set; }
}
