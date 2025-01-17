using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Interfaces;

namespace Domain.Services
{
    public class PagamentoService : IPagamentoService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPagamentoRepository _pagamentoRepository;
        private Pagamento _pagamento; 

        public PagamentoService(IMapper mapper, IUnitOfWork unitOfWork, IPagamentoRepository pagamentoRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _pagamentoRepository = pagamentoRepository;
        }

        public async Task<PagamentoDTO> AddAsync(PagamentoDTO pagamentoDTO)
        {
            _pagamento = _mapper.Map<Pagamento>(pagamentoDTO);
            var sqlQuery = "Insert Into Pagamentos (id, clienteId, valor, data, status) values (@id, @clienteId, @valor, @data, @status)";
            var oReturn = await _pagamentoRepository.AddAsync(sqlQuery, _pagamento, _unitOfWork.BeginTransaction());

            _unitOfWork.Commit();
            return pagamentoDTO;
        }

        public async Task<PagamentoDTO> GetByClienteIdAsync(string clienteId)
        {
            var sqlQuery = $"Select * From Pagamentos Where ClienteId='{clienteId}'";
            var oReturn = await _pagamentoRepository.GetByClienteIdAsync(sqlQuery, _pagamento, _unitOfWork.BeginTransaction());
            return _mapper.Map<PagamentoDTO>(oReturn);
        }

        public async Task<PagamentoDTO> GetByIdAsync(string id)
        {
            var sqlQuery = $"Select * From Pagamentos Where Id='{id}'";
            var oReturn = await _pagamentoRepository.GetByClienteIdAsync(sqlQuery, _pagamento, _unitOfWork.BeginTransaction());
            return _mapper.Map<PagamentoDTO>(oReturn);
        }

        public async Task<PagamentoDTO> UpdateAsync(PagamentoDTO pagamentoDTO)
        {
            _pagamento = _mapper.Map<Pagamento>(pagamentoDTO);
            var sqlQuery = $"Update Pagamentos Set valor=@valor, data=@data, status=@status Where Id='{pagamentoDTO.Id}'";
            var oReturn = await _pagamentoRepository.UpdateAsync(sqlQuery, _pagamento, _unitOfWork.BeginTransaction());

            _unitOfWork.Commit();
            return pagamentoDTO;
        }
    }
}
