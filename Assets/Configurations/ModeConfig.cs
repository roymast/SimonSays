namespace Configurations
{
    public partial class GameConfigurations
    {
        /// <summary>
        /// ModeConfig saves single game mode(Easy/Medium/Hard) data        
        /// </summary>
        [System.Serializable]
        public class ModeConfig
        {
            public int GameButtons;
            public int PointEachStep;
            public int GameTime;
            public bool RepeatMode;
        }
    }
}