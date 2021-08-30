using System;


namespace TicketBookingSystem.Data.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
    }
}
