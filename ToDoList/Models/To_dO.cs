using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models
{
   

    public static class To_dO_List
    {
        public static List<TASK> _taskList = null;

        public static List<TASK> taskList
        {
            get
            {
                if (_taskList == null)
                {
                    _taskList = new List<TASK>();

                    TASK task = new TASK();

                    
                    task.Id = 0;
                    task.Title = "Start homework";
                    task.Description = "What is todo list? Which properties";
                    task.Date = Convert.ToDateTime("14/10/2016 9:00:00 AM");
                    task.IsReady = false;

                    TASK task1 = new TASK(){ Id = 1,
                                             Title = "Start cooking",
                                             Description = "Make pasta",
                                             Date = Convert.ToDateTime("14/10/2016 1:00:00 PM"),
                                             IsReady = true
                                           };




                    _taskList.Add(task);
                    _taskList.Add(task1);


                }
                return _taskList;
            }
        }
    }



    public class TASK
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter title...")]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date")]
        [Required(ErrorMessage = "Enter date...")]
        public DateTime Date { get; set; }


        [Display(Name = "Description")]
        [Required(ErrorMessage = "Enter description...")]
        [StringLength(50, MinimumLength = 7, ErrorMessage = "You must enter a 7 to 1000 characters")]
        public string Description { get; set; }

        [Display(Name = "IsReady")]
        public bool IsReady { get; set; }


    }
}