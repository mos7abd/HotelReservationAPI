
using HotelReservationAPI.Data;
using Microsoft.EntityFrameworkCore.Storage;

namespace HotelReservationAPI.Middlewares
{
    public class TransactionMiddleware : IMiddleware
    {
        Context _context;
        public TransactionMiddleware(Context context)
        {
            _context = context;
        }

        public async Task InvokeAsync(HttpContext httpContext, RequestDelegate next)
        {
            IDbContextTransaction transaction = null;
            try
            {
                transaction = _context.Database.BeginTransaction();
                await next(httpContext);

                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
                // Log Error

                throw;
            }
        }
    }
}
