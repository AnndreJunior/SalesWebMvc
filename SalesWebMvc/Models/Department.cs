using System.ComponentModel.DataAnnotations;

namespace SalesWebMvc.Models;

public class Department
{
    public Department() { }

    public Department(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public int Id { get; set; }

    [Required(ErrorMessage = "Campo {0} é obrigatório")]
    public string Name { get; set; } = string.Empty;

    public ICollection<Seller> Sellers { get; set; } = [];

    #region Methods

    public void AddSeller(Seller seller) => Sellers.Add(seller);

    public double TotalSales(DateTime initialDate, DateTime finalDate)
        => Sellers.Sum(seller => seller.TotalSales(initialDate, finalDate));

    #endregion
}
