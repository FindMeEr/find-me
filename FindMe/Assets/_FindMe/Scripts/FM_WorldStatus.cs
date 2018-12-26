
namespace find_me
{

    public class FM_WorldStatus
    {

        public FM_WorldStatus(int worldId, int worldScore)
        {
            Id = worldId;
            Score = worldScore;
        }

        public int Id { get; set; }
        public int Score { get; set; }
    }

}
