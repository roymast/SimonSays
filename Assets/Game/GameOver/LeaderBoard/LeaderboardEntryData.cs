using System.Collections;

namespace Leaderboard
{
    /// <summary>
    /// Single player data in leaderboard
    /// </summary>
    [System.Serializable]
    public class LeaderboardEntryData : IComparer
    {
        public string Name;
        public int Score;
        public LeaderboardEntryData(string name, int score)
        {
            Name = name;
            Score = score;
        }

        public int Compare(object x, object y)
        {
            return (new CaseInsensitiveComparer()).Compare(((LeaderboardEntryData)x).Score,
           ((LeaderboardEntryData)y).Score);
        }

        public override string ToString()
        {
            return $"Name: {Name} Score: {Score}";
        }
    }
}
