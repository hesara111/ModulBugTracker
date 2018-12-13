using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Text;
using System.Threading.Tasks;

namespace Alpha
{
    class BugTrackerCoreClass <T> where T:Task
                    //where U:Feature,IAssistent
                    //where V:Bug
                    //where X:TechnicalDebt
    {
        public List<Bug> Bugs = new List<Bug>();//список багов
        public List<Feature> Features = new List<Feature>();//список фичь
        public List<TechnicalDebt> TechDeb = new List<TechnicalDebt>();//список техзаметок
        //public List<T> ToDo = new List<T>();//список тасков
        //public List<T> InProgress = new List<T>();//список тасков в процессе обработки
         //public List<T> Done = new List<T>();//список выполненых тасков

        //отображение списков
        public void ShowTaskList()
        {
            bool flag = true;
                foreach (var item in Features)
                {

                    Console.WriteLine($"Number of feature:{item.number},Description{item.description}, Status: {item.status}");
                flag = false;
                }
                foreach (var item in Bugs)
                {

                    Console.WriteLine($"Number of bug:{ item.number},Description{item.description}, Status: {item.status}");
                flag = false;
                }
                foreach (var item in TechDeb)
                {

                    Console.WriteLine($"Number of TechnicalDebt:{ item.number},Description{item.description}, Status: {item.status}");
                flag = false;
                }
            if(flag)
            {
                Console.WriteLine("List is empty");
            }
            Thread.Sleep(2000);
        }
            
        
        public void ShowAlreadyDone()
        {
            Console.Clear();
            Console.WriteLine("-----------------------------------------------------------------------------------------");
            bool flag = true;
            foreach (var item in Features)
            {
                if (item.status == "Done")
                {
                    item.ToString();
                    flag = false;
                }
            }
            foreach (var item in Bugs)
            {
                if (item.status == "Done")
                {
                    item.ToString();
                    flag = false;
                }
            }
            foreach (var item in TechDeb)
            {
                if (item.status == "Done")
                {
                    item.ToString();
                    flag = false;
                }
            }
            if (flag)
            {
                Console.WriteLine("List is empty");
            }
        }
        public void AddFeature(Feature feature)
        {   
            feature.status = "ToDo";

            Features.Add(feature);
        }
        public void AddBug(Bug bug)
        { bug.status = "ToDo";
            Bugs.Add(bug);
        }
        public void AddTechDeb(TechnicalDebt td)
        {
            td.status = "ToDo";
            TechDeb.Add(td);
        }
        public void Iteration(int taskAmount,int execution )
        {
            int featuresAmount=0,bugsAmount=0,techDebAmount=0;
            while (taskAmount != 0)
            {
                if (Features.Count != 0)
                {
                    taskAmount--;
                    featuresAmount++;

                }
                if (Bugs.Count != 0)
                {
                    taskAmount--;
                    bugsAmount++;
                }
                if (TechDeb.Count != 0)
                {
                    taskAmount--;
                    techDebAmount++;
                }
                if(Features.Count==0&&Bugs.Count==0&TechDeb.Count==0)
                {
                    Console.WriteLine("error");
                    break;
                }
            }//распределяем количества тасков
            for(int i=0;i<execution;i++)
            {
                Random rd = new Random();

                foreach (var item in Features.Take(featuresAmount))
                {
                    item.status = "In Progress";
                    item.referance = null;
                    Bug bug = new Bug(item.number, item.description, item.complexity);

                    if (rd.Next(1,(item.complexity*item.priority))==(item.complexity*item.priority))
                    {
                          if(Bugs.Contains(bug)==false)
                          {
                       
                            bug.reference = item;
                            item.referance = bug;
                            Bugs.Add(bug);
                            item.TimeOfExecution--;
                          }//

                    }//высчитывается вероятность появления баги=а
                    else
                    {
                        item.TimeOfExecution--;
                    }
                    if (item.TimeOfExecution == 0 && item.referance.status == "Done" || item.TimeOfExecution == 0 && item.referance == null )
                    {
                        item.status = "Done";
                        
                    }//в случае выполнения операции и выполнения её бага
                
                }//обработка определенного количества фичь
                foreach (var item in Bugs.Take(bugsAmount))
                {
                    item.status = "In Progress";
                    item.TimeOfExecution--;
                    if(item.TimeOfExecution==0)
                    {
                        item.status = "Done";
                        
                    }
                }
                foreach(var item in TechDeb.Take(techDebAmount))
                {
                    item.status = "In Progress";
                    item.TimeOfExecution--;
                    if(item.TimeOfExecution==0)
                    {
                        item.status = "Done";
                        
                    }
                }
            }
        }
        public void MainMenu()
        {
            Console.WriteLine("Hey there!\nWelcome to BugTracker v0.1!");
            Console.WriteLine("Main menu:\n" +
                "1. Add Feature\n" +
                "2. Add Bug\n" +
                "3. Add TechDeb\n" +
                "4. Show Tasklist\n" +
                "5. Show already done tasks\n" +
                "6. Do ITERATION \n"+
                "7. Exit");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch(choice)
            {
                case 1:
                    {
                        Feature feature=new Feature();
                        Console.WriteLine("Enter number:");
                        feature.number = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter description:");
                        feature.description = Console.ReadLine();
                        Console.WriteLine("Enter complexity:");
                        feature.complexity = Convert.ToInt32(Console.ReadLine());
                        
                        AddFeature(feature);
                        Console.WriteLine("Succesfully added!");
                        break;
                    }
                case 2:
                    {
                        Bug bug = new Bug();
                        Console.WriteLine("Enter number:");
                        bug.number = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter description:");
                        bug.description = Console.ReadLine();
                        Console.WriteLine("Enter complexity:");
                        bug.complexity = Convert.ToInt32(Console.ReadLine());
                        
                        AddBug(bug);
                        Console.WriteLine("Succesfully added!");
                        break;
                    }
                case 3:
                    {
                        TechnicalDebt tech = new TechnicalDebt();
                        Console.WriteLine("Enter number:");
                        tech.number = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter description:");
                        tech.description = Console.ReadLine();
                        Console.WriteLine("Enter complexity:");
                        tech.complexity = Convert.ToInt32(Console.ReadLine());
                        AddTechDeb(tech);
                        Console.WriteLine("Succesfully added!");
                        break;
                    }
                case 4:
                    {
                        ShowTaskList();
                        break;
                    }
                case 5:
                    {
                        ShowAlreadyDone();
                        break;
                    }
                case 6:
                    {
                        Console.WriteLine("Amount of task: ");
                        int taskAmount = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Amount of iterations: ");
                        int iterationAmount = Convert.ToInt32(Console.ReadLine());
                        Iteration(taskAmount,iterationAmount);
                        break;
                    }
                default:
                    {
                        Environment.Exit(0);
                        break;
                    }
            }

        }




    }
}
