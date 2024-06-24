// using SalesWebMvc.Models;
// using SalesWebMvc.Models.Enums;

// namespace SalesWebMvc.Data;

// public class SeedingService
// {
//     private readonly SalesWebMvcContext _context;

//     public SeedingService(SalesWebMvcContext context)
//     {
//         _context = context;
//     }

//     public void Seed()
//     {
//         if (_context.Departments.Any() || _context.Sellers.Any() || _context.SalesRecords.Any())
//             return;

//         Department department1 = new(1, "Computers");
//         Department department2 = new(2, "Eletronics");
//         Department department3 = new(3, "Fashion");
//         Department department4 = new(4, "Books");

//         Seller seller1 = new(1, "Bob Brown", "bob@gmail.com", new DateTime(1998, 4, 21).ToUniversalTime(), 1000.0, department1);
//         Seller seller2 = new(2, "Maria Green", "maria@gmail.com", new DateTime(1979, 12, 31).ToUniversalTime(), 3500.0, department2);
//         Seller seller3 = new(3, "Alex Grey", "alex@gmail.com", new DateTime(1988, 1, 15).ToUniversalTime(), 2200.0, department1);
//         Seller seller4 = new(4, "Martha Red", "martha@gmail.com", new DateTime(1993, 11, 30).ToUniversalTime(), 3000.0, department4);
//         Seller seller5 = new(5, "Donald Blue", "donald@gmail.com", new DateTime(2000, 1, 9).ToUniversalTime(), 4000.0, department3);
//         Seller seller6 = new(6, "Alex Pink", "bob@gmail.com", new DateTime(1997, 3, 4).ToUniversalTime(), 3000.0, department2);

//         SalesRecord salerRecord1 = new(1, new DateTime(2018, 09, 25).ToUniversalTime(), 11000.0, ESaleStatus.Billed, seller1);
//         SalesRecord salerRecord2 = new(2, new DateTime(2018, 09, 4).ToUniversalTime(), 7000.0, ESaleStatus.Billed, seller5);
//         SalesRecord salerRecord3 = new(3, new DateTime(2018, 09, 13).ToUniversalTime(), 4000.0, ESaleStatus.Canceled, seller4);
//         SalesRecord salerRecord4 = new(4, new DateTime(2018, 09, 1).ToUniversalTime(), 8000.0, ESaleStatus.Billed, seller1);
//         SalesRecord salerRecord5 = new(5, new DateTime(2018, 09, 21).ToUniversalTime(), 3000.0, ESaleStatus.Billed, seller3);
//         SalesRecord salerRecord6 = new(6, new DateTime(2018, 09, 15).ToUniversalTime(), 2000.0, ESaleStatus.Billed, seller1);
//         SalesRecord salerRecord7 = new(7, new DateTime(2018, 09, 28).ToUniversalTime(), 13000.0, ESaleStatus.Billed, seller2);
//         SalesRecord salerRecord8 = new(8, new DateTime(2018, 09, 11).ToUniversalTime(), 4000.0, ESaleStatus.Billed, seller4);
//         SalesRecord salerRecord9 = new(9, new DateTime(2018, 09, 14).ToUniversalTime(), 11000.0, ESaleStatus.Pending, seller6);
//         SalesRecord salerRecord10 = new(10, new DateTime(2018, 09, 7).ToUniversalTime(), 9000.0, ESaleStatus.Billed, seller6);
//         SalesRecord salerRecord11 = new(11, new DateTime(2018, 09, 13).ToUniversalTime(), 6000.0, ESaleStatus.Billed, seller2);
//         SalesRecord salerRecord12 = new(12, new DateTime(2018, 09, 25).ToUniversalTime(), 7000.0, ESaleStatus.Pending, seller3);
//         SalesRecord salerRecord13 = new(13, new DateTime(2018, 09, 29).ToUniversalTime(), 10000.0, ESaleStatus.Billed, seller4);
//         SalesRecord salerRecord14 = new(14, new DateTime(2018, 09, 4).ToUniversalTime(), 3000.0, ESaleStatus.Billed, seller5);
//         SalesRecord salerRecord15 = new(15, new DateTime(2018, 09, 12).ToUniversalTime(), 4000.0, ESaleStatus.Billed, seller1);
//         SalesRecord salerRecord16 = new(16, new DateTime(2018, 10, 5).ToUniversalTime(), 2000.0, ESaleStatus.Billed, seller4);
//         SalesRecord salerRecord17 = new(17, new DateTime(2018, 10, 1).ToUniversalTime(), 12000.0, ESaleStatus.Billed, seller1);
//         SalesRecord salerRecord18 = new(18, new DateTime(2018, 10, 24).ToUniversalTime(), 6000.0, ESaleStatus.Billed, seller3);
//         SalesRecord salerRecord19 = new(19, new DateTime(2018, 10, 22).ToUniversalTime(), 8000.0, ESaleStatus.Billed, seller5);
//         SalesRecord salerRecord20 = new(20, new DateTime(2018, 10, 15).ToUniversalTime(), 8000.0, ESaleStatus.Billed, seller6);
//         SalesRecord salerRecord21 = new(21, new DateTime(2018, 10, 17).ToUniversalTime(), 9000.0, ESaleStatus.Billed, seller2);
//         SalesRecord salerRecord22 = new(22, new DateTime(2018, 10, 24).ToUniversalTime(), 4000.0, ESaleStatus.Billed, seller4);
//         SalesRecord salerRecord23 = new(23, new DateTime(2018, 10, 19).ToUniversalTime(), 11000.0, ESaleStatus.Canceled, seller2);
//         SalesRecord salerRecord24 = new(24, new DateTime(2018, 10, 12).ToUniversalTime(), 8000.0, ESaleStatus.Billed, seller5);
//         SalesRecord salerRecord25 = new(25, new DateTime(2018, 10, 31).ToUniversalTime(), 7000.0, ESaleStatus.Billed, seller3);
//         SalesRecord salerRecord26 = new(26, new DateTime(2018, 10, 6).ToUniversalTime(), 5000.0, ESaleStatus.Billed, seller4);
//         SalesRecord salerRecord27 = new(27, new DateTime(2018, 10, 13).ToUniversalTime(), 9000.0, ESaleStatus.Pending, seller1);
//         SalesRecord salerRecord28 = new(28, new DateTime(2018, 10, 7).ToUniversalTime(), 4000.0, ESaleStatus.Billed, seller3);
//         SalesRecord salerRecord29 = new(29, new DateTime(2018, 10, 23).ToUniversalTime(), 12000.0, ESaleStatus.Billed, seller5);
//         SalesRecord salerRecord30 = new(30, new DateTime(2018, 10, 12).ToUniversalTime(), 5000.0, ESaleStatus.Billed, seller2);

//         _context.Departments.AddRange(department1, department2, department3, department4);
//         _context.SalesRecords.AddRange(
//             salerRecord1,
//             salerRecord2,
//             salerRecord3,
//             salerRecord4,
//             salerRecord5,
//             salerRecord6,
//             salerRecord7,
//             salerRecord8,
//             salerRecord9,
//             salerRecord10,
//             salerRecord11,
//             salerRecord12,
//             salerRecord13,
//             salerRecord14,
//             salerRecord15,
//             salerRecord16,
//             salerRecord17,
//             salerRecord18,
//             salerRecord19,
//             salerRecord20,
//             salerRecord21,
//             salerRecord22,
//             salerRecord23,
//             salerRecord24,
//             salerRecord25,
//             salerRecord26,
//             salerRecord27,
//             salerRecord28,
//             salerRecord29,
//             salerRecord30
//         );

//         _context.SaveChanges();
//     }
// }
