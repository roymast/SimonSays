using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Leaderboard
{
    public class LeaderboardLine : MonoBehaviour
    {
        public TextMeshProUGUI Name;
        public TextMeshProUGUI Score;
        public void Highligh()
        {
            HighlightLabel(Name);
            HighlightLabel(Score);
        }
        void HighlightLabel(TextMeshProUGUI label)
        {
            label.color = Color.green;
            label.fontStyle = FontStyles.Underline;
        }
    }
}
