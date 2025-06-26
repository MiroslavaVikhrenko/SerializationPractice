using System.Text.Json;

namespace _20250625_Task2
{
    /*
     Разработать класс «Счет для оплаты». В классе предусмотреть следующие поля: 

■ оплата за день; 
■ количество дней; 
■ штраф за один день задержки оплаты; 
■ количество дней задержи оплаты; 
■ сумма к оплате без штрафа (вычисляемое поле); 
■ штраф (вычисляемое поле); 
■ общая сумма к оплате (вычисляемое поле). 

В классе объявить статическое свойство типа bool, значение которого влияет на процесс 
    форматирования объектов этого класса. Если значение этого свойства равно true, тогда 
    сериализуются и десериализируются все поля, если false — вычисляемые поля не сериализуются. 

Разработать приложение, в котором необходимо продемонстрировать использование этого класса, 
    результаты должны записываться и считываться из файла.
     */
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = "invoice.json";

            Invoice invoice = new Invoice
            {
                PaymentPerDay = 100.0m,
                NumberOfDays = 10,
                PenaltyPerDay = 20.0m,
                DaysOverdue = 5
            };

            // SERIALIZE 

            Invoice.IncludeCalculatedFields = true; 
            var optionsWith = new JsonSerializerOptions { WriteIndented = true };
            optionsWith.Converters.Add(new InvoiceConverter());

            string jsonWith = JsonSerializer.Serialize(invoice, optionsWith);
            File.WriteAllText(filePath, jsonWith);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Serialized with calculated fields:");
            Console.ResetColor();
            Console.WriteLine(jsonWith);

            // DESERIALIZE

            string jsonFromFile = File.ReadAllText(filePath);
            Invoice deserializedInvoice = JsonSerializer.Deserialize<Invoice>(jsonFromFile, optionsWith);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Deserialized invoice:");
            Console.ResetColor();
            Console.WriteLine(deserializedInvoice);
        }
    }
}
