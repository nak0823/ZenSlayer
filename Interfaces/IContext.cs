using System.Collections.Generic;
using dnlib.DotNet;

namespace ZenSlayer.Interfaces
{
    public interface IContext
    {
        bool IsInitialized();

        void SaveContext();

        ILogger Logger { get; set; }
        IOptions Options { get; }

        AssemblyDef assemblyDef { get; set; }

        ModuleDef moduleDef { get; set; }

        ModuleDefMD moduleDefMD { get; set; }

        TypeDef typeDef { get; set; }

        MethodDef cctor { get; set; }
    }
}