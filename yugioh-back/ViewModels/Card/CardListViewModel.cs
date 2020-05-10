using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back.ViewModels.Card
{
    public class CardListViewModel
    {
        public string Name { get; set; }

        public CardListViewModel(ICard card)
        {
            Name = card.Name;
        }
    }
}
