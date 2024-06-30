using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Data;
using SalesWebMvc.Models;
using SalesWebMvc.Services.Exceptions;

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

    public void Update(Seller seller)
    {
        bool noSellerFound = !_context.Sellers.Any(x => x.Id == seller.Id);
        if (noSellerFound)
        {
            throw new NotFoundException("Id not found");
        }

        try
        {
            seller.BirthDate = seller.BirthDate.ToUniversalTime();
            _context.Update(seller);
            _context.SaveChanges();
        }
        catch (DbUpdateConcurrencyException ex)
        {
            throw new DbConcurrencyException(ex.Message);
        }
    }
}
