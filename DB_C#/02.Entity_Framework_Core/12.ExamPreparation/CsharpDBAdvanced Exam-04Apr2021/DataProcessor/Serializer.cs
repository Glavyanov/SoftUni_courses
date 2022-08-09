namespace TeisterMask.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using TeisterMask.DataProcessor.ExportDto;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportProjectWithTheirTasks(TeisterMaskContext context)
        {
            var projects = context.Projects
                .ToArray()
                .Where(p => p.Tasks.Any())
                .Select(x => new ExportProjectXmlDto()
                {
                    TasksCount = x.Tasks.Count,
                    ProjectName = x.Name,
                    HasEndDate = x.DueDate != null ? "Yes" : "No",
                    Tasks = x.Tasks
                    .Select(t => new ExportTaskXmlDto()
                    {
                        Name = t.Name,
                        Label = t.LabelType.ToString()
                    })
                    .OrderBy(t => t.Name)
                    .ToArray()
                })
                .OrderByDescending(p => p.TasksCount)
                .ThenBy(p => p.ProjectName)
                .ToArray();

            StringBuilder sb = new StringBuilder();
            using StringWriter writer = new StringWriter(sb);
            XmlSerializer serializer = new XmlSerializer(typeof(ExportProjectXmlDto[]), new XmlRootAttribute("Projects"));
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);
            serializer.Serialize(writer, projects, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string ExportMostBusiestEmployees(TeisterMaskContext context, DateTime date)
        {
            var employees = context.Employees
                .Include(et => et.EmployeesTasks)
                .ThenInclude(t => t.Task)
                .ToArray()
                .Where(e => e.EmployeesTasks.Any(t => t.Task.OpenDate >= date))
                .Select(e => new ExportEmployeeJsonDto()
                {
                    Username = e.Username,
                    Tasks = e.EmployeesTasks
                    .Where(t => t.Task.OpenDate >= date)
                    .OrderByDescending(t => t.Task.DueDate)
                    .ThenBy(t => t.Task.Name)
                    .Select(nt => new ExportTaskJsonDto()
                    {
                        TaskName = nt.Task.Name,
                        OpenDate = nt.Task.OpenDate.ToString("d", CultureInfo.InvariantCulture),
                        DueDate = nt.Task.DueDate.ToString("d", CultureInfo.InvariantCulture),
                        LabelType = nt.Task.LabelType.ToString(),
                        ExecutionType = nt.Task.ExecutionType.ToString()
                    })
                    .ToArray()
                })
                .OrderByDescending(t => t.Tasks.Length)
                .ThenBy(t => t.Username)
                .Take(10)
                .ToArray();

            return JsonConvert.SerializeObject(employees, Formatting.Indented);
        }
    }
}