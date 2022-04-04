using BWire.Core.Domain.Tax;
using BWire.Web.Framework.Models;

namespace BWire.Web.Models.Common
{
    public partial class TaxTypeSelectorModel : BaseNopModel
    {
        public TaxDisplayType CurrentTaxType { get; set; }
    }
}