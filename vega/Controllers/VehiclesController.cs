using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vega.Controllers.Resources;
using vega.Models;

namespace vega.Controllers
{
    [Route("/api/vehicles")]
    public class VehiclesController : Controller
    {
        private IMapper _mapper;
        private readonly VegaDBContext context;

        public VehiclesController(IMapper mapper, VegaDBContext context)
        {
            this.context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateVehicle([FromBody]VehicleResource vehicleResource)
        {
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            var vehicle = _mapper.Map<VehicleResource, Vehicle>(vehicleResource);
            vehicle.LastUpdate = DateTime.Now;
            context.Vehicles.Add(vehicle);
            await context.SaveChangesAsync();

            var result = Mapper.Map<Vehicle, VehicleResource>(vehicle);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVehicle(int id, [FromBody]VehicleResource vehicleResource)
        {
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }

            var vehicle = await context.Vehicles.Include(v => v.Features).SingleOrDefaultAsync(v => v.Id == id);

            _mapper.Map<VehicleResource, Vehicle>(vehicleResource, vehicle);
            vehicle.LastUpdate = DateTime.Now;
            
            await context.SaveChangesAsync();

            var result = Mapper.Map<Vehicle, VehicleResource>(vehicle);
            return Ok(result);
        }
    }
}