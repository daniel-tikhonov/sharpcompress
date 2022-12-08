using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpCompress.Writers;
public class WriterCompressionEntryEnd
{
    public WriterCompressionEntryEnd(string entry)
    {
        Entry = entry;
    }
    public string Entry { get; set; }
    public long Size { get; set; }
}
