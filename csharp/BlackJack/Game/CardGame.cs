namespace BlackJack.Game
{
    public abstract class CardGame
    {
        public virtual void Start()
        {
            Setup();
            GameLoop();
            ResetGame();
        }
        
        protected abstract void Setup();

        protected abstract void GameLoop();

        protected abstract void ResetGame();
    }
}
