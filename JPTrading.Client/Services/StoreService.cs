using JPTrading.Client.Models;

namespace JPTrading.Client.Services;

public class StoreService
{
    private const string DemoEmail = "buyer@jptrading.com";
    private int _orderId = 1000, _notifId = 0, _inqId = 0, _revId = 0;

    public event Action? OnChange;

    public List<Order> Orders { get; } = new();
    public List<Notification> Notifications { get; } = new();
    public List<Inquiry> Inquiries { get; } = new();
    public List<Review> Reviews { get; } = new();

    public BankInfo Bank { get; set; } = new()
    {
        BankName = "Mitsui Sumitomo Bank",
        AccountTitle = "J.P Trading Co. Ltd",
        AccountNumber = "1234567890",
        Iban = "JP00 0000 0000 0000 0000 00",
        SwiftCode = "SMBCJPJT",
        Branch = "Yokohama Branch"
    };

    public StoreService()
    {
        var o1 = SeedOrder(1, "2018 Toyota Prius", 1450000, 4023750, "Shipped", 9);
        var o2 = SeedOrder(2, "2017 Honda Fit", 950000, 2636250, "Delivered", 40);
        AddNotification(DemoEmail, $"Order #{o1.Id} update", $"Your order for {o1.VehicleTitle} is now: Shipped.");
        AddNotification(DemoEmail, $"Order #{o2.Id} update", $"Your order for {o2.VehicleTitle} is now: Delivered.");
    }

    private void Notify() => OnChange?.Invoke();

    private Order SeedOrder(int vId, string title, decimal jpy, decimal total, string status, int daysAgo)
    {
        var o = new Order
        {
            Id = ++_orderId,
            VehicleId = vId,
            VehicleTitle = title,
            BuyerEmail = DemoEmail,
            BuyerName = "Demo Buyer",
            PriceJpy = jpy,
            Country = "Pakistan",
            Currency = "PKR",
            TotalLocal = total,
            Status = status,
            CreatedAt = DateTime.Now.AddDays(-daysAgo)
        };
        Orders.Add(o);
        return o;
    }

    // Orders
    public Order CreateOrder(Vehicle v, AppUser user, Country c, decimal totalLocal)
    {
        var o = new Order
        {
            Id = ++_orderId,
            VehicleId = v.Id,
            VehicleTitle = v.Title,
            BuyerEmail = user.Email,
            BuyerName = user.FullName,
            PriceJpy = v.PriceJpy,
            Country = c.Name,
            Currency = c.Currency,
            TotalLocal = totalLocal
        };
        Orders.Add(o);
        AddNotification(user.Email, $"Order #{o.Id} received",
            $"Your request for {v.Title} was submitted. We will confirm it soon.");
        return o;
    }

    public List<Order> OrdersFor(string email) =>
        Orders.Where(o => o.BuyerEmail.Equals(email, StringComparison.OrdinalIgnoreCase))
              .OrderByDescending(o => o.CreatedAt).ToList();

    public Order? GetOrder(int id) => Orders.FirstOrDefault(o => o.Id == id);

    public void SetStatus(int id, string status)
    {
        var o = GetOrder(id);
        if (o == null) return;
        o.Status = status;
        AddNotification(o.BuyerEmail, $"Order #{o.Id} update", $"Your order for {o.VehicleTitle} is now: {status}.");
    }

    // Notifications
    public void AddNotification(string email, string title, string message)
    {
        Notifications.Add(new Notification { Id = ++_notifId, BuyerEmail = email, Title = title, Message = message });
        Notify();
    }

    public List<Notification> NotificationsFor(string email) =>
        Notifications.Where(n => n.BuyerEmail.Equals(email, StringComparison.OrdinalIgnoreCase))
                     .OrderByDescending(n => n.CreatedAt).ToList();

    public int UnreadCount(string email) =>
        Notifications.Count(n => !n.IsRead && n.BuyerEmail.Equals(email, StringComparison.OrdinalIgnoreCase));

    public void MarkRead(int id)
    {
        var n = Notifications.FirstOrDefault(x => x.Id == id);
        if (n != null) { n.IsRead = true; Notify(); }
    }

    public void MarkAllRead(string email)
    {
        foreach (var n in Notifications.Where(x => x.BuyerEmail.Equals(email, StringComparison.OrdinalIgnoreCase)))
            n.IsRead = true;
        Notify();
    }

    // Inquiries
    public void AddInquiry(string email, string name, string subject, string message)
    {
        Inquiries.Add(new Inquiry { Id = ++_inqId, BuyerEmail = email, BuyerName = name, Subject = subject, Message = message });
        Notify();
    }

    public List<Inquiry> InquiriesFor(string email) =>
        Inquiries.Where(i => i.BuyerEmail.Equals(email, StringComparison.OrdinalIgnoreCase))
                 .OrderByDescending(i => i.CreatedAt).ToList();

    public void ReplyToInquiry(int id, string reply)
    {
        var i = Inquiries.FirstOrDefault(x => x.Id == id);
        if (i == null) return;
        i.Reply = reply;
        AddNotification(i.BuyerEmail, "Reply to your inquiry", $"We replied to: {i.Subject}");
    }

    // Reviews
    public void AddReview(string email, string name, string vehicle, int rating, string comment)
    {
        Reviews.Add(new Review { Id = ++_revId, BuyerEmail = email, BuyerName = name, VehicleTitle = vehicle, Rating = rating, Comment = comment });
        Notify();
    }

    public List<Review> ReviewsFor(string email) =>
        Reviews.Where(r => r.BuyerEmail.Equals(email, StringComparison.OrdinalIgnoreCase))
               .OrderByDescending(r => r.CreatedAt).ToList();
}