using Domain.Enum;

namespace Application.DTOs
{
    public class PagamentoDTO
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }

        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        public StatusPagamento Status { get; private set; }
    }
}
