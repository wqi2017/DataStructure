using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearTable
{
    //设置一个队列的，元素为三元组，位置和回退下标

    public struct sqtype
    {
        public int x, y, pre;
    }

    //设置坐标增量表
    struct moved
    {
        public int x, y;
    }
    class CMaze
    {
        private int rows, cols;
        private int[,] elems;
        private CQueue<sqtype> sq;
        static moved[] move = new moved[8];
        public int Rows
        {
            get { return rows; }
            set { rows = value; }
        }
        public int Cols
        {
            get { return cols; }
            set { cols = value; }
        }

        public int GetIntData(string strdata, int k, out int outk)
        {
            int len = strdata.Length;
            int ks = k, data;
            string str;
            while ((ks < len) && ((strdata[ks] < '0') || (strdata[ks] > '9')))
                ks++;
            str = "";
            while ((ks < len) && ((strdata[ks] >= '0') && (strdata[ks] <= '9')))
                str = str + strdata[ks++];
            if (str != "")
                data = Convert.ToInt32(str);
            else
                data = 0;
            outk = ks;
            return (data);
        }
        public CMaze(string strmazedata)
        {
            int i,j,dd,know;
            know = 0;
            if (strmazedata == "")
            {   rows = cols = 0;   return;  }
            rows = GetIntData(strmazedata, know, out know);
            cols = GetIntData(strmazedata, know, out know);
            elems = new int[(rows + 2) , (cols + 2)];
            for(i=0;i<rows+2;i++)
            {
                for (j=0;j<cols+2;j++)
                {
                    if (i == 0 || i == rows + 1 || j == 0 || j == cols + 1)
                    {
                        elems[i, j] = 1;
                    }
                    else
                    {
                        elems[i, j] = GetIntData(strmazedata, know,out know);
                    }
                }
            }
        }
        
        public int Getelems(int row,int col)
        {
            return elems[row, col];
        }
        
        private void Setelems(int row,int col,int num)
        {
            elems[row,col]=num;
        }
        public string ShortPath()//最短路径
        {            
            move[0].x=0;move[0].y=+1;
            move[1].x=+1;move[1].y=+1;
            move[2].x=+1;move[2].y=0;
            move[3].x=+1;move[3].y=-1;
            move[4].x=0;move[4].y=-1;
            move[5].x=-1;move[5].y=-1;
            move[6].x=-1;move[6].y=0;
            move[7].x=-1;move[7].y=+1;//初始化位置坐标增量
            sq=new CQueue<sqtype>();//创建队列
            if(rows==0||cols==0) 
	            return "";
            sqtype temp=new sqtype();
            temp.x=temp.y=1;temp.pre=0;sq.In(temp); Setelems(1, 1, -1);//起点进队         
            while(!sq.IsEmpty())//队不空时循环
            {
                temp=sq.Getfront();int x=temp.x;int y=temp.y;//取队头
	            for(int k=0;k<8;k++)//查找八个方向
	            {
                        int i = x + move[k].x;int j = y + move[k].y;
                        if (Getelems(i, j) == 0)//路通
	                    {  
                            temp.x = i; 
                            temp.y = j; 
                            temp.pre = sq.Front() + 1;//前一个结点
                            sq.In(temp);//进队
                            Setelems(i, j,-1);//走过的设置为-1

                        }
                        if (i == rows && j == cols)
                        {
                            
                            int j1 = sq.Rear();
                            int len = 0;
                            for (int i1 = sq.Rear(); i1 >= 1; i1--)
                            {
                                temp = sq.Getdata(i1);
                                if (i1 == j1)
                                {
                                    Setelems(temp.x, temp.y, -1);
                                    j1 = temp.pre;
                                    len++;
                                }
                                else
                                    Setelems(temp.x, temp.y, 0);
                            }
                            return PrintMazeQueue();

                        }
                }
                sq.Out();//出队
        }
        return  "";
        }

        public string PrintMazeQueue()
        {
            int n = sq.Rear();
            int m_pre, m_x, m_y;
            string m_strout = "";
            m_strout += "┏━━┳━━┯━━┯━━┓\r\n";
            m_strout += "┃序号┃Pre │ ｘ │ ｙ ┃\r\n";
            m_strout += "┣━━╋━━┿━━┿━━┫\r\n";
            for (int i = n; i >= 1; i--)
            {
                m_pre = sq.Getdata(i).pre;
                m_x = sq.Getdata(i).x;
                m_y = sq.Getdata(i).y;
                m_strout += string.Format("┃ {0:d2} ┃ {1:d2} │ {2:d2} │ {3:d2} ┃\r\n",
                                                                                                      i, m_pre, m_x, m_y);
                if (i > 1) m_strout += "┣━━╋━━┿━━┿━━┫\r\n";
                else m_strout += "┗━━┻━━┷━━┷━━┛\r\n";
            }
            return m_strout;
        }


    }
}
