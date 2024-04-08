using System.ComponentModel.DataAnnotations.Schema;

namespace Flight.Domain.Models
{
    /// <summary>
    /// The entity.
    /// </summary>
    public class BaseEntity
    {        
        /// <summary>
        /// Date creation of entity.
        /// </summary>
        [Column("Created")]
        protected DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        /// <summary>
        /// Date where entity is modified
        /// </summary>
        [Column("Updated")]
        protected DateTime ModifiedDate { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Before the update.
        /// </summary>
        public void BeforeUpdate(){
            ModifiedDate = DateTime.UtcNow;
        }
    }

    /// <summary>
    /// The status.
    /// </summary>
    public enum Status
    {
        Active, Inactive
    }

    /// <summary>
    /// The genre.
    /// </summary>
    public enum Genre{
        Male, Female
        }

    /// <summary>
    /// The state.
    /// </summary>
    public enum State
    {
        Pending,Confirmed,Cancelled
    }

    /// <summary>
    /// The flight type.
    /// </summary>
    public enum Type
    {
        BusinessClass, Economy
    }
}
