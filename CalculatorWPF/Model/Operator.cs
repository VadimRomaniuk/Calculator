using System;
using System.Globalization;

namespace CalculatorWPF
{
    public class Operator : OnPropertyChangedClass
    {
        private string _inputOperator = string.Empty;
        private string _currentOperator = string.Empty;
        public string CurrentOperator { get => _currentOperator; set { _currentOperator = value; OnPropertyChanged(); } }

        public void OperatorCheck(string inputOperator)
        {
            if (inputOperator != null)
            {
                _inputOperator = inputOperator;
                CurrentOperator = string.Empty;
                string[] _operator = _inputOperator.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (_operator.Length == 0)
                {
                    throw new ArgumentException("Оператор не введен!");
                }
                else
                {
                    if (Calculations.DictionaryOperations.ContainsKey(_operator[0].ToLower()))
                    {
                        CurrentOperator = _operator[0].ToLower();
                    }
                    else
                    {
                        throw new Exception("Введенный оператор не определен!");
                    }
                }
            }
            else
            {
                throw new ArgumentException("Оператор не введен!");
            }
        }
    }
}
