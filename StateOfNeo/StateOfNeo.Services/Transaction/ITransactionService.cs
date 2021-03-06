﻿using StateOfNeo.Common.Enums;
using StateOfNeo.ViewModels.Chart;
using StateOfNeo.ViewModels.Transaction;
using System.Collections.Generic;
using X.PagedList;

namespace StateOfNeo.Services.Transaction
{
    public interface ITransactionService
    {
        T Find<T>(string hash);

        IPagedList<T> GetPageTransactions<T>(int page = 1, int pageSize = 10, string blockHash = null, string type = null);
        
        IPagedList<TransactionListViewModel> TransactionsForAddress(string address, int page = 1, int pageSize = 10);
        IPagedList<TransactionListViewModel> TransactionsForAsset(string asset, int page = 1, int pageSize = 10);

        IEnumerable<ChartStatsViewModel> GetStats(ChartFilterViewModel filter);
        IEnumerable<ChartStatsViewModel> GetTransactionsForAssetChart(ChartFilterViewModel filter, string assetHash);
        IEnumerable<ChartStatsViewModel> GetTransactionsForAddressChart(ChartFilterViewModel filter, string address);
        IEnumerable<ChartStatsViewModel> GetPieStats();
        IEnumerable<ChartStatsViewModel> GetTransactionTypesForAddress(string address);

        double AveragePer(UnitOfTime unitOfTime);
        long Total();
        decimal TotalClaimed();
    }
}
