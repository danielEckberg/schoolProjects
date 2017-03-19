using Exercises.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Exercises.Models.Data;
using Exercises.Models.ViewModels;

namespace Exercises.Controllers
{
    public class StudentController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            var model = StudentRepository.GetAll();

            return View(model);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var viewModel = new StudentVM();
                GetStudentVM(viewModel);
            //var viewModel = new StudentVM();
            //viewModel.SetCourseItems(CourseRepository.GetAll());
            //viewModel.SetMajorItems(MajorRepository.GetAll());
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Add(StudentVM studentVM)
        {
            
                studentVM.Student.Courses = new List<Course>();

                foreach (var id in studentVM.SelectedCourseIds)
                    studentVM.Student.Courses.Add(CourseRepository.Get(id));

                studentVM.Student.Major = MajorRepository.Get(studentVM.Student.Major.MajorId);
            if (studentVM.Student.Courses.Count == 0)
            {
                ModelState.AddModelError("SelectedCourseIds", "Please choose at least one course.");
            }
            
                if (ModelState.IsValid)
                {
                StudentRepository.Add(studentVM.Student);
                return RedirectToAction("List");
                }
                
                    studentVM = GetStudentVM(studentVM);
                return View(studentVM);
            
            

        }

        [HttpGet]
        public ActionResult EditStudent(int id)
        {
            var student = StudentRepository.Get(id);
            

            var model = new StudentVM();
            model.SetCourseItems(CourseRepository.GetAll());
            model.SetMajorItems(MajorRepository.GetAll());
            model.SetStateItems(StateRepository.GetAll());

            
            model.Student.FirstName = student.FirstName;
            model.Student.LastName = student.LastName;
            model.Student.Major = student.Major;
            model.Student.GPA = student.GPA;
            model.Student.Courses = student.Courses.ToList();
            model.Student.Address = student.Address;
            model.Student.StudentId = student.StudentId;
            foreach (var studentCourse in student.Courses)
            {
                model.SelectedCourseIds.Add(studentCourse.CourseId);
            }

            

            return View(model);

            }

        [HttpPost]
        public ActionResult EditStudent(StudentVM model)
        {
            if (ModelState.IsValid)
            {
                Student student = new Student();
                student.StudentId = model.Student.StudentId;
                student.FirstName = model.Student.FirstName;
                student.LastName = model.Student.LastName;
                student.Major = MajorRepository.Get(model.Student.Major.MajorId);
                student.GPA = model.Student.GPA;
                //student.Courses = model.Student.Courses;
                student.Address = model.Student.Address;
                student.Address.State = StateRepository.Get(model.Student.Address.State.StateAbbreviation);

                foreach (var id in model.SelectedCourseIds)
                {
                    student.Courses.Add(CourseRepository.Get(id));
                }

                StudentRepository.Edit(student);

                return RedirectToAction("List");
            }
            else
            {
                model = GetStudentVM(model);
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult DeleteStudent(int id)
        {
            var student = StudentRepository.Get(id);
            return View(student);
        }

        [HttpPost]
        public ActionResult DeleteStudent(Student student)
        {
            StudentRepository.Delete(student.StudentId);
            return RedirectToAction("List");
        }

        private StudentVM GetStudentVM(StudentVM model)
        {
            var viewModel = model;
            viewModel.SetCourseItems(CourseRepository.GetAll());
            viewModel.SetMajorItems(MajorRepository.GetAll());
            return viewModel;
        }

    }
}