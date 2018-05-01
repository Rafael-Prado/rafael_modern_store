using FluentValidator;
using Microsoft.AspNetCore.Mvc;
using ModernStore.Infra.Transactions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModernStore.Api.Controllers
{
    public class BaseController: Controller
    {
        private readonly IUow _uow;

        public BaseController(IUow uow)
        {
            _uow = uow;
        }

        public async Task<IActionResult> Response(object result, IEnumerable<Notification> notifications)
        {
            if (!notifications.Any())
            {
                try
                {
                    _uow.commit();
                    return Ok(new
                    {
                        success = true,
                        data = result
                    });

                }
                catch
                {
                    return BadRequest(new
                    {
                        success = false,
                        errors = new[] { "Ocorreu uma falha no servidor" }
                    });
                }
            }
            else
            {
                return BadRequest(new
                {
                    success = false,
                    errors = notifications
                });
            }
        }
    }
}
