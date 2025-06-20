using DynamicTimeTable.Models;
using Microsoft.AspNetCore.Mvc;

namespace DynamicTimeTable.Controllers
{
    public class TimeTableController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}
        private static InputModel _inputModel;
        private static List<SubjectHourModel> _subjects;

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            await Task.Yield(); // simulate async (for consistency)
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EnterSubjects(InputModel model)
        {
            if (!ModelState.IsValid)
                return View("Index", model);

            _inputModel = model;
            ViewBag.TotalHours = _inputModel.TotalHours;

            // Simulate async (future DB/API)
            var subjectModels = await Task.Run(() =>
            {
                var list = new List<SubjectHourModel>();
                for (int i = 0; i < model.TotalSubjects; i++)
                {
                    list.Add(new SubjectHourModel { SubjectName = $"Subject {i + 1}" });
                }
                return list;
            });

            return View("EnterSubjectHours", subjectModels);
        }

        [HttpPost]
        public async Task<IActionResult> GenerateTimeTable(List<SubjectHourModel> subjects)
        {
            if (subjects.Sum(s => s.Hours) != _inputModel.TotalHours)
            {
                ViewBag.TotalHours = _inputModel.TotalHours;
                ModelState.AddModelError("", $"Total hours must be {_inputModel.TotalHours}");
                return View("EnterSubjectHours", subjects);
            }

            _subjects = subjects;

            var table = await Task.Run(() =>
                GenerateTable(_inputModel.WorkingDays, _inputModel.SubjectsPerDay, subjects)
            );

            ViewBag.WorkingDays = _inputModel.WorkingDays;
            ViewBag.SubjectsPerDay = _inputModel.SubjectsPerDay;
            return View("Result", table);
        }

        private string[,] GenerateTable(int days, int periods, List<SubjectHourModel> subjects)
        {
            var slots = new List<string>();
            foreach (var subject in subjects)
            {
                for (int i = 0; i < subject.Hours; i++)
                    slots.Add(subject.SubjectName);
            }

            var rnd = new Random();
            slots = slots.OrderBy(_ => rnd.Next()).ToList();

            string[,] grid = new string[periods, days];
            int index = 0;

            for (int r = 0; r < periods; r++)
                for (int c = 0; c < days; c++)
                    grid[r, c] = slots[index++];

            return grid;
        }
    }
}
