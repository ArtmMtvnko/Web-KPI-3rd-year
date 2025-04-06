using Microsoft.AspNetCore.Mvc;

namespace Web_Lab2_HTTPS.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentController : ControllerBase
{
    [HttpGet("fullname")]
    public string GetFullName()
    {
        return "Artem Matviienko KP-21";
    }
}
