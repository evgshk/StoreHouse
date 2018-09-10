using StoreHouse.API.Models.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreHouse.API.Services.Interfaces
{
    public interface IDocumentsService
    {
        Task<DocumentItemModel> GetItem(Guid id);
        Task<DocumentListModel> GetItems();
        Task<DocumentAddItemModel> GetItemAddModel();
        Task<bool> AddItem(DocumentAddItemModel model);
    }
}
