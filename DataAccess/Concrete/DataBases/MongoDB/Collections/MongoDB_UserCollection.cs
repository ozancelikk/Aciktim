namespace DataAccess.Concrete.DataBases.MongoDB.Collections
{
    public class MongoDB_UserCollection : ICollection
    {
        public string CollectionName { get; set; }

        public MongoDB_UserCollection()
        {
            CollectionName = "Users";
        }
    }
}
