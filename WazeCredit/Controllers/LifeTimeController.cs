using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Options;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using WazeCredit.Models;
using WazeCredit.Models.ViewModels;
using WazeCredit.Service;
using WazeCredit.Service.LifeTimeExample;
using WazeCredit.Utility.AppSettingClasses;

namespace WazeCredit.Controllers
{
    public class LifeTimeController : Controller
    {
        private readonly TransientService _transientService;
        private readonly ScopedService _scopedService;
        private readonly SingletonService _singletonService;
        public LifeTimeController(TransientService transientService, ScopedService SingletonService
           , SingletonService singletonService)
        {
            _transientService = transientService;
            _scopedService = SingletonService;
            _singletonService = singletonService;

        }
        public IActionResult Index()
        {
            var message = new List<string>
            {
                HttpContext.Items["CustomMiddlewareTransient"].ToString(),
                $"Transient COntroller - {_transientService.GetGuid()}",
                HttpContext.Items["CustomMiddlewareScoped"].ToString(),
                $"Scoped COntroller - {_scopedService.GetGuid()}",
                HttpContext.Items["CustomMiddlewareSingleton"].ToString(),
                $"Singleton COntroller - {_singletonService.GetGuid()}"
            };
            return View(message);
        }
    }
}
