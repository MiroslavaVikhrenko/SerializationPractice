using System.Text.Json;

namespace SerializationPractice
{
    /*
     Сформировать файл, содержащий информацию о бытовых холодильниках: название холодильника, стоимость, 
    объем холодильной камеры, завод-изготовитель. Используя сформированный файл, распечатайте информацию о холодильниках, 
    стоимость которых более 55000 гривен
     */
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = "refrigerators.txt";

            List<Refrigerator> refrigerators = new List<Refrigerator>
            {
                new Refrigerator { Name = "Samsung RT38K", Price = 45000, Volume = 380, Manufacturer = "Samsung" },
                new Refrigerator { Name = "LG GA-B459", Price = 56000, Volume = 400, Manufacturer = "LG" },
                new Refrigerator { Name = "Bosch KGN39", Price = 67000, Volume = 390, Manufacturer = "Bosch" },
                new Refrigerator { Name = "Atlant XM", Price = 49000, Volume = 320, Manufacturer = "Atlant" },
                new Refrigerator { Name = "Whirlpool W7", Price = 75000, Volume = 420, Manufacturer = "Whirlpool" }
            };

            string jsonToFile = JsonSerializer.Serialize(refrigerators, new JsonSerializerOptions { WriteIndented = true });

            File.WriteAllText(filePath, jsonToFile);

            string jsonFromFile = File.ReadAllText(filePath);
            List<Refrigerator> loadedRefrigerators = JsonSerializer.Deserialize<List<Refrigerator>>(jsonFromFile);

            Console.WriteLine("Refrigerators with price more than 55000 UAH:");
            PrintExpensiveRefrigerators(loadedRefrigerators, 55000);


        }

        static void PrintExpensiveRefrigerators(List<Refrigerator> refrigerators, decimal priceThreshold)
        {
            foreach (var fridge in refrigerators)
            {
                if (fridge.Price > priceThreshold)
                {
                    Console.WriteLine(fridge);
                }
            }
        }
    }

}
