using System;

namespace CalculatorWPF
{
    public class Argument : OnPropertyChangedClass
    {
        private string _inputArgument;
        private double[] _currentArguments = Array.Empty<double>();

        public double[] CurrentArguments { get => _currentArguments; set { _currentArguments = value; OnPropertyChanged(); } }

        public void ArgumentCheck(string inputArgument)
        {
            if (inputArgument != null)
            {
                _inputArgument = inputArgument;
                CurrentArguments = Array.Empty<double>();
                string[] _argument = _inputArgument.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (_argument.Length == 0)
                {
                    throw new ArgumentException("Аргументы не введены!");
                }
                else
                {
                    CurrentArguments = new double[_argument.Length];
                    for (int i = 0; i < _argument.Length; i++)
                    {
                        bool result = Double.TryParse(_argument[i], out double number);
                        if (result)
                        {
                            CurrentArguments[i] = number;
                        }
                        else
                        {
                            CurrentArguments = Array.Empty<double>();
                            throw new ArgumentException($"Аргумент {_argument[i]} не поддерживается!");

                        }
                    }
                }
            }
            else
            {
                throw new ArgumentException("Аргументы не введены!");
            }
        }
    }
}
