using AutoMapper;
using Carea.Entities;
using Carea.Models;
using Carea.ViewModels;

namespace Mapper
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<Brand, BrandVM>();
            CreateMap<BrandVM, Brand>();

            CreateMap<Cars, CarsVM>();
            CreateMap<CarsVM, Cars>();

            CreateMap<Car_Photo_Color, Car_Photo_ColorVM>();
            CreateMap<Car_Photo_ColorVM, Car_Photo_Color>();

			CreateMap<Offers, OffersVM>();
			CreateMap<OffersVM, Offers>();

			CreateMap<CreateOrder, CreateOrderVM>();
			CreateMap<CreateOrderVM, CreateOrder>();

			CreateMap<OrderRequest, OrderRequestVM>();
			CreateMap<OrderRequestVM, OrderRequest>();

            CreateMap<Complaints_Suggestions,Complaints_SuggestionsVM>();
            CreateMap<Complaints_SuggestionsVM,Complaints_Suggestions>();

            CreateMap<PrivacyPolicy,PrivacyPolicyVM>();
            CreateMap<PrivacyPolicyVM,PrivacyPolicy>();

            CreateMap<Terms_Conditions,Terms_ConditionsVM>();
            CreateMap<Terms_ConditionsVM,Terms_Conditions>();



        }
    }
}
