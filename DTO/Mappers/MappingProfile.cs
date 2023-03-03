using AutoMapper;
using Domian.Entities;
using Services.DTOs.Attachments;
using Services.DTOs.Baskets;
using Services.DTOs.Branchies;
using Services.DTOs.Categories;
using Services.DTOs.FoodOrders;
using Services.DTOs.Foods;
using Services.DTOs.Orders;
using Services.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

                //User
            CreateMap<User, UserForCreationDTO>().ReverseMap();
            CreateMap<User, UserForViewDTO>().ReverseMap();
            CreateMap<User, UserForUpdateDTO>().ReverseMap();

                //Order
            CreateMap<Order, OrderForCreationDTO>().ReverseMap();
            CreateMap<Order, OrderForViewDTO>().ReverseMap();
            CreateMap<Order, OrderForUpdateDTO>().ReverseMap();
                //Food
            CreateMap<Food, FoodForCreationDTO>().ReverseMap();
            CreateMap<Food, FoodForViewDTO>().ReverseMap();
            CreateMap<Food, FoodForUpdateDTO>().ReverseMap();

            //Category
            CreateMap<Category, CategoryForCreationDTO>().ReverseMap();
            CreateMap<Category, CategoryForViewDTO>().ReverseMap();
            CreateMap<Category, CategoryForUpdateDTO>().ReverseMap();

            //FoodOrder
            CreateMap<FoodOrder, FoodOrderForCreationDTO>().ReverseMap();
            CreateMap<FoodOrder, FoodOrderForViewDTO>().ReverseMap();
            CreateMap<FoodOrder, FoodOrderForUpdateDTO>().ReverseMap();

            //Branch
            CreateMap<Branch, BranchForCreationDTO>().ReverseMap();
            CreateMap<Branch, BranchForViewDTO>().ReverseMap();
            CreateMap<Branch, BranchForUpdateDTO>().ReverseMap();

            //Basket
            CreateMap<Basket, BasketForCreationDTO>().ReverseMap();
            CreateMap<Basket, BasketForViewDTO>().ReverseMap();
            CreateMap<Basket, BasketForUpdateDTO>().ReverseMap();

            //Attachment
            CreateMap<Attachment, AttachmentForCreationDTO>().ReverseMap();
            CreateMap<Attachment, AttachmentForViewDTO>().ReverseMap();
            CreateMap<Attachment, AttachmentForUpdateDTO>().ReverseMap();


        }
    }
}
