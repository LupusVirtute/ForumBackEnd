using System.Collections.Generic;

namespace ForumBackEnd.Models.Database.Classes
{
    public class Category
    {
        int id;
        string categoryName;
        List<Topic> topics;

        public List<Topic> Topics
        {
            get
            {
                return topics;
            }
        }




        public Category(int id, string categoryName, List<Topic> topics)
        {
            this.id = id;
            this.categoryName = categoryName;
            this.topics = topics;
        }
        
    }
}
