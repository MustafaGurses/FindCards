using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameObject
{
    public class ObjectTransaction
    {
        private string Application_StartupPath;
        public ObjectTransaction(string application_StartupPath)
        {
            this.Application_StartupPath = application_StartupPath;
        }
        private Random randFile = new Random();
        private List<int> dosya = new List<int>();
        List<Object> path_ = new List<Object>();
        List<Object> paths = new List<Object>();
        private void ClearList()
        {
            dosya.Clear();
            path_.Clear();
            paths.Clear();
        }
        private List<Object> GetFilePathRandom()
        {
            ClearList();
            for (; ; )
            {
                int rand = randFile.Next(1, 6);
                if (!dosya.Contains(rand))
                {
                    path_.Add(new Object(Application_StartupPath + $@"\resim\{ rand }.png"));
                    dosya.Add(rand);
                }
                if (dosya.Count == 5)
                    break;
            }
            int j = 0;
            for(int i=0; i<5; i++)
            {
                Object object_ = path_[j];
                if (!paths.Contains(object_))
                    paths.Add(object_);
                j++;
            }
            j = 4;
            for (int i = 0; i < 5; i++)
            {
                Object object_ = path_[j];
                if (CountOfNumber(paths,object_.FileName1) <= 2)
                    paths.Add(object_);
                j--;
            }
            return paths;
        }
        private int CountOfNumber(List<Object>ints,string num)
        {
            int j = 0;
            for(int i=0; i < ints.Count; i++)
            {
                if (ints[i].FileName1 == num)
                    j++;
            }
            return j;
        }
        public List<Object> list()
        {
            return this.GetFilePathRandom();
        }
    }
}
