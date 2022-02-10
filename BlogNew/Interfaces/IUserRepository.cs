using BlogNew.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogNew.Interfaces
{
    public interface IUserRepository
    {
        ApplicationUser GetUser(string id);
    }
}
