using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web2_Backend.Core;
using Web2_Backend.Model;

namespace Web2_Backend.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(Web2Context context) : base(context) { }

        public User GetUserWithEmail(string email)
        {
            var query = Web2Context.Users.Where(x => x.Email == email);

            return query.FirstOrDefault();
        }

        public User GetUserWithUsernameAndPassword(string email, string password) 
        {
            var query = Web2Context.Users.Where(x => x.Email == email && x.Password == password);

            return query.FirstOrDefault();
        }

        public List<User> GetVerificationUsers()
        {
            var query = Web2Context.Users.Where(x => x.Deleted == false && x.AdminNeedApproved == true);

            return query.ToList();
        }

        public override PageResponse<User> GetAll(int page, int perPage, string search, string sort)
        {
            string term = search == null ? string.Empty : search.ToLower();

            var query = Web2Context.Users.Where(x => (x.Username.ToLower().Contains(term)
            || x.Email.ToLower().Contains(term) || x.Name.ToLower().Contains(term) ||
            x.LastName.ToLower().Contains(term) || x.Address.ToLower().Contains(term)) && x.Deleted == false);

            return new PageResponse<User>(query.Skip(page * perPage).Take(perPage).ToList(), query.Count());
        }
    }
}
