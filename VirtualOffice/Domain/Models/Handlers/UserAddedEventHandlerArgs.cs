namespace Domain.Models.Handlers
{
    public class UserAddedEventHandlerArgs : EntityAddedEventHandlerArgs<User>
    {
        public UserAddedEventHandlerArgs(User user)
        {
            this.Entity = user;
        }
    }
}