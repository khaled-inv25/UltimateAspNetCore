using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyEmployees.Domain
{
    public abstract class BaseEntity<TId> where TId : IEquatable<TId>
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public TId Id { get; set; }
    }
}
