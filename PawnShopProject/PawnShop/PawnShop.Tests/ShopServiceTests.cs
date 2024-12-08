using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using PawnShop.Core.Interfaces;
using PawnShop.Core.Models.Shop;
using PawnShop.Core.Services;
using PawnShop.Infrastructure.Data;
using PawnShop.Infrastructure.Data.Model;
using PawnShop.Infrastructure.Data.Repo;

namespace PawnShop.Tests
{
    [TestFixture]
    public class ShopServiceTests
    {
        private IRepository repo;
        private ILogger<Agreement> logger;
        private IShopService shopService;
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
        public async Task TestShopEditGoods()
        {
            var loggerMock = new Mock<ILogger<ShopService>>();

            var logger = loggerMock.Object;

            var repo = new Repository(applicationDbContext);

            shopService = new ShopService(repo, logger);

            var testGoodsInShop = repo.AddAsync(new Shop()
            {
                Id = 100,
                Name = "Test" ?? string.Empty,
                Description = ""             
            });

            await repo.SaveChangesAsync();

            await shopService.EditAsync(100, new EditGoodsInShop()
            {
                Id = 100,
                Name = "Goods Name is edited",
                Description = ""            
            });

            var dbAgreement = await repo.GetByIdAsync<Shop>(100);

            Assert.That(dbAgreement.Name, Is.EqualTo("Goods Name is edited"));
        }



        [Test]
        public async Task TestAllGoodsInShop()
        {
            var loggerMock = new Mock<ILogger<ShopService>>();

            var logger = loggerMock.Object;

            var repo = new Repository(applicationDbContext);

            shopService = new ShopService(repo, logger);

            var testGoods = repo.AddRangeAsync(new List<Shop>()
            {
            new Shop(){Id = 100, Name = "Laptop DELL", Description = ""},
            new Shop(){Id = 101, Name = "Laptop IBM", Description = ""},
            new Shop(){Id = 102, Name = "Laptop Apple", Description = ""},
      
            });

            await repo.SaveChangesAsync();

            var goodsList = await shopService.AllAsync();

            Assert.That(3, Is.EqualTo(goodsList.Count()));
        }


        [Test]
        public async Task TestAllGoodsNotSoldInShop()
        {
            var loggerMock = new Mock<ILogger<ShopService>>();

            var logger = loggerMock.Object;

            var repo = new Repository(applicationDbContext);

            shopService = new ShopService(repo, logger);

            var testGoods = repo.AddRangeAsync(new List<Shop>()
            {
            new Shop(){Id = 100, Name = "Laptop DELL", Description = "", SoldDate = null},
            new Shop(){Id = 101, Name = "Laptop IBM", Description = "", SoldDate = DateTime.Now},
            new Shop(){Id = 102, Name = "Laptop Apple", Description = "", SoldDate = DateTime.Now},

            });

            await repo.SaveChangesAsync();

            var goodsList = await shopService.AllNotSoldAsync();

            Assert.That(1, Is.EqualTo(goodsList.Count()));
        }


        [Test]
        public async Task TestGoodsInShopDeleted()
        {
            var loggerMock = new Mock<ILogger<ShopService>>();

            var logger = loggerMock.Object;

            var repo = new Repository(applicationDbContext);

            shopService = new ShopService(repo, logger);

            var testGoods = repo.AddAsync(new Shop()
            {
                Id = 100,
                Name = "Test" ?? string.Empty,
                Description = "",
                IsDeleted = false
            });


            await repo.SaveChangesAsync();

            await shopService.DeleteConfirmedAsync(100);

            var dbGoods = await repo.GetByIdAsync<Shop>(100);

            Assert.That(dbGoods.IsDeleted, Is.EqualTo(true));
        }

        [TearDown]
        public void TearDown()
        {
            applicationDbContext.Dispose();
        }
    }
}
