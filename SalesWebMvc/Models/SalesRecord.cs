using System.ComponentModel.DataAnnotations;
using SalesWebMvc.Models.Enums;

namespace SalesWebMvc.Models;

public class SalesRecord
{
    public SalesRecord() { }

    public SalesRecord(int id, DateTime date, double ammount, ESaleStatus status, Seller seller)
    {
        Id = id;
        Date = date;
        Ammount = ammount;
        Status = status;
        Seller = seller;
    }

    public int Id { get; set; }
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
    public DateTime Date { get; set; }
    [DisplayFormat(DataFormatString = "{0:F2}")]
    public double Ammount { get; set; }
    public ESaleStatus Status { get; set; }

    public Seller Seller { get; set; } = null!;
}
