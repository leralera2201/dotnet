using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Lab1.DTOs.TagDTOs;
using Lab1.Entities;
using Lab1.Interfaces;
using Lab1.Interfaces.SqlServices;
using Lab1.Entities.Parameters;

namespace Lab1.Services
{
    public class TagService : ITagService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TagService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        public async Task<IEnumerable<Tag>> GetAll(TagParameters parameters)
        {
            return await _unitOfWork._tagRepository.GetAll(parameters);
        }

        public async Task<Tag> GetOneById(int id)
        {
            return await _unitOfWork._tagRepository.GetOneById(id);
        }

        public async Task<Tag> Create(TagRequestDto dto)
        {
            Tag entity = _mapper.Map<TagRequestDto, Tag>(dto);
            Tag station = await _unitOfWork._tagRepository.Create(entity);
            await _unitOfWork.SaveChanges();
            return station;
        }

        public async Task<int> DeleteById(int id)
        {
            if (!await _unitOfWork._tagRepository.ExistsById(id))
                throw new HttpRequestException("Entity with specified id not found", null, HttpStatusCode.NotFound);
            
            int byId = await _unitOfWork._tagRepository.DeleteById(id);
            await _unitOfWork.SaveChanges();
            return byId;
        }

        public async Task<Tag> Update(int id, TagRequestDto dto)
        {
            Tag entity = _mapper.Map<TagRequestDto, Tag>(dto);
            entity.Id = id;
            Tag station = await _unitOfWork._tagRepository.Update(entity);
            await _unitOfWork.SaveChanges();
            return station;
        }
    }
}