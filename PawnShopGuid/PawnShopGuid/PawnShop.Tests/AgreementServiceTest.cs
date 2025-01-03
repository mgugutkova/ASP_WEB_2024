using Microsoft.Extensions.Logging;
using PawnShop.Core.Interfaces;
using PawnShop.Infrastructure.Data.Model;
using PawnShop.Infrastructure.Data.Repo;
using PawnShop.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Moq;
using PawnShop.Core.Services;
using PawnShop.Core.Models.Agreement;

namespace PawnShop.Tests
{
    [TestFixture]
    public class AgreementServiceTest
    {
        private IRepository repo;
        private ILogger<Agreement> logger;
        private IAgreementService agreementService;
        private ApplicationDbContext applicationDbContext;

        [SetUp]
        public void Setup()
        {
            var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("PawnShopDB")
                .Options;

            applicationDbContext = new ApplicationDbContext(dbContextOptions);

            applicationDbContext.Database.EnsureDeleted();
            applicationDbContext.Database.EnsureCreated();
        }



        [Test]
        public async Task TestAgreementAdded()
        {
            var loggerMock = new Mock<ILogger<AgreementService>>();

            var logger = loggerMock.Object;

            var repo = new Repository(applicationDbContext);

            agreementService = new AgreementService(repo, logger);

            var testAgreement = repo.AddAsync(new Agreement()
            {
                Id = Guid.Parse("fb6e9e41-e21e-4ede-8500-513f112104b3"),
                GoodName = "Test Added" ?? string.Empty,
                Description = "",
                UserId = "123",
                Price = 100.50M,
                Duration = 30
            });

            await repo.SaveChangesAsync();

            await agreementService.CreateAgreementAsync("123", "Test Added", "", 100.50M, 30);

            var dbAgreement = await repo.GetByIdAsync<Agreement>(Guid.Parse("fb6e9e41-e21e-4ede-8500-513f112104b3"));

            Assert.That(dbAgreement.Id, Is.EqualTo(Guid.Parse("fb6e9e41-e21e-4ede-8500-513f112104b3")));
        }

        [Test]
        public async Task TestAgreementEdit()
        {
            var loggerMock = new Mock<ILogger<AgreementService>>();

            var logger = loggerMock.Object;

            var repo = new Repository(applicationDbContext);

            agreementService = new AgreementService(repo, logger);

            var testAgreement = repo.AddAsync(new Agreement()
            {
                Id = Guid.Parse("fb6e9e41-e21e-4ede-8500-513f112104b3"),
                GoodName = "Test" ?? string.Empty,
                Description = "",
                AgrreementStateId = 1
            });

            await repo.SaveChangesAsync();

            await agreementService.EditAgreementAsync(Guid.Parse("fb6e9e41-e21e-4ede-8500-513f112104b3"), new AddAgreementViewModel()
            {
                Id = "fb6e9e41-e21e-4ede-8500-513f112104b3",
                GoodName = "Test edited",
                Description = "",
                AgrreementStateId = 1
            });

            var dbAgreement = await repo.GetByIdAsync<Agreement>(Guid.Parse("fb6e9e41-e21e-4ede-8500-513f112104b3"));

            Assert.That(dbAgreement.GoodName, Is.EqualTo("Test edited"));
        }



        [Test]
        public async Task TestAllAgreements()
        {
            var loggerMock = new Mock<ILogger<AgreementService>>();

            var logger = loggerMock.Object;

            var repo = new Repository(applicationDbContext);

            agreementService = new AgreementService(repo, logger);

            var testAgreements = repo.AddRangeAsync(new List<Agreement>()
            {
            new Agreement(){Id = Guid.Parse("57e71d8a-4680-4a79-9173-60f0ac21310a"), GoodName = "Test100" ?? string.Empty, Description = ""},
            new Agreement(){Id = Guid.Parse("bafc60b0-4082-48ed-b58a-21cac928eb11"), GoodName = "Test101" ?? string.Empty, Description = ""},
            new Agreement(){Id = Guid.Parse("4ae066e3-5622-4ba5-8a38-6eee24d4cdef"), GoodName = "Test102" ?? string.Empty, Description = ""}
            });

            await repo.SaveChangesAsync();

            var agreementsList = await agreementService.AllAsync();

            Assert.That(6, Is.EqualTo(agreementsList.Count()));
        }


        [Test]
        public async Task TestAgreementDeleted()
        {
            var loggerMock = new Mock<ILogger<AgreementService>>();

            var logger = loggerMock.Object;

            var repo = new Repository(applicationDbContext);

            agreementService = new AgreementService(repo, logger);

            var testAgreement = repo.AddAsync(new Agreement()
            {
                Id = Guid.Parse("fb6e9e41-e21e-4ede-8500-513f112104b3"),
                GoodName = "Test" ?? string.Empty,
                Description = "",
                IsDeleted = false
            });


            await repo.SaveChangesAsync();

            await agreementService.DeleteConfirmedAsync(Guid.Parse("fb6e9e41-e21e-4ede-8500-513f112104b3"));

            var dbAgreement = await repo.GetByIdAsync<Agreement>(Guid.Parse("fb6e9e41-e21e-4ede-8500-513f112104b3"));

            Assert.That(dbAgreement.IsDeleted, Is.EqualTo(true));
        }

        [TearDown]
        public void TearDown()
        {
            applicationDbContext.Dispose();
        }
    }
}