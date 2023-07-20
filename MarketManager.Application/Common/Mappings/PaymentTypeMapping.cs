using AutoMapper;
using MarketManager.Application.UseCases.PaymentTypes.Commands.CreatePaymentType;
using MarketManager.Application.UseCases.PaymentTypes.Commands.DeletePaymentType;
using MarketManager.Application.UseCases.PaymentTypes.Commands.UpdatePaymentType;
using MarketManager.Application.UseCases.PaymentTypes.Queries.GetAllPaymentType;
using MarketManager.Application.UseCases.PaymentTypes.Queries.GetByIdPaymentType;
using MarketManager.Domain.Entities;

namespace MarketManager.Application.Common.Mappings
{
    public class PaymentTypeMapping:Profile
    {
        public PaymentTypeMapping()
        {
            CreateMap<CreatePaymentTypeCommand, PaymentType>();
            CreateMap<DeletePaymentTypeCommand, PaymentType>();
            CreateMap<UpdatePaymentTypeCommand, PaymentType>();

            CreateMap<PaymentType, GetAllPaymentTypeQueryResponse>();
            CreateMap<PaymentType, GetByIdPaymentTypeQueryResponse>();
        }
    }
}
