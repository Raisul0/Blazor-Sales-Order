using DomainLayer.Entities.Locations;
using DomainLayer.VModels.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces.Locations
{
    public interface IStateService : IGenericService<State>
    {
        Task<List<VState>> GetAllStates();
    }
}
