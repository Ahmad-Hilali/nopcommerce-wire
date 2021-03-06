using System.Collections.Generic;
using BWire.Core.Domain.Catalog;
using BWire.Services.ExportImport.Help;

namespace BWire.Services.ExportImport
{
    public class ImportProductMetadata
    {
        public int EndRow { get; internal set; }

        public PropertyManager<Product> Manager { get; internal set; }

        public IList<PropertyByName<Product>> Properties { get; set; }

        public int CountProductsInFile => ProductsInFile.Count;

        public PropertyManager<ExportProductAttribute> ProductAttributeManager { get; internal set; }

        public PropertyManager<ExportSpecificationAttribute> SpecificationAttributeManager { get; internal set; }

        public int SkuCellNum { get; internal set; }

        public List<string> AllSku { get; set; }

        public List<int> ProductsInFile { get; set; }
    }
}
