using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using XCode.RuningCode.Core.Enums;
using XCode.RuningCode.Core.Extentions;
using XCode.RuningCode.Entity;
using XCode.RuningCode.Entity.Blog;

namespace XCode.RuningCode.Data.Data
{
    /// <summary>
    /// 数据库初始化
    /// </summary>
    internal sealed class Configuration : DbMigrationsConfiguration<XCodeContext>
    {
        private readonly DateTime now = DateTime.Now;

        public Configuration()
        {
            AutomaticMigrationsEnabled = true;//启用自动迁移
            AutomaticMigrationDataLossAllowed = true;//是否允许接受数据丢失的情况，false=不允许，会抛异常；true=允许，有可能数据会丢失
        }

        protected override void Seed(XCodeContext context)
        {


            #region 导航

            #region 系统设置

            var system_nav = new Navigate()
            {
                Name = "系统设置",
                Url = "#",
                Type = MenuType.Module,
                CreateDateTime = now,
                SoreOrder = 1
            };

            var na = new Navigate
            {
                Name = "导航管理",
                Url = "/Adm/Navigate/Index",
                Type = MenuType.Menu,
                CreateDateTime = now,
                SoreOrder = 1
            };

            get_navigates(na, "Navigate");

            system_nav.add_children_nav(na);

            var menu_manage = new Navigate
            {
                Name = "菜单管理",
                Url = "/Adm/Menu/Index",
                Type = MenuType.Menu,
                CreateDateTime = now,
                SoreOrder = 1
            };

            get_navigates(menu_manage, "Menu");

            system_nav.add_children_nav(menu_manage);

            var role_manage = new Navigate
            {
                Name = "角色管理",
                Url = "/Adm/Role/Index",
                Type = MenuType.Menu,
                CreateDateTime = now,
                SoreOrder = 2
            };

            get_navigates(role_manage, "Role");

            system_nav.add_children_nav(role_manage);

            var user_manage = new Navigate
            {
                Name = "用户管理",
                Url = "/Adm/User/Index",
                Type = MenuType.Menu,
                CreateDateTime = now,
                SoreOrder = 3
            };

            get_navigates(user_manage, "User");

            system_nav.add_children_nav(user_manage);
            system_nav.add_children_nav(new Navigate
            {
                Name = "角色授权",
                Url = "/Adm/Role/AuthMenus",
                Type = MenuType.Menu,
                CreateDateTime = now,
                SoreOrder = 4
            });

            #endregion

            #region 博客设置

            var blog_nav = new Navigate()
            {
                Name = "博客设置",
                Url = "#",
                Type = MenuType.Module,
                CreateDateTime = now,
                SoreOrder = 2
            };

            var blog_manage = new Navigate
            {
                Name = "分类管理",
                Url = "/Adm/Category/Index",
                Type = MenuType.Menu,
                CreateDateTime = now,
                SoreOrder = 1
            };

            get_navigates(blog_manage, "Category");

            blog_nav.add_children_nav(blog_manage);

            #endregion

            #region 日志查看

            var log_nav = new Navigate()
            {
                Name = "日志查看",
                Url = "#",
                Type = MenuType.Module,
                CreateDateTime = now,
                SoreOrder = 3
            };

            log_nav.add_children_nav(new Navigate
            {
                Name = "登录日志",
                Url = "/Adm/Loginlog/Index",
                Type = MenuType.Menu,
                CreateDateTime = now,
                SoreOrder = 1
            });
            log_nav.add_children_nav(new Navigate
            {
                Name = "访问日志",
                Url = "/Adm/PageView/Index",
                Type = MenuType.Menu,
                CreateDateTime = now,
                SoreOrder = 2
            });

            #endregion


            #region 邮件系统

            var mail_nav = new Navigate
            {
                Name = "邮件系统",
                Url = "#",
                Type = MenuType.Module,
                CreateDateTime = now,
                SoreOrder = 4
            };

            mail_nav.add_children_nav(new Navigate
            {
                Name = "邮件列表",
                Url = "/Adm/Email/Index",
                Type = MenuType.Menu,
                CreateDateTime = now,
                SoreOrder = 1
            });

            #endregion

            #region 实例文档

            var demo_nav = new Navigate
            {
                Name = "示例文档",
                Url = "#",
                Type = MenuType.Module,
                CreateDateTime = now,
                SoreOrder = 4
            };

            demo_nav.add_children_nav(new Navigate { Name = "按钮", Url = "/Adm/Demo/Base", Type = MenuType.Menu, SoreOrder = 1, CreateDateTime = now });
            demo_nav.add_children_nav(new Navigate { Name = "ICON图标", Url = "/Adm/Demo/Fontawosome", Type = MenuType.Menu, SoreOrder = 16, CreateDateTime = now });
            demo_nav.add_children_nav(new Navigate { Name = "高级控件", Url = "/Adm/Demo/Advance", Type = MenuType.Menu, SoreOrder = 18, CreateDateTime = now });
            demo_nav.add_children_nav(new Navigate { Name = "相册", Url = "/Adm/Demo/Gallery", Type = MenuType.Menu, SoreOrder = 19, CreateDateTime = now });
            demo_nav.add_children_nav(new Navigate { Name = "个人主页", Url = "/Adm/Demo/Profile", Type = MenuType.Menu, SoreOrder = 20, CreateDateTime = now });
            demo_nav.add_children_nav(new Navigate { Name = "个人主页", Url = "/Adm/Demo/Profile", Type = MenuType.Menu, SoreOrder = 20, CreateDateTime = now });
            demo_nav.add_children_nav(new Navigate { Name = "邮件-收件箱", Url = "/Adm/Demo/InBox", Type = MenuType.Menu, SoreOrder = 21, CreateDateTime = now });
            demo_nav.add_children_nav(new Navigate { Name = "邮件-查看邮件", Url = "/Adm/Demo/InBoxDetail", Type = MenuType.Menu, SoreOrder = 22, CreateDateTime = now });
            demo_nav.add_children_nav(new Navigate { Name = "邮件-写邮件", Url = "/Adm/Demo/InBoxCompose", Type = MenuType.Menu, SoreOrder = 23, CreateDateTime = now });
            demo_nav.add_children_nav(new Navigate { Name = "表单", Url = "/Adm/Demo/Form", Type = MenuType.Menu, SoreOrder = 17, CreateDateTime = now });

            #endregion

            #region 高级实例

            var demoAdv_nav = new Navigate
            {
                Name = "高级示例",
                Url = "#",
                Type = MenuType.Module,
                CreateDateTime = now,
                SoreOrder = 4
            };


            demoAdv_nav.add_children_nav(new Navigate { Name = "编辑器", Url = "/Adm/Demo/Editor", Type = MenuType.Menu, SoreOrder = 24, CreateDateTime = now });
            demoAdv_nav.add_children_nav(new Navigate { Name = "表单验证", Url = "/Adm/Demo/FormValidate", Type = MenuType.Menu, SoreOrder = 25, CreateDateTime = now });
            demoAdv_nav.add_children_nav(new Navigate { Name = "图表", Url = "/Adm/Demo/Chart", Type = MenuType.Menu, SoreOrder = 26, CreateDateTime = now });
            demoAdv_nav.add_children_nav(new Navigate { Name = "图表-Morris", Url = "/Adm/Demo/ChartMorris", Type = MenuType.Menu, SoreOrder = 27, CreateDateTime = now });
            demoAdv_nav.add_children_nav(new Navigate { Name = "ChartJs", Url = "/Adm/Demo/ChartJs", Type = MenuType.Menu, SoreOrder = 28, CreateDateTime = now });
            demoAdv_nav.add_children_nav(new Navigate { Name = "表格", Url = "/Adm/Demo/DataTable", Type = MenuType.Menu, SoreOrder = 29, CreateDateTime = now });
            demoAdv_nav.add_children_nav(new Navigate { Name = "高级表格", Url = "/Adm/Demo/DataTableAdv", Type = MenuType.Menu, SoreOrder = 30, CreateDateTime = now });


            var navs = new List<Navigate>
                       {
                           system_nav,
                           blog_nav,
                           log_nav,
                           mail_nav,
                           demo_nav,
                           demoAdv_nav
                       };

            AddOrUpdate(context, m => m.Name, navs.ToArray());

            #endregion

            #endregion

            var navigites = new List<Navigate>();

            foreach (var navigate in navs)
            {
                navigites.Add(navigate);
                navigites.AddRange(navigate.Children);
                foreach (var navigate_child in navigate.Children)
                {
                    navigites.AddRange(navigate_child.Children);
                }
            }

            #region 角色

            if (context.Set<Role>() != null && context.Set<Role>().FirstOrDefault() != null)
            {
                return;
            }
            var superAdminRole = new Role { Name = "超级管理员", Description = "超级管理员", Navigates = navigites };
            var guestRole = new Role { Name = "guest", Description = "游客", Navigates = navigites };
            var roles = new List<Role>
            {
                superAdminRole,
                guestRole
            };

            AddOrUpdate(context, m => m.Name, roles.ToArray());

            #endregion

            #region 用户

            var user = new List<User>
                       {
                           new User
                           {
                               LoginName = "admin",
                               RealName = "超级管理员",
                               Password = "111111".ToMD5(),
                               Email = "zero@xcode.com",
                               Status = 2,
                               CreateDateTime = now,
                               Roles = new List<Role> {superAdminRole}
                           },
                           new User
                           {
                               LoginName = "guest",
                               RealName = "游客",
                               Password = "111111".ToMD5(),
                               Email = "zero@xcode.com",
                               Status = 2,
                               CreateDateTime = now,
                               Roles = new List<Role> {guestRole}
                           }
                       };

            AddOrUpdate(context, m => m.LoginName, user.ToArray());

            #endregion

            #region 友链

            var friendly_link = new FriendlyLink()
            {
                Name = "XCode",
                Title = "XCode",
                Link = "http://www.x-code.me"
            };

            context.Set<FriendlyLink>().AddOrUpdate(friendly_link);

            var friendly_link1 = new FriendlyLink()
            {
                Name = "XCode Blog",
                Title = "XCode Blog",
                Link = "http://blog.x-code.me"
            };

            context.Set<FriendlyLink>().AddOrUpdate(friendly_link1);

            #endregion

            var article_set = context.Set<ArticleSetting>();
            article_set.Add(new ArticleSetting()
            {
                ArticlePageSize = 10,
                CommentPageSize = 5,
                LatestCommentPageSize = 5,
                HotCommentPageSize = 5,
                HotArticlePageSize = 5,
                AllowComment = true
            });

            var site_set = context.Set<SiteSetting>();
            site_set.Add(new SiteSetting()
            {
                Title = "XCode Blog",
                Separator = "|",
                MetaTitle = "XCode Blog",
                MetaKeywords = "XCode Blog",
                MetaDescription = "XCode Blog"
            });

            var ca1 = new Category()
            {
                Name = "前端",
                MetaTitle = "XCode Blog",
                MetaKeywords = "XCode Blog",
                MetaDescription = "XCode Blog"
            };

            context.Set<Category>().AddOrUpdate(ca1);

            var ca2 = new Category()
            {
                Name = "后端",
                MetaTitle = "XCode Blog",
                MetaKeywords = "XCode Blog",
                MetaDescription = "XCode Blog"
            };
            context.Set<Category>().AddOrUpdate(ca2);
            var ca3 = new Category()
            {
                Name = "杂文",
                MetaTitle = "XCode Blog",
                MetaKeywords = "XCode Blog",
                MetaDescription = "XCode Blog"
            };
            context.Set<Category>().AddOrUpdate(ca3);
            var tag1 = new Tag()
            {
                Name = "HTML"
            };
            context.Set<Tag>().AddOrUpdate(tag1);
            var tag2 = new Tag()
            {
                Name = "C#"
            };
            context.Set<Tag>().AddOrUpdate(tag2);
            var tag3 = new Tag()
            {
                Name = "React"
            };
            context.Set<Tag>().AddOrUpdate(tag3);
            var tag4 = new Tag()
            {
                Name = "历史"
            };
            context.Set<Tag>().AddOrUpdate(tag4);

            context.Set<Article>().AddOrUpdate(new Article()
            {
                Author = user.First(),
                Tags = new List<Tag>() { tag1, tag2 },
                Category = ca1,
                Title = "HTML",
                Content = "HTML 是用来描述网页的一种语言。HTML 指的是超文本标记语言(Hyper Text Markup Language)HTML 不是一种编程语言，而是一种标记语言(markup language)标记语言是一套标记标签(markup tag)HTML 使用标记标签来描述网页"
            });
            context.Set<Article>().AddOrUpdate(new Article()
            {
                Author = user.Last(),
                Tags = new List<Tag>() { tag2, tag4 },
                Category = ca2,
                Title = "C#",
                Content = "C#是微软公司发布的一种面向对象的、运行于.NET Framework之上的高级程序设计语言。并定于在微软职业开发者论坛(PDC)上登台亮相。C#是微软公司研究员Anders Hejlsberg的最新成果。C#看起来与Java有着惊人的相似；它包括了诸如单一继承、接口、与Java几乎同样的语法和编译成中间代码再运行的过程。但是C#与Java有着明显的不同，它借鉴了Delphi的一个特点，与COM（组件对象模型）是直接集成的，而且它是微软公司 .NET windows网络框架的主角。"
            });
            context.Set<Article>().AddOrUpdate(new Article()
            {
                Author = user.First(),
                Tags = new List<Tag>() { tag2, tag3 },
                Category = ca1,
                Title = "React",
                Content = "React Native使你能够在Javascript和React的基础上获得完全一致的开发体验，构建世界一流的原生APP。React Native着力于提高多平台开发的开发效率 —— 仅需学习一次，编写任何平台。(Learn once, write anywhere)Facebook已经在多项产品中使用了React Native，并且将持续地投入建设React Native。"
            });
            context.Set<Article>().AddOrUpdate(new Article()
            {
                Author = user.Last(),
                Tags = new List<Tag>() { tag3, tag4 },
                Category = ca3,
                Title = "历史",
                Content = "XCode是一个完全响应式，使用 MVC + EF + Bootstrap3.3.4 版本开发的后台管理系统模板，采用了左右两栏式等多种布局形式，使用了Html5+CSS3等现代技术，提供了诸多的强大的可以重新组合的UI组件，丰富的jQuery插件，可以用于所有的Web应用程序，如网站管理后台，会员中心，CMS，CRM，OA后台系统的模板，XCode使用到的技术完全开源，支持自定义扩展，你可以根据自己的需求定制一套属于你的后台管理模板。"
            });

        }

        #region Private

        void get_navigates(Navigate parent, string controllerName)
        {
            parent.add_children_nav(new Navigate
            {
                Name = "添加",
                Url = string.Format("/Adm/{0}/Add", controllerName),
                Type = MenuType.ButtonType,
            });

            parent.add_children_nav(new Navigate
            {
                Name = "修改",
                Url = string.Format("/Adm/{0}/Edit", controllerName),
                Type = MenuType.ButtonType,
            });

            parent.add_children_nav(new Navigate
            {
                Name = "删除",
                Url = string.Format("/Adm/{0}/Delete", controllerName),
                Type = MenuType.ButtonType,
            });
        }

        /// <summary>
        /// 添加更新数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="context"></param>
        /// <param name="exp"></param>
        /// <param name="param"></param>
        void AddOrUpdate<T>(DbContext context, Expression<Func<T, object>> exp, T[] param) where T : class
        {
            DbSet<T> set = context.Set<T>();
            set.AddOrUpdate(exp, param);
        }

        #endregion
    }
}
