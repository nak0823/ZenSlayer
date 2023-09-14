using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ZenSlayer.Interfaces;

namespace ZenSlayer
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.Title = "ZenSlayer ~ ZenFuscator Unpacker by Serialized";

            Logger Logger = new Logger();
            Logger.PrintArt();
            IContext context = new Context(new Options(args), Logger);

            if (context.IsInitialized())
            {
                foreach (IStage stage in context.Options.Stages)
                {
                    stage.Fix(context);
                }

                context.SaveContext();
            }
            else
            {
                Logger.Warn("Press any key to exit.");
                Console.ReadKey();
                Environment.Exit(0);
            }

            Console.ReadKey();
        }
    }
}