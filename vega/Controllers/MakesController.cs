using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vega.Models;

namespace vega.Controllers
{
    public class MakesController : Controller
    {
        private readonly VegaDBContext _context;

        public MakesController(VegaDBContext context)
        {
            this._context = context;
        }
        
        
        [HttpGet("/api/makes")]
        public async Task<IEnumerable<Make>> GetMakes(){
            return await _context.Makes.Include( m => m.Models).ToListAsync();


        }

    }
}