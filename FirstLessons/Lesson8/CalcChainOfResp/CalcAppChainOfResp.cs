using Lesson8;

namespace Lesson8;
internal sealed class CalcAppChainOfResp : CalcAppBase
{
    public CalcAppChainOfResp() : base()
    {
    }

    // Заменить Convert.ToDouble на собственный DoubleTryPars и обрабатываем ошибк
    // Проверка введенного числа. Положительные => good, отрицательные числа => Exception
    // Результат не может быть отрицательным (при вычитании)

    internal override void RunApp()
    {
        _firstNumber = InputNumber(FIRST_NUMBER_MSG);
        bool run = true;
        _calc = new Calc(_firstNumber);
        _calc.CalcAdvancedEventHandler += Calc_CalcAdvancedEventHandler;

        // Инициализируем цепочку обязанностей
        Operation operationItem =
            new Sum(
                new Subtract(
                    new Multipy(
                        new Divide(
                            new Quit(
                                new CancelLast(new ErrorMessage(null, 
                                            _calc, CalculateNums, RequestToExit, ErrorMessage), 
                                        _calc, CalculateNums, RequestToExit, ErrorMessage),
                                    _calc, CalculateNums, RequestToExit, ErrorMessage),
                                _calc, CalculateNums, RequestToExit, ErrorMessage),
                            _calc, CalculateNums, RequestToExit, ErrorMessage),
                        _calc, CalculateNums, RequestToExit, ErrorMessage),
                    _calc, CalculateNums, RequestToExit, ErrorMessage);

        while (run)
        {
            ConsoleKey operationKey = RequestToOperation();
            run = operationItem.Execute(operationKey) ?? false;

        }
    }

}
