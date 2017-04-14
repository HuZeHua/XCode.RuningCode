using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using XCode.RuningCode.Core.Data;
using XCode.RuningCode.Core.Extentions;
using XCode.RuningCode.Entity;
using XCode.RuningCode.Service.Abstracts;
using XCode.RuningCode.Service.Dto;

namespace XCode.RuningCode.Service.Implements
{
    public class FriendlyLinkService : IFriendlyLinkService
    {
        private readonly IRepository<FriendlyLink> repository;

        public FriendlyLinkService(IRepository<FriendlyLink> repository)
        {
            this.repository = repository;
        }

        public void Add(FriendlyLinkDto dto)
        {
            var entity = Mapper.Map<FriendlyLinkDto, FriendlyLink>(dto);
            repository.Insert(entity);
        }

        public void Update(FriendlyLinkDto dto)
        {
            var entity = Mapper.Map<FriendlyLinkDto, FriendlyLink>(dto);
            repository.Update(entity);
        }

        public void Delete(Expression<Func<FriendlyLinkDto, bool>> exp)
        {
            var where = exp.Cast<FriendlyLinkDto, FriendlyLink, bool>();

            var models = repository.Table.Where(where);
            repository.Delete(models);
        }

        public IList<FriendlyLinkDto> QueryAll()
        {
            var entity = repository.Table.AsNoTracking(); 
            return Mapper.Map<List<FriendlyLink>, List<FriendlyLinkDto>>(entity.ToList());
        }
    }
}
