using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web2_Backend.Core;
using Web2_Backend.Model;


namespace Web2_Backend.Repository
{
    public class CrewMemberRepository : Repository<CrewMember>, ICrewMemberRepository
    {
        public CrewMemberRepository(Web2Context context) : base(context) { }
        public override IEnumerable<CrewMember> GetAll()
        {
            return Web2Context.CrewMembers.Where(x => x.Deleted == false).ToList();
        }

        public override PageResponse<CrewMember> GetAll(int page, int perPage, string search)
        {
            string term = search == null ? string.Empty : search.ToLower();


            var query = Web2Context.CrewMembers.Where(x => x.User.Address.ToLower().Contains(term) || x.User.Email.ToLower().Contains(term) || x.User.LastName.ToLower().Contains(term) || x.User.Name.ToLower().Contains(term) || x.User.Password.ToLower().Contains(term) || x.User.Username.ToLower().Contains(term));

            return new PageResponse<CrewMember>(query.Skip(page * perPage).Take(perPage).ToList(), query.Count());
        }
    }
}
