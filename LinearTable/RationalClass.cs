using System;


namespace LinearTable
{
    class Rational
    {
        private	int num;//分子
        private int den;//分母
        public void optimization()                   //优化有理数函数
        {
            int gcd;
            if(den==0)  num=0;
            if(num==0) //若分子为0,则置分母为1后返回
            { 
		        den=1; 
		        return; 
	        }
            gcd = (Math.Abs(num) < Math.Abs(den)) ? Math.Abs(num) : Math.Abs(den);
	        //取分子,分母中较小的数作为公约的极限
            if(gcd==0)  return;
            int i;
            for(i=gcd;i>1;i--) //有循环找最大公约数
		        if((num%i==0)&&(den%i==0))  
			        break;
            num/=i;den/=i;  //i是最大公约数
            if((num<0)&&(den<0))
            { 
		        num=-num;
		        den=-den; 
	        }
            else if((num<0)||(den<0))
	        {
                num = -Math.Abs(num);
                den = Math.Abs(den); 
	        }
        }
//---------------------------------------------------------------------------

        public Rational()//无参的构造有理数
        { 
	        num=0;
	        den=1;
        }
        public Rational(int x,int y)//已知分子分母构造有理数
        { 
	        num=x;
	        den=y;
	        optimization();
        }
        public Rational(Rational ob)//拷贝构造函数
        {
            num = ob.num;
            den = ob.den;
            optimization();
        }
        public Rational(double x)//通过实数构造有理数
        {
            if((int)(x)==x)
            {	
		        num=(int)x;
		        den=1; 
	        }
            else
            {	
		        num=(int)(x*1000+0.5);
		        den=1000; 
	        }
            optimization();
        }
		//public int Getnum(){ return num; }           //取分子
		//public int Getden(){ return den; }           //取分母
        //public void Setnum(int num) { this.num=num; }           //设置分子
        //public void Setden(int den) { this.den=den; }           //设置分母
//---------------------------------------------------------------------------
        public override string ToString()
        {
            if(den==1)
                return ("" + num);
            else
                return ("" + num + "/" + den);
        }

        public double todouble()
        { 
	        return ((double)num)/den; 
        }
//---------------------------------------------------------------------------
        public static Rational operator +  (Rational rat1,Rational rat2)
        {
            Rational temp=new Rational(0,1);
            temp.den=rat1.den*rat2.den;
            temp.num=rat1.num*rat2.den+rat1.den*rat2.num;
            temp.optimization();
            return temp;
        }
//---------------------------------------------------------------------------
        public static Rational operator - (Rational rat1, Rational rat2)
        {
            Rational temp = new Rational(0, 1);
            temp.den = rat1.den * rat2.den;
            temp.num = rat1.num * rat2.den - rat1.den * rat2.num;
            temp.optimization();
            return temp;
        }
//---------------------------------------------------------------------------
        public static Rational operator -(Rational rat1)
        {
            Rational temp = new Rational(0, 1);
            temp.den = rat1.den ;
            temp.num = -rat1.num ;
            temp.optimization();
            return temp;
        }

//---------------------------------------------------------------------------
        public static Rational operator * (Rational rat1, Rational rat2)
        {
            Rational temp = new Rational(0, 1);
            temp.den = rat1.den * rat2.den;
            temp.num = rat1.num * rat2.num;
            temp.optimization();
            return temp;
        }
//---------------------------------------------------------------------------
        public static Rational operator / (Rational rat1, Rational rat2)
        {
            Rational temp = new Rational(0, 1);
            temp.den = rat1.den * rat2.num;
            temp.num = rat1.num * rat2.den;
            temp.optimization();
            return temp;
        }
//---------------------------------------------------------------------------
        public static Rational operator ^(Rational rat1, int k)
        {
            Rational temp = new Rational(1, 1);
            temp.den = 1 ;
            temp.num = 1 ;
            if (k > 0)
            {
                for (int i = 1; i <= k; i++)
                {
                    temp.den = temp.den * rat1.den;
                    temp.num = temp.num * rat1.num;
                }
            }
            else if (k < 0)
            {
                for (int i = 1; i <= -k; i++)
                {
                    temp.den = temp.den * rat1.num;
                    temp.num = temp.num * rat1.den;
                }
            }
            temp.optimization();
            return temp;
        }
      
//---------------------------------------------------------------------------
        public static Rational operator ++ (Rational rat1)
        {
            Rational rat2 = new Rational(1, 1);
            rat1 = rat1 + rat2;
            rat1.optimization();
            return rat1;
        }
//---------------------------------------------------------------------------
        public static Rational operator --(Rational rat1)
        {
            Rational rat2 = new Rational(1, 1);
            rat1 = rat1 - rat2;
            rat1.optimization();
            return rat1;
        }
        public int Num
        {
            get
            { return num; }
            set
            { num = value; }
        }
        public int Den
        {
            get
            { return den; }
            set
            { den = value; }
        }


    }
}
