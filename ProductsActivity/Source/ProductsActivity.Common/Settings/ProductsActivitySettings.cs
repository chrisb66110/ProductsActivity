using System.Diagnostics.CodeAnalysis;
using APIBase.Common.Settings;

namespace  ProductsActivity.Common.Settings
{
    [ExcludeFromCodeCoverage]
    public class ProductsActivitySettings : BaseSettings
    {
        public ConnectionStrings ConnectionStrings { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ConnectionStrings
    {
        public string ProductsActivityConnectionString { get; set; }
        public string CatalogueConnectionString { get; set; }
    }
}
