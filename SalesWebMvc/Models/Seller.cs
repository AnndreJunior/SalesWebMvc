using System.ComponentModel.DataAnnotations;

namespace SalesWebMvc.Models;

public class Seller
{
    public Seller() { }

    public Seller(
        string name,
        string email,
        DateTime birthDate,
        double baseSalary,
        Department department)
    {
        Name = name;
        Email = email;
        BirthDate = birthDate.ToUniversalTime();
        BaseSalary = baseSalary;
        Department = department;
    }

    public int Id { get; set; }

    [Display(Name = "Nome")]
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(60, MinimumLength = 3, ErrorMessage = "O tamanho do {0} deve ser entre {2} e {1}")]
    public string Name { get; set; } = string.Empty;

    [DataType(DataType.EmailAddress)]
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [EmailAddress(ErrorMessage = "Formato de email inválido")]
    public string Email { get; set; } = string.Empty;

    [Display(Name = "Data de nascimento")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public DateTime BirthDate { get; set; }

    [Display(Name = "Salário base")]
    [DisplayFormat(DataFormatString = "{0:F2}")]
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [Range(100, 50000, ErrorMessage = "{0} deve ser entre {1} e {2}")]
    public double BaseSalary { get; set; }

    [Display(Name = "Departamento")]
    public Department Department { get; set; } = null!;
    public int DepartmentId { get; set; }
    public ICollection<SalesRecord> Sales { get; set; } = [];

    # region Methods


    public void AddSales(SalesRecord salesRecord) => Sales.Add(salesRecord);

    public void RemoveSales(SalesRecord salesRecord) => Sales.Remove(salesRecord);

    public double TotalSales(DateTime initialDate, DateTime finalDate)
        => Sales.Where(sr => sr.Date >= initialDate && sr.Date <= finalDate).Sum(sr => sr.Ammount);

    #endregion
}
