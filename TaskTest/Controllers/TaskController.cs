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

        //[Authorize(Roles = nameof(Roles.Admin))]
        //public IActionResult AddTask()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public async Task<IActionResult> AddTask(TaskDTO task)
        //{
        //    if (!ModelState.IsValid)
        //        return View(task);

        //    try
        //    {
        //        ConstCategories CategoryCode =
        //            (ConstCategories)Enum.Parse(typeof(ConstCategories), task.Category);
        //        int CategoryId = (int)CategoryCode;

        //        Tasks newTask = new()
        //        {
        //            Title = task.Title,
        //            Description = task.Description,
        //            UserId = _userManager.GetUserId(User),
        //            DifficultyId = task.Difficulty,
        //            CategoryId = CategoryId,
        //            CreatedAt = DateTime.Now,
        //            UpdatedAt = DateTime.Now,
        //        };

        //        await _taskRepositories.AddTask(newTask);

        //        Tasks lastTask = await _taskRepositories.GetLatest();

        //        if (task.Images != null)
        //        {
        //            string folderName = "images/tasks";
        //            foreach (var image in task.Images)
        //            {
        //                if (image.Length > 1 * 1024 * 1024)
        //                {
        //                    throw new InvalidOperationException("Image file can not exceed 1 MB");
        //                }
        //                string[] allowedExtensions = [".jpeg", ".jpg", ".png"];
        //                string imageName = await _fileService.SaveFile(image, allowedExtensions, folderName);

        //                TaskImages taskImage = new TaskImages
        //                {
        //                    TaskId = lastTask.Id,
        //                    URL = folderName + "/" + imageName,
        //                };
        //                await _taskImageRepo.AddImage(taskImage);
        //            }
        //        }

        //        TempData["successMessage"] = "Task is added successfully";
        //        return RedirectToAction(nameof(AddTask));

        //    }
        //    catch(Exception ex)
        //    {
        //        TempData["errorMessage"] = ex.Message;
        //        return View(task);
        //    }
        //}

    }
}
