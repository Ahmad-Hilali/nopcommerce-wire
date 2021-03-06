using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using BWire.Core.Domain.Forums;
using BWire.Web.Framework.Models;

namespace BWire.Web.Models.Boards
{
    public partial class EditForumTopicModel : BaseNopModel
    {
        #region Ctor

        public EditForumTopicModel()
        {
            TopicPriorities = new List<SelectListItem>();
        }

        #endregion

        #region Properties

        public bool IsEdit { get; set; }

        public int Id { get; set; }

        public int ForumId { get; set; }

        public string ForumName { get; set; }

        public string ForumSeName { get; set; }

        public int TopicTypeId { get; set; }

        public EditorType ForumEditor { get; set; }

        public string Subject { get; set; }

        public string Text { get; set; }

        public bool IsCustomerAllowedToSetTopicPriority { get; set; }

        public IEnumerable<SelectListItem> TopicPriorities { get; set; }

        public bool IsCustomerAllowedToSubscribe { get; set; }

        public bool Subscribed { get; set; }

        public bool DisplayCaptcha { get; set; }

        #endregion
    }
}