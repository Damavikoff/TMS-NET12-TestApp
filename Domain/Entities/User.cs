using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NET12_test.Domain.Entities
{
    [Table("tst_users")]
    public class User
    {
        [Key]
        [Column("id")]
        public Guid? Id { get; set; }
        [Column("name")]
        public required string Name { get; set; }
        [Column("email")]
        public required string Email { get; set; }
        [Column("last_action")]
        public required DateTime? LastAction { get; set; }
        [Column("action_count")]
        public required int? ActionCount { get; set; } = 1;

        public User(Guid? id, string name, string email, DateTime? lastAction, int? actionCount) {
            Id = id ?? Guid.NewGuid();
            Name = name;
            Email = email;
            LastAction = lastAction ?? DateTime.UtcNow;
            ActionCount = actionCount ?? 1;
        }
    }
}
