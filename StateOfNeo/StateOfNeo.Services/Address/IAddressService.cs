﻿using StateOfNeo.Common.Enums;
using StateOfNeo.ViewModels.Address;
using StateOfNeo.ViewModels.Chart;
using System;
using System.Collections.Generic;
using System.Text;

namespace StateOfNeo.Services.Address
{
    public interface IAddressService
    {
        int ActiveAddressesInThePastThreeMonths();

        int CreatedAddressesPer(UnitOfTime timePeriod);

        int CreatedAddressesCount();

        IEnumerable<ChartStatsViewModel> GetStats(ChartFilterViewModel filter);

        IEnumerable<PublicAddressListViewModel> TopOneHundredNeo();

        IEnumerable<PublicAddressListViewModel> TopOneHundredGas();
    }
}
