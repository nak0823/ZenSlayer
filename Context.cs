using dnlib.DotNet;
using dnlib.DotNet.Writer;
using System;
using ZenSlayer.Interfaces;
using ILogger = ZenSlayer.Interfaces.ILogger;

namespace ZenSlayer
{
    public class Context : IContext
    {
        public Context(IOptions options, ILogger logger)
        {
            Options = options;
            Logger = logger;
        }

        public bool IsInitialized()
        {
            if (string.IsNullOrEmpty(Options.AssemblyPath))
            {
                Logger.Warn("No valid assembly has been found.");
                return false;
            }
            try
            {
                assemblyDef = AssemblyDef.Load(Options.AssemblyPath);
                moduleDef = assemblyDef.ManifestModule;
                moduleDefMD = ModuleDefMD.Load(Options.AssemblyPath);

                Logger.Success("Assembly has been loaded.");
                return true;
            }
            catch (Exception ex)
            {
                Logger.Warn($"Failed to load Assembly. {ex.Message}");
                return false;
            }
        }

        public void SaveContext()
        {
            var SaveOptions = new ModuleWriterOptions(assemblyDef.ManifestModule);
            SaveOptions.Logger = DummyLogger.NoThrowInstance;
            assemblyDef.Write(Options.AssemblyOutput, SaveOptions);
            Logger.Success("Assembly has been saved.");
        }

        public IOptions Options { get; }
        public ILogger Logger { get; set; }
        public AssemblyDef assemblyDef { get; set; }
        public TypeDef typeDef { get; set; }
        public ModuleDef moduleDef { get; set; }
        public ModuleDefMD moduleDefMD { get; set; }
        public MethodDef cctor { get; set; }
    }
}