namespace Configurations
{
    /// <summary>
    /// GameConfigurations saves all of the configurations data
    /// </summary>
    public partial class GameConfigurations
    {
        [System.Serializable]
        public class Root
        {
            public ModeConfig Easy;
            public ModeConfig Medium;
            public ModeConfig Hard;
        }
    }
}