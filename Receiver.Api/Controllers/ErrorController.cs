using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Receiver.Api.Controllers
{
    [ApiController]
    public class ErrorController : ControllerBase
    {
        // send an RFC-7807 problem report back to the client
        [Route("/error")]
        public IActionResult Error() => Problem();        
    }
}