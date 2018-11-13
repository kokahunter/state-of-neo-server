﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StateOfNeo.Data;

namespace StateOfNeo.Data.Migrations
{
    [DbContext(typeof(StateOfNeoContext))]
    partial class StateOfNeoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("StateOfNeo.Data.Models.Address", b =>
                {
                    b.Property<string>("PublicAddress")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedOn");

                    b.Property<DateTime>("FirstTransactionOn");

                    b.Property<DateTime>("LastTransactionOn");

                    b.HasKey("PublicAddress");

                    b.HasIndex("LastTransactionOn");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("StateOfNeo.Data.Models.AddressAssetBalance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AddressPublicAddress");

                    b.Property<int>("AssetId");

                    b.Property<decimal>("Balance")
                        .HasColumnType("decimal(26, 9)");

                    b.Property<DateTime>("CreatedOn");

                    b.HasKey("Id");

                    b.HasIndex("AddressPublicAddress");

                    b.HasIndex("AssetId");

                    b.ToTable("AddressBalances");
                });

            modelBuilder.Entity("StateOfNeo.Data.Models.Asset", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedOn");

                    b.Property<long>("CurrentSupply");

                    b.Property<int>("Decimals");

                    b.Property<byte?>("GlobalType");

                    b.Property<string>("Hash");

                    b.Property<long>("MaxSupply");

                    b.Property<string>("Name");

                    b.Property<string>("Symbol");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.ToTable("Assets");
                });

            modelBuilder.Entity("StateOfNeo.Data.Models.Block", b =>
                {
                    b.Property<string>("Hash")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("ConsensusData")
                        .HasConversion(new ValueConverter<decimal, decimal>(v => default(decimal), v => default(decimal), new ConverterMappingHints(precision: 20, scale: 0)));

                    b.Property<DateTime>("CreatedOn");

                    b.Property<int>("Height");

                    b.Property<string>("InvocationScript");

                    b.Property<string>("NextConsensusNodeAddress");

                    b.Property<string>("PreviousBlockHash");

                    b.Property<int>("Size");

                    b.Property<double>("TimeInSeconds");

                    b.Property<long>("Timestamp");

                    b.Property<string>("Validator");

                    b.Property<string>("VerificationScript");

                    b.HasKey("Hash");

                    b.HasIndex("Height");

                    b.HasIndex("PreviousBlockHash");

                    b.HasIndex("Timestamp");

                    b.ToTable("Blocks");
                });

            modelBuilder.Entity("StateOfNeo.Data.Models.Node", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedOn");

                    b.Property<long?>("FirstRuntime");

                    b.Property<string>("FlagUrl");

                    b.Property<int?>("Height");

                    b.Property<bool>("IsHttps");

                    b.Property<long?>("LastAudit");

                    b.Property<long?>("LatestRuntime");

                    b.Property<double?>("Latitude");

                    b.Property<string>("Locale");

                    b.Property<string>("Location");

                    b.Property<double?>("Longitude");

                    b.Property<int?>("MemoryPool");

                    b.Property<string>("Net");

                    b.Property<int?>("Peers");

                    b.Property<string>("Protocol");

                    b.Property<long>("SecondsOnline");

                    b.Property<string>("SuccessUrl");

                    b.Property<int>("Type");

                    b.Property<string>("Url");

                    b.Property<string>("Version");

                    b.HasKey("Id");

                    b.ToTable("Nodes");
                });

            modelBuilder.Entity("StateOfNeo.Data.Models.NodeAddress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ip");

                    b.Property<int>("NodeId");

                    b.Property<long?>("Port");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.HasIndex("NodeId");

                    b.ToTable("NodeAddresses");
                });

            modelBuilder.Entity("StateOfNeo.Data.Models.NodeAudit", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedOn");

                    b.Property<int>("Latency");

                    b.Property<int>("NodeId");

                    b.Property<decimal>("Peers")
                        .HasColumnType("decimal(26, 9)");

                    b.Property<long>("Timestamp");

                    b.HasKey("Id");

                    b.HasIndex("NodeId");

                    b.HasIndex("Timestamp");

                    b.ToTable("NodeAudits");
                });

            modelBuilder.Entity("StateOfNeo.Data.Models.NodeStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BlockHash");

                    b.Property<int>("BlockId");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<bool>("IsP2pTcpOnline");

                    b.Property<bool>("IsP2pWsOnline");

                    b.Property<bool>("IsRpcOnline");

                    b.Property<int>("NodeId");

                    b.HasKey("Id");

                    b.HasIndex("BlockHash");

                    b.HasIndex("NodeId");

                    b.ToTable("NodeStatusUpdates");
                });

            modelBuilder.Entity("StateOfNeo.Data.Models.Transactions.EnrollmentTransaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("PublicKey");

                    b.Property<int>("TransactionId");

                    b.HasKey("Id");

                    b.ToTable("EnrollmentTransactions");
                });

            modelBuilder.Entity("StateOfNeo.Data.Models.Transactions.InvocationTransaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedOn");

                    b.Property<decimal>("Gas")
                        .HasColumnType("decimal(26, 9)");

                    b.Property<string>("ScriptAsHexString");

                    b.Property<int>("TransactionId");

                    b.HasKey("Id");

                    b.ToTable("InvocationTransactions");
                });

            modelBuilder.Entity("StateOfNeo.Data.Models.Transactions.MinerTransaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedOn");

                    b.Property<long>("Nonce");

                    b.Property<int>("TransactionId");

                    b.HasKey("Id");

                    b.ToTable("MinerTransaction");
                });

            modelBuilder.Entity("StateOfNeo.Data.Models.Transactions.PublishTransaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Author");

                    b.Property<string>("CodeVersion");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Description");

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<bool>("NeedStorage");

                    b.Property<string>("ParameterList");

                    b.Property<string>("ReturnType");

                    b.Property<string>("ScriptAsHexString");

                    b.Property<int>("TransactionId");

                    b.HasKey("Id");

                    b.ToTable("PublishTransactions");
                });

            modelBuilder.Entity("StateOfNeo.Data.Models.Transactions.RegisterTransaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AdminAddress");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(26, 9)");

                    b.Property<byte>("AssetType");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Name");

                    b.Property<string>("OwnerPublicKey");

                    b.Property<byte>("Precision");

                    b.Property<int>("TransactionId");

                    b.HasKey("Id");

                    b.ToTable("RegisterTransactions");
                });

            modelBuilder.Entity("StateOfNeo.Data.Models.Transactions.StateDescriptor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Field");

                    b.Property<string>("KeyAsHexString");

                    b.Property<int>("TransactionId");

                    b.Property<byte>("Type");

                    b.Property<string>("ValueAsHexString");

                    b.HasKey("Id");

                    b.HasIndex("TransactionId");

                    b.ToTable("StateDescriptors");
                });

            modelBuilder.Entity("StateOfNeo.Data.Models.Transactions.StateTransaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedOn");

                    b.Property<int>("TransactionId");

                    b.HasKey("Id");

                    b.ToTable("StateTransactions");
                });

            modelBuilder.Entity("StateOfNeo.Data.Models.Transactions.TransactedAsset", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(26, 9)");

                    b.Property<int>("AssetId");

                    b.Property<int>("AssetType");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("FromAddressPublicAddress");

                    b.Property<string>("InGlobalTransactionScriptHash");

                    b.Property<string>("OutGlobalTransactionScriptHash");

                    b.Property<string>("ToAddressPublicAddress");

                    b.Property<string>("TransactionScriptHash");

                    b.HasKey("Id");

                    b.HasIndex("AssetId");

                    b.HasIndex("FromAddressPublicAddress");

                    b.HasIndex("InGlobalTransactionScriptHash");

                    b.HasIndex("OutGlobalTransactionScriptHash");

                    b.HasIndex("ToAddressPublicAddress");

                    b.HasIndex("TransactionScriptHash");

                    b.ToTable("TransactedAssets");
                });

            modelBuilder.Entity("StateOfNeo.Data.Models.Transactions.Transaction", b =>
                {
                    b.Property<string>("ScriptHash")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BlockId");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<int?>("EnrollmentTransactionId");

                    b.Property<int?>("InvocationTransactionId");

                    b.Property<int?>("MinerTransactionId");

                    b.Property<decimal>("NetworkFee")
                        .HasColumnType("decimal(26, 9)");

                    b.Property<int?>("PublishTransactionId");

                    b.Property<int?>("RegisterTransactionId");

                    b.Property<int>("Size");

                    b.Property<int?>("StateTransactionId");

                    b.Property<decimal>("SystemFee")
                        .HasColumnType("decimal(26, 9)");

                    b.Property<long>("Timestamp");

                    b.Property<byte>("Type");

                    b.Property<int>("Version");

                    b.HasKey("ScriptHash");

                    b.HasIndex("BlockId");

                    b.HasIndex("EnrollmentTransactionId")
                        .IsUnique()
                        .HasFilter("[EnrollmentTransactionId] IS NOT NULL");

                    b.HasIndex("InvocationTransactionId")
                        .IsUnique()
                        .HasFilter("[InvocationTransactionId] IS NOT NULL");

                    b.HasIndex("MinerTransactionId")
                        .IsUnique()
                        .HasFilter("[MinerTransactionId] IS NOT NULL");

                    b.HasIndex("PublishTransactionId")
                        .IsUnique()
                        .HasFilter("[PublishTransactionId] IS NOT NULL");

                    b.HasIndex("RegisterTransactionId")
                        .IsUnique()
                        .HasFilter("[RegisterTransactionId] IS NOT NULL");

                    b.HasIndex("StateTransactionId")
                        .IsUnique()
                        .HasFilter("[StateTransactionId] IS NOT NULL");

                    b.HasIndex("Timestamp");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("StateOfNeo.Data.Models.Transactions.TransactionAttribute", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("DataAsHexString");

                    b.Property<int>("TransactionId");

                    b.Property<string>("TransactionScriptHash");

                    b.Property<int>("Usage");

                    b.HasKey("Id");

                    b.HasIndex("TransactionScriptHash");

                    b.ToTable("TransactionAttributes");
                });

            modelBuilder.Entity("StateOfNeo.Data.Models.Transactions.TransactionWitness", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("InvocationScriptAsHexString");

                    b.Property<int>("TransactionId");

                    b.Property<string>("TransactionScriptHash");

                    b.Property<string>("VerificationScriptAsHexString");

                    b.HasKey("Id");

                    b.HasIndex("TransactionScriptHash");

                    b.ToTable("TransactionWitnesses");
                });

            modelBuilder.Entity("StateOfNeo.Data.Models.AddressAssetBalance", b =>
                {
                    b.HasOne("StateOfNeo.Data.Models.Address", "Address")
                        .WithMany("Balances")
                        .HasForeignKey("AddressPublicAddress");

                    b.HasOne("StateOfNeo.Data.Models.Asset", "Asset")
                        .WithMany("Balances")
                        .HasForeignKey("AssetId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("StateOfNeo.Data.Models.Block", b =>
                {
                    b.HasOne("StateOfNeo.Data.Models.Block", "PreviousBlock")
                        .WithMany()
                        .HasForeignKey("PreviousBlockHash");
                });

            modelBuilder.Entity("StateOfNeo.Data.Models.NodeAddress", b =>
                {
                    b.HasOne("StateOfNeo.Data.Models.Node", "Node")
                        .WithMany("NodeAddresses")
                        .HasForeignKey("NodeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("StateOfNeo.Data.Models.NodeAudit", b =>
                {
                    b.HasOne("StateOfNeo.Data.Models.Node", "Node")
                        .WithMany("Audits")
                        .HasForeignKey("NodeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("StateOfNeo.Data.Models.NodeStatus", b =>
                {
                    b.HasOne("StateOfNeo.Data.Models.Block", "Block")
                        .WithMany("NodeStatusUpdates")
                        .HasForeignKey("BlockHash");

                    b.HasOne("StateOfNeo.Data.Models.Node", "Node")
                        .WithMany("NodeStatusUpdates")
                        .HasForeignKey("NodeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("StateOfNeo.Data.Models.Transactions.StateDescriptor", b =>
                {
                    b.HasOne("StateOfNeo.Data.Models.Transactions.StateTransaction", "Transaction")
                        .WithMany("Descriptors")
                        .HasForeignKey("TransactionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("StateOfNeo.Data.Models.Transactions.TransactedAsset", b =>
                {
                    b.HasOne("StateOfNeo.Data.Models.Asset", "Asset")
                        .WithMany("TransactedAssets")
                        .HasForeignKey("AssetId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("StateOfNeo.Data.Models.Address", "FromAddress")
                        .WithMany("OutgoingTransactions")
                        .HasForeignKey("FromAddressPublicAddress");

                    b.HasOne("StateOfNeo.Data.Models.Transactions.Transaction", "InGlobalTransaction")
                        .WithMany("GlobalIncomingAssets")
                        .HasForeignKey("InGlobalTransactionScriptHash");

                    b.HasOne("StateOfNeo.Data.Models.Transactions.Transaction", "OutGlobalTransaction")
                        .WithMany("GlobalOutgoingAssets")
                        .HasForeignKey("OutGlobalTransactionScriptHash");

                    b.HasOne("StateOfNeo.Data.Models.Address", "ToAddress")
                        .WithMany("IncomingTransactions")
                        .HasForeignKey("ToAddressPublicAddress");

                    b.HasOne("StateOfNeo.Data.Models.Transactions.Transaction", "Transaction")
                        .WithMany("Assets")
                        .HasForeignKey("TransactionScriptHash");
                });

            modelBuilder.Entity("StateOfNeo.Data.Models.Transactions.Transaction", b =>
                {
                    b.HasOne("StateOfNeo.Data.Models.Block", "Block")
                        .WithMany("Transactions")
                        .HasForeignKey("BlockId");

                    b.HasOne("StateOfNeo.Data.Models.Transactions.EnrollmentTransaction", "EnrollmentTransaction")
                        .WithOne("Transaction")
                        .HasForeignKey("StateOfNeo.Data.Models.Transactions.Transaction", "EnrollmentTransactionId");

                    b.HasOne("StateOfNeo.Data.Models.Transactions.InvocationTransaction", "InvocationTransaction")
                        .WithOne("Transaction")
                        .HasForeignKey("StateOfNeo.Data.Models.Transactions.Transaction", "InvocationTransactionId");

                    b.HasOne("StateOfNeo.Data.Models.Transactions.MinerTransaction", "MinerTransaction")
                        .WithOne("Transaction")
                        .HasForeignKey("StateOfNeo.Data.Models.Transactions.Transaction", "MinerTransactionId");

                    b.HasOne("StateOfNeo.Data.Models.Transactions.PublishTransaction", "PublishTransaction")
                        .WithOne("Transaction")
                        .HasForeignKey("StateOfNeo.Data.Models.Transactions.Transaction", "PublishTransactionId");

                    b.HasOne("StateOfNeo.Data.Models.Transactions.RegisterTransaction", "RegisterTransaction")
                        .WithOne("Transaction")
                        .HasForeignKey("StateOfNeo.Data.Models.Transactions.Transaction", "RegisterTransactionId");

                    b.HasOne("StateOfNeo.Data.Models.Transactions.StateTransaction", "StateTransaction")
                        .WithOne("Transaction")
                        .HasForeignKey("StateOfNeo.Data.Models.Transactions.Transaction", "StateTransactionId");
                });

            modelBuilder.Entity("StateOfNeo.Data.Models.Transactions.TransactionAttribute", b =>
                {
                    b.HasOne("StateOfNeo.Data.Models.Transactions.Transaction", "Transaction")
                        .WithMany("Attributes")
                        .HasForeignKey("TransactionScriptHash");
                });

            modelBuilder.Entity("StateOfNeo.Data.Models.Transactions.TransactionWitness", b =>
                {
                    b.HasOne("StateOfNeo.Data.Models.Transactions.Transaction", "Transaction")
                        .WithMany("Witnesses")
                        .HasForeignKey("TransactionScriptHash");
                });
#pragma warning restore 612, 618
        }
    }
}
