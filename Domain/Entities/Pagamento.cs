using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Pagamento
    {
        public Guid Id { get; set; }
        public Guid ClienteId { get; set; }

        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        public StatusPagamento Status { get; private set; }

    }
}
