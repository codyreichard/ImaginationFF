namespace FFWidgetService.Models
{
  using System;
  using System.Collections.Generic;

  using System.Globalization;
  using Newtonsoft.Json;
  using Newtonsoft.Json.Converters;

  public partial class GameInfo
  {
    [JsonProperty("home")]
    public TeamScore Home { get; set; }

    [JsonProperty("away")]
    public TeamScore Away { get; set; }

    [JsonProperty("bp")]
    public long BallPlacement { get; set; }

    [JsonProperty("down")]
    public object Down { get; set; }

    [JsonProperty("togo")]
    public object YardsTogo { get; set; }

    [JsonProperty("clock")]
    public object Clock { get; set; }

    [JsonProperty("posteam")]
    public object Posteam { get; set; }

    [JsonProperty("note")]
    public object Note { get; set; }

    [JsonProperty("redzone")]
    public object Redzone { get; set; }

    [JsonProperty("stadium")]
    public string Stadium { get; set; }

    [JsonProperty("media")]
    public Media Media { get; set; }

    [JsonProperty("yl")]
    public object Yl { get; set; }

    [JsonProperty("qtr")]
    public object Qtr { get; set; }
  }

  public partial class TeamScore
  {
    [JsonProperty("score")]
    public Score Score { get; set; }

    [JsonProperty("abbr")]
    public string Abbr { get; set; }

    [JsonProperty("to")]
    public object To { get; set; }
  }

  public partial class Score
  {
    [JsonProperty("1")]
    public object QuarterOne { get; set; }

    [JsonProperty("2")]
    public object QuarterTwo { get; set; }

    [JsonProperty("3")]
    public object QuarterThree { get; set; }

    [JsonProperty("4")]
    public object QuarterFour { get; set; }

    [JsonProperty("5")]
    public object Overtime { get; set; }

    [JsonProperty("T")]
    public object Total { get; set; }
  }

  public partial class Media
  {
    [JsonProperty("radio")]
    public Radio Radio { get; set; }

    [JsonProperty("tv")]
    public Tv Tv { get; set; }

    [JsonProperty("sat")]
    public object Sat { get; set; }

    [JsonProperty("sathd")]
    public object Sathd { get; set; }
  }

  public partial class Radio
  {
    [JsonProperty("home")]
    public object Home { get; set; }

    [JsonProperty("away")]
    public object Away { get; set; }
  }

  public enum Tv { Cbs, Fox, Nbc };

  public partial class GameInfo
  {
    public static Dictionary<string, GameInfo> FromJson(string json) => JsonConvert.DeserializeObject<Dictionary<string, GameInfo>>(json, FFWidgetService.Models.Converter.Settings);
  }

  public static class Serialize
  {
    public static string ToJson(this Dictionary<string, GameInfo> self) => JsonConvert.SerializeObject(self, FFWidgetService.Models.Converter.Settings);
  }

  internal static class Converter
  {
    public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
    {
      MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
      DateParseHandling = DateParseHandling.None,
      Converters =
            {
                TvConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
    };
  }

  internal class TvConverter : JsonConverter
  {
    public override bool CanConvert(Type t) => t == typeof(Tv) || t == typeof(Tv?);

    public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
    {
      if (reader.TokenType == JsonToken.Null) return null;
      var value = serializer.Deserialize<string>(reader);
      switch (value)
      {
        case "CBS":
          return Tv.Cbs;
        case "FOX":
          return Tv.Fox;
        case "NBC":
          return Tv.Nbc;
      }
      throw new Exception("Cannot unmarshal type Tv");
    }

    public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
    {
      if (untypedValue == null)
      {
        serializer.Serialize(writer, null);
        return;
      }
      var value = (Tv)untypedValue;
      switch (value)
      {
        case Tv.Cbs:
          serializer.Serialize(writer, "CBS");
          return;
        case Tv.Fox:
          serializer.Serialize(writer, "FOX");
          return;
        case Tv.Nbc:
          serializer.Serialize(writer, "NBC");
          return;
      }
      throw new Exception("Cannot marshal type Tv");
    }

    public static readonly TvConverter Singleton = new TvConverter();
  }
}

