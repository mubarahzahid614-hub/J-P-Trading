namespace JPTrading.Client.Models;

public class Order
{
    public static readonly string[] Steps =
        { "Requested", "Confirmed", "Payment Received", "Purchased in Japan", "Shipped", "Arrived at Port", "Delivered" };

    public int Id { get; set; }
    public int VehicleId { get; set; }
    public string VehicleTitle { get; set; } = "";
    public string BuyerEmail { get; set; } = "";
    public string BuyerName { get; set; } = "";
    public decimal PriceJpy { get; set; }
    public string Country { get; set; } = "";
    public string Currency { get; set; } = "";
    public decimal TotalLocal { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public string Status { get; set; } = "Requested";
    public int StepIndex => Array.IndexOf(Steps, Status);
}

public class Notification
{
    public int Id { get; set; }
    public string BuyerEmail { get; set; } = "";
    public string Title { get; set; } = "";
    public string Message { get; set; } = "";
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public bool IsRead { get; set; }
}

public class Inquiry
{
    public int Id { get; set; }
    public string BuyerEmail { get; set; } = "";
    public string BuyerName { get; set; } = "";
    public string Subject { get; set; } = "";
    public string Message { get; set; } = "";
    public string Reply { get; set; } = "";
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}

public class Review
{
    public int Id { get; set; }
    public string BuyerEmail { get; set; } = "";
    public string BuyerName { get; set; } = "";
    public string VehicleTitle { get; set; } = "";
    public int Rating { get; set; }
    public string Comment { get; set; } = "";
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}

public class BankInfo
{
    public string BankName { get; set; } = "";
    public string AccountTitle { get; set; } = "";
    public string AccountNumber { get; set; } = "";
    public string Iban { get; set; } = "";
    public string SwiftCode { get; set; } = "";
    public string Branch { get; set; } = "";
}