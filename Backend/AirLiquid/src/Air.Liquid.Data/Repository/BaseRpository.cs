namespace Air.Liquide.Data.Repository
{
    public class BaseRpository
    {
        protected readonly Context Db;

        public BaseRpository(Context dbContext)
        {
            Db = dbContext;
        }
    }
}
