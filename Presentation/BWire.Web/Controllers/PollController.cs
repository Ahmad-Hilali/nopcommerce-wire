using System;
using Microsoft.AspNetCore.Mvc;
using BWire.Core;
using BWire.Core.Domain.Polls;
using BWire.Services.Customers;
using BWire.Services.Localization;
using BWire.Services.Polls;
using BWire.Services.Stores;
using BWire.Web.Factories;

namespace BWire.Web.Controllers
{
    public partial class PollController : BasePublicController
    {
        #region Fields

        private readonly ICustomerService _customerService;
        private readonly ILocalizationService _localizationService;
        private readonly IPollModelFactory _pollModelFactory;
        private readonly IPollService _pollService;
        private readonly IStoreMappingService _storeMappingService;
        private readonly IWorkContext _workContext;

        #endregion

        #region Ctor

        public PollController(ICustomerService customerService, 
            ILocalizationService localizationService, 
            IPollModelFactory pollModelFactory,
            IPollService pollService,
            IStoreMappingService storeMappingService,
            IWorkContext workContext)
        {
            _customerService = customerService;
            _localizationService = localizationService;
            _pollModelFactory = pollModelFactory;
            _pollService = pollService;
            _storeMappingService = storeMappingService;
            _workContext = workContext;
        }

        #endregion

        #region Methods

        [HttpPost]
        [IgnoreAntiforgeryToken]
        public virtual IActionResult Vote(int pollAnswerId)
        {
            var pollAnswer = _pollService.GetPollAnswerById(pollAnswerId);
            if (pollAnswer == null)
                return Json(new { error = "No poll answer found with the specified id" });

            var poll = _pollService.GetPollById(pollAnswer.PollId);

            if (!poll.Published || !_storeMappingService.Authorize(poll))
                return Json(new { error = "Poll is not available" });

            if (_customerService.IsGuest(_workContext.CurrentCustomer) && !poll.AllowGuestsToVote)
                return Json(new { error = _localizationService.GetResource("Polls.OnlyRegisteredUsersVote") });

            var alreadyVoted = _pollService.AlreadyVoted(poll.Id, _workContext.CurrentCustomer.Id);
            if (!alreadyVoted)
            {
                //vote
                _pollService.InsertPollVotingRecord(new PollVotingRecord
                {
                    PollAnswerId = pollAnswer.Id,
                    CustomerId = _workContext.CurrentCustomer.Id,
                    CreatedOnUtc = DateTime.UtcNow
                });

                //update totals
                pollAnswer.NumberOfVotes = _pollService.GetPollVotingRecordsByPollAnswer(pollAnswer.Id).Count;
                _pollService.UpdatePollAnswer(pollAnswer);
                _pollService.UpdatePoll(poll);
            }

            return Json(new
            {
                html = RenderPartialViewToString("_Poll", _pollModelFactory.PreparePollModel(poll, true)),
            });
        }

        #endregion
    }
}