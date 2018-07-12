using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vega.Controllers.Resources;
using vega.Models;

namespace vega.Controllers
{
    public class FeaturesController : Controller
    {
        private readonly VegaDBContext context;

        private readonly IMapper mapper;

        public FeaturesController(VegaDBContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;
        }

         [HttpGet("/api/features")]
        public async Task<ICollection<FeatureResource>> GetFeatures(){
            var features = await context.Features.ToListAsync();

            return mapper.Map<ICollection<Feature>, ICollection<FeatureResource>>(features);
        }
    }
}