using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZenSlayer.Interfaces
{
    public interface IOptions
    {
        string AssemblyPath { get; set; }
        string AssemblyName { get; set; }
        string AssemblyExtension { get; set; }
        string AssemblyOutput { get; set; }
        string AssemblyDirectory { get; set; }
        List<IStage> Stages { get; }
    }
}