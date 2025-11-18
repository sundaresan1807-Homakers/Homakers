using AutoMapper;
using Homakers.Applications.DTOs;
using Homakers.Applications.RepoInterfaces;
using Homakers.Applications.Repositories.RepoInterfaces;
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
        private IProfessionalsRepository _professionalRepository;
        private IProfessionRepository _professionRepository;
        private ICustomersRepository _customersRepository;
        private IMapper _mapper;
        public BookServicesService(IBookServiceRepository bookServiceRepository, IProfessionalsRepository professionalRepository, IProfessionRepository professionRepository, ICustomersRepository customersRepository)
        {
            _bookServiceRepository = bookServiceRepository;
            _professionalRepository = professionalRepository;
            _professionRepository = professionRepository;
            _customersRepository = customersRepository;
        }

        public async Task<List<BookServiceDto>> GetBookingServiceByCustomerId(string customerId)
        {
            List<BookService> BookedServiceList = new List<BookService>();
            List<BookServiceDto> BookedServiceDtoList = new List<BookServiceDto>();
            List<Professionals> professionalList = new List<Professionals>();
            List<Profession> professionList = new List<Profession>();
            try
            {
                BookedServiceList = await _bookServiceRepository.GetBookingServiceByCustomerId(Guid.Parse(customerId));
                if (BookedServiceList.Count == 0)
                {
                    return BookedServiceDtoList;
                }
                professionalList = await _professionalRepository.GetProfessionalsAsync();
                professionList = await _professionRepository.GetProfessionsAsync();
                BookedServiceList.ForEach(BookedService =>
                {
                    BookServiceDto BookedServiceDto = new BookServiceDto();
                    BookedServiceDto.BookServiceID = BookedService.BookServiceID;
                    BookedServiceDto.CustomerID = BookedService.CustomerID;
                    BookedServiceDto.ProfessionName = professionList.Where(p => p.ProfessionID == BookedService.ProfessionID).FirstOrDefault().ProfessionName;
                    BookedServiceDto.ProfessionalName = professionalList.Where(p => p.ProfessionalsID == BookedService.ProfessionalsID).FirstOrDefault().Name;
                    BookedServiceDto.ProfessionID = BookedService.ProfessionID;
                    BookedServiceDto.ProfessionalsID = BookedService.ProfessionalsID;
                    BookedServiceDto.Price = BookedService.Price;
                    BookedServiceDto.SGST = BookedService.SGST;
                    BookedServiceDto.CGST = BookedService.CGST;
                    BookedServiceDto.TotalPrice = BookedService.TotalPrice;
                    BookedServiceDto.CreatedDateTime = BookedService.CreatedDateTime;
                    BookedServiceDto.BookingStatus = BookedService.BookingStatus;
                    BookedServiceDto.AcceptedDateTime = BookedService.AcceptedDateTime;
                    BookedServiceDto.RejectedDateTime = BookedService.RejectedDateTime;
                    BookedServiceDto.UpdatedDateTime = BookedService.UpdatedDateTime;
                    BookedServiceDtoList.Add(BookedServiceDto);
                });
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
            List<Customers> customerList = new List<Customers>();
            List<Profession> professionList = new List<Profession>();
            try
            {
                BookedServiceList = await _bookServiceRepository.GetBookingServiceByProfessionalsID(Guid.Parse(professionalsID));
                if (BookedServiceList.Count == 0)
                {
                    return BookedServiceDtoList;
                }
                customerList = await _customersRepository.GetCustomersAsync();
                professionList = await _professionRepository.GetProfessionsAsync();
                BookedServiceList.ForEach(BookedService =>
                {
                    BookServiceDto BookedServiceDto = new BookServiceDto();
                    BookedServiceDto.BookServiceID = BookedService.BookServiceID;
                    BookedServiceDto.CustomerID = BookedService.CustomerID;
                    BookedServiceDto.ProfessionName = professionList.Where(p => p.ProfessionID == BookedService.ProfessionID).FirstOrDefault().ProfessionName;
                    BookedServiceDto.CustomerName = customerList.Where(p => p.CustomerID == BookedService.CustomerID).FirstOrDefault().Name;
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
                    BookedServiceDtoList.Add(BookedServiceDto);
                });
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
        public async Task<BookServiceDto> AcceptServiceByProfessional(BookServiceDto bookServiceDto)
        {
            BookService BookedService = new BookService();
            BookServiceDto BookedServiceDto = new BookServiceDto();
            BookService bookService = new BookService();
            try
            {
                BookedService = await _bookServiceRepository.AcceptServiceByProfessional(bookServiceDto);
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

            }
            finally
            {

            }
            return BookedServiceDto;
        }

        public async Task<BookServiceDto> RejectServiceByProfessional(BookServiceDto bookServiceDto)
        {
            BookService BookedService = new BookService();
            BookServiceDto BookedServiceDto = new BookServiceDto();
            BookService bookService = new BookService();
            try
            {
                BookedService = await _bookServiceRepository.RejectServiceByProfessional(bookServiceDto);
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

            }
            finally
            {

            }
            return BookedServiceDto;
        }
    }
}
