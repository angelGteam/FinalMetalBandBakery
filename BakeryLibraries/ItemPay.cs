using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryLibraries {
    public class ItemPay {
        public ItemPay() {
        }

        public ItemPay(double amount, string payer, string reciver) {
            Amount = amount;
            Payer = payer;
            Reciver = reciver;
            Date = DateTime.Now;
        }
        public double Amount { get; set; }
        public string Payer { get; set; }
        public string Reciver { get; set; }
        public DateTime Date { get; set; }
    }
}
