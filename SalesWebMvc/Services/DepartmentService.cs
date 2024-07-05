using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Data;
using SalesWebMvc.Models;

namespace SalesWebMvc.Services;

public class DepartmentService
{
    private readonly SalesWebMvcContext _context;

    public DepartmentService(SalesWebMvcContext context)
    {
        _context = context;
    }

    public async Task<List<Department>> FindAll()
    {
        return await _context.Departments.OrderBy(x => x.Name).ToListAsync();
    }
}
