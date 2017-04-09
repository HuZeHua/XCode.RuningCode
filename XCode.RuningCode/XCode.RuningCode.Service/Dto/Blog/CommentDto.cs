using System.Collections.Generic;

namespace XCode.RuningCode.Service.Dto.Blog
{
    public class CommentDto : BaseDto
    {
        public UserDto Author { get; set; }
        public string CommentText { get; set; }
        public bool Active { get; set; }

        public IList<CommentDto> Comments { get; set; }
    }
}
