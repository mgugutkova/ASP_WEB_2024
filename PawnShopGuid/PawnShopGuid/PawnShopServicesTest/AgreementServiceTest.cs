using PawnShop.Core.Interfaces;
using PawnShop.Infrastructure.Data.Repo;
using PawnShop.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using PawnShop.Core.Services;
using PawnShop.Infrastructure.Data.Model;
using PawnShop.Core.Models.Agreement;
using NUnit.Framework;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.Serialization;
using Microsoft.Extensions.Logging;
using Moq;

namespace PawnShopServices.Test
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
                .UseInMemoryDatabase("PawnShop")
                .Options;

            applicationDbContext = new ApplicationDbContext(dbContextOptions);

            //  var repo = new Repository(applicationDbContext);

           applicationDbContext.Database.EnsureCreatedAsync();
         //   applicationDbContext.Database.EnsureCreated();

        }

        [Test]
        public async Task TestAgreementEdit()
        {
            var loggerMock = new Mock<ILogger<AgreementService>>();

            var logger = loggerMock.Object;

            var repo = new Repository(applicationDbContext);

            agreementService = new AgreementService(repo, logger);

            await repo.AddAsync(new Agreement()
            {
                Id = 1,
                GoodName = "Test",
                Description = ""
            });

            await repo.SaveChangesAsync();

            await agreementService.EditAgreementAsync(1, new AddAgreementViewModel()
            {
                Id = 1,
                GoodName = "Test edited",
                Description = "This record is edited"
            });

            var dbAgreement = await repo.GetByIdAsync<Agreement>(1);

            Assert.That(dbAgreement.GoodName, Is.EqualTo("Test edited"));
        }

        [TearDown]
        public void TearDown()
        {
            applicationDbContext.Dispose();
        }
    }
}