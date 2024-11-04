using System.ComponentModel.DataAnnotations;

namespace Common.Domain
{
    public class BaseEntity
    {
      
        public long Id { get; protected set; }
        public DateTime CreationDate { get;   set; }

        public BaseEntity()
        {
            CreationDate = new DateTime();
        }
    }
}
