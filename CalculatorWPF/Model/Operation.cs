using System;

namespace CalculatorWPF
{
    public interface IOperation
    {
        double Call(params double[] args);
        int GetNumberParams();
    }
    public static class Callback
    {
        public delegate double Function<ar1>(ar1 item1);
        public delegate double Function<ar1, ar2>(ar1 item1, ar2 item2);
        
        public static double OnCallback(Function<double> t, params double[] args)
        {
            return t(args[0]);
        }

        public static double OnCallback(Function<double, double> t, params double[] args)
        {
            return t(args[0], args[1]);
        } 
    }
    public static class AlarmHendler
    {
        public static void IsNanResult()
        {
            throw new ArgumentException("Ошибка в ходе вычисления!");
        }
    }
    public class MySum : IOperation
    {

        public double Sum(double args1, double args2)
        {
            return args1 + args2;
        }
        public double Call(params double[] args)
        {
            return Callback.OnCallback(Sum, args);
        }
        public int GetNumberParams()
        {
            return GetType().GetMethod("Sum").GetParameters().Length;
        }
        
    }
    public class MySubtraction : IOperation
    {
        public double Subtraction(double args1, double args2)
        {
            return args1 - args2;
        }
        public double Call(params double[] args)
        {
            return Callback.OnCallback(Subtraction, args);
        }
        public int GetNumberParams()
        {
            return GetType().GetMethod("Subtraction").GetParameters().Length;
        }
    }
    public class MyMultiplication : IOperation
    {
        public double Multiplication(double args1, double args2)
        {
            return args1 * args2;
        }
        public double Call(params double[] args)
        {
            return Callback.OnCallback(Multiplication, args);
        }
        public int GetNumberParams()
        {
            return GetType().GetMethod("Multiplication").GetParameters().Length;
        }
    }
    public class MyDivision : IOperation
    {
        public double Division(double args1, double args2)
        {
            if (args2 == 0)
            {
                throw new ArgumentException("Второй аргумент не должен быть равен нулю! На ноль делить нельзя.");
            }
            return args1 / args2;
        }
        public double Call(params double[] args)
        {
            return Callback.OnCallback(Division, args);
        }
        public int GetNumberParams()
        {
            return GetType().GetMethod("Division").GetParameters().Length;
        }
    }
    public class MyAbs : IOperation
    {
        public double Abs(double args1)
        {
            if (double.IsNaN(Math.Abs(args1))) AlarmHendler.IsNanResult();
            return Math.Abs(args1);
        }
        public double Call(params double[] args)
        {
            return Callback.OnCallback(Abs, args);
        }
        public int GetNumberParams()
        {
            return GetType().GetMethod("Abs").GetParameters().Length;
        }
    }
    public class MyAcos : IOperation
    {
        public double Acos(double args1)
        {
            if (double.IsNaN(Math.Acos(args1))) AlarmHendler.IsNanResult();
            return Math.Acos(args1);
        }
        public double Call(params double[] args)
        {
            return Callback.OnCallback(Acos, args);
        }
        public int GetNumberParams()
        {
            return GetType().GetMethod("Acos").GetParameters().Length;
        }
    }
    public class MyAsin : IOperation
    {
        public double Asin(double args1)
        {
            if (double.IsNaN(Math.Asin(args1))) AlarmHendler.IsNanResult();
            return Math.Asin(args1);
        }
        public double Call(params double[] args)
        {
            return Callback.OnCallback(Asin, args);
        }
        public int GetNumberParams()
        {
            return GetType().GetMethod("Asin").GetParameters().Length;
        }
    }
    public class MyAtan : IOperation
    {
        public double Atan(double args1)
        {
            if (double.IsNaN(Math.Atan(args1))) AlarmHendler.IsNanResult();
            return Math.Atan(args1);
        }
        public double Call(params double[] args)
        {
            return Callback.OnCallback(Atan, args);
        }
        public int GetNumberParams()
        {
            return GetType().GetMethod("Atan").GetParameters().Length;
        }
    }
    public class MyAtan2 : IOperation
    {
        public double Atan2(double args1, double args2)
        {
            if (double.IsNaN(Math.Atan2(args1,args2))) AlarmHendler.IsNanResult();
            return Math.Atan2(args1,args2);
        }
        public double Call(params double[] args)
        {
            return Callback.OnCallback(Atan2, args);
        }
        public int GetNumberParams()
        {
            return GetType().GetMethod("Atan2").GetParameters().Length;
        }
    }
    public class MySqrt : IOperation
    {
        public double Sqrt(double args1)
        {
            if (double.IsNaN(Math.Sqrt(args1))) AlarmHendler.IsNanResult();
            return Math.Sqrt(args1);
        }
        public double Call(params double[] args)
        {
            return Callback.OnCallback(Sqrt, args);
        }
        public int GetNumberParams()
        {
            return GetType().GetMethod("Sqrt").GetParameters().Length;
        }
    }
    public class MyMax : IOperation
    {
        public double Max(double args1, double args2)
        {
            if (double.IsNaN(Math.Max(args1, args2))) AlarmHendler.IsNanResult();
            return Math.Max(args1, args2);
        }
        public double Call(params double[] args)
        {
            return Callback.OnCallback(Max, args);
        }
        public int GetNumberParams()
        {
            return GetType().GetMethod("Max").GetParameters().Length;
        }
    }
    public class MySin : IOperation
    {
        public double Sin(double args1)
        {
            if (double.IsNaN(Math.Sin(args1))) AlarmHendler.IsNanResult();
            return Math.Sin(args1);
        }
        public double Call(params double[] args)
        {
            return Callback.OnCallback(Sin, args);
        }
        public int GetNumberParams()
        {
            return GetType().GetMethod("Sin").GetParameters().Length;
        }
    }
}
