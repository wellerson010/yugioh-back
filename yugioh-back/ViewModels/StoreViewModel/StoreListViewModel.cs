using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back.ViewModels.StoreViewModel
{
    public class StoreListViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public StoreListViewModel(Store store)
        {
            Id = store.Id;
            Name = store.Name;
        }
    }
}
