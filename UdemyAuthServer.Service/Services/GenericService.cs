using Microsoft.EntityFrameworkCore;
using SharedLibrary.Dtos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using UdemyAuthServer.Core.Repositories;
using UdemyAuthServer.Core.Services;
using UdemyAuthServer.Core.UnitOfWork;

namespace UdemyAuthServer.Service.Services
{
    internal class GenericService<T, TDto> : IGenericService<T, TDto> where T : class where TDto : class
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<T> _genericRepository;

        public GenericService(
            IUnitOfWork unitOfWork,
            IGenericRepository<T> genericRepository
            )
        {
            _unitOfWork = unitOfWork;
            _genericRepository = genericRepository;
        }

        public async Task<Response<TDto>> AddAsync(TDto dto)
        {
            var newEntity = ObjectMapper.Mapper.Map<T>(dto);
            await _genericRepository.AddAsync(newEntity);

            await _unitOfWork.CommitAsync();

            var newDto = ObjectMapper.Mapper.Map<TDto>(newEntity);
            return Response<TDto>.Success(newDto);
        }

        public async Task<Response<IEnumerable<TDto>>> GetAllAsync()
        {
            var entities = await _genericRepository.GetAllAsync();
            var dtos = ObjectMapper.Mapper.Map<IEnumerable<TDto>>(entities);
            return Response<IEnumerable<TDto>>.Success(dtos);
        }

        public async Task<Response<TDto>> GetByIdAsync(int id)
        {
            var isExistEntity = await _genericRepository.GetByIdAsync(id);
            if (isExistEntity == null)
            {
                return Response<TDto>.Fail("Id not found", 404, true);
            }
            var dto = ObjectMapper.Mapper.Map<TDto>(isExistEntity);
            return Response<TDto>.Success(dto);
        }

        public async Task<Response<NoDataDto>> Remove(int id)
        {
            var isExistEntity = await _genericRepository.GetByIdAsync(id);
            if (isExistEntity == null)
            {
                return Response<NoDataDto>.Fail("Id not found", 404, true);
            }

            _genericRepository.Remove(isExistEntity);

            return Response<NoDataDto>.Success(204);
        }

        public async Task<Response<NoDataDto>> Update(int id, TDto dto)
        {
            var isExistEntity = await _genericRepository.GetByIdAsync(id);
            if (isExistEntity == null)
            {
                return Response<NoDataDto>.Fail("Id not found", 404, true);
            }

            var updatedEntity = ObjectMapper.Mapper.Map<T>(dto);
            _genericRepository.Update(updatedEntity);

            await _unitOfWork.CommitAsync();

            return Response<NoDataDto>.Success(204);
        }

        public async Task<Response<IEnumerable<TDto>>> Where(Expression<Func<T, bool>> expression)
        {
            var list = _genericRepository.Where(expression);
            var listDtos = ObjectMapper.Mapper.Map<IEnumerable<TDto>>(await list.ToListAsync());
            return Response<IEnumerable<TDto>>.Success(listDtos);
        }
    }
}
