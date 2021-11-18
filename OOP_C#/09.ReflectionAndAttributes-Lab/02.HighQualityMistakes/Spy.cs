using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string AnalyzeAccessModifiers(string className)
        {
            Type investigatedClass = Type.GetType(className);
            FieldInfo[] classFields = investigatedClass.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance);
            MethodInfo[] methodPublicInfo = investigatedClass.GetMethods(BindingFlags.Public | BindingFlags.Instance);
            MethodInfo[] methodNonPublicInfo = investigatedClass.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);
            StringBuilder sb = new StringBuilder();
            foreach (var item in classFields)
            {
                sb.AppendLine($"{item.Name} must be private!");
            }
            foreach (var item in methodNonPublicInfo.Where(m => m.Name.StartsWith("get")))
            {
                sb.AppendLine($"{item.Name} have to be public!");
            }
            foreach (var item in methodPublicInfo.Where(m => m.Name.StartsWith("set")))
            {
                sb.AppendLine($"{item.Name} have to be private!");
            }
            return sb.ToString().Trim();

        }
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
