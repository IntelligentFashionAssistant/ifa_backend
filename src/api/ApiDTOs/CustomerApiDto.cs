namespace api.ApiDTOs
{
    public class CustomerApiDto 
    {
        public long Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? Photo { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public string Username { get; set; }
        public string? PhoneNumber { get; set; }
        public float? ShoulderSize { get; set; }
        public float? BustSize { get; set; }
        public float? HipSize { get; set; }
        public float? WaistSize { get; set; }
        public string? Shape { get; set; }
        public Dictionary<string, string>? Sizes { get; set; }

    }
}
