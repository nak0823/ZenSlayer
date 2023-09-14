using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZenSlayer.Interfaces;

namespace ZenSlayer.Stages
{
    internal class StringDecrypter : IStage
    {
        private int Found = 0;

        public void Fix(IContext context)
        {
            context.Logger.Debug($"Running String Decrypter.");

            var moduleDef = context.moduleDef;

            if (moduleDef == null)
            {
                context.Logger.Warn("ModuleDef is null.");
                return;
            }

            foreach (var method in moduleDef.GetTypes().SelectMany(type => type.Methods).ToList())
            {
                if (method.Body == null)
                    continue;

                var instructions = method.Body.Instructions;
                var instructionsToRemove = new List<Instruction>();

                for (int i = 0; i < instructions.Count; i++)
                {
                    var instruction = instructions[i];

                    if (instruction.Operand != null &&
                        instruction.Operand.ToString().Contains("System.Text.Encoding System.Text.Encoding::get_UTF8()") &&
                        i + 2 < instructions.Count && instructions[i + 2].Operand != null &&
                        instructions[i + 2].Operand.ToString().Contains("System.Byte[] System.Convert::FromBase64String(System.String)") &&
                        i + 3 < instructions.Count && instructions[i + 3].Operand != null &&
                        instructions[i + 3].Operand.ToString().Contains("System.String System.Text.Encoding::GetString(System.Byte[])"))
                    {
                        if (i + 1 < instructions.Count && instructions[i + 1].OpCode == OpCodes.Ldstr && instructions[i + 1].Operand is string base64String)
                        {
                            var decryptedString = Encoding.UTF8.GetString(Convert.FromBase64String(base64String));
                            instructions[i + 1].OpCode = OpCodes.Ldstr;
                            instructions[i + 1].Operand = decryptedString;
                            instructionsToRemove.Add(instructions[i]);
                            instructionsToRemove.Add(instructions[i + 2]);
                            instructionsToRemove.Add(instructions[i + 3]);
                            Found++;
                        }
                    }
                }

                foreach (var instructionToRemove in instructionsToRemove)
                {
                    instructions.Remove(instructionToRemove);
                }
            }

            context.Logger.Info($"Decrypted {Found} strings.");
        }
    }
}