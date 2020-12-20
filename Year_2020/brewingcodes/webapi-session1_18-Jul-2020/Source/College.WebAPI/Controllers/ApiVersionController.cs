using College.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Reflection;

namespace College.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiVersionController : ControllerBase
    {

        [HttpGet]
        public IActionResult Get()
        {
            var apiVersion = new ApiVersion()
            {
                AssemblyVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString(),
                FileVersion = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion,
                ProductVersion = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).ProductVersion
            };

            return Ok(apiVersion);
        }

    }

}
