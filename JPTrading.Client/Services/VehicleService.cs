using JPTrading.Client.Models;

namespace JPTrading.Client.Services;

public class VehicleService
{
    private readonly List<Vehicle> _vehicles;

    public VehicleService()
    {
        _vehicles = new List<Vehicle>
        {
            V(1, "Toyota", "Prius", 2018, 52000, 1450000, "Hybrid", "Automatic", "Hatchback", "White", 1800, "Yokohama",
              "Fuel efficient hybrid with clean interior.",
              Sheet("USS Tokyo", "4.5", "B", "B",
                ("修復歴なし", "No accident repair history"),
                ("フロントバンパー擦り傷", "Scrape on front bumper"),
                ("内装きれい", "Interior clean"))),
            V(2, "Honda", "Fit", 2017, 61000, 950000, "Petrol", "Automatic", "Hatchback", "Silver", 1300, "Osaka",
              "Compact and easy to drive in the city.",
              Sheet("HAA Kobe", "4", "B", "C",
                ("修復歴なし", "No accident repair history"),
                ("ドアに小さなへこみ", "Small dent on door"),
                ("タバコ臭なし", "No cigarette smell"))),
            V(3, "Toyota", "Corolla Axio", 2019, 38000, 1300000, "Petrol", "Automatic", "Sedan", "Pearl White", 1500, "Nagoya",
              "Low mileage sedan in very good condition.",
              Sheet("TAA Chubu", "4.5", "A", "B",
                ("修復歴なし", "No accident repair history"),
                ("走行距離確認済み", "Mileage verified"),
                ("内装きれい", "Interior clean"))),
            V(4, "Suzuki", "Alto", 2020, 24000, 780000, "Petrol", "Automatic", "Kei Car", "Red", 660, "Tokyo",
              "Light kei car, very low running cost.",
              Sheet("USS Tokyo", "4", "B", "B",
                ("修復歴なし", "No accident repair history"),
                ("小キズあり", "Small scratches"))),
            V(5, "Nissan", "Note e-Power", 2018, 47000, 1100000, "Hybrid", "Automatic", "Hatchback", "Blue", 1200, "Yokohama",
              "e-Power hybrid with smooth drive.",
              Sheet("USS Yokohama", "4", "B", "B",
                ("修復歴なし", "No accident repair history"),
                ("エンジン良好", "Engine in good condition"))),
            V(6, "Toyota", "Land Cruiser Prado", 2016, 78000, 3900000, "Diesel", "Automatic", "SUV", "Black", 2800, "Osaka",
              "Strong 4WD SUV for rough roads.",
              Sheet("HAA Kobe", "4", "B", "B",
                ("修復歴なし", "No accident repair history"),
                ("フロントバンパー擦り傷", "Scrape on front bumper"),
                ("走行距離確認済み", "Mileage verified"))),
            V(7, "Honda", "Vezel", 2018, 43000, 1600000, "Hybrid", "Automatic", "SUV", "Grey", 1500, "Tokyo",
              "Stylish compact SUV hybrid.",
              Sheet("USS Tokyo", "4.5", "B", "A",
                ("修復歴なし", "No accident repair history"),
                ("内装きれい", "Interior clean"),
                ("タバコ臭なし", "No cigarette smell"))),
            V(8, "Mazda", "CX-5", 2017, 66000, 1700000, "Diesel", "Automatic", "SUV", "Red", 2200, "Nagoya",
              "Diesel SUV with good power and comfort.",
              Sheet("TAA Chubu", "4", "B", "B",
                ("修復歴なし", "No accident repair history"),
                ("ドアに小さなへこみ", "Small dent on door"))),
            V(9, "Toyota", "Hiace", 2017, 90000, 2400000, "Diesel", "Automatic", "Van", "White", 2800, "Yokohama",
              "Spacious van for passengers or cargo.",
              Sheet("USS Yokohama", "3.5", "C", "C",
                ("小キズあり", "Small scratches"),
                ("走行距離確認済み", "Mileage verified"))),
            V(10, "Daihatsu", "Tanto", 2019, 30000, 850000, "Petrol", "Automatic", "Kei Car", "Pink", 660, "Osaka",
              "Roomy kei car with sliding door.",
              Sheet("HAA Kobe", "4", "B", "B",
                ("修復歴なし", "No accident repair history"),
                ("内装きれい", "Interior clean")))
        };
    }

    public List<Vehicle> GetAll() => _vehicles;

    public Vehicle? GetById(int id) => _vehicles.FirstOrDefault(v => v.Id == id);

    private static Vehicle V(int id, string make, string model, int year, int km, decimal price,
        string fuel, string trans, string body, string color, int cc, string loc, string desc, AuctionSheet sheet)
        => new()
        {
            Id = id,
            Make = make,
            Model = model,
            Year = year,
            Mileage = km,
            PriceJpy = price,
            FuelType = fuel,
            Transmission = trans,
            BodyType = body,
            Color = color,
            EngineCc = cc,
            Location = loc,
            Description = desc,
            Sheet = sheet
        };

    private static AuctionSheet Sheet(string house, string overall, string ext, string inter,
        params (string jp, string en)[] notes)
        => new()
        {
            AuctionHouse = house,
            OverallGrade = overall,
            ExteriorGrade = ext,
            InteriorGrade = inter,
            Notes = notes.Select(n => new SheetNote { Japanese = n.jp, English = n.en }).ToList()
        };
}