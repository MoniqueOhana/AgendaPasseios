﻿
namespace AgendaPasseios.Services
{
    [Serializable]
    internal class DbConcurrencyException : Exception
    {
        public DbConcurrencyException()
        {
        }

        public DbConcurrencyException(string? message) : base(message)
        {
        }

        public DbConcurrencyException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}