using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using XCode.RuningCode.Service.Dto.Blog;

namespace XCode.RuningCode.Service.Abstracts.Blog
{
    public interface INoticeService
    {
        void Add(NoticeDto dto);

        void Update(NoticeDto dto);

        void Delete(Expression<Func<NoticeDto, bool>> exp);

        IList<NoticeDto> QueryAll();
    }
}
