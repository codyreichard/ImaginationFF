using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using FFWidgetService.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FFWidgetService.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class TeamsController : Controller
  {
    private readonly string API_KEY = "bejtmezvrx9t";

    // GET: api/values
    [HttpGet]
    public async Task<NflTeams> Get()
    {
      var httpClient = new HttpClient();
      //var teams = new List<Team>();

      var task = await httpClient.GetAsync("https://www.fantasyfootballnerd.com/service/nfl-teams/json/" + API_KEY + "/");
      var jsonString = await task.Content.ReadAsStringAsync();

      NflTeams teams = JsonConvert.DeserializeObject<NflTeams>(jsonString);

      return teams;
    }
  }
}
