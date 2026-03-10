#if DEBUG
using AppProject.Exceptions;
using AppProject.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppProject.Core.Controllers.General
{
    [Route("api/general/[controller]/[action]")]
    [ApiController]
    public class SampleController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetSample()
        {
            return this.Ok("This is a sample response from GeneralSampleController");
        }

        [HttpGet]
        public IActionResult GetCultureSample()
        {
            return this.Ok(StringResource.GetStringByKey("Sample_Message_Text"));
        }

        [HttpGet]
        public IActionResult GetException()
        {
            throw new AppException(ExceptionCode.Generic, "This is a simple exception for testing purposes");
        }
    }
}
#endif