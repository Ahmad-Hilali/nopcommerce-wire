using Microsoft.AspNetCore.Mvc;
using Nop.Web.Factories.Mobile;
using System.Linq;

namespace Nop.Web.Controllers.Mobile
{
    [Route("api/[controller]")]
    [ApiController]
    public class PollController : ControllerBase
    {
        private readonly IHomepagePollsMobFactory _homepagePollsFactory;
        public PollController(IHomepagePollsMobFactory homepagePollsFactory)
        {
            _homepagePollsFactory = homepagePollsFactory;
        }

        [HttpGet]
        public IActionResult GetHomePagePolls()
        {
            var model = _homepagePollsFactory.GetHomePagePolls();
            if (!model.Any())
                return BadRequest();

            return Ok(model);
        }

        //[HttpPost]
        //[Route("Vote")]
        //public IActionResult Vote()
        //{
        //    var pollAnswer = _pollService.GetPollAnswerById(pollAnswerId);
        //    if (pollAnswer == null)
        //        return Json(new { error = "No poll answer found with the specified id" });

        //    var poll = _pollService.GetPollById(pollAnswer.PollId);

        //    if (!poll.Published || !_storeMappingService.Authorize(poll))
        //        return Json(new { error = "Poll is not available" });

        //    if (_customerService.IsGuest(_workContext.CurrentCustomer) && !poll.AllowGuestsToVote)
        //        return Json(new { error = _localizationService.GetResource("Polls.OnlyRegisteredUsersVote") });

        //    var alreadyVoted = _pollService.AlreadyVoted(poll.Id, _workContext.CurrentCustomer.Id);
        //    if (!alreadyVoted)
        //    {
        //        //vote
        //        _pollService.InsertPollVotingRecord(new PollVotingRecord
        //        {
        //            PollAnswerId = pollAnswer.Id,
        //            CustomerId = _workContext.CurrentCustomer.Id,
        //            CreatedOnUtc = DateTime.UtcNow
        //        });

        //        //update totals
        //        pollAnswer.NumberOfVotes = _pollService.GetPollVotingRecordsByPollAnswer(pollAnswer.Id).Count;
        //        _pollService.UpdatePollAnswer(pollAnswer);
        //        _pollService.UpdatePoll(poll);
        //    }

        //    return Json(new
        //    {
        //        html = RenderPartialViewToString("_Poll", _pollModelFactory.PreparePollModel(poll, true)),
        //    });
        //}
    }
}
