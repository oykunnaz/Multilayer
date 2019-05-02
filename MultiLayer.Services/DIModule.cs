using MultiLayer.Domain.Entities;
using MultiLayer.Domain.Interfaces;
using MultiLayer.Infrasturcture.Repositories;
using MultiLayer.Presentation.Models;
using Ninject.Modules;

namespace MultiLayer.Services
{
    public class DIModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IRepository<Forms>>().To<Repository<Forms>>();
            Bind<IRepository<fields>>().To<Repository<fields>>();
        }
    }
}
