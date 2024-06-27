using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Data;
using SalesWebMvc.Models;

namespace SalesWebMvc.Services;

public class SellerService
{
    private readonly SalesWebMvcContext _context;

    public SellerService(SalesWebMvcContext context)
    {
        _context = context;
    }

    public List<Seller> FindAll() => [.. _context.Sellers]; // _context.Sellers.ToList()

    public void Insert(Seller seller)
    {
        seller.BirthDate = seller.BirthDate.ToUniversalTime();
        _context.Sellers.Add(seller);
        _context.SaveChanges();
    }

    public Seller? FindById(int id)
    {
        return _context.Sellers.Include(x => x.Department).FirstOrDefault(x => x.Id == id);
    }

    public void Remove(int id)
    {
        var obj = _context.Sellers.First(x => x.Id == id);
        _context.Sellers.Remove(obj);
        _context.SaveChanges();
    }
}
