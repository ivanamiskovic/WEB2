using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web2_Backend.Configuration
{
    public class ProjectConfiguration : IProjectConfiguration
    {
        public DatabaseConfiguration DatabaseConfiguration { get; set; } = new DatabaseConfiguration();
        public Jwt Jwt { get; set; } = new Jwt();
        //public EmailSettings EmailSettings { get; set; } = new EmailSettings();
    }

    public class EmailSettings 
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int Port { get; set; }
        public string SMTP { get; set; }
        public string FromEmail { get; set; }
        public string DisplayName { get; set; }
    }

    public class DatabaseConfiguration 
    {
        public string ConnectionString { get; set; }
    }

    public class Jwt 
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Subject { get; set; }
    }
}
