using Bytes2you.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Data.Common.Context.Save.Contracts;
using TaskManager.Data.Common.Repositories.Contracts;
using TaskManager.Models;
using TaskManager.Services.TaskServices.Contracts;
using TaskManager.Services.UserServices.Contracts;

namespace TaskManager.Services.TaskServices
{
    public class TaskService : ITaskService
    {
        private IDbRepository<TaskModel> taskRepo;
        private IUserService service;
        private IPrincipal identity;
        private ISaveContext saveContext;

        public TaskService(IDbRepository<TaskModel> taskRepo, IPrincipal identity
            ,ISaveContext saveContext, IUserService service)
        {
            Guard.WhenArgument(taskRepo, "dbRepository").IsNull().Throw();
            Guard.WhenArgument(identity, "principal").IsNull().Throw();
            Guard.WhenArgument(saveContext, "saveContext").IsNull().Throw();
            Guard.WhenArgument(service, "userService").IsNull().Throw();

            this.taskRepo = taskRepo;
            this.identity = identity;
            this.saveContext = saveContext;
            this.service = service;
        }

        public List<TaskModel> GetAll()
        {
            var user = service.GetUser();
            return user.Tasks.ToList();
        }

        public void AddTask(TaskModel model)
        {
            var user = service.GetUser();
            user.Tasks.Add(model);
            this.saveContext.Commit();
        }

        public string GetUsername()
        {
            return this.identity.Identity.Name;
        }
    }
}
