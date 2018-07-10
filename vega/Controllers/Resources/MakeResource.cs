using System.Collections.Generic;
using System.Collections.ObjectModel;
using vega.Models;

namespace vega.Controllers.Resources
{
    public class MakeResource
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Model> Models { get;set; }

        MakeResource(){
            Models = new Collection<ModelResource>();
        }
    }
}