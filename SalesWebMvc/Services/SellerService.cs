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

    public async Task<List<Seller>> FindAll() => await _context.Sellers.ToListAsync();

    public async Task Insert(Seller seller)
    {
        seller.BirthDate = seller.BirthDate.ToUniversalTime();
        _context.Sellers.Add(seller);
        await _context.SaveChangesAsync();
    }

    public async Task<Seller?> FindById(int id)
    {
        return await _context.Sellers.Include(x => x.Department).FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task Remove(int id)
    {
        try
        {
            var obj = await _context.Sellers.FirstAsync(x => x.Id == id);
            _context.Sellers.Remove(obj);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException)
        {
            throw new IntegrityException("Não foi possível deletar um vendedor pois ele(a) já possui vendas");
        }
    }

    public async Task Update(Seller seller)
    {
        bool noSellerFound = !await _context.Sellers.AnyAsync(x => x.Id == seller.Id);
        if (noSellerFound)
        {
            throw new NotFoundException("Id not found");
        }

        try
        {
            seller.BirthDate = seller.BirthDate.ToUniversalTime();
            _context.Update(seller);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException ex)
        {
            throw new DbConcurrencyException(ex.Message);
        }
    }
}
