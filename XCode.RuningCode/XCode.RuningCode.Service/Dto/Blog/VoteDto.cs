namespace XCode.RuningCode.Service.Dto.Blog
{
    /// <summary>
    /// 投票
    /// </summary>
    public class VoteDto : BaseDto
    {
        public string IPAddress { get; set; }

        public UserDto Author { get; set; }

        public ArticleDto Article { get; set; }
    }
}
