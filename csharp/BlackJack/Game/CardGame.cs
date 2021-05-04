namespace BlackJack.Game
{
    public abstract class CardGame
    {
        protected abstract void Setup();

        public virtual void Start()
        {
            Setup();
            GameLoop();
        }

        protected abstract void GameLoop();
    }
}
