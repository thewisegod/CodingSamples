using ErrorLogger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Http;
using System.Net.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.Results;
using OrderManagementSystem_WebAPI.Repositories.Concrete;
using System.Web.UI;

namespace OrderManagementSystem_WebAPI
{
    public static class Helper
    {
        public static string ErrorLogPath => HostingEnvironment.MapPath("~/Logs/Errors/ErrorLogs.txt");

        public static IHttpActionResult Post<T>(ApiController controller, UnitOfWork uow, GenericRepository<T> repository, T entity, ModelStateDictionary modelState) where T : class
        {
            if (!modelState.IsValid)
            {
                string error = $"Invalid {typeof(T).Name} Data Post Attempt";
                Logger.LogError(ErrorLogPath, error);
                return new BadRequestErrorMessageResult(error, controller);
            }

            try
            {
                repository.Insert(entity);
                uow.Complete();
            }
            catch (Exception ex)
            {
                Logger.LogError(Helper.ErrorLogPath, ex.ToString());
                return new BadRequestErrorMessageResult(ex.Message, controller);
            }

            return new OkResult(controller);
        }

        public static IHttpActionResult Put<T>(ApiController controller, UnitOfWork uow, GenericRepository<T> repository, T entity, ModelStateDictionary modelState) where T : class
        {
            if (!modelState.IsValid)
            {
                string error = $"Invalid {typeof(T).Name} Data Put Attempt";
                Logger.LogError(ErrorLogPath, error);
                return new BadRequestErrorMessageResult(error, controller);
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
                    Logger.LogError(Helper.ErrorLogPath, $"{typeof(T).Name} Not Found");
                    return new NotFoundResult(controller);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(Helper.ErrorLogPath, ex.ToString());
                return new BadRequestErrorMessageResult(ex.Message, controller);
            }

            return new OkResult(controller);
        }

        public static IHttpActionResult Delete<T>(ApiController controller, UnitOfWork uow, GenericRepository<T> repository, int id, ModelStateDictionary modelState) where T : class
        {
            if (!modelState.IsValid)
            {
                string error = $"Invalid {typeof(T).Name} Data Delete Attempt";
                Logger.LogError(Helper.ErrorLogPath, error);
                return new BadRequestErrorMessageResult(error, controller);
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
                    Logger.LogError(Helper.ErrorLogPath, $"{typeof(T).Name} Not Found");
                    return new NotFoundResult(controller);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(Helper.ErrorLogPath, ex.ToString());
                return new BadRequestErrorMessageResult(ex.Message, controller);
            }

            return new OkResult(controller);
        }
    }
}