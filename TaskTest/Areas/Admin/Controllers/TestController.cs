using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskTest.Constants;

namespace TaskTest.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = nameof(Roles.Admin))]
    public class TestController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly ITaskRepository _taskRepository;
        private readonly ITestRepository _testRepository;
        private readonly IProgrammingLanguagesRepository _programmingLanguagesRepository;
        public TestController(ITaskRepository taskRepository, ITestRepository testRepository,
            IProgrammingLanguagesRepository programmingLanguagesRepository, UserManager<User> userManager)
        {
            _taskRepository = taskRepository;
            _testRepository = testRepository;
            _programmingLanguagesRepository = programmingLanguagesRepository;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> AddTest()
        {
            AddTestDTO model = new AddTestDTO();
            model.Tasks = await _taskRepository.GetNameOfTasks();
            model.ProgrammingLanguages = await _programmingLanguagesRepository.GetProgrammingLanguages();
            //model.Test[0] = new AddedTestDTO();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddTest(AddTestDTO data)
        {

            data.Tasks = await _taskRepository.GetNameOfTasks();
            data.ProgrammingLanguages = await _programmingLanguagesRepository.GetProgrammingLanguages();
            if (!ModelState.IsValid)
                return View(data);

            try
            {
                List<Tests> insertData = new List<Tests>();

                foreach (var test in data.Test)
                {
                    ConstProgrammingLanguages languageCode =
                    (ConstProgrammingLanguages)Enum.Parse(typeof(ConstProgrammingLanguages), test.LanguageCode);
                    int LanguageId = (int)languageCode;
                    insertData.Add(
                        new Tests
                        {
                            Parameter = test.Parameter,
                            Result = test.Result,
                            TaskId = data.TaskId,
                            UserId = _userManager.GetUserId(User),
                            LanguageId = LanguageId,
                            CreatedAt = DateTime.Now,
                        }); ;
                }

                await _testRepository.AddTest(insertData);

            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View(data);

            }

            TempData["successMessage"] = "Tests added successfully";
            return View(data);
        }


        public async Task<AddTestDTO> GetAddTestData()
        {
            var tasks = await _taskRepository.GetNameOfTasks();
            var programmingLanguages = await _programmingLanguagesRepository.GetProgrammingLanguages();
            AddTestDTO data = new AddTestDTO();
            data.Tasks = tasks;
            data.ProgrammingLanguages = programmingLanguages;

            return data;
        }


    }
}
