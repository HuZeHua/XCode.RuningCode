using System;
using System.Linq;
using AutoMapper;
using XCode.RuningCode.Core.Data;
using XCode.RuningCode.Entity.Blog;
using XCode.RuningCode.Service.Abstracts.Blog;
using XCode.RuningCode.Service.Dto.Blog;

namespace XCode.RuningCode.Service.Implements.Blog
{
    public class SiteSettingService : ISiteSettingService
    {
        private readonly IRepository<SiteSetting> _repository;

        public SiteSettingService(IRepository<SiteSetting> repository)
        {
            this._repository = repository;
        }

        public SiteSettingDto GetSiteSetting()
        {
            return Mapper.Map<SiteSetting, SiteSettingDto>(_repository.Table.First());
        }

        public void Update(SiteSettingDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException("article");
            var entity = Mapper.Map<SiteSettingDto, SiteSetting>(dto);
            _repository.Update(entity);
        }
    }
}
