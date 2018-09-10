using BaseGame;
using BaseModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SurvivalServer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurvivalServer.Controllers
{
    [Route("api/[controller]")]
    public class CharacterController : Controller
    {
        // GET api/Character/latest 
        [HttpGet("Latest/{num}")]
        public IActionResult Latest(int num = 10)
        {
            var sampleCharacters = new List<CharacterViewModel>();

            // add a bunch of sample Characterzes 
            for (int i = 1; i <= num; i++)
            {
                sampleCharacters.Add(new CharacterViewModel()
                {
                    Id = i,
                    Name = String.Format("Sample Character {0}", i),
                    Sex = RNG.Dice(2) == 0 ? Sex.Male : Sex.Female,
                    CreatedDate = DateTime.Now,
                    LastModifiedDate = DateTime.Now
                });
            }

            // output the result in JSON format 
            return new JsonResult(
                sampleCharacters,
                new JsonSerializerSettings()
                {
                    Formatting = Formatting.Indented
                });
        }
    }
}
