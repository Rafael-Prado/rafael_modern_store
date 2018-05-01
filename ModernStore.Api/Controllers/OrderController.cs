using Microsoft.AspNetCore.Mvc;
using ModernStore.Domain.Commads.Handlers;
using ModernStore.Domain.Commands.Inputs;
using ModernStore.Infra.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModernStore.Api.Controllers
{
    public class OrderController: BaseController
    {
        private readonly OrderCommadHandler _handler;
        public OrderController(IUow uow, OrderCommadHandler handler)
            :base(uow)
        {
            _handler = handler;
        }
        [HttpPost]
        [Route("v1/orders")]
        public async Task<IActionResult> Post([FromBody]RegisterOrderCommad commad)
        {
            var result = _handler.Handle(commad);
            return await Response(result, _handler.Notifications);
        }
    }
}
