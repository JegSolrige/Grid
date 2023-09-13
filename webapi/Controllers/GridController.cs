using Microsoft.AspNetCore.Mvc;
using Models;

namespace Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GridController : ControllerBase
    {
        [HttpGet(Name = "GetBlankGrid")]
        public GridViewModel GetBlank()
        {
            return new GridViewModel(new Grid());
        }
    }
}
