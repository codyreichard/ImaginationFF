using System.Collections.Generic;
using Newtonsoft.Json;

namespace FFWidgetService.Models
{
  public class NflTeams
  {
    public NflTeams() {}

    [JsonProperty("NFLTeams")]
    public List<Team> Teams { get; set; }
  }
}
