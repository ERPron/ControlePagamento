using Domain.Enum;

namespace Application.DTOs
{
    public class PagamentoDTO
    {
        public Guid Id { get; set; }
        public Guid ClienteId { get; set; }

        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        public StatusPagamento Status { get; private set; }
    }
}
