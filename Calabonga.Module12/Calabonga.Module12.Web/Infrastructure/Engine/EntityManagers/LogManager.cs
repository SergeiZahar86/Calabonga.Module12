using AutoMapper;
using Calabonga.Microservices.Core.Validators;
using Calabonga.Module12.Entities;
using Calabonga.Module12.Web.ViewModels.LogViewModels;
using Calabonga.UnitOfWork.Controllers.Factories;
using Calabonga.UnitOfWork.Controllers.Managers;

namespace Calabonga.Module12.Web.Infrastructure.Engine.EntityManagers
{
    /// <summary>
    /// Entity manager for <see cref="Log"/>
    /// </summary>
    public class LogManager : EntityManager<LogViewModel, Log, LogCreateViewModel, LogUpdateViewModel>
    {
        /// <inheritdoc />
        public LogManager(IMapper mapper, IViewModelFactory<LogCreateViewModel, LogUpdateViewModel> viewModelFactory, IEntityValidator<Log> validator)
            : base(mapper, viewModelFactory, validator)
        {
        }
    }
}
