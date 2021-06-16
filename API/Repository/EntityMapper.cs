using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DOMAIN;
using API.Models;
using AutoMapper;
using DataAccessLayer;

namespace API.Repository
{
    public class EntityMapper<TSource, TDestination> where TSource : class where TDestination : class 
    {
        public EntityMapper()
        {
            Mapper.CreateMap<StudentModel, DataAccessLayer.Student>();
            Mapper.CreateMap<DataAccessLayer.Student, StudentModel>();
        }

        public TDestination Translate(TSource obj)
        {
            return Mapper.Map<TDestination>(obj);
        }
    
    }

}