using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Back.ViewModels;
using Back.ViewModels.StoreViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Interfaces.Repositories;
using Model.Models;

namespace Back.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IRepository<Store> StoreRepository;

        public StoreController(IRepository<Store> storeRepository)
        {
            StoreRepository = storeRepository;
        }

        [Route("save")]
        [HttpPost]
        public async Task<ResponseViewModel<bool>> Save([FromBody] StoreEditViewModel data)
        {
            Store store;

            if (String.IsNullOrEmpty(data.Id))
            {
                store = new Store();
            }
            else
            {
                store = await StoreRepository.GetById(data.Id);
            }

            store.Name = data.Name;
            store.Url = data.Url;

            await StoreRepository.Save(store);

            return new ResponseViewModel<bool>(true);
        }

        [Route("list")]
        [HttpGet]
        public async Task<ResponseViewModel<IList<StoreListViewModel>>> List()
        {
            List<Store> stores = await StoreRepository.GetAll();

            List<StoreListViewModel> viewModels = stores.Select(x => new StoreListViewModel(x)).ToList();

            return new ResponseViewModel<IList<StoreListViewModel>>(viewModels);
        }
    }
}
