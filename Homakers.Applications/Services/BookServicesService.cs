using AutoMapper;
using Homakers.Applications.DTOs;
using Homakers.Applications.RepoInterfaces;
using Homakers.Applications.ServiceInterfaces;
using Homakers.Domain.DataModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homakers.Applications.Services
{
    public class BookServicesService : IBookServicesService
    {
        private IBookServiceRepository _bookServiceRepository;
        private IMapper _mapper;
        public BookServicesService(IBookServiceRepository bookServiceRepository)
        {
            _bookServiceRepository = bookServiceRepository;
        }

        public async Task<List<BookServiceDto>> GetBookingServiceByCustomerId(string customerId)
        {
            List<BookService> BookedServiceList = new List<BookService>();
            List<BookServiceDto> BookedServiceDtoList = new List<BookServiceDto>();
            try
            {
                BookedServiceList = await _bookServiceRepository.GetBookingServiceByCustomerId(Guid.Parse(customerId));
                BookedServiceDtoList = _mapper.Map<List<BookServiceDto>>(BookedServiceList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            return BookedServiceDtoList;
        }

        public async Task<List<BookServiceDto>> GetBookingServiceByProfessionalsID(string professionalsID)
        {
            List<BookService> BookedServiceList = new List<BookService>();
            List<BookServiceDto> BookedServiceDtoList = new List<BookServiceDto>();
            try
            {
                BookedServiceList = await _bookServiceRepository.GetBookingServiceByProfessionalsID(Guid.Parse(professionalsID));
                BookedServiceDtoList = _mapper.Map<List<BookServiceDto>>(BookedServiceList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            return BookedServiceDtoList;
        }

        public async Task<BookServiceDto> BookServiceByCustomer(BookServiceDto bookServiceDto)
        {
            BookService BookedService = new BookService();
            BookServiceDto BookedServiceDto = new BookServiceDto();
            BookService bookService = new BookService();
            try
            {
                BookedService = await _bookServiceRepository.BookServiceByCustomer(bookServiceDto);
                BookedServiceDto.BookServiceID = BookedService.BookServiceID;
                BookedServiceDto.CustomerID = BookedService.CustomerID;
                BookedServiceDto.ProfessionalsID = BookedService.ProfessionalsID;
                BookedServiceDto.ProfessionID = BookedService.ProfessionID;
                BookedServiceDto.Price = BookedService.Price;
                BookedServiceDto.SGST = BookedService.SGST;
                BookedServiceDto.CGST = BookedService.CGST;
                BookedServiceDto.TotalPrice = BookedService.TotalPrice;
                BookedServiceDto.CreatedDateTime = BookedService.CreatedDateTime;
                BookedServiceDto.BookingStatus = BookedService.BookingStatus;
                BookedServiceDto.AcceptedDateTime = BookedService.AcceptedDateTime;
                BookedServiceDto.RejectedDateTime = BookedService.RejectedDateTime;
                BookedServiceDto.UpdatedDateTime = BookedService.UpdatedDateTime;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            return BookedServiceDto;
        }

        public async Task<BookServiceDto> GetBookingServiceByUniqueKey(BookServicesUniqueKeysDto bookServiceDto)
        {
            BookService BookedService = new BookService();
            BookServiceDto BookedServiceDto = new BookServiceDto();
            BookService bookService = new BookService();
            try
            {
                BookedService = await _bookServiceRepository.GetBookingServiceByUniqueKey(bookServiceDto);
                if (BookedService == null)
                {
                    return new BookServiceDto();
                }
                BookedServiceDto.BookServiceID = BookedService.BookServiceID;
                BookedServiceDto.CustomerID = BookedService.CustomerID;
                BookedServiceDto.ProfessionalsID = BookedService.ProfessionalsID;
                BookedServiceDto.ProfessionID = BookedService.ProfessionID;
                BookedServiceDto.Price = BookedService.Price;
                BookedServiceDto.SGST = BookedService.SGST;
                BookedServiceDto.CGST = BookedService.CGST;
                BookedServiceDto.TotalPrice = BookedService.TotalPrice;
                BookedServiceDto.CreatedDateTime = BookedService.CreatedDateTime;
                BookedServiceDto.BookingStatus = BookedService.BookingStatus;
                BookedServiceDto.AcceptedDateTime = BookedService.AcceptedDateTime;
                BookedServiceDto.RejectedDateTime = BookedService.RejectedDateTime;
                BookedServiceDto.UpdatedDateTime = BookedService.UpdatedDateTime;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            return BookedServiceDto;
        }
    }
}
