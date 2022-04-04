using BWire.Web.Models.Polls;
using System.Collections.Generic;

namespace BWire.Web.Factories.Mobile
{
    public interface IHomepagePollsMobFactory
    {
        List<PollModel> GetHomePagePolls();
    }
}
