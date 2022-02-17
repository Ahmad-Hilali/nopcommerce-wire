using Nop.Web.Models.Polls;
using System.Collections.Generic;
using System.Linq;

namespace Nop.Web.Factories.Mobile
{
    public class HomepagePollsMobFactory : IHomepagePollsMobFactory
    {
        private readonly IPollModelFactory _pollModelFactory;

        public HomepagePollsMobFactory(IPollModelFactory pollModelFactory)
        {
            _pollModelFactory = pollModelFactory;
        }
        public List<PollModel> GetHomePagePolls()
        {
            var model = _pollModelFactory.PrepareHomepagePollModels();
            if (!model.Any())
                return null;

            return model;
        }

    }
}
