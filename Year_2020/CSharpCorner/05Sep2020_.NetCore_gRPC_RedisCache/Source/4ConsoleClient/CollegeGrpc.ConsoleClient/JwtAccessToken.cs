using System;

namespace CollegeGrpc.ConsoleClient
{

    public class JwtAccessToken
    {
        public string Access_Token { get; set; }

        public int Expires_In { get; set; }

        public string Token_Type { get; set; }

        public DateTime Expiration { get; set; } = DateTime.Now;
    }

}
