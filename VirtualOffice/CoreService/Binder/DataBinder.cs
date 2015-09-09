using System;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.ModelBinding;
using Domain.Infrastructure.Log;
using Newtonsoft.Json;

namespace CoreService.Binder
{
    public class DataBinder : IModelBinder
    {
        private ILogger _logger;

        public DataBinder()
        {
            _logger = GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(ILogger)) as ILogger;

            if (_logger == null)
            {
                throw new InvalidOperationException("Logger could not be resolved on LoggerActionFilter");
            }
        }

        public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
        {
            string content = actionContext.Request.Content.ReadAsStringAsync().Result;

            _logger.Debug(string.Format("Data Binding To:\n {0}", content));

            content = content.Replace("Data=", "");

            string json = HttpUtility.UrlDecode(content);

            Type modelType = bindingContext.ModelType;

            object data = JsonConvert.DeserializeObject(json, modelType);

            bindingContext.Model = data;

            ValidateModel(actionContext, bindingContext);

            return true;
        }

        private void ValidateModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
        {
            IValidatableObject validable = bindingContext.Model as IValidatableObject;

            if (validable != null)
            {
                var result = validable.Validate(new ValidationContext(validable, null, null));

                foreach (var validationResult in result)
                {
                    actionContext.ModelState.AddModelError("error", validationResult.ErrorMessage);
                }
            }
        }
    }
}