using AutoMapper;
using Nop.Core.Infrastructure.Mapper;
using Nop.Web.Models.Catalog;
using Nop.Web.Models.Mobile.Catalog;

namespace Nop.Web.Areas.Admin.Infrastructure.Mapper
{
    public class MobileMapperConfiguration : Profile, IOrderedMapperProfile
    {
        /// <summary>
        /// Order of this mapper implementation
        /// </summary>
        public int Order => 1;

        public MobileMapperConfiguration()
        {
            CreateMap<CategoryModel, CategoryMobModel>();
            CreateMap<CategorySimpleModel, CategorySimpleMobModel>();
        }
    }
}
