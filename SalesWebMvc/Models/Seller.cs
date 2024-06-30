using System.ComponentModel.DataAnnotations;
using Npgsql.Internal;

namespace SalesWebMvc.Models;

public class Seller
{
    public Seller() { }

    public Seller(
        int id,
        string name,
        string email,
        DateTime birthDate,
        double baseSalary,
        Department department)
    {
        Id = id;
        Name = name;
        Email = email;
        BirthDate = birthDate.ToUniversalTime();
        BaseSalary = baseSalary;
        Department = department;
    }

    public int Id { get; set; }

    [Display(Name = "Nome")]
    public string Name { get; set; } = string.Empty;

    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = string.Empty;

    [Display(Name = "Data de nascimento")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
    public DateTime BirthDate { get; set; }

    [Display(Name = "Salário base")]
    [DisplayFormat(DataFormatString = "{0:F2}")]
    public double BaseSalary { get; set; }

    [Display(Name = "Departamento")]
    public Department Department { get; set; } = null!;
    public int DepartmentId { get; set; }

    # region Methods

    public ICollection<SalesRecord> Sales { get; set; } = [];

    public void AddSales(SalesRecord salesRecord) => Sales.Add(salesRecord);

    public void RemoveSales(SalesRecord salesRecord) => Sales.Remove(salesRecord);

    public double TotalSales(DateTime initialDate, DateTime finalDate)
        => Sales.Where(sr => sr.Date >= initialDate && sr.Date <= finalDate).Sum(sr => sr.Ammount);

    #endregion
}
