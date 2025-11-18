using Homakers.Applications.DTOs;
using Homakers.Applications.RepoInterfaces;
using Homakers.Domain;
using Homakers.Domain.DataModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homakers.Infrastructure.Repositories
{
    public class BookServiceRepository : IBookServiceRepository
    {
        private HomakerContext _dbContext;
        public BookServiceRepository(HomakerContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<BookService>> GetBookingServiceByCustomerId(Guid customerId)
        {
            List<BookService> BookedServiceList = new List<BookService>();
            try
            {
                BookedServiceList = await _dbContext.BookService.Where(bc => bc.CustomerID == customerId).ToListAsync();
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
            return BookedServiceList;
        }

        public async Task<List<BookService>> GetBookingServiceByProfessionalsID(Guid professionalsID)
        {
            List<BookService> BookedServiceList = new List<BookService>();
            try
            {
                BookedServiceList = await _dbContext.BookService.Where(bc => bc.ProfessionalsID == professionalsID).ToListAsync();
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
            return BookedServiceList;
        }

        public async Task<BookService> GetBookingServiceByUniqueKey(BookServicesUniqueKeysDto bookService)
        {
            BookService? BookedService = new BookService();
            try
            {
                BookedService = await _dbContext.BookService.Where(bs => bs.CustomerID == bookService.CustomerID && bs.ProfessionalsID == bookService.ProfessionalsID && bs.ProfessionID == bookService.ProfessionID).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
            return BookedService;
        }

        public async Task<BookService> BookServiceByCustomer(BookServiceDto bookServiceDto)
        {
            BookService BookedServiceByUniqueKeys = new BookService();
            BookService bookService = new BookService();
            BookServicesUniqueKeysDto uniqueKeysDto = new BookServicesUniqueKeysDto();
            try
            {
                bookService.CustomerID = bookServiceDto.CustomerID;
                bookService.ProfessionalsID = bookServiceDto.ProfessionalsID;
                bookService.ProfessionID = bookServiceDto.ProfessionID;
                bookService.Price = bookServiceDto.Price;
                bookService.SGST = 0;
                bookService.CGST = 0;
                bookService.TotalPrice = bookServiceDto.Price + bookServiceDto.SGST + bookServiceDto.CGST;
                bookService.CreatedDateTime = DateTime.Now;
                bookService.BookingStatus = "Pending";
                bookService.AcceptedDateTime = null;
                bookService.RejectedDateTime = null;
                bookService.UpdatedDateTime = null;

                uniqueKeysDto.CustomerID = bookServiceDto.CustomerID;
                uniqueKeysDto.ProfessionID = bookServiceDto.ProfessionID;
                uniqueKeysDto.ProfessionalsID = bookServiceDto.ProfessionalsID;
                BookedServiceByUniqueKeys = await GetBookingServiceByUniqueKey(uniqueKeysDto);
                if (BookedServiceByUniqueKeys == null)
                {
                    await _dbContext.BookService.AddAsync(bookService);
                    _dbContext.SaveChanges();
                    BookedServiceByUniqueKeys = await GetBookingServiceByUniqueKey(uniqueKeysDto);
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
            return BookedServiceByUniqueKeys;
        }
        public async Task<BookService> AcceptServiceByProfessional(BookServiceDto bookServiceDto)
        {
            BookService BookedServiceByUniqueKeys = new BookService();
            BookService bookService = new BookService();
            BookServicesUniqueKeysDto uniqueKeysDto = new BookServicesUniqueKeysDto();
            try
            {
                uniqueKeysDto.CustomerID = bookServiceDto.CustomerID;
                uniqueKeysDto.ProfessionID = bookServiceDto.ProfessionID;
                uniqueKeysDto.ProfessionalsID = bookServiceDto.ProfessionalsID;
                BookedServiceByUniqueKeys = await GetBookingServiceByUniqueKey(uniqueKeysDto);
                
                bookService.BookServiceID = BookedServiceByUniqueKeys.BookServiceID;
                bookService.CustomerID = BookedServiceByUniqueKeys.CustomerID;
                bookService.ProfessionalsID = BookedServiceByUniqueKeys.ProfessionalsID;
                bookService.ProfessionID = BookedServiceByUniqueKeys.ProfessionID;
                bookService.Price = BookedServiceByUniqueKeys.Price;
                bookService.SGST = BookedServiceByUniqueKeys.SGST;
                bookService.CGST = BookedServiceByUniqueKeys.CGST;
                bookService.TotalPrice = BookedServiceByUniqueKeys.Price + BookedServiceByUniqueKeys.SGST + BookedServiceByUniqueKeys.CGST;
                bookService.CreatedDateTime = BookedServiceByUniqueKeys.CreatedDateTime;
                bookService.BookingStatus = "Accepted";
                bookService.AcceptedDateTime = DateTime.Now;
                bookService.RejectedDateTime = null;
                bookService.UpdatedDateTime = BookedServiceByUniqueKeys.UpdatedDateTime;
                _dbContext.BookService.Update(bookService);
                _dbContext.SaveChanges();
                BookedServiceByUniqueKeys = await GetBookingServiceByUniqueKey(uniqueKeysDto);
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
            return BookedServiceByUniqueKeys;
        }

        public async Task<BookService> RejectServiceByProfessional(BookServiceDto bookServiceDto)
        {
            BookService BookedServiceByUniqueKeys = new BookService();
            BookService bookService = new BookService();
            BookServicesUniqueKeysDto uniqueKeysDto = new BookServicesUniqueKeysDto();
            try
            {
                uniqueKeysDto.CustomerID = bookServiceDto.CustomerID;
                uniqueKeysDto.ProfessionID = bookServiceDto.ProfessionID;
                uniqueKeysDto.ProfessionalsID = bookServiceDto.ProfessionalsID;
                BookedServiceByUniqueKeys = await GetBookingServiceByUniqueKey(uniqueKeysDto);

                bookService.BookServiceID = BookedServiceByUniqueKeys.BookServiceID;
                bookService.CustomerID = BookedServiceByUniqueKeys.CustomerID;
                bookService.ProfessionalsID = BookedServiceByUniqueKeys.ProfessionalsID;
                bookService.ProfessionID = BookedServiceByUniqueKeys.ProfessionID;
                bookService.Price = BookedServiceByUniqueKeys.Price;
                bookService.SGST = BookedServiceByUniqueKeys.SGST;
                bookService.CGST = BookedServiceByUniqueKeys.CGST;
                bookService.TotalPrice = BookedServiceByUniqueKeys.Price + BookedServiceByUniqueKeys.SGST + BookedServiceByUniqueKeys.CGST;
                bookService.CreatedDateTime = BookedServiceByUniqueKeys.CreatedDateTime;
                bookService.BookingStatus = "Rejected";
                bookService.AcceptedDateTime = null;
                bookService.RejectedDateTime = DateTime.Now;
                bookService.UpdatedDateTime = BookedServiceByUniqueKeys.UpdatedDateTime;
                _dbContext.BookService.Update(bookService);
                _dbContext.SaveChanges();
                BookedServiceByUniqueKeys = await GetBookingServiceByUniqueKey(uniqueKeysDto);
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
            return BookedServiceByUniqueKeys;
        }
    }
}
