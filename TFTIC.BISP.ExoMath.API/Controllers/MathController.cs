using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TFTIC.BISP.ExoMath.API.Controllers
{
    [ApiController]
    public class MathController : ControllerBase
    {
        //    [HttpGet("[action]/{nb1:long:required:min(0)}/{nb2:long:required:min(0)}")]
        //    public long Addition (long nb1, long nb2)
        //    {
        //        return nb1 + nb2;
        //    }

        [HttpGet("[action]/{nb1:long:required}/{nb2:long:required}")]
        public ActionResult<long> Addition (long nb1, long nb2)
        {
            if (nb1 < 0) return BadRequest(new { Variable="nb1", Value = nb1, Message = "Must be positive." });
            if (nb2 < 0) return BadRequest(new { Variable="nb2", Value = nb2, Message = "Must be positive." });
            return Ok(nb1+nb2);
        }

        [HttpGet("table/[action]/{nombre:int:range(1,10)?}")]
        public Dictionary<string, int> Multiplication (int? nombre)
        {
            Dictionary<string, int> result = new Dictionary<string, int>();
            for (int i = 1; i <= 10; i++)
            {
                if (!(nombre is null)) result.Add($"{i}X{(int)nombre}", i * (int)nombre);
                else
                {
                    for (int j = 1; j <= 10; j++)
                    {
                        result.Add($"{i}X{j}", i * j);
                    }
                }
            }
            return result;
        }

    }
}
