using BlogNew.Interfaces;
using BlogNew.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogNew.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ApplicationUserManager _userManager;

        public UserRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(_dbContext));
        }

        public ApplicationUser GetUser(string id)
        {
            return _userManager.FindById(id);
        }
    }
}