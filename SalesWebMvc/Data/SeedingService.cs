
using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Models;
using SalesWebMvc.Models.Enums;

namespace SalesWebMvc.Data;

public sealed class SeedingService
{
    private readonly SalesWebMvcContext _context;

    public SeedingService(SalesWebMvcContext context)
    {
        _context = context;
    }

    public async Task Seed()
    {
        await SeedDepartments();
        await SeedSellers();
        await SeedSalesRecords();
    }

    private async Task SeedSellers()
    {
        bool isThereAnySeller = await _context.Sellers.AnyAsync();
        if (isThereAnySeller)
        {
            var sellers = await _context.Sellers.ToListAsync();
            foreach (var seller in sellers)
            {
                _context.Sellers.Remove(seller);
            }
        }
        var departments = await _context.Departments.ToListAsync();
        IEnumerable<Seller> sellersList = [
            new(
                "André",
                "andre@gmail.com",
                new DateTime(2006, 06, 05).ToUniversalTime(),
                1720,
                departments[0]
            ),
            new(
                "Elisa",
                "elisa@gmail.com",
                new DateTime(1998, 09, 14).ToUniversalTime(),
                4300,
                departments[1]
            )
        ];
        _context.Sellers.AddRange(sellersList);
        await _context.SaveChangesAsync();
    }

    private async Task SeedSalesRecords()
    {
        bool isThereAnysalesRecord = await _context.SalesRecords.AnyAsync();
        if (isThereAnysalesRecord)
        {
            var salesRecords = await _context.SalesRecords.ToListAsync();
            foreach (var salesRecord in salesRecords)
            {
                _context.SalesRecords.Remove(salesRecord);
            }
        }
        var sellers = await _context.Sellers.ToListAsync();
        IEnumerable<SalesRecord> salesRecordsList = [
            new(
                DateTime.UtcNow,
                3400,
                ESaleStatus.Billed,
                sellers[0]
            ),
            new(
                DateTime.UtcNow.AddDays(4),
                820,
                ESaleStatus.Billed,
                sellers[1]
            )
        ];
        _context.SalesRecords.AddRange(salesRecordsList);
        await _context.SaveChangesAsync();
    }

    private async Task SeedDepartments()
    {
        bool isThereAnyDepartment = await _context.Departments.AnyAsync();
        if (isThereAnyDepartment)
        {
            var departments = await _context.Departments.ToListAsync();
            foreach (var department in departments)
            {
                _context.Departments.Remove(department);
            }
        }
        IEnumerable<Department> departmentsList = [
            new("Eletrônicos"),
            new("Moda")
        ];
        _context.Departments.AddRange(departmentsList);
        await _context.SaveChangesAsync();
    }
}
