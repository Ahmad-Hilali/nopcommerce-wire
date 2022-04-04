using BWire.Web.Framework.Models;

namespace BWire.Web.Models.Common
{
    public partial class SocialModel : BaseNopModel
    {
        public string FacebookLink { get; set; }
        public string TwitterLink { get; set; }
        public string YoutubeLink { get; set; }
        public int WorkingLanguageId { get; set; }
        public bool NewsEnabled { get; set; }
    }
}