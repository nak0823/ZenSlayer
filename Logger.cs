using System;
using System.Drawing;
using Console = Colorful.Console;
using ZenSlayer.Interfaces;

namespace ZenSlayer
{
    public class Logger : ILogger
    {
        private string currentTime = DateTime.Now.ToString("T");

        public void Debug(string message)
        {
            Console.Write("[", Color.White);
            Console.Write(currentTime, Color.Aqua);
            Console.Write("]", Color.White);
            Console.Write("[", Color.White);
            Console.Write("*", Color.BlueViolet);
            Console.Write("] ", Color.White);
            Console.Write(message + "\n", Color.BlueViolet);
        }

        public void Error(string message)
        {
            Console.Write("[", Color.White);
            Console.Write(currentTime, Color.Aqua);
            Console.Write("]", Color.White);
            Console.Write("[", Color.White);
            Console.Write("!", Color.Red);
            Console.Write("] ", Color.White);
            Console.Write(message + "\n", Color.Red);
        }

        public void Info(string message)
        {
            Console.Write("[", Color.White);
            Console.Write(currentTime, Color.Aqua);
            Console.Write("]", Color.White);
            Console.Write("[", Color.White);
            Console.Write("^", Color.DodgerBlue);
            Console.Write("] ", Color.White);
            Console.Write(message + "\n", Color.DodgerBlue);
        }

        public void Success(string message)
        {
            Console.Write("[", Color.White);
            Console.Write(currentTime, Color.Aqua);
            Console.Write("]", Color.White);
            Console.Write("[", Color.White);
            Console.Write("+", Color.LimeGreen);
            Console.Write("] ", Color.White);
            Console.Write(message + "\n", Color.LimeGreen);
        }

        public void Warn(string message)
        {
            Console.Write("[", Color.White);
            Console.Write(currentTime, Color.Aqua);
            Console.Write("]", Color.White);
            Console.Write("[", Color.White);
            Console.Write("!", Color.HotPink);
            Console.Write("] ", Color.White);
            Console.Write(message + "\n", Color.HotPink);
        }

        public void PrintArt()
        {
            string[] asciiDesign =
            {
                "",
                "::::::::: :::::::::: ::::    :::  ::::::::  :::            :::   :::   ::: :::::::::: :::::::::  ",
                "     :+:  :+:        :+:+:   :+: :+:    :+: :+:          :+: :+: :+:   :+: :+:        :+:    :+: ",
                "    +:+   +:+        :+:+:+  +:+ +:+        +:+         +:+   +:+ +:+ +:+  +:+        +:+    +:+ ",
                "   +#+    +#++:++#   +#+ +:+ +#+ +#++:++#++ +#+        +#++:++#++: +#++:   +#++:++#   +#++:++#:  ",
                "  +#+     +#+        +#+  +#+#+#        +#+ +#+        +#+     +#+  +#+    +#+        +#+    +#+ ",
                " #+#      #+#        #+#   #+#+# #+#    #+# #+#        #+#     #+#  #+#    #+#        #+#    #+# ",
                "######### ########## ###    ####  ########  ########## ###     ###  ###    ########## ###    ### ",
                "",
            };

            Array.ForEach(asciiDesign,
                line => Colorful.Console.WriteLine(line.PadLeft((Console.WindowWidth - line.Length) / 2 + line.Length),
                    Color.Aqua));
        }
    }
}