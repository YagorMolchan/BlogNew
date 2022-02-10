using BlogNew.Interfaces;
using BlogNew.Repositories;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogNew.Infrastructure.Ninject
{
    public class NinjectRegistrations:NinjectModule
    {
        public override void Load()
        {
            Bind<ICategoryRepository>().To<CategoryRepository>();
            Bind<IArticleRepository>().To<ArticleRepository>();
            Bind<IUserRepository>().To<UserRepository>();
        }
    }
}