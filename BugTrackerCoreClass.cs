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

        }
        public void ShowBugList()
        {

        }
        public void ShowTechDebtList()
        {

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
            for(int i=0;i<iterationAmount;i++)
            {
                foreach(var item in Bugs)
                {

                }
                foreach(var item in Features)
                {

                }
                foreach(var item in TechDeb)
                {

                }
            }
        }





    }
}
