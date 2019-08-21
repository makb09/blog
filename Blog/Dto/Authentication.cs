namespace Blog.Dto
{
    public class Authentication
    {
        public class Login
        {
            public string EmailAddress { get; set; }
            public string Password { get; set; }
        }

        public class LoginResult
        {
            public string Name { get; set; }
            public string Surname { get; set; }
            public string EmailAddress { get; set; }
            public string Token { get; set; }
        }
    }
}
