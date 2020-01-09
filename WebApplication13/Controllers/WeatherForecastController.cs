using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApplication13.Controllers
{
    /// <summary>
    /// https://www.cnblogs.com/laozhang-is-phi/p/9795689.html
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [ApiExplorerSettings(GroupName ="v1")]
        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        /// <summary>
        /// 获取用户详情API
        /// </summary>
        /// <remarks>
        /// 例子：
        /// /WeatherForecast/test
        /// </remarks>
        /// <param name="id">
        /// 主键
        /// </param>
        /// <returns>用户身份信息</returns>
        /// <response code="201">返回value字符串</response>
        /// <response code="400">如果id为空</response>
        [ApiExplorerSettings(GroupName = "v2")]
        [HttpGet("test")]
        public IActionResult GetTest(int id)
        {
            return new JsonResult(new{Name="zhangsan"});
        }
    }
}
