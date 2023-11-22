using NET12_test.Domain;
using NET12_test.Domain.Entities;

namespace NET12_test.Services
{
    public class UserService
    {
        private readonly ApplicationContext _context;

        public UserService(ApplicationContext applicationContext)
        {
            _context = applicationContext;
        }

        public void Add(User user)
        {
            var entity = _context.Users.Where(x => x.Email == user.Email).SingleOrDefault();
            if (entity == null)
            {
                _context.Users.Add(user);
            } else
            {
                entity.ActionCount++;
                entity.LastAction = DateTime.UtcNow;
                _context.Users.Update(entity);
            }
            _context.SaveChanges();
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users.OrderByDescending(x => x.LastAction);
        }
    }
}
