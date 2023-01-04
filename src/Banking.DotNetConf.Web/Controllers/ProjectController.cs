using System.Linq;
using System.Threading.Tasks;
using Banking.DotNetConf.Core;
using Banking.DotNetConf.Core.ProjectAggregate;
using Banking.DotNetConf.Core.ProjectAggregate.Specifications;
using Banking.DotNetConf.SharedKernel.Interfaces;
using Banking.DotNetConf.Web.ApiModels;
using Banking.DotNetConf.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Banking.DotNetConf.Web.Controllers;

[Route("[controller]")]
public class ProjectController : Controller
{
    private readonly IRepository<Project> _projectRepository;

    public ProjectController(IRepository<Project> projectRepository)
    {
        _projectRepository = projectRepository;
    }

    // GET project/{projectId?}
    [HttpGet("{projectId:int}")]
    public async Task<IActionResult> Index(int projectId = 1)
    {
        var spec = new ProjectByIdWithItemsSpec(projectId);
        var project = await _projectRepository.GetBySpecAsync(spec);

        var dto = new ProjectViewModel
        {
            Id = project.Id,
            Name = project.Name,
            Items = project.Items
                        .Select(item => ToDoItemViewModel.FromToDoItem(item))
                        .ToList()
        };
        return View(dto);
    }
}
