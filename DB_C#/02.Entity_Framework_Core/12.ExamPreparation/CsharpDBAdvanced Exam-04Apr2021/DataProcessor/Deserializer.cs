namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using TeisterMask.Data.Models;
    using TeisterMask.Data.Models.Enums;
    using TeisterMask.DataProcessor.ImportDto;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            XmlSerializer serializer =
                new XmlSerializer(typeof(ImportProjectsXmlDto[]), new XmlRootAttribute("Projects"));
            using StringReader reader = new StringReader(xmlString);
            StringBuilder sb = new StringBuilder();

            var projects = (ImportProjectsXmlDto[])serializer.Deserialize(reader);
            List<Project> validProjects = new List<Project>();

            foreach (var p in projects)
            {
                if (!IsValid(p))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool validOpenDate =
                    DateTime.TryParseExact(p.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime pOpenDate);

                bool validDueDate =
                    DateTime.TryParseExact(p.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime pDueDate);
                if (!validOpenDate)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Project project = new Project()
                {
                    Name = p.Name,
                    OpenDate = pOpenDate,


                };
                if (p.DueDate == "" || p.DueDate == null)
                {
                    project.DueDate = null;
                }
                else
                {
                    project.DueDate = pDueDate;
                }
                List<Task> validTasks = new List<Task>();
                foreach (var t in p.Tasks)
                {
                    if (!IsValid(t))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    bool validTaskOpenDate =
                    DateTime.TryParseExact(t.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime tOpenDate);

                    bool validTaskDueDate =
                        DateTime.TryParseExact(t.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime tDueDate);

                    if (!validTaskOpenDate || !validTaskDueDate || tOpenDate < pOpenDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    if (project.DueDate != null && tDueDate > project.DueDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;

                    }

                    bool validExecType = Enum.TryParse(t.ExecutionType, out ExecutionType execType);
                    bool validLabelType = Enum.TryParse(t.LabelType, out LabelType labelType);
                    if (!validExecType || !validLabelType)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Task task = new Task()
                    {
                        Name = t.Name,
                        OpenDate = tOpenDate,
                        DueDate = tDueDate,
                        ExecutionType = execType,
                        LabelType = labelType
                    };
                    validTasks.Add(task);
                }

                project.Tasks = validTasks;
                validProjects.Add(project);
                sb.AppendLine(String.Format(SuccessfullyImportedProject, project.Name, project.Tasks.Count));
            }
            context.Projects.AddRange(validProjects);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            ImportEmployeeJsonDto[] employees = JsonConvert.DeserializeObject<ImportEmployeeJsonDto[]>(jsonString);

            List<Employee> validEmployees = new List<Employee>();
            StringBuilder sb = new StringBuilder();
            List<int> validTasksIdDataBase = context.Tasks.Select(t => t.Id).ToList();
            foreach (var e in employees)
            {
                if (!IsValid(e))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                List<int> validTasks = new List<int>();

                foreach (var t in e.Tasks.Distinct())
                {
                    if (!validTasksIdDataBase.Contains(t))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    validTasks.Add(t);
                }
                Employee employee = new Employee()
                {
                    Username = e.UserName,
                    Email = e.Email,
                    Phone = e.Phone
                };
                List<EmployeeTask> tasks = new List<EmployeeTask>();
                foreach (var tsk in validTasks)
                {
                    EmployeeTask task = new EmployeeTask()
                    {
                        TaskId = tsk
                    };
                    tasks.Add(task);
                }
                employee.EmployeesTasks = tasks;
                validEmployees.Add(employee);
                sb.AppendLine(String.Format(SuccessfullyImportedEmployee, employee.Username, employee.EmployeesTasks.Count));

            }
            context.Employees.AddRange(validEmployees);
            context.SaveChanges();

            return sb.ToString().TrimEnd();

        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}