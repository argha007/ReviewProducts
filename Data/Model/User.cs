namespace Data.Model
{
    public class User
    {
        public int id { get; set; }
        public string userName { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public Gender gender { get; set; }
        public string password { get; set; }


        public AuthUser ToAuthUser(string token)
        {
            return new AuthUser
            {
                Id = this.id,
                FirstName = this.firstName,
                LastName = this.lastName,
                UserName = this.userName,
                Gender = this.gender,
                Token = token
            };
        }
    }

    public enum Gender
    {
        Male,
        Female,
        Other,
        Unknown
    }


}
