using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskTest.Constants;
using TaskTest.Shared;


namespace TaskTest.Controllers
{
    [Authorize]
    public class TaskController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly ITaskRepository _taskRepositories;
        private readonly IFileService _fileService;
        private readonly ITaskImageRepository _taskImageRepo;

        public TaskController(UserManager<User> userManager, ITaskRepository taskRepositories, 
            IFileService fileService, ITaskImageRepository taskImageRepo)
        {
            _userManager = userManager;
            _taskRepositories = taskRepositories;
            _fileService = fileService;
            _taskImageRepo = taskImageRepo;

        }
        public async Task<IActionResult> Index()
        {
            var data = await _taskRepositories.GetAllTasks();
            return View(data);
        }

       

    }
}
