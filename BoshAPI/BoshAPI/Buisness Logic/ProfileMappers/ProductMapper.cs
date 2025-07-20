using AutoMapper;
using BoshAPI.Buisness_Logic.DTO;
using BoshAPI.Entities;

namespace BoshAPI.Buisness_Logic.Maps
{
    public class ProductMapper: Profile
    {
        public ProductMapper() {

            CreateMap<Product, CardItemDto>().ForMember(dest => dest.Image, opt => opt.MapFrom(src =>
            src.Images != null && src.Images.Count > 1 ? src.Images[0].Name : null
            )).ReverseMap();

            CreateMap<TechsSpec, TechSpecDto>()
            .AfterMap((src, dest) =>
            {
                if (src.BatteryVoltage == 0) dest.BatteryVoltage = null;
                if (src.MaxTorque == 0) dest.MaxTorque = null;
                if (src.Weight == 0) dest.Weight = null;
                if (src.ChuckSize == 0) dest.ChuckSize = null;
                if (src.PowerInput == 0) dest.PowerInput = null;
                if (src.DiscDiameter == 0) dest.DiscDiameter = null;
                if (src.ImpactEnergy == 0) dest.ImpactEnergy = null;
                if (src.DrillDiameterConcrete == 0) dest.DrillDiameterConcrete = null;
                if (src.StrokeLength == 0) dest.StrokeLength = null;
                if (src.OscillationAngle == 0) dest.OscillationAngle = null;
                if (src.BladeDiametar == 0) dest.BladeDiametar = null;
                if (src.PlaningWidth == 0) dest.PlaningWidth = null;

                if (src.NoLoadSpeed == "N/A") dest.NoLoadSpeed = null;
                if (src.Speed == "N/A") dest.Speed = null;
                if (src.MeasuringRange == "N/A") dest.MeasuringRange = null;
                if (src.Bluetooth == "N/A") dest.Bluetooth = null;
                if (src.TemperatureRang == "N/A") dest.TemperatureRang = null;
            }).ReverseMap();

            CreateMap<Product, ProductDetailedInfoDto>()
                .ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.Images.Select(img => img.Name).ToList()))
                .ForMember(dest => dest.TechSpec, opt => opt.MapFrom(src => src.TechsSpec))
                .ReverseMap();

        }
    }
}
