using System.Collections.Generic;
using System.Threading.Tasks;

using SyncfusionWpfApp.Models;

namespace SyncfusionWpfApp.Contracts.Services
{
    public interface ISampleDataService
    {
        Task<IEnumerable<SampleOrder>> GetMasterDetailDataAsync();
    }
}
