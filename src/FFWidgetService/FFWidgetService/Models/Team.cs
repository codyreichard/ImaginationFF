using Newtonsoft.Json;

namespace FFWidgetService.Models
{
  public class Team
  {
    public Team(){ }


    [JsonProperty]
    public string code { get; set; }

    [JsonProperty]
    public string fullName { get; set; }

    [JsonProperty]
    public string shortName { get; set; }
  }
}
