using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecsHub.Domain.Abstract;
using RecsHub.Domain.Entities;
using RecsHub.DTO.Request;
using RecsHub.DTO.Response;

namespace RecsHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseController<ProductController>
    {
        private readonly IProductRepository _product;
        private readonly IDailyStoreRecordRepository _dailyStore;
        private readonly ISalesItemRepository _salesItem;
        private readonly ISalesMasterRepository _salesMaster;
        private readonly IStockKeepingRepository _stockKeeping;
        private readonly IStoreRecordRepository _storeRecord;
        private readonly ISupplierRepository _supplier;
        private readonly ISupplyRecordRepository _supplyRecord;

        public ProductController(IProductRepository product, IDailyStoreRecordRepository dailyStore, ISalesMasterRepository salesMaster, ISalesItemRepository salesItem, IStockKeepingRepository stockKeeping,
            IStoreRecordRepository storeRecord, ISupplierRepository supplier, ISupplyRecordRepository supplyRecord)
        {
            _product = product;
            _dailyStore = dailyStore;
            _salesItem = salesItem;
            _salesMaster = salesMaster;
            _stockKeeping = stockKeeping;
            _storeRecord = storeRecord;
            _supplier = supplier;
            _supplyRecord = supplyRecord;
        }


        [HttpPost("uploadproduct")]
        //[Authorize(Roles = "Admin")]
        [Produces(typeof(List<ProductResponse>))]
        public async Task<IActionResult> UploadProduct([FromBody] List<ProductRequest> products)
        {
            try
            {
                var rt = new List<ProductResponse>();
                foreach (var item in products)
                {
                    var prod = _mapper.Map<Product>(item);
                    _product.Add(prod);
                    rt.Add(_mapper.Map<ProductResponse>(prod));
                }
                await _product.Save(User.Identity.Name, _accessor.ActionContext.HttpContext.Connection.RemoteIpAddress.ToString());
                return Ok(rt);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost("uploaddailystorerecord")]
        [Produces(typeof(List<DailyStoreRecordResponse>))]
        public async Task<IActionResult> UploadDailyStoreRecord([FromBody] List<DailyStoreRecordRequest> items)
        {
            try
            {
                var rt = new List<DailyStoreRecordResponse>();
                foreach (var item in items)
                {
                    var obj = _mapper.Map<DailyStoreRecord>(item);
                    _dailyStore.Add(obj);
                    rt.Add(_mapper.Map<DailyStoreRecordResponse>(obj));
                }

                await _product.Save(User.Identity.Name, _accessor.ActionContext.HttpContext.Connection.RemoteIpAddress.ToString());
                return Ok(rt);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost("uploadsalesitem")]
        [Produces(typeof(List<SalesItemResponse>))]
        public async Task<IActionResult> UploadSalesItem([FromBody] List<SalesItemRequest> items)
        {
            try
            {
                var rt = new List<SalesItemResponse>();
                foreach (var item in items)
                {
                    var obj = _mapper.Map<SalesItem>(item);
                    _salesItem.Add(obj);
                    rt.Add(_mapper.Map<SalesItemResponse>(obj));
                }

                await _salesItem.Save(User.Identity.Name, _accessor.ActionContext.HttpContext.Connection.RemoteIpAddress.ToString());
                return Ok(rt);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost("uploadsalesmaster")]
        [Produces(typeof(List<SalesMasterResponse>))]
        public async Task<IActionResult> UploadSalesMaster([FromBody] List<SalesMasterRequest> items)
        {
            try
            {
                var rt = new List<SalesMasterResponse>();
                foreach (var item in items)
                {
                    var obj = _mapper.Map<SalesMaster>(item);
                    _salesMaster.Add(obj);
                    rt.Add(_mapper.Map<SalesMasterResponse>(obj));
                }

                await _salesMaster.Save(User.Identity.Name, _accessor.ActionContext.HttpContext.Connection.RemoteIpAddress.ToString());
                return Ok(rt);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }


        [HttpPost("uploadstockkeeping")]
        [Produces(typeof(List<StockKeepingResponse>))]
        public async Task<IActionResult> UploadStockKeeping([FromBody] List<StockKeepingRequest> items)
        {
            try
            {
                var rt = new List<StockKeepingResponse>();
                foreach (var item in items)
                {
                    var obj = _mapper.Map<StockKeeping>(item);
                    _stockKeeping.Add(obj);
                    rt.Add(_mapper.Map<StockKeepingResponse>(obj));
                }

                await _stockKeeping.Save(User.Identity.Name, _accessor.ActionContext.HttpContext.Connection.RemoteIpAddress.ToString());
                return Ok(rt);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost("uploadstorerecord")]
        [Produces(typeof(List<StoreRecordResponse>))]
        public async Task<IActionResult> UploadStoreRecord([FromBody] List<StoreRecordRequest> items)
        {
            try
            {
                var rt = new List<StoreRecordResponse>();
                foreach (var item in items)
                {
                    var obj = _mapper.Map<StoreRecord>(item);
                    _storeRecord.Add(obj);
                    rt.Add(_mapper.Map<StoreRecordResponse>(obj));
                }

                await _storeRecord.Save(User.Identity.Name, _accessor.ActionContext.HttpContext.Connection.RemoteIpAddress.ToString());
                return Ok(rt);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost("uploadsuppliers")]
        [Produces(typeof(List<SupplierResponse>))]
        public async Task<IActionResult> UploadSuppliers([FromBody] List<SupplierRequest> items)
        {
            try
            {
                var rt = new List<SupplierResponse>();
                foreach (var item in items)
                {
                    var obj = _mapper.Map<Supplier>(item);
                    _supplier.Add(obj);
                    rt.Add(_mapper.Map<SupplierResponse>(obj));
                }

                await _supplier.Save(User.Identity.Name, _accessor.ActionContext.HttpContext.Connection.RemoteIpAddress.ToString());
                return Ok(rt);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost("uploadsupplyrecords")]
        [Produces(typeof(List<SupplyRecordResponse>))]
        public async Task<IActionResult> UploadSupplyRecords([FromBody] List<SupplyRecordRequest> items)
        {
            try
            {
                var rt = new List<SupplyRecordResponse>();
                foreach (var item in items)
                {
                    var obj = _mapper.Map<SupplyRecord>(item);
                    _supplyRecord.Add(obj);
                    rt.Add(_mapper.Map<SupplyRecordResponse>(obj));
                }

                await _supplyRecord.Save(User.Identity.Name, _accessor.ActionContext.HttpContext.Connection.RemoteIpAddress.ToString());
                return Ok(rt);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

    }
}