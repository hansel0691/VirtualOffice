namespace Domain.Models
{
    public class HashKey : BaseModel
    {
        public string Hash { get; set; }

        public int UserId { get; set; }
        
        public virtual User User { get; set; }

        public HashKey()
        {
        }

        public HashKey(string hash)
        {
            Hash = hash;
        }
    }
}