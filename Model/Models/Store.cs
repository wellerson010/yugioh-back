using Model.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Models
{
    public class Store:IBaseModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }
    }
}
