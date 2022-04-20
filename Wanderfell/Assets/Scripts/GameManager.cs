public class GameManager
{
    public enum EnumGameState
    {
        Playing,
        Dialogue,
        Pause,
        GameOver
    }

    public static EnumGameState GameState { get; set; }
}
