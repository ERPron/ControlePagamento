using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Interfaces;
using System.Data;

namespace Domain.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IClienteRepository _repository;
        private Cliente _cliente;

        public ClienteService(IClienteRepository repository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<ClienteDTO> AddAsync(ClienteDTO cliente)
        {
            _cliente = _mapper.Map<Cliente>(cliente);
            var sqlQuery = "Insert Into Clientes (id, nome, email) values (@id, @nome, @email)";
            var oReturn = await _repository.AddAsync(sqlQuery, _cliente, _unitOfWork.BeginTransaction());

            _unitOfWork.Commit();
            return cliente;
        }

        public async Task<IEnumerable<ClienteDTO>> GetAllAsync()
        {
            var sqlQuery = "Select * From Clientes";
            var oReturn = await _repository.GetAllAsync(sqlQuery, _cliente, _unitOfWork.BeginTransaction());
            return _mapper.Map<IEnumerable<ClienteDTO>>(oReturn);
        }

        public async Task<ClienteDTO> GetByIdAsync(string id)
        {
            var sqlQuery = $"Select * From Clientes Where id='{id}'";
            var oReturn = await _repository.GetByIdAsync(sqlQuery, _cliente, _unitOfWork.BeginTransaction());
            return _mapper.Map<ClienteDTO>(oReturn);
        }
    }
}
