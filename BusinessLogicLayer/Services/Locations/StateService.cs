using AutoMapper;
using BusinessLogicLayer.Interfaces.Locations;
using DataAccessLayer.IRepository;
using DataAccessLayer.UnitOfWork;
using DomainLayer.Entities.Locations;
using DomainLayer.VModels.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.Locations
{
    public class StateService : GenericService<State>, IStateService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StateService(IUnitOfWork unitOfWork,IMapper mapper) : base(unitOfWork, unitOfWork.State)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<VState>> GetAllStates()
        {
            var states = await _unitOfWork.State.GetAllAsync();
            var vStates = _mapper.Map<List<State>, List<VState>>(states);

            return vStates;
        }
    }
}
