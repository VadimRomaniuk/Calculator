using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace CalculatorWPF
{
    public class CalculatorViewModel : OnPropertyChangedClass
    {
        Argument _argumentModel;
        Operator _operatorModel;
        Calculations _calculationsModel;
        public CalculatorViewModel()
        {
            _argumentModel = new Argument();
            _operatorModel = new Operator();
            _calculationsModel = new Calculations();
            _operatorModel.PropertyChanged += (s, a) => { OnAllPropertyChanged(); };
            _argumentModel.PropertyChanged += (s, a) => { OnAllPropertyChanged(); };
            _calculationsModel.PropertyChanged += (s, a) => { OnAllPropertyChanged(); };
        }

        private string _errorOperator;
        private string _errorArgument;
        private string _errorResult;
        private ICommand _resultCommand;


        public string Operator { get; set; }
        public string Args { get; set; }
        public string ErrorOperator { get => _errorOperator; set { _errorOperator = value; OnPropertyChanged(); } }
        public string ErrorArgument { get => _errorArgument; set { _errorArgument = value; OnPropertyChanged(); } }
        public string ErrorResult { get => _errorResult; set { _errorResult = value; OnPropertyChanged(); } }
        
        public ICommand ResultCommand => _resultCommand ?? (_resultCommand = new RelayCommand(OnResultCommand));

        public string CurrentOperator => _operatorModel.CurrentOperator;
        public double[] CurrentArgs => _argumentModel.CurrentArguments;
        public double Result => _calculationsModel.Result;
        public ObservableCollection<string> AvailableOperations => Calculations.AvailableOperations;

        public void OnResultCommand(object Value = null)
        {
            try
            {
                _operatorModel.OperatorCheck(Operator);
                ErrorOperator = string.Empty;
            }
            catch (Exception ex)
            {
                ErrorOperator = ex.Message;
            }
            try
            {
                _argumentModel.ArgumentCheck(Args);
                ErrorArgument = string.Empty;
            }
            catch (Exception ex)
            {
                ErrorArgument = ex.Message;
            }
            try
            {
                _calculationsModel.Calculate(CurrentOperator, CurrentArgs);
                ErrorResult = string.Empty;
            }
            catch (Exception ex)
            {
                ErrorResult = ex.Message;
            }
        }
    }
}
