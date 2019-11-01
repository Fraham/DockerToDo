using System.Text.Json.Serialization;

namespace Data.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TodoItemStatus
    {
        Pending = 0,
        InProgress = 1,
        Paused = 2,
        Completed = 3,
        Rejected = 4
    }
}