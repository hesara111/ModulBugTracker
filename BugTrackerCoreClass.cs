using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpha
{
    class BugTrackerCoreClass<T> where T:Task
    {
        public List<T> Bugs = new List<T>();//список багов
        public List<T> Features = new List<T>();//список фичь
        public List<T> TechDeb = new List<T>();//список техзаметок
        //public List<T> ToDo = new List<T>();//список тасков
        //public List<T> InProgress = new List<T>();//список тасков в процессе обработки
         public List<T> Done = new List<T>();//список выполненых тасков

        //отображение списков
        public void ShowFeatureList()
        {

        }
        public void ShowBugList()
        {

        }
        public void ShowTechDebtList()
        {

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
            for(int i=0;i<execution;i++)
            {
                Random rd = new Random();

                foreach (var item in Features.Take(taskAmount))
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
                        
                    }//в случае выполнения операции и выполнения бага
                
                }//обработка фичь
                foreach (var item in Bugs)
                {

                }
                foreach(var item in TechDeb)
                {

                }
            }
        }





    }
}
