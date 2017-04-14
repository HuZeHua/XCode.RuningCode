using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using XCode.RuningCode.Service.Dto;

namespace XCode.RuningCode.Service.Abstracts
{
    public interface IFriendlyLinkService
    {
        void Add(FriendlyLinkDto dto);

        void Update(FriendlyLinkDto dto);

        void Delete(Expression<Func<FriendlyLinkDto, bool>> exp);

        IList<FriendlyLinkDto> QueryAll();
    }
}
