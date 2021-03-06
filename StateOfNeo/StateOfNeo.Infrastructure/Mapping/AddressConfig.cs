﻿using AutoMapper;
using StateOfNeo.Common.Extensions;
using StateOfNeo.Data.Models;
using StateOfNeo.ViewModels.Address;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StateOfNeo.Infrastructure.Mapping
{
    public class AddressConfig
    {
        internal static void InitMap(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Address, AddressListViewModel>()
                .ForMember(x => x.Address, opt => opt.MapFrom(x => x.PublicAddress))
                .ForMember(x => x.Created, opt => opt.MapFrom(x => x.FirstTransactionOn))
                .ForMember(x => x.Transactions, opt => opt.MapFrom(x => x.TransactionsCount))
                .ForMember(x => x.LastTransactionTime, opt => opt.MapFrom(x => x.LastTransactionOn.ToLocalTime()))
                .ReverseMap();

            cfg.CreateMap<AddressAssetBalance, AddressAssetViewModel>()
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Asset.Name))
                .ForMember(x => x.AssetType, opt => opt.MapFrom(x => x.Asset.Type.ToString()))
                .ReverseMap();

            cfg.CreateMap<Address, AddressDetailsViewModel>()
                .ForMember(x => x.Address, opt => opt.MapFrom(x => x.PublicAddress))
                .ForMember(x => x.Created, opt => opt.MapFrom(x => x.FirstTransactionOn))
                .ForMember(x => x.LastTransactionTime, opt => opt.MapFrom(x => x.LastTransactionOn.ToLocalTime()))
                .ReverseMap();
        }
    }
}
