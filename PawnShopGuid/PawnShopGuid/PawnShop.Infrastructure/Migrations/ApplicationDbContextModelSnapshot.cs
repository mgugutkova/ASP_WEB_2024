﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PawnShop.Infrastructure.Data;

#nullable disable

namespace PawnShop.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("PawnShop.Infrastructure.Data.Model.Agreement", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Идентификатор на договора");

                    b.Property<int>("AgrreementStateId")
                        .HasColumnType("int")
                        .HasComment("Статус на договора");

                    b.Property<decimal>("Ainterest")
                        .HasColumnType("decimal(18,2)")
                        .HasComment("Лихва");

                    b.Property<Guid?>("ClientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Описание");

                    b.Property<int>("Duration")
                        .HasColumnType("int")
                        .HasComment("Срок на договора");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2")
                        .HasComment("Крайна дата на договора");

                    b.Property<string>("GoodName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Стока");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasComment("SoftDeleted");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)")
                        .HasComment("Заложна стойност");

                    b.Property<decimal>("ReturnPrice")
                        .HasColumnType("decimal(18,2)")
                        .HasComment("Стойност за връщане");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2")
                        .HasComment("Начална дата на договора");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasComment("Идентификатор на потребителя");

                    b.HasKey("Id");

                    b.HasIndex("AgrreementStateId");

                    b.HasIndex("ClientId");

                    b.HasIndex("UserId");

                    b.ToTable("Agreements");

                    b.HasData(
                        new
                        {
                            Id = new Guid("dca08201-5d45-46a7-8e97-7050c17b7fe9"),
                            AgrreementStateId = 2,
                            Ainterest = 3m,
                            Description = "used - produced 2012",
                            Duration = 30,
                            EndDate = new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GoodName = "SONY TV",
                            IsDeleted = false,
                            Price = 100m,
                            ReturnPrice = 103m,
                            StartDate = new DateTime(2024, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = "5cf194c7-b26e-42ed-8efd-d98c7980373b"
                        },
                        new
                        {
                            Id = new Guid("7bee2aba-cd40-4d44-b9e0-52759e2eacd6"),
                            AgrreementStateId = 1,
                            Ainterest = 1m,
                            Description = "4GB RAM, 120SSD",
                            Duration = 10,
                            EndDate = new DateTime(2024, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GoodName = "лаптоп Acer",
                            IsDeleted = false,
                            Price = 200m,
                            ReturnPrice = 201m,
                            StartDate = new DateTime(2024, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = "ffae7662-4ff3-4698-8f36-c4e4f392da18"
                        },
                        new
                        {
                            Id = new Guid("d71c98e0-c86b-4215-914e-1917e1da023e"),
                            AgrreementStateId = 5,
                            Ainterest = 0m,
                            Description = "model Balkan",
                            Duration = 30,
                            EndDate = new DateTime(2024, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GoodName = "Bike",
                            IsDeleted = false,
                            Price = 30m,
                            ReturnPrice = 33m,
                            StartDate = new DateTime(2024, 11, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = "5cf194c7-b26e-42ed-8efd-d98c7980373b"
                        });
                });

            modelBuilder.Entity("PawnShop.Infrastructure.Data.Model.AgreementState", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Идентификатор на статус");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasComment("Име на статуса");

                    b.HasKey("Id");

                    b.ToTable("AgreementStates");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Аwaiting approval"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Approved (Active)"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Finished"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Late"
                        },
                        new
                        {
                            Id = 5,
                            Name = "For а Shop"
                        });
                });

            modelBuilder.Entity("PawnShop.Infrastructure.Data.Model.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "ffae7662-4ff3-4698-8f36-c4e4f392da18",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "f188b077-4bed-4e86-9f16-b8aeb6f3683c",
                            Email = "ksef@abv.bg",
                            EmailConfirmed = false,
                            FirstName = "Kalin",
                            LastName = "Sarafov",
                            LockoutEnabled = false,
                            NormalizedEmail = "KSEF@ABV.BG",
                            NormalizedUserName = "KSEF@ABV.BG",
                            PasswordHash = "AQAAAAIAAYagAAAAENS9TIq0+JOxgASEilVEPIO85JQKbbHc4G7MlB/rr1EQsnN+hBIfKR6kQngAkQT7Jw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "825818b9-f318-4453-a750-05e47f57c5cf",
                            TwoFactorEnabled = false,
                            UserName = "ksef@abv.bg"
                        },
                        new
                        {
                            Id = "5cf194c7-b26e-42ed-8efd-d98c7980373b",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "1f47fa9d-1583-4653-a642-f1658bb1d041",
                            Email = "msef@abv.bg",
                            EmailConfirmed = false,
                            FirstName = "Mary",
                            LastName = "Seferov",
                            LockoutEnabled = false,
                            NormalizedEmail = "MSEF@ABV.BG",
                            NormalizedUserName = "MSEF@ABV.BG",
                            PasswordHash = "AQAAAAIAAYagAAAAEIl8GW0GAe1rQF8zIFP4//MBHk1Y5BgB5W8rV67yj1250V2kyk72wuuC3s6w2OE0Rg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "5b2ea4f1-1de2-42a6-8816-d5cd67037f2c",
                            TwoFactorEnabled = false,
                            UserName = "msef@abv.bg"
                        },
                        new
                        {
                            Id = "b97f29e7-1edd-4666-a8d8-8882858d7ccf",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "327e3e8f-7fe2-43ad-b6dc-763e6c65ee07",
                            Email = "admin@abv.bg",
                            EmailConfirmed = false,
                            FirstName = "Admin",
                            LastName = "Boss",
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@ABV.BG",
                            NormalizedUserName = "ADMIN@ABV.BG",
                            PasswordHash = "AQAAAAIAAYagAAAAENNaJEY2des0AzyDtTRI1t8w6ZZsHoKwREWSxTvDknARLirZsjEYRFXB+w2yCmlSfA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "914dabc7-6fa3-41fb-8401-ead8f7487bf4",
                            TwoFactorEnabled = false,
                            UserName = "admin@abv.bg"
                        },
                        new
                        {
                            Id = "70e39283-bd42-4d0a-aa2e-46d2a31c4f87",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "6be15968-1ff7-4eb0-98b3-ff264a994678",
                            Email = "guest@abv.bg",
                            EmailConfirmed = false,
                            FirstName = "Guest",
                            LastName = "Guestov",
                            LockoutEnabled = false,
                            NormalizedEmail = "GUEST@ABV.BG",
                            NormalizedUserName = "GUEST@ABV.BG",
                            PasswordHash = "AQAAAAIAAYagAAAAEFLuqeSzKC74eoC1xdVQzSLAw62bDAwKGV+b34+TTi7kbO+x4ha1KNMUWBNNig+L0w==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "1e9c3156-ba33-4024-be93-ce7a89f13a7b",
                            TwoFactorEnabled = false,
                            UserName = "guest@abv.bg"
                        });
                });

            modelBuilder.Entity("PawnShop.Infrastructure.Data.Model.Client", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("PhoneNumber")
                        .IsUnique();

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Clients");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c7872079-c1c8-45fd-937d-12e721c3d877"),
                            Address = "Plovdiv,Izgrev",
                            IsDeleted = false,
                            PhoneNumber = "1234599999",
                            UserId = "ffae7662-4ff3-4698-8f36-c4e4f392da18"
                        },
                        new
                        {
                            Id = new Guid("01ead869-aa93-4c6a-a250-971e053007a5"),
                            Address = "Sofiq,Dianabad",
                            IsDeleted = false,
                            PhoneNumber = "1234567890",
                            UserId = "5cf194c7-b26e-42ed-8efd-d98c7980373b"
                        },
                        new
                        {
                            Id = new Guid("30c83814-2a9a-412e-bb47-79b0bbe52ec5"),
                            Address = "Varna,Center",
                            IsDeleted = false,
                            PhoneNumber = "8888899999",
                            UserId = "b97f29e7-1edd-4666-a8d8-8882858d7ccf"
                        });
                });

            modelBuilder.Entity("PawnShop.Infrastructure.Data.Model.Interest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Идентификатор на лихва");

                    b.Property<Guid>("AgreementId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Идентификатор на договора");

                    b.Property<DateTime>("DateInterest")
                        .HasColumnType("datetime2")
                        .HasComment("Дата на внасяне на лихвата");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasComment("SoftDeleted");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasComment("Идентификатор на потребителя");

                    b.Property<decimal>("ValueInterest")
                        .HasColumnType("decimal(18,2)")
                        .HasComment("Стойност на лихвата");

                    b.HasKey("Id");

                    b.HasIndex("AgreementId");

                    b.HasIndex("UserId");

                    b.ToTable("Interests");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d878db1c-db65-4120-bd81-de4cb4dc34e9"),
                            AgreementId = new Guid("dca08201-5d45-46a7-8e97-7050c17b7fe9"),
                            DateInterest = new DateTime(2025, 1, 2, 12, 42, 31, 740, DateTimeKind.Local).AddTicks(8754),
                            IsDeleted = false,
                            UserId = "5cf194c7-b26e-42ed-8efd-d98c7980373b",
                            ValueInterest = 3m
                        });
                });

            modelBuilder.Entity("PawnShop.Infrastructure.Data.Model.Shop", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Идентификатор на стоката в магазин");

                    b.Property<Guid>("AgreementId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Идентификатор на договора");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Допълнително описание - не е задължително");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasComment("SoftDeleted");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Име на стоката");

                    b.Property<decimal>("SellPrice")
                        .HasColumnType("decimal(18,2)")
                        .HasComment("Цена на стоката");

                    b.Property<DateTime?>("SoldDate")
                        .HasColumnType("datetime2")
                        .HasComment("Дата на продажба на стоката");

                    b.HasKey("Id");

                    b.HasIndex("AgreementId");

                    b.ToTable("Shop");

                    b.HasData(
                        new
                        {
                            Id = new Guid("71d22cba-64a5-489c-8166-aed8dd5d5a82"),
                            AgreementId = new Guid("d71c98e0-c86b-4215-914e-1917e1da023e"),
                            Description = "",
                            IsDeleted = false,
                            Name = "Bike",
                            SellPrice = 30m
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("PawnShop.Infrastructure.Data.Model.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("PawnShop.Infrastructure.Data.Model.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PawnShop.Infrastructure.Data.Model.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("PawnShop.Infrastructure.Data.Model.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PawnShop.Infrastructure.Data.Model.Agreement", b =>
                {
                    b.HasOne("PawnShop.Infrastructure.Data.Model.AgreementState", "AgrreementStates")
                        .WithMany()
                        .HasForeignKey("AgrreementStateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PawnShop.Infrastructure.Data.Model.Client", null)
                        .WithMany("Contracts")
                        .HasForeignKey("ClientId");

                    b.HasOne("PawnShop.Infrastructure.Data.Model.ApplicationUser", "Account")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("AgrreementStates");
                });

            modelBuilder.Entity("PawnShop.Infrastructure.Data.Model.Client", b =>
                {
                    b.HasOne("PawnShop.Infrastructure.Data.Model.ApplicationUser", "User")
                        .WithOne("Client")
                        .HasForeignKey("PawnShop.Infrastructure.Data.Model.Client", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("PawnShop.Infrastructure.Data.Model.Interest", b =>
                {
                    b.HasOne("PawnShop.Infrastructure.Data.Model.Agreement", "Agreement")
                        .WithMany("Interests")
                        .HasForeignKey("AgreementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PawnShop.Infrastructure.Data.Model.ApplicationUser", "Account")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Agreement");
                });

            modelBuilder.Entity("PawnShop.Infrastructure.Data.Model.Shop", b =>
                {
                    b.HasOne("PawnShop.Infrastructure.Data.Model.Agreement", "Agreement")
                        .WithMany()
                        .HasForeignKey("AgreementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Agreement");
                });

            modelBuilder.Entity("PawnShop.Infrastructure.Data.Model.Agreement", b =>
                {
                    b.Navigation("Interests");
                });

            modelBuilder.Entity("PawnShop.Infrastructure.Data.Model.ApplicationUser", b =>
                {
                    b.Navigation("Client");
                });

            modelBuilder.Entity("PawnShop.Infrastructure.Data.Model.Client", b =>
                {
                    b.Navigation("Contracts");
                });
#pragma warning restore 612, 618
        }
    }
}
