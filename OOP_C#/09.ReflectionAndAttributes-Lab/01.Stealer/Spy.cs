using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string nameClass, params string[] namesFields)
        {
            StringBuilder sb = new StringBuilder();
            Type investigatedClass = Type.GetType(nameClass);
            FieldInfo[] investigatedFields = investigatedClass.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance | BindingFlags.NonPublic);
            Object classInstance = Activator.CreateInstance(investigatedClass, new object[] { });
            sb.AppendLine($"Class under investigation: {nameClass}");
            foreach (var item in investigatedFields.Where(f => namesFields.Contains(f.Name)))
            {
                sb.AppendLine($"{item.Name} = {item.GetValue(classInstance)}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
