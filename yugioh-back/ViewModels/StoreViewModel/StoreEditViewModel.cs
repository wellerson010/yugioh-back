using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back.ViewModels.StoreViewModel
{
    public class StoreEditViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }

        public StoreEditViewModel() { }

        public StoreEditViewModel(Store store)
        {
            Id = store.Id;
            Name = store.Name;
            Url = store.Url;
        }
    }
}
