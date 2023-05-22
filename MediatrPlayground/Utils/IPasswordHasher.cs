namespace MediatrPlayground.Utils;

public interface IPasswordHasher
{
    public string Hash(string password);
    
    public bool Validate(string passwordHash, string password);
}