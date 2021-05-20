using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Lab1.DTOs.ClientDTOs;
using Lab1.Entities;
using Lab1.Interfaces;
using Lab1.Interfaces.SqlServices;
using Lab1.Entities.Parameters;

namespace Lab1.Services
{
    public class ClientService : IClientService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ClientService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        public async Task<IEnumerable<Client>> GetAll(ClientParameters parameters)
        {
            return await _unitOfWork._clientRepository.GetAll(parameters);
        }

        public async Task<Client> GetOneById(int id)
        {
            return await _unitOfWork._clientRepository.GetOneById(id);
        }

        public async Task<Client> Create(ClientRequestDto dto)
        {
            Client entity = _mapper.Map<ClientRequestDto, Client>(dto);
            entity.User = await _unitOfWork._userRepository.GetOneById(dto.UserId);

            Client route = await _unitOfWork._clientRepository.Create(entity);
            await _unitOfWork.SaveChanges();
            return route;
        }

        public async Task<int> DeleteById(int id)
        {
            if (!await _unitOfWork._productRepository.ExistsById(id))
                throw new HttpRequestException("Entity with specified id not found", null, HttpStatusCode.NotFound);
            
            int byId = await _unitOfWork._clientRepository.DeleteById(id);
            await _unitOfWork.SaveChanges();
            return byId;
        }

        public async Task<Client> Update(int id, ClientRequestDto dto)
        {
            Client entity = _mapper.Map<ClientRequestDto, Client>(dto);
            entity.Id = id;
            entity.User = await _unitOfWork._userRepository.GetOneById(dto.UserId);

            Client route = await _unitOfWork._clientRepository.Update(entity);
            await _unitOfWork.SaveChanges();
            return route;
        }
    }
}