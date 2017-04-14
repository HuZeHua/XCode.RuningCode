using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using XCode.RuningCode.Core.Data;
using XCode.RuningCode.Core.Extentions;
using XCode.RuningCode.Entity;
using XCode.RuningCode.Entity.Blog;
using XCode.RuningCode.Service.Abstracts;
using XCode.RuningCode.Service.Abstracts.Blog;
using XCode.RuningCode.Service.Dto;
using XCode.RuningCode.Service.Dto.Blog;

namespace XCode.RuningCode.Service.Implements.Blog
{
    public class NoticeService : INoticeService
    {
        private readonly IRepository<Notice> repository;

        public NoticeService(IRepository<Notice> repository)
        {
            this.repository = repository;
        }

        public void Add(NoticeDto dto)
        {
            var entity = Mapper.Map<NoticeDto, Notice>(dto);
            repository.Insert(entity);
        }

        public void Update(NoticeDto dto)
        {
            var entity = Mapper.Map<NoticeDto, Notice>(dto);
            repository.Update(entity);
        }

        public void Delete(Expression<Func<NoticeDto, bool>> exp)
        {
            var where = exp.Cast<NoticeDto, Notice, bool>();

            var models = repository.Table.Where(where);
            repository.Delete(models);
        }

        public IList<NoticeDto> QueryAll()
        {
            var entity = repository.Table.AsNoTracking(); 
            return Mapper.Map<List<Notice>, List<NoticeDto>>(entity.ToList());
        }
    }
}
