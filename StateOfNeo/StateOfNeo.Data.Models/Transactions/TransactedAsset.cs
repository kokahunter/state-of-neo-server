﻿using StateOfNeo.Common.Enums;

namespace StateOfNeo.Data.Models.Transactions
{
    public class TransactedAsset : BaseEntity
    {
        public int Id { get; set; }

        public decimal Amount { get; set; }
        
        public AssetType AssetType { get; set; }
        
        public string FromAddressPublicAddress { get; set; }

        public virtual Address FromAddress { get; set; }

        public string ToAddressPublicAddress { get; set; }

        public virtual Address ToAddress { get; set; }

        public string TransactionHash { get; set; }

        public virtual Transaction Transaction { get; set; }

        public string InGlobalTransactionHash { get; set; }

        public virtual Transaction InGlobalTransaction { get; set; }

        public string OutGlobalTransactionHash { get; set; }

        public virtual Transaction OutGlobalTransaction { get; set; }

        public string AssetHash { get; set; }

        public virtual Asset Asset { get; set; }
    }
}
