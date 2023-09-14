using System.Linq;
using ZenSlayer.Interfaces;

namespace ZenSlayer.Stages
{
    internal class AttributeRemover : IStage
    {
        private int Found = 0;

        private static string[] KnownAttributes = new[]
        {
            "ObfuscatedByGoliath",
            "NineRays.Obfuscator.Evaluation",
            "NetGuard",
            "dotNetProtector",
            "YanoAttribute",
            "Xenocode.Client.Attributes.AssemblyAttributes.ProcessedByXenocode",
            "PoweredByAttribute",
            "DotNetPatcherPackerAttribute",
            "DotNetPatcherObfuscatorAttribute",
            "DotfuscatorAttribute",
            "CryptoObfuscator.ProtectedWithCryptoObfuscatorAttribute",
            "BabelObfuscatorAttribute",
            "BabelAttribute",
            "AssemblyInfoAttribute",
            "ZYXDNGuarder",
            "ConfusedByAttribute"
        };

        public void Fix(IContext context)
        {
            context.Logger.Debug($"Running Attribute Remover.");

            foreach (var type in context.moduleDef.Types.ToList())
            {
                if (!type.Fields.Any() && !type.Methods.Any(method => !method.IsStaticConstructor))
                {
                    if (KnownAttributes.Any(attr => type.Name.Contains(attr)))
                    {
                        Found++;
                        context.moduleDef.Types.Remove(type);
                    }

                    if (type != context.moduleDef.GlobalType)
                    {
                        Found++;
                        context.moduleDef.Types.Remove(type);
                    }
                }
            }

            context.Logger.Info($"Deleted {Found} types.");
        }
    }
}