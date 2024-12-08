using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using PawnShop.Core.Interfaces;
using PawnShop.Core.Services;
using PawnShop.Infrastructure.Data;
using PawnShop.Infrastructure.Data.Model;
using PawnShop.Infrastructure.Data.Repo;

namespace PawnShop.Tests
{
    [TestFixture]
    public class InterestServiceTests
    {
        private IRepository repo;
        private ILogger<Agreement> logger;
        private IInterestService interestService;
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
        public async Task TestInterestAdded()
        {
            var loggerMock = new Mock<ILogger<InterestService>>();

            var logger = loggerMock.Object;

            var repo = new Repository(applicationDbContext);

            interestService = new InterestService(repo, logger);

            var testInterest = repo.AddAsync(new Interest()
            {
                Id = 200,
                AgreementId = 1,
                ValueInterest = 50,
                UserId = "123"
            });

            await repo.SaveChangesAsync();

            await interestService.AddInterestAsync(1, "123");

            var dbInterest = await repo.GetByIdAsync<Interest>(200);

            Assert.That(dbInterest.Id, Is.EqualTo(200));
        }


        //[Test]
        //public async Task TestAllInterests()
        //{
        //    var loggerMock = new Mock<ILogger<InterestService>>();

        //    var logger = loggerMock.Object;

        //    var repo = new Repository(applicationDbContext);

        //    interestService = new InterestService(repo, logger);

        //    var testInterests = repo.AddRangeAsync(new List<Interest>()
        //    {
        //    new Interest(){Id = 100, AgreementId = 2, ValueInterest = 10, DateInterest = DateTime.Now},
        //    new Interest(){Id = 101, AgreementId = 2, ValueInterest = 20, DateInterest = DateTime.Now},
        //    new Interest(){Id = 102, AgreementId = 2, ValueInterest = 30, DateInterest = DateTime.Now}
        //    });

        //    await repo.SaveChangesAsync();

        //    var interestsList = await interestService.GetAllInterestsAsync(2);

        //    Assert.That(3, Is.EqualTo(interestsList.Count()));
        //}


        [Test]
        public async Task TestInterestDeleted()
        {
            var loggerMock = new Mock<ILogger<InterestService>>();

            var logger = loggerMock.Object;

            var repo = new Repository(applicationDbContext);

            interestService = new InterestService(repo, logger);

            var testInterest = repo.AddAsync(new Interest()
            {
                Id = 100,
                IsDeleted = false
            });


            await repo.SaveChangesAsync();

            await interestService.DeleteConfirmedAsync(100);

            var dbInterest = await repo.GetByIdAsync<Interest>(100);

            Assert.That(dbInterest.IsDeleted, Is.EqualTo(true));
        }

        [TearDown]
        public void TearDown()
        {
            applicationDbContext.Dispose();
        }
    }
}
