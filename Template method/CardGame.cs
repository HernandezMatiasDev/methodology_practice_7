namespace methodology
{
    public abstract class CardGame
    {
        protected Person player_1;
        protected Person player_2;
        protected Person? winner;
        public CardGame(Person player_1, Person player_2)
        {
            this.player_1 = player_1;
            this.player_2 = player_2;
            this.winner = null;
        }
        public Person? Game()
        {
            this.winner = null; 

            mixDeck();       
            distributecards(); 
            play();            
            isWin();           
            return winer();    
        }

        public abstract void mixDeck();
        public abstract void distributecards();
        public abstract void play();
        public abstract void isWin();
        public abstract Person? winer();
    }
}