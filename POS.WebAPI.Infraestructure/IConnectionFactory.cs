using System;
using System.Data;

namespace POS.WebAPI.Infraestructure
{
    public interface IConnectionFactory : IDisposable
    {
        IDbConnection GetConnection { get; }
    }
}
