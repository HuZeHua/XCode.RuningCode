﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq.Expressions;
using XCode.RuningCode.Core.Extentions;
using XCode.RuningCode.Data.Data;
using XCode.RuningCode.Entity;

namespace XCode.RuningCode.Data.Mapping
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
            #region 角色

            var superAdminRole = new Role { Name = "超级管理员", Description = "超级管理员" };
            var guestRole = new Role { Name = "guest", Description = "游客" };
            var roles = new List<Role>
            {
                superAdminRole,
                guestRole
            };

            #endregion

            #region 用户

            var admin = new User
            {
                LoginName = "admin",
                RealName = "超级管理员",
                Password = "111111".ToMD5(),
                Email = "zero@xcode.com",
                Status = 2,
                CreateDateTime = now,
                Roles = new List<Role> { superAdminRole}
            };
            var guest = new User
            {
                LoginName = "guest",
                RealName = "游客",
                Password = "111111".ToMD5(),
                Email = "zero@xcode.com",
                Status = 2,
                CreateDateTime = now,
                Roles = new List<Role> { superAdminRole }
            };
            //用户
            var user = new List<User>
            {
                admin,
                guest
            };
            #endregion

            #region 菜单

            var system = new Menu
            {
                Name = "系统设置",
                Url = "#",
                Type = 1,
                CreateDateTime = now,
                Order = 1
            };
            var menuMgr = new Menu
            {
                ParentId = 1,
                Name = "菜单管理",
                Url = "/Adm/Menu/Index",
                Type = 2,
                CreateDateTime = now,
                Order = 2
            };//2
            var roleMgr = new Menu
            {
                ParentId = 1,
                Name = "角色管理",
                Url = "/Adm/Role/Index",
                Type = 2,
                CreateDateTime = now,
                Order = 3
            };//3
            var userMgr = new Menu
            {
                ParentId = 1,
                Name = "用户管理",
                Url = "/Adm/User/Index",
                Type = 2,
                CreateDateTime = now,
                Order = 4
            };//4
            var roleAuthMgr = new Menu
            {
                ParentId = 1,
                Name = "角色授权",
                Url = "/Adm/Role/AuthMenus",
                Type = 2,
                CreateDateTime = now,
                Order = 5
            };//5

            var mail = new Menu
            {
                Name = "邮件系统",
                Url = "#",
                Type = 1,
                CreateDateTime = now,
                Order = 6
            };//6
            var mailMgr = new Menu
            {
                ParentId = 6,
                Name = "邮件列表",
                Url = "/Adm/Email/Index",
                Type = 2,
                CreateDateTime = now,
                Order = 7
            };//7
            var log = new Menu
            {
                Name = "日志查看",
                Url = "#",
                Type = 1,
                CreateDateTime = now,
                Order = 8
            };//8
            
            //菜单
            var menus = new List<Menu>
            {
                system,
                menuMgr,
                roleMgr,
                userMgr,
                roleAuthMgr,
                mail,
                mailMgr,
                log,
                new Menu
                {
                    ParentId = 8,
                    Name = "登录日志",
                    Url = "/Adm/Loginlog/Index",
                    Type = 2,
                    CreateDateTime = now,
                    Order = 9
                },
                new Menu
                {
                    ParentId = 8,
                    Name = "访问日志",
                    Url = "/Adm/PageView/Index",
                    Type = 2,
                    CreateDateTime = now,
                    Order = 10
                },
                new Menu
                {
                    ParentId = 1,
                    Name = "分类管理",
                    Url = "/Adm/Category/Index",
                    Type = 2,
                    CreateDateTime = now,
                    Order = 2
                }

            };
            var menuBtns = GetMenuButtons(2, "Menu");//13
            var rolwBtns = GetMenuButtons(3, "Role");//16
            var userBtns = GetMenuButtons(4, "User");//19
            var catrgoryBtns = GetMenuButtons(40, "Category");//19
            userBtns.Add(new Menu
            {
                ParentId = 4,
                Name = "用户角色授权",
                Url = string.Format("/Adm/{0}/Authen", "User"),
                Type = 3,
                CreateDateTime = now,
                Order = 11
            });//20

            menus.AddRange(menuBtns);//23
            menus.AddRange(rolwBtns);//26
            menus.AddRange(userBtns);//29
            menus.AddRange(catrgoryBtns);//29
            var demo = new Menu
            {
                ParentId = 0, Name = "示例文档", Url = "#", Type = 1,Order = 12,
                CreateDateTime = now
            };//30
            var demoAdv = new Menu
            {
                ParentId = 0, Name = "高级示例", Url = "#", Type = 1,
                Order = 13,
                CreateDateTime = now
            };//31
            menus.Add(new Menu { ParentId = mailMgr.Id, Name = "发送邮件", Url = "/Adm/Email/Add", Type = 3, Order = 14, CreateDateTime = now });
            menus.Add(demo);
            menus.Add(demoAdv);
            menus.Add(new Menu { ParentId = 22, Name = "按钮", Url = "/Adm/Demo/Base", Type = 2, Order = 15, CreateDateTime = now });
            menus.Add(new Menu { ParentId = 22, Name = "ICON图标", Url = "/Adm/Demo/Fontawosome", Type = 2, Order = 16, CreateDateTime = now });
            menus.Add(new Menu { ParentId = 22, Name = "表单", Url = "/Adm/Demo/Form", Type = 2, Order = 17, CreateDateTime = now });
            menus.Add(new Menu { ParentId = 22, Name = "高级控件", Url = "/Adm/Demo/Advance", Type = 2, Order = 18, CreateDateTime = now });
            menus.Add(new Menu { ParentId = 22, Name = "相册", Url = "/Adm/Demo/Gallery", Type = 2, Order = 19, CreateDateTime = now });
            menus.Add(new Menu { ParentId = 22, Name = "个人主页", Url = "/Adm/Demo/Profile", Type = 2, Order = 20, CreateDateTime = now });
            menus.Add(new Menu { ParentId = 22, Name = "邮件-收件箱", Url = "/Adm/Demo/InBox", Type = 2, Order = 21, CreateDateTime = now });
            menus.Add(new Menu { ParentId = 22, Name = "邮件-查看邮件", Url = "/Adm/Demo/InBoxDetail", Type = 2, Order = 22, CreateDateTime = now });
            menus.Add(new Menu { ParentId = 22, Name = "邮件-写邮件", Url = "/Adm/Demo/InBoxCompose", Type = 2, Order = 23, CreateDateTime = now });
            menus.Add(new Menu { ParentId = 23, Name = "编辑器", Url = "/Adm/Demo/Editor", Type = 2, Order = 24, CreateDateTime = now });
            menus.Add(new Menu { ParentId = 23, Name = "表单验证", Url = "/Adm/Demo/FormValidate", Type = 2, Order = 25, CreateDateTime = now });
            menus.Add(new Menu { ParentId = 23, Name = "图表", Url = "/Adm/Demo/Chart", Type = 2, Order = 26, CreateDateTime = now });
            menus.Add(new Menu { ParentId = 23, Name = "图表-Morris", Url = "/Adm/Demo/ChartMorris", Type = 2, Order = 27, CreateDateTime = now });
            menus.Add(new Menu { ParentId = 23, Name = "ChartJs", Url = "/Adm/Demo/ChartJs", Type = 2, Order = 28, CreateDateTime = now });
            menus.Add(new Menu { ParentId = 23, Name = "表格", Url = "/Adm/Demo/DataTable", Type = 2, Order = 29, CreateDateTime = now });
            menus.Add(new Menu { ParentId = 23, Name = "高级表格", Url = "/Adm/Demo/DataTableAdv", Type = 2, Order = 30, CreateDateTime = now });
            

            #endregion

            #region 角色菜单权限关系
            //超级管理员授权/游客授权
            List<RoleMenu> roleMenus = new List<RoleMenu>();
            var len = menus.Count;
            for (int i = 0; i < len; i++)
            {
                roleMenus.Add(new RoleMenu {RoleId = 1, MenuId = i + 1});
                roleMenus.Add(new RoleMenu {RoleId = 2, MenuId = i + 1});
            }

            #endregion

            AddOrUpdate(context, m => m.LoginName, user.ToArray());

            AddOrUpdate(context, m => new { m.ParentId, m.Name, m.Type }, menus.ToArray());

            AddOrUpdate(context, m => m.Name, roles.ToArray());

            AddOrUpdate(context, m => new { m.MenuId, m.RoleId }, roleMenus.ToArray());

        }

        #region Private

        /// <summary>
        /// 获取菜单的基础按钮
        /// </summary>
        /// <param name="parentId"></param>
        /// <param name="controllerName"></param>
        /// <returns></returns>
        List<Menu> GetMenuButtons(int parentId, string controllerName)
        {
            return new List<Menu>
            {
                new Menu
                {
                    ParentId = parentId,
                    Name = "添加",
                    Url = string.Format("/Adm/{0}/Add",controllerName),
                    Type = 3,
                    CreateDateTime = now,
                    Order = 1
                },
                new Menu
                {
                    ParentId = parentId,
                    Name = "修改",
                    Url = string.Format("/Adm/{0}/Edit",controllerName),
                    Type = 3,
                    CreateDateTime = now,
                    Order = 2
                },
                new Menu
                {
                    ParentId = parentId,
                    Name = "删除",
                    Url = string.Format("/Adm/{0}/Delete",controllerName),
                    Type = 3,
                    CreateDateTime = now,
                    Order = 3
                }
            };
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
