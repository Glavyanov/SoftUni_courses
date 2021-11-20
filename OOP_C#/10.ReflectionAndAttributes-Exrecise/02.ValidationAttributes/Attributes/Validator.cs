using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ValidationAttributes.Attributes
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            PropertyInfo[] properties = obj.GetType().GetProperties();
            foreach (var property in properties)
            {
                var attributes = property.GetCustomAttributes().Where(p => p.GetType().IsSubclassOf(typeof(MyValidationAttribute))).ToArray();
                foreach (MyValidationAttribute attribut in attributes)
                {
                    bool isValid = attribut.IsValid(property.GetValue(obj));
                    if (!isValid)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
