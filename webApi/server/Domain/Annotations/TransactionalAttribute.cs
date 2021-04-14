using System;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.AspNetCore.Mvc.Filters;

namespace server.Domain.Annotations
{
    public class TransactionalAttribute : Attribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            using (var transactionScope = new TransactionScope())
            {
                await next();
                transactionScope.Complete();
            }
        }
    }
}
