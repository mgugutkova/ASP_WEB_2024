using Microsoft.AspNetCore.Identity;
using PawnShop.Infrastructure.Data.Model;

namespace PawnShop.Infrastructure.SeedDataDB
{
    public class SeedData
    {    

        public ApplicationUser AdminUser { get; set; }
        public ApplicationUser UserMsef { get; set; }
        public ApplicationUser UserKsef { get; set; }
        public ApplicationUser GuestUser { get; set; }

        public Client ClientMsef { get; set; }
        public Client ClientKsef { get; set; }
        public Client AdminClient { get; set; }

        public AgreementState AwaitingApproval { get; set; }
        public AgreementState Approved { get; set; }
        public AgreementState Finished { get; set; }
        public AgreementState Late { get; set; }
        public AgreementState ForShop { get; set; }

        public Agreement Laptop { get; set; }
        public Agreement TV { get; set; }
        public Agreement Bike { get; set; }

        public Shop BikeForShop { get; set; }
        public Interest TVInterest { get; set; }


        public SeedData()
        {
            SeedUsers();
            SeedClient();
            SeedState();
            SeedAgreement();
            SeedShop();
            SeedInterest();
        }

        private void SeedUsers()
        {
            var hasher = new PasswordHasher<IdentityUser>();

            AdminUser = new ApplicationUser()
            {
                Id = "b97f29e7-1edd-4666-a8d8-8882858d7ccf",
                UserName = "admin@abv.bg",
                NormalizedUserName = "ADMIN@ABV.BG",
                Email = "admin@abv.bg",
                NormalizedEmail = "ADMIN@ABV.BG",
                FirstName = "Admin",
                LastName = "Boss"
            };

            AdminUser.PasswordHash = hasher.HashPassword(AdminUser, "123456");

            UserMsef = new ApplicationUser()
            {
                Id = "5cf194c7-b26e-42ed-8efd-d98c7980373b",
                UserName = "msef@abv.bg",
                NormalizedUserName = "MSEF@ABV.BG",
                Email = "msef@abv.bg",
                NormalizedEmail = "MSEF@ABV.BG",
                FirstName = "Mary",
                LastName = "Seferov"
            };

            UserMsef.PasswordHash = hasher.HashPassword(UserMsef, "123456");

            UserKsef = new ApplicationUser()
            {
                Id = "ffae7662-4ff3-4698-8f36-c4e4f392da18",
                UserName = "ksef@abv.bg",
                NormalizedUserName = "KSEF@ABV.BG",
                Email = "ksef@abv.bg",
                NormalizedEmail = "KSEF@ABV.BG",
                FirstName = "Kalin",
                LastName = "Sarafov"
            };

            UserKsef.PasswordHash = hasher.HashPassword(UserKsef, "123456");


            GuestUser = new ApplicationUser()
            {
                Id = "70e39283-bd42-4d0a-aa2e-46d2a31c4f87",
                UserName = "guest.abv.bg",
                NormalizedUserName = "GUEST@ABV.BG",
                Email = "guest@abv.bg",
                NormalizedEmail = "GUEST@ABV.BG",
                FirstName = "Guest",
                LastName = "Guestov"
            };

            GuestUser.PasswordHash = hasher.HashPassword(GuestUser, "123456");
        }       

        private void SeedClient()
        {
            ClientMsef = new Client
            {
                Id = 1,
                PhoneNumber = "1234567890",
                Address = "Sofiq,Dianabad",
                UserId = UserMsef.Id,
                IsDeleted = false
            };

            ClientKsef = new Client
            {
                Id = 2,
                PhoneNumber = "1234599999",
                Address = "Plovdiv,Izgrev",
                UserId = UserKsef.Id,
                IsDeleted = false
            };


            AdminClient = new Client
            {
                Id = 3,
                PhoneNumber = "8888899999",
                Address = "Varna,Center",
                UserId = AdminUser.Id,
                IsDeleted = false
            };
        }

        private void SeedState()
        {
            AwaitingApproval = new AgreementState
            {
                Id = 1,
                Name = "Аwaiting approval"
            };

            Approved = new AgreementState
            {
                Id = 2,
                Name = "Approved (Active)"
            };

            Finished = new AgreementState
            {
                Id = 3,
                Name = "Finished"
            };

            Late = new AgreementState
            {
                Id = 4,
                Name = "Late"
            };

            ForShop = new AgreementState
            {
                Id = 5,
                Name = "For а Shop"
            };
        }

        private void SeedAgreement()
        {
            Laptop = new Agreement
            {
                Id = 1,
                GoodName = "лаптоп Acer",
                Description = "4GB RAM, 120SSD",
                Price = 200,
                ReturnPrice = 201,
                Duration = 10,
                StartDate = new DateTime(2024, 11, 25, 0, 0, 0),
                EndDate = new DateTime(2024, 12, 5, 0, 0, 0),
                UserId = UserKsef.Id,
                AgrreementStateId = 1,
                Ainterest = 1
            };

            TV = new Agreement
            {
                Id = 2,
                GoodName = "SONY TV",
                Description ="used - produced 2012",
                Price = 100,
                ReturnPrice = 103,
                Duration = 30,
                StartDate = new DateTime(2024, 11, 26, 0, 0, 0),
                EndDate = new DateTime(2024, 12, 26, 0, 0, 0),
                UserId = UserMsef.Id,
                AgrreementStateId = 2,
                Ainterest = 3
            };

            Bike = new Agreement
            {
                Id = 3,
                GoodName = "Bike",
                Description = "model Balkan",
                Price = 30,
                ReturnPrice = 33,
                Duration = 30,
                StartDate = new DateTime(2024, 11, 27, 0, 0, 0),
                EndDate = new DateTime(2024, 12, 27, 0, 0, 0),
                UserId = UserMsef.Id,
                AgrreementStateId =5
                
            };
        }
            
        private void SeedShop()
        {

            BikeForShop = new Shop
            {
                Id = 1,
                Name = Bike.GoodName,
                AgreementId = Bike.Id,
                SellPrice = Bike.Price
            };
        }

        private void SeedInterest()
        {
            TVInterest = new Interest
            {
                Id = 1,
                ValueInterest = TV.Ainterest,
                DateInterest = DateTime.Now,
                AgreementId = TV.Id,
                UserId = TV.UserId,

            };
        }

    }
}
