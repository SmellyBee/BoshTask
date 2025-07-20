using BoshAPI.Entities;
using BoshAPI.SeedFile;
using System.Text.Json;

namespace BoshAPI.Repository
{
    public static class DatabaseSeeder
    {
        public static async Task SeedAsync(AppDbContext context)
        {
            if (!context.Products.Any())
            {
                var json = await File.ReadAllTextAsync("SeedFile/products.json");
                var products = JsonSerializer.Deserialize<List<ProductSeedDto>>(json);
                Console.WriteLine("Seeding started...");

                if (!File.Exists("SeedFile/products.json"))
                {
                    Console.WriteLine("products.json file not found!");
                    return;
                }
                foreach (var item in products!)
                {
                    var product = new Product
                    {
                        Name = item.name,
                        ShortDescription = item.shortDescription,
                        FullDescription = item.fullDescription,
                        Price = item.price,
                        TechsSpec = new TechsSpec
                        {
                            BatteryVoltage = TryParseDecimal(item.technicalSpecifications.GetValueOrDefault("Battery Voltage")),
                            MaxTorque = TryParseDecimal(item.technicalSpecifications.GetValueOrDefault("Max Torque")),
                            Weight = TryParseDecimal(item.technicalSpecifications.GetValueOrDefault("Weight")),
                            ChuckSize = TryParseDecimal(item.technicalSpecifications.GetValueOrDefault("Chuck Size")),
                            NoLoadSpeed = item.technicalSpecifications.GetValueOrDefault("No Load Speed") ?? "N/A",
                            PowerInput = TryParseDecimal(item.technicalSpecifications.GetValueOrDefault("Power")),
                            DiscDiameter = TryParseDecimal(item.technicalSpecifications.GetValueOrDefault("Disc Diameter")),
                            ImpactEnergy = TryParseDecimal(item.technicalSpecifications.GetValueOrDefault("Impact Energy")),
                            DrillDiameterConcrete = TryParseDecimal(item.technicalSpecifications.GetValueOrDefault("Drill Diameter Concrete")),
                            StrokeLength = TryParseDecimal(item.technicalSpecifications.GetValueOrDefault("Stroke Length")),
                            OscillationAngle = TryParseDecimal(item.technicalSpecifications.GetValueOrDefault("Oscillation Angle")),
                            Speed = item.technicalSpecifications.GetValueOrDefault("Speed") ?? "N/A",
                            BladeDiametar = TryParseDecimal(item.technicalSpecifications.GetValueOrDefault("Blade Diameter")),
                            PlaningWidth = TryParseDecimal(item.technicalSpecifications.GetValueOrDefault("Planing Width")),
                            MeasuringRange = item.technicalSpecifications.GetValueOrDefault("Measuring Range") ?? "N/A",
                            Bluetooth = item.technicalSpecifications.GetValueOrDefault("Bluetooth") ?? "N/A",
                            TemperatureRang = item.technicalSpecifications.GetValueOrDefault("Temperature Range") ?? "N/A"
                        }
                    };

                    product.Images = item.images.Select(imageName => new Image
                    {
                        Name = imageName,
                        Product = product
                    }).ToList();

                    context.Products.Add(product);
                }

                var cart = new Cart
                {
                    Check = 0,

                };

                context.Carts.Add(cart);

                try
                {
                    await context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Seeding failed: " + ex.Message);
                }

                

            }
        }

        private static decimal TryParseDecimal(string? input)
        {
            if (string.IsNullOrWhiteSpace(input)) return 0;

            // Strip common units
            var cleaned = new string(input
                .Where(c => char.IsDigit(c) || c == '.' || c == ',')
                .ToArray());

            // Use invariant culture
            return decimal.TryParse(cleaned.Replace(",", "."), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out var result)
                ? result
                : 0;
        }
    }
}
