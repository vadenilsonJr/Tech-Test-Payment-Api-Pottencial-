using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tech_test_payment_api.Src.Models
{
    public class Vendas
    {
        public int Id { get; set; }
        public string Produto { get; set; }
        public string Vendedor { get; set; }
        public DateTime Data { get; set; }
        public EnumStatusVenda Status { get; set; }
    }
}