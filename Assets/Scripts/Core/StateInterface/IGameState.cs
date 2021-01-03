namespace MynetDemo.Core
{
    public interface IGameState
    {
        void Begin();
        void End();
        void Update();
    }
}