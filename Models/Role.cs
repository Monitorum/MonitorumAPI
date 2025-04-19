namespace MonitorumAPI.Models
{
    public class Role
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
    }

    public static class Roles
    {
        public static Role Admin { get; } = new Role { Id = 1, Name = "Admin" };
    }
}
