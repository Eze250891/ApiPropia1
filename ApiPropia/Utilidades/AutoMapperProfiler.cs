using ApiPropia.DTOs;
using ApiPropia.Entidades;
using AutoMapper;

namespace ApiPropia.Utilidades
{
    public class AutoMapperProfiler : Profile
    {
        public AutoMapperProfiler()
        {
            CreateMap<ProductoCreacionDTO, Productos>();

        }
    }

    
}
