using Nop.Web.Models.Polls;
using System.Collections.Generic;

namespace Nop.Web.Factories.Mobile
{
    public interface IHomepagePollsMobFactory
    {
        List<PollModel> GetHomePagePolls();
    }
}
