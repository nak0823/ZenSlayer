﻿namespace ZenSlayer.Interfaces
{
    public interface ILogger
    {
        void Error(string message);

        void Info(string message);

        void Warn(string message);

        void Debug(string message);

        void Success(string message);

        void PrintArt();
    }
}