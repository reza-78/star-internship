using Microsoft.AspNetCore.Mvc;

namespace Example.Controllers
{
    [ApiController]
    [Route("[controller]/[Action]")]
    public class SimpleController : ControllerBase
    {
        [HttpGet]
        public async Task<string> Get()
        {
            await using var file = System.IO.File.Open("", FileMode.Append);
            await file.WriteAsync(new byte[] {1});
            
            return "Hello world!";
        }
    }
}
