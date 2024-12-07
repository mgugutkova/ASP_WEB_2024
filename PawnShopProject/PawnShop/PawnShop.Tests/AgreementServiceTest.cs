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
                Id = 100,
                GoodName = "Test Added" ?? string.Empty,
                Description = "",
                UserId = "123",
                Price = 100.50M,
                Duration = 30
            });

            await repo.SaveChangesAsync();

            await agreementService.CreateAgreementAsync("123", "Test Added", "", 100.50M, 30);

            var dbAgreement = await repo.GetByIdAsync<Agreement>(100);

            Assert.That(dbAgreement.Id, Is.EqualTo(100));
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
                Id = 100,
                GoodName = "Test" ?? string.Empty,
                Description = "",
                AgrreementStateId = 1
            });

            await repo.SaveChangesAsync();

            await agreementService.EditAgreementAsync(100, new AddAgreementViewModel()
            {
                Id = 100,
                GoodName = "Test edited",
                Description = "",
                AgrreementStateId = 1
            });

            var dbAgreement = await repo.GetByIdAsync<Agreement>(100);

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
            new Agreement(){Id = 100, GoodName = "Test100" ?? string.Empty, Description = "",IsDeleted = false},
            new Agreement(){Id = 101, GoodName = "Test101" ?? string.Empty, Description = "",IsDeleted = true},
            new Agreement(){Id = 102, GoodName = "Test102" ?? string.Empty, Description = "",IsDeleted = false},
            });

            await repo.SaveChangesAsync();

            var agreementsList = await agreementService.AllAsync();

            Assert.That(5, Is.EqualTo(agreementsList.Count()));
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
                Id = 100,
                GoodName = "Test" ?? string.Empty,
                Description = "",
                IsDeleted = false
            });


            await repo.SaveChangesAsync();

            await agreementService.DeleteConfirmedAsync(100);

            var dbAgreement = await repo.GetByIdAsync<Agreement>(100);

            Assert.That(dbAgreement.IsDeleted, Is.EqualTo(true));
        }

        [TearDown]
        public void TearDown()
        {
            applicationDbContext.Dispose();
        }
    }
}