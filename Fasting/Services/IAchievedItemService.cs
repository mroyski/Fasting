using Fasting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fasting.Services
{
    public interface IAchievedItemService
    {
        Task<Rhythm[]> GetIncompleteItemsAsync();
        Task<bool> MarkDoneAsync(int id);
        Task<bool> MarkNotDoneAsync(int id);

    }
}
