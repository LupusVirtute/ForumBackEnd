using System.Collections.Generic;

namespace ForumBackEnd.Models.Database.Classes
{
    public class Topic
    {
        int id;
        string topicName;
        User creator;
        Category category;
        List<Post> posts;
        public List<Post> Posts
        {
            get
            {
                return posts;
            }
        }

        public Topic(int id, string topicName, User creator, Category category,List<Post> posts)
        {
            this.id = id;
            this.topicName = topicName;
            this.creator = creator;
            this.category = category;
            this.posts = posts;

        }
        public void ChangeTopicCategory(Category cat)
        {
            category = cat;
        }
    }
}
