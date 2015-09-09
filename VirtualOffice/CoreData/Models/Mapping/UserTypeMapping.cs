using Domain.Models;

namespace CoreData.Models.Mapping
{
    public class UserTypeMapping : BaseMapping<UserType>
    {
        public UserTypeMapping()
        {
            this.HasKey(t => t.Id);

            this.Property(t => t.TypeName)
                .IsRequired();
        }
    }
}