using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace _20250625_Task2
{
    public class InvoiceConverter : JsonConverter<Invoice>
    {

        public override Invoice Read (ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            Invoice invoice = new Invoice();
            using (var doc = JsonDocument.ParseValue(ref reader))
            {
                var root = doc.RootElement;
                invoice.PaymentPerDay = root.GetProperty("PaymentPerDay").GetDecimal();
                invoice.NumberOfDays = root.GetProperty("NumberOfDays").GetInt32();
                invoice.PenaltyPerDay = root.GetProperty("PenaltyPerDay").GetDecimal();
                invoice.DaysOverdue = root.GetProperty("DaysOverdue").GetInt32();
                if (Invoice.IncludeCalculatedFields)
                {
                    // These properties are calculated, so we don't need to set them explicitly
                    // They will be calculated automatically when accessed
                }
            }
            return invoice;
        }

        public override void Write (Utf8JsonWriter writer, Invoice invoice, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WriteNumber("PaymentPerDay", invoice.PaymentPerDay);
            writer.WriteNumber("NumberOfDays", invoice.NumberOfDays);
            writer.WriteNumber("PenaltyPerDay", invoice.PenaltyPerDay);
            writer.WriteNumber("DaysOverdue", invoice.DaysOverdue);
            if (Invoice.IncludeCalculatedFields)
            {
                writer.WriteNumber("TotalWithoutPenalty", invoice.TotalWithoutPenalty);
                writer.WriteNumber("PenaltyAmount", invoice.PenaltyAmount);
                writer.WriteNumber("TotalWithPenalty", invoice.TotalWithPenalty);
            }
            writer.WriteEndObject();
        }
    }
}
