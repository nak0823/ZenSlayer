using System.Collections.Generic;
using System.IO;
using ZenSlayer.Stages;

namespace ZenSlayer.Interfaces
{
    public class Options : IOptions
    {
        public string AssemblyPath { get; set; }
        public string AssemblyName { get; set; }
        public string AssemblyExtension { get; set; }
        public string AssemblyOutput { get; set; }
        public string AssemblyDirectory { get; set; }

        public List<IStage> Stages { get; private set; } = new List<IStage>()
        {
            new AttributeRemover(),
            new StringDecrypter()
        };

        public Options(string[] args)
        {
            if (args.Length == 0)
                return;

            if (args[0] == string.Empty)
                return;

            if (File.Exists(args[0]))
            {
                AssemblyPath = Path.GetFullPath(args[0]);
                AssemblyName = Path.GetFileNameWithoutExtension(args[0]);
                AssemblyExtension = Path.GetExtension(args[0]);
                AssemblyDirectory = Path.GetDirectoryName(args[0]);
                AssemblyOutput = $"{AssemblyDirectory}/{AssemblyName}_up{AssemblyExtension}";
            }
        }
    }
}