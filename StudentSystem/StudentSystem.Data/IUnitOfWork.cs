using System;

namespace StudentSystem.Data
{
    public interface IUnitOfWork : IDisposable
    {

        void Save();

    }
}
