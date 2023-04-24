using BusinessLogicLayer.Interfaces;
using DataAccessLayer.IRepository;
using DataAccessLayer.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BusinessLogicLayer.Services
{
    public class GenericService<T> : IGenericService<T> where T : class
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<T> _repository;

        public GenericService(IUnitOfWork unitOfWork, IGenericRepository<T> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public async Task<T> Add(T entity)
        {
            var returnObject = await _repository.AddAsync(entity);
            await _unitOfWork.CompleteAsync();
            return returnObject;
        }

        public async Task<List<T>> AddRange(List<T> entities)
        {
            var returnObjects = await _repository.AddRangeAsync(entities);
            await _unitOfWork.CompleteAsync();

            return returnObjects;
        }

        public async Task<T> GetById(int Id)
        {
            var returnObject = await _repository.GetByIdAsync(Id);
            return returnObject;
        }

        public async Task<List<T>> GetAll()
        {

            var returnObjects = await _repository.GetAllAsync();
            return returnObjects;
        }

        public async Task<T> Remove(int Id)
        {
            var returnObject = await _repository.GetByIdAsync(Id);

            if (returnObject != null)
            {
                _repository.Remove(returnObject);
                await _unitOfWork.CompleteAsync();
                return returnObject;

            }
            return returnObject;
        }

        public async Task<List<T>> RemoveRange(List<T> entities)
        {
            _repository.RemoveRange(entities);
            await _unitOfWork.CompleteAsync();

            return entities;
        }

    }
}
