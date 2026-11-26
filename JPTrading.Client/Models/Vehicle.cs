namespace JPTrading.Client.Models;

public class Vehicle
{
    public int Id { get; set; }
    public string Make { get; set; } = "";
    public string Model { get; set; } = "";
    public int Year { get; set; }
    public int Mileage { get; set; }
    public decimal PriceJpy { get; set; }
    public string FuelType { get; set; } = "";
    public string Transmission { get; set; } = "";
    public string BodyType { get; set; } = "";
    public string Color { get; set; } = "";
    public int EngineCc { get; set; }
    public string Location { get; set; } = "";
    public string Status { get; set; } = "Available";
    public string Description { get; set; } = "";
    public AuctionSheet Sheet { get; set; } = new();

    public string Title => $"{Year} {Make} {Model}";
}

public class AuctionSheet
{
    public string AuctionHouse { get; set; } = "";
    public string OverallGrade { get; set; } = "";
    public string ExteriorGrade { get; set; } = "";
    public string InteriorGrade { get; set; } = "";
    public List<SheetNote> Notes { get; set; } = new();
}

public class SheetNote
{
    public string Japanese { get; set; } = "";
    public string English { get; set; } = "";
}