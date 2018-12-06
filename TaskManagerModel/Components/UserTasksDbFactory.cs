namespace TaskManagerModel.Components
{
    public class UserTasksDbFactory : IContextFactory
    {
        public IContext BuildContex()
        {
            return new UserTasksDbAdapter();
        }
    }
}
