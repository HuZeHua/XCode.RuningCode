using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using XCode.RuningCode.Entity;
using XCode.RuningCode.Service.Dto;
using XCode.RuningCode.Service.Enum;

namespace XCode.RuningCode.Service.Abstracts
{
    public partial class EmailPoolService : IEmailPoolService
    {
        /// <summary>
        /// 获取指定数量的待发送邮件
        /// </summary>
        /// <param name="top"></param>
        /// <returns></returns>
        public List<EmailPoolDto> GetWithReceivers(int top)
        {
            using (var scope = _dbScopeFactory.CreateReadOnly())
            {
                var db = GetDb(scope);
                var dbSet = GetDbSet(db);
                var query = GetQuery(dbSet, item => item.Receivers,
                    item => !item.IsDeleted && item.Status == (byte) EmailStatus.等待发送 && item.FailTimes < 3
                    , item => item.Id, false);
                var list = query.Skip(0).Take(top).ToList();
                var res = Mapper.Map<List<EmailPoolEntity>, List<EmailPoolDto>>(list);
                return res;
            }
        }
    }
}
