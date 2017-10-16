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

namespace TaskManager.Services.TaskServices
{
    public class TaskService : ITaskService
    {
        private IDbRepository<TaskModel> taskRepo;
        private IPrincipal identity;
        private ISaveContext saveContext;

        public TaskService(IDbRepository<TaskModel> taskRepo, IPrincipal identity
            ,ISaveContext saveContext)
        {
            Guard.WhenArgument(taskRepo, "dbRepository").IsNull().Throw();
            Guard.WhenArgument(identity, "principal").IsNull().Throw();
            Guard.WhenArgument(saveContext, "saveContext").IsNull().Throw();

            this.taskRepo = taskRepo;
            this.identity = identity;
            this.saveContext = saveContext; 
        }

        public List<TaskModel> GetAll()
        {
            return this.taskRepo.All().Where(m => m.Username.ToLower() ==
            this.identity.Identity.Name.ToLower()).ToList();
        }

        public void AddTask(TaskModel model)
        {
            model.Username = this.identity.Identity.Name;
           
            this.taskRepo.Add(model);
            this.saveContext.Commit();
        }

        public string GetUsername()
        {
            return this.identity.Identity.Name;
        }
    }
}
