﻿namespace TestAPI.Helpers
{
    public class UserSession
    {
        public int? UserId { get; set; }
        public string SessionId { get; set; }
        public DateTime LastActivity { get; set; }
    }
}
