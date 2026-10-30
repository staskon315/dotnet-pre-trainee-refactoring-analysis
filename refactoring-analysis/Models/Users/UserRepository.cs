public class UserRepository
{
    private readonly List<User> _users = new();
    public void Add(User user) => _users.Add(user);
    public User? GetById(int id) =>_users.Find(x=>x.Id==id);
}