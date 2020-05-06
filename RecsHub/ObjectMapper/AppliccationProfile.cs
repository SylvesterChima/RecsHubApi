using AutoMapper;
using RecsHub.DTO.Response;
using RecsHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecsHub.ObjectMapper
{
    public class AppliccationProfile: Profile
    {
        public AppliccationProfile()
        {
            //CreateMap<SalesMaster, SalesMasterRequest>().ReverseMap()
            //    .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.CustomerPhoneNumber));

            //CreateMap<SalesItem, SalesItemRequest>().ReverseMap();

            CreateMap<ApplicationUser, RegisterResponse>().ReverseMap();
            //CreateMap<DailySales, DailySalesModel>().ReverseMap();
            //CreateMap<IncomeExpenses, IncomeExpensesModel>().ReverseMap();
        }
    }
}
