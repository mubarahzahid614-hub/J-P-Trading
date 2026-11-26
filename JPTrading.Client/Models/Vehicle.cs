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
    public Vehicle Clone() => new()
    {
        Id = Id,
        Make = Make,
        Model = Model,
        Year = Year,
        Mileage = Mileage,
        PriceJpy = PriceJpy,
        FuelType = FuelType,
        Transmission = Transmission,
        BodyType = BodyType,
        Color = Color,
        EngineCc = EngineCc,
        Location = Location,
        Status = Status,
        Description = Description,
        Sheet = new AuctionSheet
        {
            AuctionHouse = Sheet.AuctionHouse,
            OverallGrade = Sheet.OverallGrade,
            ExteriorGrade = Sheet.ExteriorGrade,
            InteriorGrade = Sheet.InteriorGrade,
            Notes = Sheet.Notes.Select(n => new SheetNote { Japanese = n.Japanese, English = n.English }).ToList()
        }
    };
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