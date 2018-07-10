using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vega.Controllers.Resources;
using vega.Models;

namespace vega.Controllers
{
    public class MakesController : Controller
    {
        private readonly VegaDBContext _context;
        private readonly IMapper mapper;

        public MakesController(VegaDBContext context, IMapper mapper)
        {
            this._context = context;
            this.mapper = mapper;
        }
        
        
        [HttpGet("/api/makes")]
        public async Task<IEnumerable<MakeResource>> GetMakes(){
            var makes = await _context.Makes.Include( m => m.Models).ToListAsync();

            return mapper.Map<List<Make>, List<MakeResource>>(makes);
        }

    }
}