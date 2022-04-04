
namespace BWire.Web.Framework.Models
{
    /// <summary>
    /// Represents base b-Wire entity model
    /// </summary>
    public partial class BaseNopEntityModel : BaseNopModel
    {
        /// <summary>
        /// Gets or sets model identifier
        /// </summary>
        public virtual int Id { get; set; }
    }
}