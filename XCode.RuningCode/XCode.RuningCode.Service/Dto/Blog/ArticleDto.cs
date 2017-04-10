﻿using System.Collections.Generic;
using XCode.RuningCode.Entity.Blog;

namespace XCode.RuningCode.Service.Dto.Blog
{
    public class ArticleDto : BaseDto
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 正文
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// SEO关键字
        /// </summary>
        public string MetaKeywords { get; set; }

        /// <summary>
        /// SEO描述
        /// </summary>
        public string MetaDescription { get; set; }

        /// <summary>
        /// SEO标题
        /// </summary>
        public string MetaTitle { get; set; }

        /// <summary>
        /// 封面图
        /// </summary>
        public int PictureId { get; set; }

        /// <summary>
        /// 访问量
        /// </summary>
        public int Views { get; set; }

        /// <summary>
        /// 评论个数
        /// </summary>
        public int CommentCount { get; set; }

        /// <summary>
        /// 推荐
        /// </summary>
        public int Favor { get; set; }

        /// <summary>
        /// 踩
        /// </summary>
        public int Hate { get; set; }

        /// <summary>
        /// 允许评论
        /// </summary>
        public bool AllowComment { get; set; }

        /// <summary>
        /// 置顶
        /// </summary>
        public bool ShowOnTop { get; set; }

        /// <summary>
        /// 已发布
        /// </summary>
        public bool Published { get; set; }

        /// <summary>
        /// 已删除
        /// </summary>
        public bool Deleted { get; set; }

        /// <summary>
        /// 类别
        /// </summary>

        public virtual CategoryDto Category { get; set; }

        /// <summary>
        /// 评论
        /// </summary>
        public ICollection<CommentDto> Comments { get; set; }

        /// <summary>
        /// 标签
        /// </summary>
        public virtual ICollection<TagDto> Tags { get; set; }

        public virtual UserDto Author { get; set; }
    }
}
