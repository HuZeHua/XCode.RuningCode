using System.Collections.Generic;
using System.ComponentModel;

namespace XCode.RuningCode.Service.Dto.Blog
{
    public class ArticleDto : BaseDto
    {
        [DisplayName("标题")]
        public string Title { get; set; }

        [DisplayName("正文")]
        public string Content { get; set; }

        [DisplayName("SEO关键字")]
        public string MetaKeywords { get; set; }

        [DisplayName("SEO描述")]
        public string MetaDescription { get; set; }

        [DisplayName("SEO标题")]
        public string MetaTitle { get; set; }

        [DisplayName("封面图")]
        public int PictureId { get; set; }

        [DisplayName("访问量")]
        public int Views { get; set; }

        [DisplayName("评论个数")]
        public int CommentCount { get; set; }

        [DisplayName("推荐")]
        public int Favor { get; set; }

        [DisplayName("踩")]
        public int Hate { get; set; }

        [DisplayName("允许评论")]
        public bool AllowComment { get; set; }

        [DisplayName("置顶")]
        public bool ShowOnTop { get; set; }

        [DisplayName("已发布")]
        public bool Published { get; set; } 

        [DisplayName("类别")]
        public virtual CategoryDto Category { get; set; }

        [DisplayName("评论")]
        public ICollection<CommentDto> Comments { get; set; }

        [DisplayName("标签")]
        public virtual ICollection<TagDto> Tags { get; set; }=new List<TagDto>();

        [DisplayName("作者")]
        public virtual UserDto Author { get; set; }
    }
}

