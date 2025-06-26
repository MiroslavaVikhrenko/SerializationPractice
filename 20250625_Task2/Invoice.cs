using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace _20250625_Task2
{
    public class Invoice
    {
        public decimal PaymentPerDay { get; set; }
        public int NumberOfDays { get; set; }
        public decimal PenaltyPerDay { get; set; }
        public int DaysOverdue { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public decimal TotalWithoutPenalty => PaymentPerDay * NumberOfDays;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public decimal PenaltyAmount => PenaltyPerDay * DaysOverdue;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public decimal TotalWithPenalty => TotalWithoutPenalty + PenaltyAmount;

        public static bool IncludeCalculatedFields { get; set; } = true;

        public override string ToString()
        {
            return $"Invoice: PaymentPerDay={PaymentPerDay}, NumberOfDays={NumberOfDays}, " +
                   $"PenaltyPerDay={PenaltyPerDay}, DaysOverdue={DaysOverdue}, " +
                   $"TotalWithoutPenalty={TotalWithoutPenalty}, PenaltyAmount={PenaltyAmount}, " +
                   $"TotalWithPenalty={TotalWithPenalty}";
        }

    }
}
