namespace IPLDapperService.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slogan { get; set; }
        public string City { get; set; }
        public List<Player> Players { get; set; }   =new List<Player>();
    }
}
