using AutoMapper;
using RecsHub.Domain.Entities;
using RecsHub.DTO.Request;
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
            CreateMap<Product, ProductRequest>().ReverseMap();
            CreateMap<Product, ProductResponse>().ReverseMap();

            CreateMap<DailyStoreRecord, DailyStoreRecordRequest>().ReverseMap();
            CreateMap<DailyStoreRecord, DailyStoreRecordResponse>().ReverseMap();

            CreateMap<SalesItem, SalesItemRequest>().ReverseMap();
            CreateMap<SalesItem, SalesItemResponse>().ReverseMap();

            CreateMap<SalesMaster, SalesMasterRequest>().ReverseMap();
            CreateMap<SalesMaster, SalesMasterResponse>().ReverseMap();

            CreateMap<StockKeeping, StockKeepingRequest>().ReverseMap();
            CreateMap<StockKeeping, StockKeepingResponse>().ReverseMap();

            CreateMap<StoreRecord, StoreRecordRequest>().ReverseMap();
            CreateMap<StoreRecord, StoreRecordResponse>().ReverseMap();

            CreateMap<Supplier, SupplierRequest>().ReverseMap();
            CreateMap<Supplier, SupplierResponse>().ReverseMap();

            CreateMap<SupplyRecord, SupplyRecordRequest>().ReverseMap();
            CreateMap<SupplyRecord, SupplyRecordResponse>().ReverseMap();

            CreateMap<ApplicationUser, RegisterResponse>().ReverseMap();




            //CreateMap<DailySales, DailySalesModel>().ReverseMap();
            //CreateMap<IncomeExpenses, IncomeExpensesModel>().ReverseMap();
        }
    }
}
