using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventorySystem.Training.BusinessObjects;
using InventorySystem.Training.Exceptions;
using InventorySystem.Training.UnitOfWorks;

namespace InventorySystem.Training.Services
{
    public class StockService : IStockService
    {

        private readonly ITrainingUnitOfWork _trainingUnitOfWork;

        private readonly IMapper _mapper;


        public StockService(ITrainingUnitOfWork trainingUnitOfWork, IMapper mapper)
        {
            _trainingUnitOfWork = trainingUnitOfWork;
            _mapper = mapper;

        }

        public void CreateStock(Stock stock)
        {
            if (stock == null)
                throw new InvalidParameterException("stock is not provided");

            _trainingUnitOfWork.Stocks.Add(_mapper.Map<Entities.Stock>(stock));
            _trainingUnitOfWork.Save(); ;


        }

        public void DeleteStock(int id)
        {
             _trainingUnitOfWork.Stocks.Remove(id);
            _trainingUnitOfWork.Save();


        }

        public Stock GetStock(int id)
        {
            var stock = _trainingUnitOfWork.Stocks.GetById(id);
            if (stock == null)
                return null;
            return _mapper.Map<Stock>(stock);


        }

        //public (IList<Stock> records, int total, int totalDisplay) GetStocks(int pageIndex, 
        //    int pageSize, string searchText, string sortText)
        //{
        //    var ticketData = _trainingUnitOfWork.Stocks.GetDynamic(
        //       string.IsNullOrEmpty(searchText) ? null : x => x.Quantity.Contains(searchText), sortText,
        //       string.Empty, pageIndex, pageSize);

        //    var resultData = (from ticket in ticketData.data
        //                      select _mapper.Map<Ticket>(ticket)
        //                     ).ToList();

        //    return (resultData, ticketData.total, ticketData.totalDisplay);
        //}

        //public void UpdateTicket(Ticket ticket)
        //{ 
        //        if (ticket == null)
        //            throw new InvalidOperationException("ticket is missing");


        //        var ticketEntity = _trainingUnitOfWork.Tickets.GetById(ticket.Id);

        //        if (ticketEntity != null)
        //        {
        //            _mapper.Map(ticket, ticketEntity);
        //            _trainingUnitOfWork.Save();
        //        }
        //        else
        //            throw new InvalidOperationException("Couldn't found ticket ");
        //    }
        

        
    }
}
