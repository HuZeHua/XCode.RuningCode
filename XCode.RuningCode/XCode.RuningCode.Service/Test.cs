using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using XCode.RuningCode.Core;
using XCode.RuningCode.Core.Data;
using XCode.RuningCode.Core.Infrastucture;
using XCode.RuningCode.Entity;
using XCode.RuningCode.Service.Abstracts;
using XCode.RuningCode.Service.Dto;

namespace XCode.RuningCode.Service
{
    public class Test:ITest,IDependency
    {
        private IRepository<User> repository;


        public Test(IRepository<User> repository)
        {
            this.repository = repository;
        }

        public UserDto Get()
        {
            var test= repository.GetById(1);
            return Mapper.Map<User, UserDto>(test);
        }
    }
}
