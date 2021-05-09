using ErrorLogger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using OrderManagementSystem_MVC.Repositories.Concrete;
using System.Web.UI;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using OrderManagementSystem_MVC.ViewModels;

namespace OrderManagementSystem_MVC
{
    public static class Helper
    {
        public static string ErrorLogPath => HostingEnvironment.MapPath("~/Logs/Errors/ErrorLogs.txt");

        public static string Post<T>(UnitOfWork uow, GenericRepository<T> repository, T entity, ModelStateDictionary modelState) where T : class
        {
            if (!modelState.IsValid)
            {
                return LogInvalidModelError<T>("Post");
            }

            try
            {
                repository.Insert(entity);
                uow.Complete();
            }
            catch (Exception ex)
            {
                return LogExceptionError(ex);
            }

            return $"Your new {typeof(T).Name} was added successfully";
        }

        public static string Put<T>(UnitOfWork uow, GenericRepository<T> repository, T entity, ModelStateDictionary modelState) where T : class
        {
            if (!modelState.IsValid)
            {
                return LogInvalidModelError<T>("Put");
            }

            try
            {
                var foundEntity = repository.GetByID(int.Parse(entity.GetType().GetProperty("Id").GetValue(entity).ToString()));
                if (foundEntity != null)
                {
                    repository.Update(foundEntity, entity);
                    uow.Complete();
                }
                else
                {
                    return LogNotFoundError<T>();
                }
            }
            catch (Exception ex)
            {
                return LogExceptionError(ex);
            }

            return $"The {typeof(T).Name} was updated successfully";
        }

        public static string Delete<T>(UnitOfWork uow, GenericRepository<T> repository, int id, ModelStateDictionary modelState) where T : class
        {
            if (!modelState.IsValid)
            {
                return LogInvalidModelError<T>("Delete");
            }

            try
            {
                var foundEntity = repository.GetByID(id);
                if (foundEntity != null)
                {
                    repository.Delete(foundEntity);
                    uow.Complete();
                }
                else
                {
                    return LogNotFoundError<T>();
                }
            }
            catch (Exception ex)
            {
                return LogExceptionError(ex);
            }

            return $"The {typeof(T).Name} was deleted successfully";
        }

        public static U CopyModelToViewModel<T, U>(T entity) where T : class where U : new()
        {
            var cvm = new U();
            foreach (var property in entity.GetType().GetProperties())
            {
                cvm.GetType().GetProperty(property.Name).SetValue(cvm, property.GetValue(entity));
            }
            return cvm;
        }

        private static string LogInvalidModelError<T>(string verb) where T : class
        {
            string error = $"Invalid {typeof(T).Name} Data {verb} Attempt";
            Logger.LogError(ErrorLogPath, error);
            return error;
        }

        private static string LogNotFoundError<T>() where T : class
        {
            string error = $"{typeof(T).Name} Not Found";
            Logger.LogError(Helper.ErrorLogPath, error);
            return error;
        }

        private static string LogExceptionError(Exception ex)
        {
            Logger.LogError(Helper.ErrorLogPath, ex.ToString());
            return ex.Message;
        }
    }
}