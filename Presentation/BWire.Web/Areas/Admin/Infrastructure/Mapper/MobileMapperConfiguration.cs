using AutoMapper;
using BWire.Core.Infrastructure.Mapper;
using BWire.Web.Models.Catalog;
using BWire.Web.Models.Mobile.Catalog;

namespace BWire.Web.Areas.Admin.Infrastructure.Mapper
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
