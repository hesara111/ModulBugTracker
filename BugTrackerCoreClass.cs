using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpha
{
    class BugTrackerCoreClass<T>
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
            foreach( var item in Features)
            {
                item.ToString();
            }
        }
        public void ShowBugList()
        {
            foreach (var i in Bugs)
            {
                item.ToString();
            }
        }
        public void ShowTechDebtList()
        { 
             foreach(var i in TechDeb)
            {
                item.ToString();
            }

        }
        public void AddFeature(T feature)
        {

            Features.Add(feature);
        }
        public void AddBug(T bug)
        {
            Bugs.Add(bug);
        }
        public void AddTechDeb(T td)
        {
            TechDeb.Add(td);
        }
        public void Iteration(int iterationAmount)
        {
            Random rd = new Random();
            for (int i=0;i<iterationAmount;i++)
            {
                 foreach (var item in Features)
                {
                    item.status = "In Progress";
                    if(rd.Next(1, 10)==3)
                    {
                        if (Bugs.Contains(item) == false)
                        {
                            item.TimeOfExecution--;
                            AddBug(item);
                            Features.Remove(item);
                        }
                    }
                    item.TimeOfExecution--;
                    if(item.TimeOfExecution==0)
                    {
                        item.status = "Done";
                        Done.Add(item);
                        Features.Remove(item);
                    }
                }
                foreach (var item in Bugs)
                {
                    item.status = "In Progress";
                    item.TimeOfExecution--;
                    if (item.TimeOfExecution == 0)
                    {
                        item.status = "Done";
                        Done.Add(item);
                        Bugs.Remove(item);
                    }
                }
               
                foreach(var item in TechDeb)
                {
                    item.status = "In Progress";
                    item.TimeOfExecution--;
                    if (item.TimeOfExecution == 0)
                    {
                        item.status = "Done";
                        Done.Add(item);
                        TechDeb.Remove(item);
                    }
                }
            }
        }





    }
}
