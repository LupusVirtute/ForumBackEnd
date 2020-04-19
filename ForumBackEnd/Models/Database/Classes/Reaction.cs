namespace ForumBackEnd.Models.Database.Structs
{
    public class Reaction
    {
        int reactionAmount;
        string reactionName;
        public int ReactionAmount 
        {
            get
            {
                return reactionAmount;
            }
        }
        public string ReactionName
        {
            get
            {
                return reactionName;
            }
        }
        public void IncrementReaction()
        {
            reactionAmount++;
        }
        public void DecrementReaction()
        {
            reactionAmount--;
        }
        public Reaction(int reactionAmount, string reactionName)
        {
            this.reactionAmount = reactionAmount;
            this.reactionName = reactionName;
        }
    }
}
