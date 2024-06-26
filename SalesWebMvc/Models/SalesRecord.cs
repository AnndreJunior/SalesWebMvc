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
    public DateTime Date { get; set; }
    public double Ammount { get; set; }
    public ESaleStatus Status { get; set; }

    public Seller Seller { get; set; } = null!;
}
