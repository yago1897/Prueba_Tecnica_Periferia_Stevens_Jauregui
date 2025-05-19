using AutoMapper;
using Services.Core.DTOs;
using Services.Core.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Infraestructure.Mappings
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Department, DepartamentDTO>().ReverseMap();
            //CreateMap<Employee, EmployeeDTOs>().ReverseMap();

            CreateMap<Department, DepartamentDTO>();
            CreateMap<DepartamentDTO, Department>();

            CreateMap<Employee, EmployeeDTOs>();
            CreateMap<EmployeeDTOs, Employee>();




            //CreateMap<Employee, EmployeeDTOs>()
            //.ForMember(destino => destino.Name,
            //    opt => opt.MapFrom(origen => origen.IdDepartamentNavigation.Name)
            //    );


            //CreateMap<EmployeeDTOs, Employee>()
            //.ForMember(destino => destino.IdDepartamentNavigation,
            //    opt => opt.Ignore()
            //    );




        }
    }
}
