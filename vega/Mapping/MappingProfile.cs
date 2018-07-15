using AutoMapper;
using vega.Controllers.Resources;
using vega.Models;
using System.Linq;

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

            //Api to resource domain
            CreateMap<VehicleResource, Vehicle>()
                .ForMember(v => v.ContactName, opt => opt.MapFrom(vr => vr.Contact.Name))
                .ForMember(v => v.ContactEmail, opt => opt.MapFrom(vr => vr.Contact.Email))
                .ForMember(v => v.ContactPhone, opt => opt.MapFrom(vr => vr.Contact.Phone))
                .ForMember(v => v.Features, opt => opt.MapFrom(vr => vr.Features.Select(f => new VehicleFeature{FeatureId = f})));
        }
  }
}