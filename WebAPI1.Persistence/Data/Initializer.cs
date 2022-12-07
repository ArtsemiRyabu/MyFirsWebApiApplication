using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using WebAPI1.Domain.Models;

namespace WebAPI1.Persistence.Data
{
    public static class Initializer
    {
        public static void Initialize(Context context)
        {
            //context.Database.EnsureCreated();
            if(context.ComputerOrders.Any())
            {
                return;
            }
            List<string> Name = new List<string>{"Артемий", "Александр", "Николай", "Игорь", "Денис"};
            List<string> Surname = new List<string>{"Рябый", "Поминдеев", "Ялченко", "Шух", "Михайловский"};
            List<string> Job = new List<string>{"Помощник", "Старший работник", "Младший работник", "Начальник"};
            List<string> TypeComponentName = new List<string>{"Видеокарта", "Процессор", "ОЗУ", "Кулер", "Материнская плата", "Корпус"};
            List<string> Country = new List<string>{"Япония", "США", "Германия", "Россия", "Франция", "Китай"};
            List<string> Firm = new List<string>{"Intel", "Nvidia", "AMD", "Эльбрус", "MTK", "Qualcomm"};

            for (int id = 1; id <= 100; id++)
            {
                string typeComponent = TypeComponentName[new Random().Next(TypeComponentName.Count - 1)];
                string description = "описание" + new Random().Next(100).ToString();
                context.TypeComponents.Add(new TypeComponent { Name = typeComponent, Description = description });
            }
            context.SaveChanges();
            for (int id = 1; id <= 100; id++)
            {
                string name = Name[new Random().Next(Name.Count - 1)] + " " + Surname[new Random().Next(Name.Count - 1)];
                string job = Job[new Random().Next(Name.Count - 1)];
                context.Employees.Add(new Employee { Name = name, JobTitle = job });
            }
            context.SaveChanges();
            for (int id = 1; id <= 100; id++)
            {
                string name = Name[new Random().Next(Name.Count - 1)] + " " + Surname[new Random().Next(Name.Count - 1)];
                string address = "адрес" + new Random().Next(100).ToString();
                string phone = "телефон" + new Random().Next(100).ToString();
                int sale = new Random().Next(40);
                context.Customers.Add(new Customer { Name = name, Address = address, Phone = phone, Sale = sale });
            }
            context.SaveChanges();
            
            for (int id = 1; id <= 100; id++)
            {
                string mark = new Random().Next(100).ToString();
                string firm = Firm[new Random().Next(Name.Count - 1 )];
                string country = Country[new Random().Next(Name.Count - 1)];
                DateTime dateComponent = DateTime.Now.AddDays(new Random().Next(1000));
                string guaranteePeriod = new Random().Next(3).ToString();
                string description = "описание" + new Random().Next(100).ToString();
                string charcterist = "характеристика" + new Random().Next(100).ToString();
                int cost = new Random().Next(500);
                int typeComponent = new Random().Next(1, 100);
                context.Components.Add(new Component { Mark = mark, Firm = firm, Country = country, DateComponent = dateComponent, GuaranteePeriod = guaranteePeriod, Description = description, Cost = cost, TypeComponentId = typeComponent, Charcterist = charcterist });
            }
            for (int id = 1; id <= 100; id++)
            {
                string name = "сервис" + new Random().Next(100).ToString();
                int cost = new Random().Next(100);
                context.ComputerServices.Add(new ComputerService { Name = name, Cost = cost });
            }
            for (int id = 1; id <= 100; id++)
            {
                DateTime orderDate = DateTime.Now.AddDays(new Random().Next(1000));
                DateTime executionDate = DateTime.Now.AddDays(new Random().Next(1000));
                int customer = new Random().Next(1, 100);
                int prepayment = new Random().Next(200);
                string workMark = "рабочая марка" + new Random().Next(100).ToString();
                int cost = new Random().Next(500);
                string guaranteePeriod = new Random().Next(3).ToString();
                int employee = new Random().Next(1, 100);
                context.ComputerOrders.Add(new ComputerOrder { OrderDate = orderDate, ExecutionDate = executionDate, CustomerId = customer, Prepayment = prepayment, Workmark = workMark, AllCost = cost, GuaranteePeriod = guaranteePeriod, EmployeeId = employee });
            }
            context.SaveChanges();

            for (int id = 1; id <= 100; id++)
            {
                int computerOrder = new Random().Next(1, 100);
                int component = new Random().Next(1, 100);
                context.ComponentsLists.Add(new ComponentsList { ComponentId = component, ComputerOrderId = computerOrder });
            }
            for (int id = 1; id <= 100; id++)
            {
                int computerOrder = new Random().Next(1, 100);
                int service = new Random().Next(1, 100);
                context.ServicesLists.Add(new ServicesList { ComputerServiceId = service, ComputerOrderId = computerOrder });
            }
            context.SaveChanges();
        }
    }
}
