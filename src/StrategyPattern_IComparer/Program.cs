using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern_IComparer
{
    public class Village
    {
        private int mId;
        private string mName;
        private int mPopulation;
        private double mArea;
        public Village(int id, string name, int population, double area)
        {
            this.mId = id;
            this.mName = name;
            this.mPopulation = population;
            this.mArea = area;
        }

        public int ID { get { return mId; } }
        public string Name { get { return mName; } }
        public int Population { get { return mPopulation; } }
        public double Area { get { return mArea; } }

        public override string ToString()
        {
            return $"{mId}.{mName}: (population = {mPopulation:N3}, area = {mArea:N3})";
        }
    }

    public class SortVillageById : IComparer<Village>
    {
        public int Compare(Village o1, Village o2)
        {
            int ret = 0;
            if (o1.ID > o2.ID)
                ret = 1;
            else if (o2.ID > o1.ID)
                ret = -1;

            return ret;
        }
    }

    public class SortVillageByPopulation : IComparer<Village>
    {
        public int Compare(Village o1, Village o2)
        {
            int ret = 0;
            if (o1.Population > o2.Population)
                ret = 1;
            else if (o2.Population > o1.Population)
                ret = -1;

            return ret;
        }
    }

    public class SortVillageByArea : IComparer<Village>
    {
        public int Compare(Village o1, Village o2)
        {
            int ret = 0;
            if (o1.Area > o2.Area)
                ret = 1;
            else if (o2.Area > o1.Area)
                ret = -1;

            return ret;
        }
    }

    public class SortVillageByName : IComparer<Village>
    {
        public int Compare(Village o1, Village o2)
        {
            int ret = 0;
            if (o1.Name[0] > o2.Name[0])
                ret = 1;
            else if (o2.Name[0] > o1.Name[0])
                ret = -1;

            return ret;
        }
    }

    class Program
    {
        static void ShowList(List<Village> list)
        {
            foreach (var v in list)
                Console.WriteLine(v.ToString());
        }
        
        static void Main(string[] args)
        {
            Village appleFarm = new Village(3, "apple farm", 32, 5.1);
            Village barnField = new Village(1, "barn farm", 22, 1.7);
            Village capeValley = new Village(2, "cape valley", 10, 10.2);

            List<Village> villages = new List<Village>();
            villages.Add(appleFarm);
            villages.Add(barnField);
            villages.Add(capeValley);

            Console.WriteLine("Data didn't sorted");
            ShowList(villages);

            Console.WriteLine("\nSorted by ID");
            villages.Sort(new SortVillageById());
            ShowList(villages);

            Console.WriteLine("\nSorted by population");
            villages.Sort(new SortVillageByPopulation());
            ShowList(villages);

            Console.WriteLine("\nSorted by name");
            villages.Sort(new SortVillageByName());
            ShowList(villages);

            Console.WriteLine("\nSorted by area");
            villages.Sort(new SortVillageByArea());
            ShowList(villages);

            Console.ReadLine();
        }
    }
}
