using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DotVVM.Framework.ViewModel;
using DotVVM.Framework.Runtime.Filters;

namespace DotVVM.Samples.BasicSamples.ViewModels
{
    public class Sample11ViewModel : DotvvmViewModelBase 
    {
        
        [Required]
        [EmailAddress]
        public string NewTaskTitle { get; set; }

        public List<TaskViewModel> Tasks { get; set; }

        public Sample11ViewModel()
        {
            Tasks = new List<TaskViewModel>();
        }

        public override Task Init()
        {
            if (!Context.IsPostBack)
            {
                Tasks.Add(new TaskViewModel() { IsCompleted = false, TaskId = Guid.NewGuid(), Title = "Do the laundry" });
                Tasks.Add(new TaskViewModel() { IsCompleted = true, TaskId = Guid.NewGuid(), Title = "Wash the car" });
                Tasks.Add(new TaskViewModel() { IsCompleted = true, TaskId = Guid.NewGuid(), Title = "Go shopping" });
            }
            return base.Init();
        }
        
        public void AddTask()
        {
            Tasks.Add(new TaskViewModel() 
            { 
                Title = NewTaskTitle, 
                TaskId = Guid.NewGuid() 
            });
            NewTaskTitle = string.Empty;
        }

        //[ModelValidationFilter("CompleteTask")]
        public void CompleteTask(Guid id)
        {
            Tasks.Single(t => t.TaskId == id).IsCompleted = true;
        }

        public class TaskViewModel
        {

            public Guid TaskId { get; set; }

            [RegularExpression("^[^_]", ErrorMessage = "Task starting with underscore is incompletible")]
            [ValidationSettings(OnlyInTarget = true, OnlyInGroups = new[] { "CompleteTask" })]
            public string Title { get; set; }

            public bool IsCompleted { get; set; }
        }
    }
}