using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpha
{
    class BugTrackerCoreClass<T,U,V,X> where T:Task
                    //where U:Feature,IAssistent
                    //where V:Bug
                    //where X:TechnicalDebt
    {
        public List<T> Bugs = new List<T>();//список багов
        public List<T> Features = new List<T>();//список фичь
        public List<T> TechDeb = new List<T>();//список техзаметок
        //public List<T> ToDo = new List<T>();//список тасков
        //public List<T> InProgress = new List<T>();//список тасков в процессе обработки
         public List<T> Done = new List<T>();//список выполненых тасков

        //отображение списков
        public void ShowTaskList()
        {
            
            foreach(var item in Features)
            {
            
                Console.WriteLine($"Number of feature:{0},Description{1}, Status: {2}", item.number,item.description,item.status);
              
            }
            foreach (var item in Bugs)
            {

                Console.WriteLine($"Number of bug:{0},Description{1}, Status: {2}", item.number, item.description, item.status);

            }
            foreach (var item in TechDeb)
            {

                Console.WriteLine($"Number of TechDeb:{0},Description{1}, Status: {2}", item.number, item.description, item.status);

            }
        }
        public void ShowAlreadyDone()
        {
            Console.WriteLine("-----------------------------------------------------------------------------------------");
            foreach(var item in Done)
            {
                Console.WriteLine($"Number of task:{0},Description{1}, Status: {2}", item.number, item.description, item.status);

            }
        }
        public void AddFeature(T feature)
        {   
            feature.status = "ToDo";
            Features.Add(feature);
        }
        public void AddBug(T bug)
        { bug.status = "ToDo";
            Bugs.Add(bug);
        }
        public void AddTechDeb(T td)
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
                    if(rd.Next(1,(item.complexity*item.priority))==(item.complexity*item.priority))
                    {
                          if(Bugs.Contains(item)==false)
                        {
                            item.status = "ToDo";
                            Bugs.Add(item);
                            item.status = "In Progress";
                            
                          }//если фичи нет в багах

                    }//высчитывается вероятность появления баги=а
                    else
                    {
                        item.TimeOfExecution--;
                    }    
                    if(item.TimeOfExecution==0&& Bugs.Contains(item) == false)
                    {
                        item.status = "Done";
                        Done.Add(item);
                        Features.Remove(item);
                        
                    }//в случае выполнения операции и выполнения её бага
                
                }//обработка определенного количества фичь
                foreach (var item in Bugs.Take(bugsAmount))
                {
                    item.status = "In Progress";
                    item.TimeOfExecution--;
                    if(item.TimeOfExecution==0)
                    {
                        item.status = "Done";
                        Done.Add(item);
                        Bugs.Remove(item);
                    }
                }
                foreach(var item in TechDeb.Take(techDebAmount))
                {
                    item.status = "In Progress";
                    item.TimeOfExecution--;
                    if(item.TimeOfExecution==0)
                    {
                        item.status = "Done";
                        Done.Add(item);
                        TechDeb.Remove(item);
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
                "6. Exit\n  ");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch(choice)
            {
                case 1:
                    { Console.WriteLine("Enter number:");
                        int number = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter description:");
                        string describe = Console.ReadLine();
                        Console.WriteLine("Enter complexity:");
                        int complexity = Convert.ToInt32(Console.ReadLine());


                        AddFeature();//хз как создать фичу и добавить её
                        break;
                    }
                
            }

        }




    }
}
