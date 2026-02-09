using System;
using System.Collections.Generic;
using Clinical_Trial_Task_Manager.Domain.Entities;
using Clinical_Trial_Task_Manager.Domain.Enums;

namespace Clinical_Trial_Task_Manager.ViewModels
{
    public class DashboardViewModel
    {
        public int TotalStudies { get; set; }
        public int TotalPatients { get; set; }
        public int TotalTasks { get; set; }

        public int OverdueTasksCount { get; set; }
        public int Next7DaysTasksCount { get; set; }

        public Dictionary<Clinical_Trial_Task_Manager.Domain.Enums.TaskStatus, int> TasksByStatus { get; set; } = new();
        public Dictionary<TaskPriority, int> TasksByPriority { get; set; } = new();

        public List<TaskItem> OverdueTasks { get; set; } = new();
        public List<TaskItem> Next7DaysTasks { get; set; } = new();
    }
}
