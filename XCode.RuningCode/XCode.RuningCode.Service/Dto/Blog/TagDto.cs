using System.Collections.Generic;

namespace XCode.RuningCode.Service.Dto.Blog
{
    public class TagDto : BaseDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        //public virtual ICollection<ArticleDto> Articles { get; set; }
    }
}
