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
        public async Task TestInterestAdded()
        {
            var loggerMockInterest = new Mock<ILogger<InterestService>>();
            var loggerMockAgreement = new Mock<ILogger<AgreementService>>();

            var loggerInterest = loggerMockInterest.Object;
            var loggerAgreement = loggerMockAgreement.Object;

            var repo = new Repository(applicationDbContext);

            interestService = new InterestService(repo, loggerInterest);
            agreementService = new AgreementService(repo, loggerAgreement);

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

            var testInterest = repo.AddAsync(new Interest()
            {
                Id = Guid.Parse("4ae066e3-5622-4ba5-8a38-6eee24d4cdef"),
                AgreementId = Guid.Parse("fb6e9e41-e21e-4ede-8500-513f112104b3"),
                ValueInterest = 50,
                UserId = "123"
            });

            await repo.SaveChangesAsync();

            await interestService.AddInterestAsync(Guid.Parse("fb6e9e41-e21e-4ede-8500-513f112104b3"), "123");

            var dbInterest = await repo.GetByIdAsync<Interest>(Guid.Parse("4ae066e3-5622-4ba5-8a38-6eee24d4cdef"));

            Assert.That(dbInterest.Id, Is.EqualTo(Guid.Parse("4ae066e3-5622-4ba5-8a38-6eee24d4cdef")));
        }


        [Test]
        public async Task TestInterestDeleted()
        {
            var loggerMock = new Mock<ILogger<InterestService>>();

            var logger = loggerMock.Object;

            var repo = new Repository(applicationDbContext);

            interestService = new InterestService(repo, logger);

            var testInterest = repo.AddAsync(new Interest()
            {
                Id = Guid.Parse("fb6e9e41-e21e-4ede-8500-513f112104b3"),
                IsDeleted = false
            });


            await repo.SaveChangesAsync();

            await interestService.DeleteConfirmedAsync(Guid.Parse("fb6e9e41-e21e-4ede-8500-513f112104b3"));

            var dbInterest = await repo.GetByIdAsync<Interest>(Guid.Parse("fb6e9e41-e21e-4ede-8500-513f112104b3"));

            Assert.That(dbInterest.IsDeleted, Is.EqualTo(true));
        }

        [TearDown]
        public void TearDown()
        {
            applicationDbContext.Dispose();
        }
    }
}
