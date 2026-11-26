using JPTrading.Client.Models;

namespace JPTrading.Client.Services;

public class CurrencyService
{
    public List<Country> Countries { get; } = new()
    {
        new Country { Name = "Pakistan",       Currency = "PKR", RatePerJpy = 1.85m,   DutyPercent = 50 },
        new Country { Name = "Kenya",          Currency = "KES", RatePerJpy = 0.86m,   DutyPercent = 35 },
        new Country { Name = "Tanzania",       Currency = "TZS", RatePerJpy = 17m,     DutyPercent = 30 },
        new Country { Name = "Uganda",         Currency = "UGX", RatePerJpy = 24m,     DutyPercent = 30 },
        new Country { Name = "Zambia",         Currency = "ZMW", RatePerJpy = 0.18m,   DutyPercent = 25 },
        new Country { Name = "Bangladesh",     Currency = "BDT", RatePerJpy = 0.79m,   DutyPercent = 60 },
        new Country { Name = "Sri Lanka",      Currency = "LKR", RatePerJpy = 2.0m,    DutyPercent = 70 },
        new Country { Name = "United Kingdom", Currency = "GBP", RatePerJpy = 0.0050m, DutyPercent = 10 },
        new Country { Name = "UAE",            Currency = "AED", RatePerJpy = 0.024m,  DutyPercent = 5 }
    };

    public Country Selected { get; private set; }

    public CurrencyService()
    {
        Selected = Countries[0];
    }

    public void Select(string name)
    {
        var found = Countries.FirstOrDefault(c => c.Name == name);
        if (found != null) Selected = found;
    }
    public void AddCountry(Country c) => Countries.Add(c);

    public void RemoveCountry(Country c)
    {
        if (Countries.Count > 1)
        {
            Countries.Remove(c);
            if (Selected == c) Selected = Countries[0];
        }
    }

    public decimal Convert(decimal jpy, Country? country = null)
        => Math.Round(jpy * (country ?? Selected).RatePerJpy, 0);

    public decimal Duty(decimal jpy, Country? country = null)
    {
        var c = country ?? Selected;
        return Math.Round(Convert(jpy, c) * c.DutyPercent / 100m, 0);
    }

    public string Format(decimal jpy, Country? country = null)
        => $"{(country ?? Selected).Currency} {Convert(jpy, country):N0}";
}