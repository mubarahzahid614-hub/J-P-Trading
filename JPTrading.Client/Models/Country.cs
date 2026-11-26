namespace JPTrading.Client.Models;

public class Country
{
    public string Name { get; set; } = "";
    public string Currency { get; set; } = "";
    public decimal RatePerJpy { get; set; }
    public decimal DutyPercent { get; set; }
}