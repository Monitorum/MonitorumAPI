namespace MonitorumAPI.Models
{
    public class User
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public required Role Role { get; set; }


    }
}
