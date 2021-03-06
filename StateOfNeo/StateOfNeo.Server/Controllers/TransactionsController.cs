﻿using Microsoft.AspNetCore.Mvc;
using Neo.Network.P2P.Payloads;
using Serilog;
using StateOfNeo.Common;
using StateOfNeo.Common.Constants;
using StateOfNeo.Common.Enums;
using StateOfNeo.Common.Extensions;
using StateOfNeo.Server.Actors;
using StateOfNeo.Services;
using StateOfNeo.Services.Transaction;
using StateOfNeo.ViewModels.Chart;
using StateOfNeo.ViewModels.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StateOfNeo.Server.Controllers
{
    public class TransactionsController : BaseApiController
    {
        private readonly IPaginatingService paginating;
        private readonly ITransactionService transactions;
        private readonly IStateService state;

        public TransactionsController(
            IPaginatingService paginating,
            ITransactionService transactions,
            IStateService state)
        {
            this.paginating = paginating;
            this.transactions = transactions;
            this.state = state;
        }

        [HttpGet("[action]/{hash}")]
        [ResponseCache(Duration = CachingConstants.TenYears)]
        public IActionResult Get(string hash)
        {
            var transaction = this.transactions.Find<TransactionDetailsViewModel>(hash);
            if (transaction == null)
            {
                return this.BadRequest("Invalid block hash");
            }

            return this.Ok(transaction);
        }

        [HttpGet("[action]/{hash}")]
        [ResponseCache(Duration = CachingConstants.TenYears)]
        public IActionResult GetAssets(string hash)
        {
            var transaction = this.transactions.Find<TransactionAssetsViewModel>(hash);
            if (transaction == null)
            {
                return this.BadRequest("Invalid block hash");
            }

            return this.Ok(transaction);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> List(
            int page = 1, 
            int pageSize = 10, 
            string blockHash = null, 
            string address = null, 
            string asset = null, 
            string type = null)
        {
            if (!string.IsNullOrEmpty(address))
            {
                var res = this.transactions.TransactionsForAddress(address, page, pageSize);
                return this.Ok(res.ToListResult());
            }

            if (!string.IsNullOrEmpty(asset))
            {
                var sw = System.Diagnostics.Stopwatch.StartNew();
                var res = this.transactions.TransactionsForAsset(asset, page, pageSize);
                sw.Stop();
                Log.Information($"{this.GetType().FullName} from List - ${sw.ElapsedMilliseconds}");
                return this.Ok(res.ToListResult());
            }

            if (!string.IsNullOrEmpty(blockHash))
            {
                var result = this.transactions.GetPageTransactions<TransactionListViewModel>(page, pageSize, blockHash);
                return this.Ok(result.ToListResult());
            }

            if (page * pageSize <= StateService.CachedTransactionsCount)
            {
                var data = this.state.GetTransactionsPage(page, pageSize, type);
                var result = data.ToListResult();

                if (string.IsNullOrEmpty(type))
                {
                    var extended = PagedListMetadataExtended.FromParent(result.MetaData);
                    var pages = extended.TotalItemCount % pageSize == 0 
                        ? extended.TotalItemCount / pageSize 
                        : extended.TotalItemCount / pageSize + 1;

                    extended.TotalItemCount = (int)this.state.MainStats.TotalStats.TransactionsCount;
                    extended.PageCount = pages;
                    result.MetaData = extended;
                }

                return this.Ok(result);
            }
            else
            {
                var result = this.transactions.GetPageTransactions<TransactionListViewModel>(page, pageSize, type: type);                
                return this.Ok(result.ToListResult());
            }
        }

        [HttpPost("[action]")]
        [ResponseCache(Duration = CachingConstants.Hour)]
        public IActionResult Chart([FromBody]ChartFilterViewModel filter)
        {
            //var result = this.transactions.GetStats(filter);
            var result = this.state.GetTransactionsChart(filter.UnitOfTime, filter.EndPeriod);
            return this.Ok(result);
        }
        
        [HttpPost("[action]")]
        [ResponseCache(Duration = CachingConstants.Hour)]
        public IActionResult AddressChart([FromBody]ChartFilterViewModel filter, string address)
        {
            var result = this.transactions.GetTransactionsForAddressChart(filter, address);
            return this.Ok(result);
        }

        [HttpPost("[action]")]
        [ResponseCache(Duration = CachingConstants.Hour)]
        public IActionResult AssetChart([FromBody]ChartFilterViewModel filter, string assetHash)
        {
            var result = this.transactions.GetTransactionsForAssetChart(filter, assetHash);
            return this.Ok(result);
        } 

        [HttpGet("[action]")]
        public IActionResult TransactionTypesForAddress(string address)
        {
            var result = this.transactions.GetTransactionTypesForAddress(address);
            return this.Ok(result);
        }

        [HttpGet("[action]")]
        [ResponseCache(Duration = CachingConstants.Hour)]
        public IActionResult PieChart()
        {
            //IEnumerable<ChartStatsViewModel> result = this.transactions.GetPieStats();
            var result = this.state.GetTransactionTypes();
            return this.Ok(result);
        }

        [HttpGet("[action]")]
        [ResponseCache(Duration = CachingConstants.Hour)]
        public IActionResult AveragePer([FromQuery]UnitOfTime unit = UnitOfTime.Day)
        {
            return this.Ok(this.transactions.AveragePer(unit));
        }

        [HttpGet("[action]")]
        public IActionResult Total()
        {
            return this.Ok(this.state.MainStats.GetTotalTxCount());
        }

        [HttpGet("[action]")]
        public IActionResult TotalClaimed()
        {
            return this.Ok(this.state.MainStats.GetTotalClaimed());
        }
    }
}
