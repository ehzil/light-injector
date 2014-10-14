using LightInjector.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LightInjector.Core
{
    public class ObjectFactory
    {
        private static object lockObj = new object();

        /// <summary>
        /// 获取对象
        /// </summary>
        /// <param name="name"></param>
        public static object GetObject(Type type)
        {
            var name = type.FullName;
            if (!ObjectContainer.Objects.ContainsKey(name))
            {
                lock (lockObj)
                {
                    if (!ObjectContainer.Objects.ContainsKey(name))
                    {
                        FillContainer(ObjectContainer.Objects, type);
                    }
                }
            }
            return ObjectContainer.Objects[name];
        }

        /// <summary>
        /// 填充容器
        /// </summary>
        /// <param name="objects"></param>
        /// <param name="type"></param>
        private static void FillContainer(Dictionary<string, object> objects, Type type)
        {
            if (!type.GetCustomAttributes().Any(c => c.GetType() == typeof(ComponentAttribute)))
            {
                throw new NotSupportedTypeException("Not Supported Type:" + type.FullName + ". Only [ComponentAttribute] marked class is supported.");
            }

            var obj = Activator.CreateInstance(type);

            var fields = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (var f in fields)
            {
                if (f.CustomAttributes.Any(ca => ca.AttributeType == typeof(AutowiredAttribute)))
                {
                    if (objects.ContainsKey(f.FieldType.FullName))
                    {
                        f.SetValue(obj, objects[f.FieldType.FullName]);
                    }
                    else
                    {
                        FillContainer(objects, f.FieldType);
                        if (objects.ContainsKey(f.FieldType.FullName))
                        {
                            f.SetValue(obj, objects[f.FieldType.FullName]);
                        }
                        else
                        {
                            throw new ObjectNotFoundException("Cannot find object:" + f.FieldType.FullName);
                        }
                    }
                }
            }
            objects.Add(type.FullName, obj);
        }
    }
}
