using AutoMapper;
using Calabonga.AspNetCore.Controllers.Handlers;
using Calabonga.AspNetCore.Controllers.Queries;
using Calabonga.Microservices.Core.QueryParams;
using Calabonga.Module12.Entities;
using Calabonga.Module12.Web.ViewModels.LogViewModels;
using Calabonga.UnitOfWork;

namespace Calabonga.Module12.Web.Mediator.LogsReadonly
{
    /// <summary>
    /// Request for paged list of Logs
    /// </summary>
    public class LogGetPagedRequest : GetPagedQuery<LogViewModel, PagedListQueryParams>
    {
        public LogGetPagedRequest(PagedListQueryParams queryParams) : base(queryParams)
        {
        }
    }

    /// <summary>
    /// Request for paged list of Logs
    /// </summary>
    public class LogGetPagedRequestHandler : GetPagedHandlerBase<LogGetPagedRequest, Log, PagedListQueryParams, LogViewModel>
    {
        public LogGetPagedRequestHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }
    }
}
