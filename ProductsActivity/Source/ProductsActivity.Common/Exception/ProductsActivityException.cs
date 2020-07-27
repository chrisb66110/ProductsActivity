using System.Net;
using APIBase.Common.Exceptions;

namespace ProductsActivity.Common.Exception
{
    public class ProductsActivityException : BaseException
    {
        public ProductsActivityException(string message, HttpStatusCode statusCode) : base(message, statusCode)
        {
        }
    }
}
