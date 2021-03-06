﻿using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using XCode.RuningCode.Data.Mapping;
using XCode.RuningCode.Data.Mapping.Blog;

namespace XCode.RuningCode.Data.Data
{
    //[DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class XCodeContext : DbContext, IDbContext
    {
        public XCodeContext() : base("XCodeConnection")
        {
            //SQL语句拦截器
            //System.Data.Entity.Infrastructure.Interception.DbInterception.Add(new SqlCommandInterceptor());
        }

        /// <summary>
        /// 带参数构造函数
        /// </summary>
        /// <param name="connectionString">数据库连接字符串名称</param>
        public XCodeContext(string connectionString) : base(connectionString)
        {
        }

        /// <summary>
        /// OnModelCreating
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //移除一对多的级联删除关系
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            //移除表名复数形式
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();

            //配置实体和数据表的关系
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new RoleMap());
            modelBuilder.Configurations.Add(new LoginLogMap());
            modelBuilder.Configurations.Add(new PageViewMap());
            modelBuilder.Configurations.Add(new EmailPoolMap());
            modelBuilder.Configurations.Add(new EmailReceiverMap());
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new NavigateMap());
            modelBuilder.Configurations.Add(new ArticleMap());
            modelBuilder.Configurations.Add(new ArticleSettingMap());
            modelBuilder.Configurations.Add(new CommentMap());
            modelBuilder.Configurations.Add(new SiteSettingMap());
            modelBuilder.Configurations.Add(new TagMap());
            modelBuilder.Configurations.Add(new VoteMap());
            modelBuilder.Configurations.Add(new FriendlyLinkMap());
            modelBuilder.Configurations.Add(new NoticeMap());
        }

        public int ExecuteSqlCommand(string sql, params object[] parameters)
        {
            return this.Database.ExecuteSqlCommand(sql, parameters);
        }

        IDbSet<TEntity> IDbContext.Set<TEntity>()
        {
            return base.Set<TEntity>();
        }

        ///// <summary>
        ///// 重写SaveChanges方法，增加ID自动生成
        ///// </summary>
        ///// <returns></returns>
        //public override int SaveChanges()
        //{
        //    RegisterIdGenerator<UserEntity>();
        //    RegisterIdGenerator<MenuEntity>();
        //    RegisterIdGenerator<RoleEntity>();
        //    RegisterIdGenerator<RoleMenuEntity>();
        //    RegisterIdGenerator<UserRoleEntity>();
        //    RegisterIdGenerator<LoginLogEntity>();
        //    RegisterIdGenerator<PageViewEntity>();
        //    RegisterIdGenerator<EmailPoolEntity>();
        //    RegisterIdGenerator<EmailReceiverEntity>();

        //    return base.SaveChanges();
        //}

        ///// <summary>
        ///// 新增的时候，自动生成ID
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        //private void RegisterIdGenerator<T>() where T : BaseEntity
        //{
        //    foreach (var entity in ChangeTracker.Entries<T>()
        //        .Where(et => et.State == EntityState.Added))
        //    {
        //        entity.Entity.Id = GuidGeneratorHelper.NewGuid().ToString().Replace("-", string.Empty).ToUpper();
        //    }
        //}
    }
}
