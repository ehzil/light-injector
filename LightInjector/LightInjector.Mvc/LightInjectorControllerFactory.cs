using LightInjector.Annotations;
using LightInjector.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;

namespace LightInjector.Mvc
{
    public class LightInjectorControllerFactory : DefaultControllerFactory
    {
        /// <summary>
        /// 重写controller实例创建方法，注入对象
        /// </summary>
        /// <param name="requestContext"></param>
        /// <param name="controllerName"></param>
        /// <returns></returns>
        public override IController CreateController(RequestContext requestContext, string controllerName)
        {
            var controller = base.CreateController(requestContext, controllerName);

            var fileds = controller.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (var f in fileds)
            {
                if (f.CustomAttributes.Any(ca => ca.AttributeType == typeof(AutowiredAttribute)))
                {
                    f.SetValue(controller, ObjectFactory.GetObject(f.FieldType));
                }
            }

            return controller;
        }
    }
}
