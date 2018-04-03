using System;
using System.Collections.Generic;
using System.Text;


namespace LinearTable
{
    class Calculator
    {
        private int Maxsize;
        private CSeqStack<Rational> data;//操作数栈
        private CSeqStack<char> oper;//操作符栈
		private CSeqStack<int>  degree;  //操作符优先级栈
		private void AddOperand(Rational value)
        { 
	        data.Push(value); 
        }
        private bool Get2Operands(out Rational left,out Rational right)
        {
            left = right = new Rational();
            if (data.IsEmpty())
                return (false);
            right=data.Pop();
            if (data.IsEmpty())
                return (false);
            left=data.Pop();
            return (true);
        }
        private void DoOperator(char op)
        {
            Rational left, right, ling = new Rational();
            if (Get2Operands(out left, out right))
            {
                switch (op)
                {
                    case '+': { data.Push(left + right); break; }
                    case '-': { data.Push(left - right); break; }
                    case '*': { data.Push(left * right); break; }
                    case '/': { data.Push(left / right); break; }
                    case '^': { data.Push(left ^ Convert.ToInt16(right.Num/right.Den)); break; }
                }
            }
            else data.MakeEmpty();
        }
        public Calculator(int sz)
        {
            Maxsize = sz;
            data = new CSeqStack<Rational>(Maxsize);
            oper = new CSeqStack<char>(Maxsize);
            degree = new CSeqStack<int>(Maxsize);
        }
		public void Clear()
        { 
	        data.MakeEmpty();
        }
    ///////////////////////////////////////////////////////////
        public Rational Run(string pc,out string strout)
        {
            int de=0;//输入字符的优先级
            char c;//输入的字符
	        int i=0,n=pc.Length;
        //  pc//存放输入的全部字符
            char op;
            c=pc[i++];
	        Rational ling=new Rational();
            strout = "";
            while (c != 0)
            {
                string strt, strd;
                while (c == ' ') c = pc[i++];
                strt = "+-*/^()[]{}0123456789.";
                if(strt.IndexOf(c)>=0)
                { 
                    strt="+-*/^()[]{}";
                    if(strt.IndexOf(c)>=0)
                    {
                        switch(c)
                        {
                            case'{':
                                {
                                    de = 1; break;
                                }
                            case'}':
                                {
                                    de = 1; break;
                                }
                            case'[':
                                {
                                    de = 2; break;
                                }
                            case']':
                                {
                                    de = 2; break;
                                }
                            case'(':
                                {
                                    de = 3; break;
                                }
                            case')':
                                {
                                    de = 3; break;
                                }
                            case '+':
                                {
                                    de = 4; break;
                                };
                            case '-':
                                {
                                    de = 4; break;
                                };
                            case '*':
                                {
                                    de = 5; break;
                                };
                            case '/':
                                {
                                    de = 5; break;
                                };
                            case'^':
                                { 
                                    de = 6; break; 
                                }
                            
                        }
                        while (!degree.IsEmpty() && de <= degree.Gettop()&&de>3&&de<6)
                        {
                            switch(op=oper.Gettop())
                            {
                                case'+':case'-':case'*':case'/':case'^':
                                    DoOperator(op);break;
                            }
                            oper.Pop(); degree.Pop();
                            strout = strout + oper.GetStackALLDate("oper");
                            strout = strout + data.GetStackALLDate("data");
                            if ((op == '(') || (op == '[') || (op == '{')) break;
                        }
                        
                        if((c!=')')&&c!=']'&&c!='}')
                        {
                            oper.Push(c);
                            strout = strout + oper.GetStackALLDate("oper");
                            //strout = strout + data.GetStackALLDate("data");
                            //if ((c == '(')) degree.Push(0);
                            //else if (c == '[') degree.Push(-1);
                            //else if (c == '{') degree.Push(-2);
                            //else degree.Push(de);
                            //if (c == '(' || c == '[' || c == '{') degree.push(de);
                            degree.Push(de);
                        }
                        else
                        {
                            if(de==3)
                            {
                                bool flag = false;
                                while (!degree.IsEmpty())
                                {
                                    int de1 = degree.Gettop();
                                    if (de1 <= 2) { strout = "error"; return ling; }
                                    switch (op = oper.Gettop())
                                    {
                                        case '(': { flag = true; break; }
                                        case '+':
                                        case '-':
                                        case '*':
                                        case '/':
                                        case '^':
                                            DoOperator(op); break;
                                    }
                                    oper.Pop(); degree.Pop();
                                    strout = strout + oper.GetStackALLDate("oper");
                                    strout = strout + data.GetStackALLDate("data");
                                    if (flag == true) break;
                                    //if ((op == '(') || (op == '[') || (op == '{')) break;
                                }
                                if (flag == false) { strout = "error"; return ling; }
                                //degree.Pop(); oper.Pop();
                            }
                            else if(de==2)
                            {
                                bool flag = false;
                                while (!degree.IsEmpty())
                                {
                                    int de1 = degree.Gettop();
                                    if (de1 <= 1) { strout = "error"; return ling; }
                                    switch (op = oper.Gettop())
                                    {
                                        case '[': { flag = true; break; }
                                        case '+':
                                        case '-':
                                        case '*':
                                        case '/':
                                        case '^':
                                            DoOperator(op); break;
                                    }
                                    oper.Pop(); degree.Pop();
                                    strout = strout + oper.GetStackALLDate("oper");
                                    strout = strout + data.GetStackALLDate("data");
                                    if (flag == true) break;
                                    //if ((op == '(') || (op == '[') || (op == '{')) break;
                                }
                                //degree.Pop(); oper.Pop();
                                if (flag == false) { strout = "error"; return ling; }
                            }
                            else
                            {
                                bool flag = false;
                                while (!degree.IsEmpty())
                                {
                                    int de1 = degree.Gettop();
                                    if (de1 <= 0) { strout = "error"; return ling; }
                                    switch (op = oper.Gettop())
                                    {
                                        case '{': { flag = true; break; }
                                        case '+':
                                        case '-':
                                        case '*':
                                        case '/':
                                        case '^':
                                            DoOperator(op); break;
                                    }
                                    oper.Pop(); degree.Pop();
                                    strout = strout + oper.GetStackALLDate("oper");
                                    strout = strout + data.GetStackALLDate("data");
                                    if (flag == true) break;
                                    //if ((op == '(') || (op == '[') || (op == '{')) break;
                                }
                                //degree.Pop(); oper.Pop();
                                if (flag == false) { strout = "error"; return ling; }
                            }
                        }
                        if (i < n) c = pc[i++];
                        else c = (char)0;
                    }
                    else 
                    {
                        strd = "";
                        if (c != 0) strd = strd + c;
                        if (i < n) c = pc[i++];
                        else c = (char)0;
                        strt = "0123456789.";
                        while((c!=0)&&(strt.IndexOf(c)>=0))
                        {
                            if (c != 0)
                                strd = strd + c;
                            if (i < n)
                                c = pc[i++];
                            else c = (char)0;
                        }
                        data.Push(new Rational(Convert.ToDouble(strd)));
                        strout += data.GetStackALLDate("data");
                    }
                }
                else return ling;

            }
         
            while(!oper.IsEmpty())//处理剩余运算符
            {
                switch(op=oper.Gettop())
                {
                    case'+':case'-':case'*':case'/':case'^':
                        DoOperator(op);break;
                }
                oper.Pop();
                degree.Pop();
                strout+=oper.GetStackALLDate("oper");
                strout+=data.GetStackALLDate("data");
            }
            return data.Gettop();
        }
    }
}
