using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CalculatorWPF
{
    public class Calculations : OnPropertyChangedClass
    {
        private double _result = 0;

        public static Dictionary<string, IOperation> DictionaryOperations { get; private set; }
        public static Dictionary<string, int> NumberOfArgumentsOfTheOperation { get; private set; } = new Dictionary<string, int>();
        public static ObservableCollection<string> AvailableOperations { get; set; } = new ObservableCollection<string>();
        public double Result { get => _result; set { _result = value; OnPropertyChanged(); } }

        static Calculations()
        {
            DictionaryOperations = new Dictionary<string, IOperation>
            {
                { "+", new MySum() },
                { "-", new MySubtraction() },
                { "*", new MyMultiplication() },
                { "/", new MyDivision() },
                { "sin", new MySin() },
                { "acos", new MyAcos() },
                { "asin", new MyAsin() },
                { "atan", new MyAtan() },
                { "atan2", new MyAtan2() },
                { "sqrt", new MySqrt() },
                { "max", new MyMax() },
                { "abs", new MyAbs() }
            };
            ICollection<string> keys = DictionaryOperations.Keys;
            foreach (var key in keys)
            {
                int numberParams = DictionaryOperations[key].GetNumberParams();
                NumberOfArgumentsOfTheOperation.Add(key, numberParams);
                AvailableOperations.Add(key);
            }
        }
        public void Calculate(string op, params double[] args)
        {
            Result = 0;
            if (!DictionaryOperations.ContainsKey(op))
            {
                throw new ArgumentException($"Введенный оператор не определен!");
            }
            if (args.Length < NumberOfArgumentsOfTheOperation[op])
            {
                throw new ArgumentException($"Недостаточно аргументов для выполнения операции \"{op}\", необходим(о) {NumberOfArgumentsOfTheOperation[op]} аргумент(а)!");
            }
            Result = DictionaryOperations[op].Call(args);
        }
    }
}
