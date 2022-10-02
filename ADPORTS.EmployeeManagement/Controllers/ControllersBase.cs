using ADPORTS.EmployeeManagement.Core.Common;
using Microsoft.AspNetCore.Mvc;

namespace ADPORTS.EmployeeManagement.Controllers
{
    [Route("api/[controller]")]
    public class ControllersBase : Controller
    {
        protected IActionResult GetActionResult<T>(ServiceResult<T> serviceResult)
        {
            int statusCode = (int)serviceResult.Status;

            if (serviceResult.Status == ResultCode.NoContent)
            {
                return NoContent();
            }
            else if (serviceResult.Status == ResultCode.Ok || serviceResult.Status == ResultCode.Created)
            {
                return StatusCode(statusCode, serviceResult.Data);
            }
            else
            {
                return StatusCode(statusCode, serviceResult.Errors);
            }
        }
        protected IActionResult GetActionResult(ServiceResult serviceResult)
        {
            int statusCode = (int)serviceResult.Status;

            if (serviceResult.Status == ResultCode.NoContent)
            {
                return NoContent();
            }
            else if (serviceResult.IsSucceed)
            {
                return StatusCode(statusCode);
            }
            else
            {
                return StatusCode(statusCode, serviceResult.Errors);
            }
        }
    }
}
