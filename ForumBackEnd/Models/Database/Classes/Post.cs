using ForumBackEnd.Models.Database.Structs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ForumBackEnd.Models.Database.Classes
{
    public class Post
    {
        User user;
        string text;
        bool isModified;
        DateTime dateModified;
        Topic topic;
        List<Reaction> reactions;

        public void AddReaction(Reaction reaction)
        {
            Reaction r = reactions.FirstOrDefault(o => o.ReactionName == reaction.ReactionName);
            if (r == null)
            {
                reactions.Add(reaction);
            }
            else
            {
                r.IncrementReaction();
            }
        }
        public void RemoveReaction(Reaction reaction)
        {
            Reaction r = reactions.FirstOrDefault(o => o.ReactionName == reaction.ReactionName);
            if (r != null)
            {
                r.DecrementReaction();
            }
            if (r.ReactionAmount <= 0)
            {
                reactions.Remove(r);
            }
        }

        public Post(User user, string text, bool isModified, DateTime dateModified, Topic topic)
        {
            this.user = user;
            this.text = text;
            this.isModified = isModified;
            this.dateModified = dateModified;
            this.topic = topic;
        }
    }
}
