using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearTable
{
    class SingleListNodeClass<Type>//节点类
    {
        private Type data;
        private SingleListNodeClass<Type> next;
        public SingleListNodeClass()//构造函数
        {
	    next = null; 
        }

        public SingleListNodeClass(Type data)//构造函数
        {
                this.data=data;  next = null; 
        }

        public SingleListNodeClass(Type data, SingleListNodeClass<Type> next)//构造函数
        {
            this.data = data; this.next = next;
        }

        public Type Data//属性
        {
            get
            {
                return data;
            }
            set
            {
                data = value;
            }
        }

        public SingleListNodeClass<Type> Next
        {
            get
            {
                return next;
            }
            set
            {
                next = value;
            }
        }
    }

    class SingleListClass<Type>//单链表类
    {
        private SingleListNodeClass<Type> head;//头结点的引用
        private SingleListNodeClass<Type> current;//当前结点的引用

        public SingleListClass()//构造函数，空表，只有头结点
        {
            head = new SingleListNodeClass<Type>();
            current = head;//只是一个引用，不是一个对象实体
        }

        public SingleListNodeClass<Type> Currrent
        {
            get
            {
                return current;
            }
            set
            {
                current = value;
            }
        }

        public SingleListNodeClass<Type> Head
        {
            get
            {
                return head;
            }
        }
        public SingleListNodeClass<Type> Rear
        {
            get
            {
                SingleListNodeClass<Type> p = head;
                while (p.Next != null)
                    p = p.Next;
                return p;
            }
        }

        public int Length//单链表长度
        {
            get
            {
                SingleListNodeClass<Type> p = head.Next;
                int count = 0;
                while (p != null)
                {
                    p = p.Next;
                    count++;
                }
                return count;
            }
        }

        public void MakeEmpty()//清空单链表
        {
            head.Next = null;
            current = head;
        }

        public Type FirstNode()//设置头结点为当前结点
        {
            current = head;
            return current.Data;
        }

        public Type NextNode()//设置下一结点为当前结点
        {
            if (current.Next != null)
                current = current.Next;
            return current.Data;
        }

        public void InsertHead(Type value)//头插法插入结点
        {
            head.Next = new SingleListNodeClass<Type>(value, head.Next);
            current = head.Next;
        }

        public void AppendRear(Type value)//尾插法插入结点
        {
            current = new SingleListNodeClass<Type>(value, null);
            this.Rear.Next = current;

        }

        public void CreateHead(Type[] dt, int n)//头插法生成n个结点
        {
            MakeEmpty();
            for (int i = 1; i <= n; i++)
                head.Next = new SingleListNodeClass<Type>(dt[i - 1], head.Next);
            current = head.Next;
        }

        public void CreateRear(Type[] dt, int n)//尾插法生成n个结点
        {
            MakeEmpty();
            for (int i = 1; i <= n; i++)
            {
                current.Next = new SingleListNodeClass<Type>(dt[i - 1], null);
                current = current.Next;
            }
        }

        public void Insert(Type value, bool before)
        {
            if (current == head)
                before = false;
            if (before)
            {
                SingleListNodeClass<Type> p = head;
                while (p.Next != current)
                    p = p.Next;
                p.Next = new SingleListNodeClass<Type>(value, p.Next);
                current = p.Next;
            }
            else
            {
                current.Next = new SingleListNodeClass<Type>(value, current.Next);
                current = current.Next;
            }
        }

        public void Delete()//删除当前结点
        {
            if (current == head)
                return;
            SingleListNodeClass<Type> p = head;
            while (p.Next != current)
                p = p.Next;
            p.Next = current.Next;
            if (p.Next != null)
                current = p.Next;
            else
                current = p;
        }
        public void DeleteNode(SingleListNodeClass<Type> p1)
        {
            if (p1 == head)
                return;
            SingleListNodeClass<Type> p = head;
            while (p.Next != p1)
                p = p.Next;
            p.Next = p1.Next;
            if (p.Next != null)
                current = p.Next;
            else
                current = p;
        }

        public void Update(SingleListNodeClass<Type> t)//修改节点
        {
            current.Data = t.Data;
        }
        public void convers()
        {
            SingleListNodeClass<Type> p, q;
            p = head.Next;
            head.Next = null;
            while (p != null)
            {
                q = p;
                p = p.Next;
                q.Next = head.Next;
                head.Next = q;
            }
        }

     
    }


}
