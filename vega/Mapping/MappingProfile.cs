using AutoMapper;
using vega.Controllers.Resources;
using vega.Models;
using System.Linq;
using System.Collections.Generic;

namespace vega.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Domain to api results
            CreateMap<Make, MakeResource>();
            CreateMap<Model, ModelResource> ();
            CreateMap<Feature, FeatureResource>();
            CreateMap<Vehicle, VehicleResource>()
                .ForMember(vr => vr.Contact, opt => opt.MapFrom( v => new ContactResource{Name = v.ContactName, Phone= v.ContactPhone, Email = v.ContactEmail}))
                .ForMember(vr => vr.Features, opt =>  opt.MapFrom(v => v.Features.Select(vf => vf.FeatureId)));

            //Api to resource domain
            CreateMap<VehicleResource, Vehicle>()
                .ForMember(v => v.Id, opt => opt.Ignore())
                .ForMember(v => v.ContactName, opt => opt.MapFrom(vr => vr.Contact.Name))
                .ForMember(v => v.ContactEmail, opt => opt.MapFrom(vr => vr.Contact.Email))
                .ForMember(v => v.ContactPhone, opt => opt.MapFrom(vr => vr.Contact.Phone))
                .ForMember(v => v.Features, opt => opt.Ignore())
                .AfterMap((vr, v) => {
                    var toRemove =  v.Features.Where(f => !vr.Features.Contains(f.FeatureId));
                    foreach(var f in toRemove){
                        v.Features.Remove(f);
                    }
                    
                    var toAdd = vr.Features
                        .Where(id => !v.Features.Any(f=>f.FeatureId == id))
                        .Select(id => new VehicleFeature{FeatureId = id});
                    foreach(var f in toAdd){
                        v.Features.Add(f);
                    }
                });
        }
  }
}