using System;
using System.Diagnostics.CodeAnalysis;

namespace ProductsActivity.Api.Responses
{
    [ExcludeFromCodeCoverage]
    public class ImageLikeResponse
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public string Url { get; set; }
        public string Username { get; set; }
        public DateTime DateTime { get; set; }
        public long ImageId { get; set; }
    }
}
