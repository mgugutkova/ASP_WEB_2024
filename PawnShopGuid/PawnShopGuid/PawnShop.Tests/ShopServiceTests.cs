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
                Id = Guid.Parse("fb6e9e41-e21e-4ede-8500-513f112104b3"),
                Name = "Test" ?? string.Empty,
                Description = ""             
            });

            await repo.SaveChangesAsync();

            await shopService.EditAsync(Guid.Parse("fb6e9e41-e21e-4ede-8500-513f112104b3"), new EditGoodsInShop()
            {
                Id = "fb6e9e41-e21e-4ede-8500-513f112104b3",
                Name = "Goods Name is edited",
                Description = ""            
            });

            var dbAgreement = await repo.GetByIdAsync<Shop>(Guid.Parse("fb6e9e41-e21e-4ede-8500-513f112104b3"));

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
            new Shop(){Id = Guid.Parse("fb6e9e41-e21e-4ede-8500-513f112104b3"), Name = "Laptop DELL", Description = ""},
            new Shop(){Id = Guid.Parse("6ecb5c88-db24-4ec2-94fa-c9eca4b884e9"), Name = "Laptop IBM", Description = ""},
            new Shop(){Id = Guid.Parse("bee198e4-939a-440c-9994-9240427c8cd4"), Name = "Laptop Apple", Description = ""},
      
            });

            await repo.SaveChangesAsync();

            var goodsList = await shopService.AllAsync();

            Assert.That(4, Is.EqualTo(goodsList.Count()));
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
            new Shop(){Id = Guid.Parse("fb6e9e41-e21e-4ede-8500-513f112104b3"), Name = "Laptop DELL", Description = "", SoldDate = null},
            new Shop(){Id = Guid.Parse("6ecb5c88-db24-4ec2-94fa-c9eca4b884e9"), Name = "Laptop IBM", Description = "", SoldDate = DateTime.Now},
            new Shop(){Id = Guid.Parse("bee198e4-939a-440c-9994-9240427c8cd4"), Name = "Laptop Apple", Description = "", SoldDate = DateTime.Now},

            });

            await repo.SaveChangesAsync();

            var goodsList = await shopService.AllNotSoldAsync();

            Assert.That(2, Is.EqualTo(goodsList.Count()));
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
                Id = Guid.Parse("fb6e9e41-e21e-4ede-8500-513f112104b3"),
                Name = "Test" ?? string.Empty,
                Description = "",
                IsDeleted = false
            });


            await repo.SaveChangesAsync();

            await shopService.DeleteConfirmedAsync(Guid.Parse("fb6e9e41-e21e-4ede-8500-513f112104b3"));

            var dbGoods = await repo.GetByIdAsync<Shop>(Guid.Parse("fb6e9e41-e21e-4ede-8500-513f112104b3"));

            Assert.That(dbGoods.IsDeleted, Is.EqualTo(true));
        }

        [TearDown]
        public void TearDown()
        {
            applicationDbContext.Dispose();
        }
    }
}
