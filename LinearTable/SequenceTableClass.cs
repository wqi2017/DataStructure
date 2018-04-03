using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearTable
{
    class SequenceTableClass<Type>
    {
        private Type[] data;//顺序表数据
        private int MaxSize;//最大空间
        private int datasize;//实际元素个数
        public SequenceTableClass(int MaxSize)//构造函数
        {
            this.MaxSize = MaxSize;
            data = new Type[MaxSize];
            datasize = 0;
        }

        public SequenceTableClass(int MaxSize, Type[] data, int n)//构造函数
        {
            this.MaxSize = MaxSize;
            this.data = new Type[MaxSize];
            for (int i = 0; i < n; i++)
                this.data[i] = data[i];
            datasize = n;
        }

        public bool Inset(int k, Type dt)//插入函数
        {
            if (k < 1 || k > datasize + 1)
                return false;
            if (datasize == MaxSize)
                return false;
            for (int i = datasize - 1; i >= k - 1; i--)
                data[i + 1] = data[i];
            data[k - 1] = dt;
            datasize++;
            return true;
        }

        public bool Delete(int k)//删除函数
        {
            if (k < 1 || k > datasize)
                return false;
            for (int i = k - 1; i < datasize - 1; i++)
                data[i] = data[i + 1];
            datasize--;
            return true;
        }

        public bool Update(int k, Type dt)//更新数据
        {
            if (k < 1 || k > datasize)
                return false;
            data[k - 1] = dt;
            return true;
        }

        public void MakeEmpty()//置空函数
        {
            MaxSize = 0;
            datasize = 0;
        }

        public int DataSize//返回表长
        {
            get
            {
                return datasize;
            }
        }

        public string MyPrint()//打印顺序表
        {
            string strout = "";
            for (int i = 0; i < MaxSize; i++)
            {
                if (i < datasize)
                    strout += "\t" + (i + 1) + "\t【\t" + data[i] + "\t】\n";
                else strout += "\t" + (i + 1) + "\t【\t\t】\n";
            }
            return strout;
        }
        public Type getData(int k)
        {
            if (k >= 0 && k < datasize)
                return data[k];
            else return data[0];
        }
        public void reverse(int i, int j)
        {
            Type da = data[i];
            data[i] = data[j];
            data[j] = da;
        }
    }
   
}
