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
}
