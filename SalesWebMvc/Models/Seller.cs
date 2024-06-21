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
        BirthDate = birthDate;
        BaseSalary = baseSalary;
        Department = department;
    }

    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; }
    public double BaseSalary { get; set; }

    # region Methods

    public Department Department { get; set; } = null!;
    public ICollection<SalesRecord> Sales { get; set; } = [];

    public void AddSales(SalesRecord salesRecord) => Sales.Add(salesRecord);

    public void RemoveSales(SalesRecord salesRecord) => Sales.Remove(salesRecord);

    public double TotalSales(DateTime initialDate, DateTime finalDate)
        => Sales.Where(sr => sr.Date >= initialDate && sr.Date <= finalDate).Sum(sr => sr.Ammount);

    #endregion
}
