using BogsyVideoStore.Data.Enum;
using BogsyVideoStore.Models;
using Microsoft.EntityFrameworkCore;

namespace BogsyVideoStore.Data
{
    public class DataSeeder
    {
        public static void Seed(AppDbContext context)
        {
            // Check if data already exists
            if (context.Customers.Any() || context.Videos.Any() || context.Rentals.Any())
            {
                return;
            }

            // Seed Customers
            var customers = GenerateCustomers();
            context.Customers.AddRange(customers);
            context.SaveChanges();

            // Seed Videos
            var videos = GenerateVideos();
            context.Videos.AddRange(videos);
            context.SaveChanges();

            // Seed Rentals
            var rentals = GenerateRentals();
            context.Rentals.AddRange(rentals);
            context.SaveChanges();
        }

        private static List<Customer> GenerateCustomers()
        {
            var customers = new List<Customer>
            {
                new Customer { Name = "James Anderson", Address = "123 Main St, Springfield, IL", BirthDate = new DateTime(1985, 3, 15), Email = "james.anderson@email.com", ContactNo = "217-555-0101", Sex = Sex.Male },
                new Customer { Name = "Maria Garcia", Address = "456 Oak Ave, Chicago, IL", BirthDate = new DateTime(1990, 7, 22), Email = "maria.garcia@email.com", ContactNo = "312-555-0102", Sex = Sex.Female },
                new Customer { Name = "Robert Chen", Address = "789 Elm St, Naperville, IL", BirthDate = new DateTime(1988, 11, 8), Email = "robert.chen@email.com", ContactNo = "630-555-0103", Sex = Sex.Male },
                new Customer { Name = "Sarah Johnson", Address = "321 Pine Rd, Evanston, IL", BirthDate = new DateTime(1992, 5, 14), Email = "sarah.johnson@email.com", ContactNo = "847-555-0104", Sex = Sex.Female },
                new Customer { Name = "Michael Brown", Address = "654 Maple Dr, Aurora, IL", BirthDate = new DateTime(1987, 9, 28), Email = "michael.brown@email.com", ContactNo = "331-555-0105", Sex = Sex.Male },
                new Customer { Name = "Jessica Williams", Address = "987 Cedar Ln, Joliet, IL", BirthDate = new DateTime(1994, 2, 3), Email = "jessica.williams@email.com", ContactNo = "815-555-0106", Sex = Sex.Female },
                new Customer { Name = "David Rodriguez", Address = "147 Birch Way, Rockford, IL", BirthDate = new DateTime(1986, 12, 19), Email = "david.rodriguez@email.com", ContactNo = "779-555-0107", Sex = Sex.Male },
                new Customer { Name = "Lisa Martinez", Address = "258 Willow St, Peoria, IL", BirthDate = new DateTime(1991, 6, 27), Email = "lisa.martinez@email.com", ContactNo = "309-555-0108", Sex = Sex.Female },
                new Customer { Name = "Christopher Lee", Address = "369 Spruce Ave, Champaign, IL", BirthDate = new DateTime(1989, 4, 11), Email = "christopher.lee@email.com", ContactNo = "217-555-0109", Sex = Sex.Male },
                new Customer { Name = "Angela Davis", Address = "741 Ash Blvd, Bloomington, IL", BirthDate = new DateTime(1993, 8, 30), Email = "angela.davis@email.com", ContactNo = "309-555-0110", Sex = Sex.Female },
                new Customer { Name = "Daniel Taylor", Address = "852 Poplar Dr, Urbana, IL", BirthDate = new DateTime(1987, 1, 6), Email = "daniel.taylor@email.com", ContactNo = "217-555-0111", Sex = Sex.Male },
                new Customer { Name = "Michelle Anderson", Address = "963 Sycamore Ln, Elgin, IL", BirthDate = new DateTime(1995, 10, 17), Email = "michelle.anderson@email.com", ContactNo = "847-555-0112", Sex = Sex.Female },
                new Customer { Name = "Joseph Martin", Address = "159 Hackberry St, Schaumburg, IL", BirthDate = new DateTime(1984, 3, 25), Email = "joseph.martin@email.com", ContactNo = "847-555-0113", Sex = Sex.Male },
                new Customer { Name = "Emma Wilson", Address = "357 Cottonwood Ave, Bridgeview, IL", BirthDate = new DateTime(1996, 7, 9), Email = "emma.wilson@email.com", ContactNo = "708-555-0114", Sex = Sex.Female },
                new Customer { Name = "Thomas Thompson", Address = "468 Hemlock Rd, Tinley Park, IL", BirthDate = new DateTime(1988, 9, 13), Email = "thomas.thompson@email.com", ContactNo = "708-555-0115", Sex = Sex.Male },
                new Customer { Name = "Olivia Jackson", Address = "579 Juniper Dr, Oak Lawn, IL", BirthDate = new DateTime(1992, 5, 21), Email = "olivia.jackson@email.com", ContactNo = "708-555-0116", Sex = Sex.Female },
                new Customer { Name = "Matthew White", Address = "680 Linden St, Calumet City, IL", BirthDate = new DateTime(1990, 11, 2), Email = "matthew.white@email.com", ContactNo = "708-555-0117", Sex = Sex.Male },
                new Customer { Name = "Sophia Harris", Address = "791 Magnolia Ave, Lombard, IL", BirthDate = new DateTime(1994, 4, 18), Email = "sophia.harris@email.com", ContactNo = "630-555-0118", Sex = Sex.Female },
                new Customer { Name = "Andrew Moore", Address = "802 Nutmeg Ln, Downers Grove, IL", BirthDate = new DateTime(1987, 6, 30), Email = "andrew.moore@email.com", ContactNo = "630-555-0119", Sex = Sex.Male },
                new Customer { Name = "Ava Thomas", Address = "913 Oak Park Blvd, Western Springs, IL", BirthDate = new DateTime(1993, 8, 14), Email = "ava.thomas@email.com", ContactNo = "630-555-0120", Sex = Sex.Female },
                new Customer { Name = "Daniel Jackson", Address = "124 Orchid Way, LaGrange, IL", BirthDate = new DateTime(1986, 2, 7), Email = "daniel.jackson@email.com", ContactNo = "708-555-0121", Sex = Sex.Male },
                new Customer { Name = "Isabella Clark", Address = "235 Pansy St, Hinsdale, IL", BirthDate = new DateTime(1995, 9, 23), Email = "isabella.clark@email.com", ContactNo = "630-555-0122", Sex = Sex.Female },
                new Customer { Name = "James Lewis", Address = "346 Quince Ave, Wheaton, IL", BirthDate = new DateTime(1988, 12, 5), Email = "james.lewis@email.com", ContactNo = "630-555-0123", Sex = Sex.Male },
                new Customer { Name = "Mia Walker", Address = "457 Rose Dr, Batavia, IL", BirthDate = new DateTime(1994, 3, 11), Email = "mia.walker@email.com", ContactNo = "630-555-0124", Sex = Sex.Female },
                new Customer { Name = "Benjamin Hall", Address = "568 Sage Ln, Geneva, IL", BirthDate = new DateTime(1989, 7, 19), Email = "benjamin.hall@email.com", ContactNo = "630-555-0125", Sex = Sex.Male },
                new Customer { Name = "Charlotte Young", Address = "679 Thistle St, St Charles, IL", BirthDate = new DateTime(1992, 1, 8), Email = "charlotte.young@email.com", ContactNo = "630-555-0126", Sex = Sex.Female },
                new Customer { Name = "Lucas Hernandez", Address = "780 Tulip Ave, Carpentersville, IL", BirthDate = new DateTime(1987, 10, 26), Email = "lucas.hernandez@email.com", ContactNo = "331-555-0127", Sex = Sex.Male },
                new Customer { Name = "Amelia King", Address = "891 Vanilla Rd, Algonquin, IL", BirthDate = new DateTime(1996, 6, 14), Email = "amelia.king@email.com", ContactNo = "224-555-0128", Sex = Sex.Female },
                new Customer { Name = "Henry Wright", Address = "902 Walnut Dr, Crystal Lake, IL", BirthDate = new DateTime(1985, 8, 22), Email = "henry.wright@email.com", ContactNo = "815-555-0129", Sex = Sex.Male },
                new Customer { Name = "Harper Lopez", Address = "113 Xavier Ln, McHenry, IL", BirthDate = new DateTime(1998, 4, 9), Email = "harper.lopez@email.com", ContactNo = "815-555-0130", Sex = Sex.Female },
                new Customer { Name = "Mason Scott", Address = "224 York St, Huntley, IL", BirthDate = new DateTime(1991, 5, 17), Email = "mason.scott@email.com", ContactNo = "331-555-0131", Sex = Sex.Male },
                new Customer { Name = "Evelyn Green", Address = "335 Zephyr Ave, Gilberts, IL", BirthDate = new DateTime(1993, 9, 4), Email = "evelyn.green@email.com", ContactNo = "331-555-0132", Sex = Sex.Female }
            };

            return customers;
        }

        private static List<Video> GenerateVideos()
        {
            var videos = new List<Video>
            {
                new Video { Title = "Inception", Genre = Genre.Fantasy, VideoType = VideoType.DVD, rentDuration = RentDuration.TwoDays, QtyTotal = 5, QtyIn = 5, QtyOut = 0 },
                new Video { Title = "The Dark Knight", Genre = Genre.Action, VideoType = VideoType.DVD, rentDuration = RentDuration.TwoDays, QtyTotal = 8, QtyIn = 3, QtyOut = 5 },
                new Video { Title = "Forrest Gump", Genre = Genre.Drama, VideoType = VideoType.DVD, rentDuration = RentDuration.ThreeDays, QtyTotal = 6, QtyIn = 4, QtyOut = 2 },
                new Video { Title = "The Matrix", Genre = Genre.Action, VideoType = VideoType.VCD, rentDuration = RentDuration.OneDay, QtyTotal = 4, QtyIn = 2, QtyOut = 2 },
                new Video { Title = "Pulp Fiction", Genre = Genre.Drama, VideoType = VideoType.DVD, rentDuration = RentDuration.TwoDays, QtyTotal = 5, QtyIn = 5, QtyOut = 0 },
                new Video { Title = "The Shawshank Redemption", Genre = Genre.Drama, VideoType = VideoType.DVD, rentDuration = RentDuration.ThreeDays, QtyTotal = 7, QtyIn = 6, QtyOut = 1 },
                new Video { Title = "Gladiator", Genre = Genre.Action, VideoType = VideoType.DVD, rentDuration = RentDuration.TwoDays, QtyTotal = 6, QtyIn = 2, QtyOut = 4 },
                new Video { Title = "The Ring", Genre = Genre.Horror, VideoType = VideoType.DVD, rentDuration = RentDuration.OneDay, QtyTotal = 5, QtyIn = 3, QtyOut = 2 },
                new Video { Title = "The Lion King", Genre = Genre.Fantasy, VideoType = VideoType.VCD, rentDuration = RentDuration.ThreeDays, QtyTotal = 8, QtyIn = 8, QtyOut = 0 },
                new Video { Title = "Titanic", Genre = Genre.Drama, VideoType = VideoType.DVD, rentDuration = RentDuration.TwoDays, QtyTotal = 7, QtyIn = 4, QtyOut = 3 },
                new Video { Title = "Avatar", Genre = Genre.Fantasy, VideoType = VideoType.DVD, rentDuration = RentDuration.TwoDays, QtyTotal = 10, QtyIn = 5, QtyOut = 5 },
                new Video { Title = "The Avengers", Genre = Genre.Action, VideoType = VideoType.DVD, rentDuration = RentDuration.TwoDays, QtyTotal = 9, QtyIn = 3, QtyOut = 6 },
                new Video { Title = "Interstellar", Genre = Genre.Drama, VideoType = VideoType.DVD, rentDuration = RentDuration.ThreeDays, QtyTotal = 6, QtyIn = 4, QtyOut = 2 },
                new Video { Title = "The Conjuring", Genre = Genre.Horror, VideoType = VideoType.DVD, rentDuration = RentDuration.OneDay, QtyTotal = 5, QtyIn = 2, QtyOut = 3 },
                new Video { Title = "Jurassic Park", Genre = Genre.Adventure, VideoType = VideoType.DVD, rentDuration = RentDuration.TwoDays, QtyTotal = 7, QtyIn = 5, QtyOut = 2 },
                new Video { Title = "The Hunger Games", Genre = Genre.Adventure, VideoType = VideoType.DVD, rentDuration = RentDuration.TwoDays, QtyTotal = 6, QtyIn = 3, QtyOut = 3 },
                new Video { Title = "Mission: Impossible", Genre = Genre.Action, VideoType = VideoType.VCD, rentDuration = RentDuration.OneDay, QtyTotal = 4, QtyIn = 4, QtyOut = 0 },
                new Video { Title = "The Sixth Sense", Genre = Genre.Horror, VideoType = VideoType.DVD, rentDuration = RentDuration.TwoDays, QtyTotal = 5, QtyIn = 3, QtyOut = 2 },
                new Video { Title = "Frozen", Genre = Genre.Fantasy, VideoType = VideoType.DVD, rentDuration = RentDuration.ThreeDays, QtyTotal = 10, QtyIn = 7, QtyOut = 3 },
                new Video { Title = "Deadpool", Genre = Genre.Action, VideoType = VideoType.DVD, rentDuration = RentDuration.TwoDays, QtyTotal = 8, QtyIn = 2, QtyOut = 6 },
                new Video { Title = "Doctor Strange", Genre = Genre.Fantasy, VideoType = VideoType.DVD, rentDuration = RentDuration.TwoDays, QtyTotal = 7, QtyIn = 4, QtyOut = 3 },
                new Video { Title = "Black Panther", Genre = Genre.Action, VideoType = VideoType.DVD, rentDuration = RentDuration.TwoDays, QtyTotal = 9, QtyIn = 3, QtyOut = 6 },
                new Video { Title = "The Witch", Genre = Genre.Horror, VideoType = VideoType.DVD, rentDuration = RentDuration.OneDay, QtyTotal = 4, QtyIn = 2, QtyOut = 2 },
                new Video { Title = "Spider-Man", Genre = Genre.Action, VideoType = VideoType.VCD, rentDuration = RentDuration.OneDay, QtyTotal = 6, QtyIn = 3, QtyOut = 3 },
                new Video { Title = "Wonder Woman", Genre = Genre.Action, VideoType = VideoType.DVD, rentDuration = RentDuration.TwoDays, QtyTotal = 8, QtyIn = 4, QtyOut = 4 },
                new Video { Title = "Aquaman", Genre = Genre.Action, VideoType = VideoType.DVD, rentDuration = RentDuration.TwoDays, QtyTotal = 7, QtyIn = 5, QtyOut = 2 },
                new Video { Title = "The Invisible Man", Genre = Genre.Horror, VideoType = VideoType.DVD, rentDuration = RentDuration.OneDay, QtyTotal = 5, QtyIn = 4, QtyOut = 1 },
                new Video { Title = "Dune", Genre = Genre.Adventure, VideoType = VideoType.DVD, rentDuration = RentDuration.ThreeDays, QtyTotal = 8, QtyIn = 6, QtyOut = 2 },
                new Video { Title = "The Batman", Genre = Genre.Action, VideoType = VideoType.DVD, rentDuration = RentDuration.TwoDays, QtyTotal = 10, QtyIn = 4, QtyOut = 6 },
                new Video { Title = "Top Gun: Maverick", Genre = Genre.Action, VideoType = VideoType.DVD, rentDuration = RentDuration.TwoDays, QtyTotal = 9, QtyIn = 3, QtyOut = 6 },
                new Video { Title = "The Lost City", Genre = Genre.Adventure, VideoType = VideoType.DVD, rentDuration = RentDuration.TwoDays, QtyTotal = 7, QtyIn = 5, QtyOut = 2 },
                new Video { Title = "Uncharted", Genre = Genre.Adventure, VideoType = VideoType.DVD, rentDuration = RentDuration.TwoDays, QtyTotal = 6, QtyIn = 4, QtyOut = 2 },
                new Video { Title = "The Adam Project", Genre = Genre.Comedy, VideoType = VideoType.DVD, rentDuration = RentDuration.TwoDays, QtyTotal = 8, QtyIn = 5, QtyOut = 3 }
            };

            return videos;
        }

        private static List<Rental> GenerateRentals()
        {
            var random = new Random(42); // Fixed seed for reproducibility
            var rentals = new List<Rental>();
            var today = DateTime.Now;

            // Generate 40 rentals to cover variety
            for (int i = 1; i <= 40; i++)
            {
                int customerId = ((i - 1) % 32) + 1; // Distribute across 32 customers
                int videoId = ((i - 1) % 32) + 1; // Distribute across 32 videos
                int qtyRented = random.Next(1, 4); // Rent 1-3 items

                // Vary the rental dates
                int daysAgo = random.Next(0, 60); // rentals from 0-60 days ago
                int rentDurationDays = random.Next(1, 4); // 1-3 days rental duration
                
                var dateRented = today.AddDays(-daysAgo);
                var rentDueDate = dateRented.AddDays(rentDurationDays);

                // Calculate rent charge (varies by quantity: 1-3 items = 50-150 pesos)
                int rentCharge = qtyRented * 50;

                var rental = new Rental
                {
                    CustomerId = customerId,
                    VideoId = videoId,
                    DateRented = dateRented,
                    RentDueDate = rentDueDate,
                    QtyRented = qtyRented,
                    RentCharge = rentCharge,
                    DueFees = null, // Will be calculated in the Report action
                    TotalCharge = null // Will be calculated in the Report action
                };

                rentals.Add(rental);
            }

            return rentals;
        }
    }
}
