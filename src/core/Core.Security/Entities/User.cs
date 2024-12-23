using Core.Persistence.Repositories;

namespace Core.Security.Entities;

public class User : Entity<int>
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public byte[] PasswordSalt { get; set; } = Array.Empty<byte>();
    public byte[] PasswordHash { get; set; } = Array.Empty<byte>();
    public bool Status { get; set; }

    public virtual ICollection<UserOperationClaim> UserOperationClaims { get; set; } = null!;

    public User()
    {

    }

    public User(string firstName, string lastName, string email, byte[] passwordSalt, byte[] passwordHash, bool status)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PasswordSalt = passwordSalt;
        PasswordHash = passwordHash;
        Status = status;
    }

    public User(int id, string firstName, string lastName, string email, byte[] passwordSalt, byte[] passwordHash, bool status) : base(id) 
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PasswordSalt = passwordSalt;
        PasswordHash = passwordHash;
        Status = status;
    }
}