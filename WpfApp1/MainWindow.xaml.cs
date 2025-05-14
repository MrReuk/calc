using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Data;

namespace calculator
{
    public partial class MainWindow : Window
    {
        private StringBuilder builder = new StringBuilder();
        private bool resultDisplayed = false;
        private bool error = false;

        private string lastOperator = null;
        private string lastOperand = null;
        private bool lastCalculationRepeated = false;

        private bool isEquationDisplayed = false;

        public MainWindow()
        {
            InitializeComponent();
            ResultDisplay.Text = "0";
            ExpressionDisplay.Text = "0";
        }

        private void ClearAll(object sender, RoutedEventArgs e)
        {
            builder.Clear();
            ResultDisplay.Text = "0";
            ExpressionDisplay.Text = "0";
            resultDisplayed = false;
            error = false;
            lastOperator = null;
            lastOperand = null;
            lastCalculationRepeated = false;
            isEquationDisplayed = false;
        }

        private void Clear(object sender, RoutedEventArgs e)
        {
            if (resultDisplayed || isEquationDisplayed)
            {
                ClearAll(sender, e);
            }
            else if (builder.Length > 0)
            {
                builder.Remove(builder.Length - 1, 1);
                UpdateExpressionDisplay();
            }
        }

        private void DigitButton_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            string digit = button.Content.ToString();
            HandleInput(digit);
        }

        private void OperatorButton_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            string op = button.Content.ToString();
            HandleInput(op);
        }

        private void PowerButton_Click(object sender, RoutedEventArgs e)
        {
            if (isEquationDisplayed)
            {
                string currentResult = ResultDisplay.Text;
                builder.Clear();
                builder.Append(currentResult);
                isEquationDisplayed = false;
            }
            else if (resultDisplayed)
            {
                string currentResult = ResultDisplay.Text;
                builder.Clear();
                builder.Append(currentResult);
                resultDisplayed = false;
            }

            builder.Append("^");
            UpdateExpressionDisplay();
        }

        private void PlusMinusButton_Click(object sender, RoutedEventArgs e)
        {
            if (error)
            {
                builder.Clear();
                error = false;
                ExpressionDisplay.Text = "0";
                ResultDisplay.Text = "0";
                return;
            }

            if (isEquationDisplayed || resultDisplayed)
            {
                string currentValue = ResultDisplay.Text;
                if (currentValue == "0") return;

                if (currentValue.StartsWith("-"))
                {
                    ResultDisplay.Text = currentValue.Substring(1);
                }
                else
                {
                    ResultDisplay.Text = "-" + currentValue;
                }

                builder.Clear();
                builder.Append(ResultDisplay.Text);
                resultDisplayed = true;
                isEquationDisplayed = true;
                return;
            }

            if (builder.Length == 0)
            {
                builder.Append("-");
                UpdateExpressionDisplay();
                return;
            }

            int i = builder.Length - 1;
            while (i >= 0 && (char.IsDigit(builder[i]) || builder[i] == ','))
            {
                i--;
            }

            if (i >= 0 && (builder[i] == '+' || builder[i] == '-'))
            {
                bool isSignNotOperator = (i == 0) ||
                                       (!char.IsDigit(builder[i - 1]) &&
                                       (builder[i - 1] != ')'));

                if (isSignNotOperator)
                {
                    builder[i] = builder[i] == '+' ? '-' : '+';
                    UpdateExpressionDisplay();
                    return;
                }
            }
            if (i < builder.Length - 1)
            {
                builder.Insert(i + 1, "-");
            }
            else
            {
                builder.Append("-");
            }

            UpdateExpressionDisplay();
        }

        private void FunctionButton_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            string function = button.Content.ToString();

            try
            {
                string expr = builder.Length > 0 ? builder.ToString() : ResultDisplay.Text;

                if (isEquationDisplayed)
                {
                    expr = ResultDisplay.Text;
                    builder.Clear();
                    isEquationDisplayed = false;
                }

                expr = expr.Replace(',', '.');

                double value = EvaluateExpression(expr);
                double result;

                switch (function)
                {
                    case "|x|":
                        result = Math.Abs(value);
                        break;
                    case "1/x":
                        if (value == 0) throw new DivideByZeroException();
                        result = 1 / value;
                        break;
                    case "√x":
                        if (value < 0) throw new Exception("Нельзя извлечь корень из отрицательного числа");
                        result = Math.Sqrt(value);
                        break;
                    case "n!":
                        if (value < 0 || value % 1 != 0) throw new Exception("Факториал определён только для неотрицательных целых");
                        result = Factorial((int)value);
                        break;
                    case "x^2":
                        result = Math.Pow(value, 2);
                        break;
                    case "sin":
                        result = Math.Sin(value * Math.PI / 180);
                        break;
                    case "cos":
                        result = Math.Cos(value * Math.PI / 180);
                        break;
                    case "tg":
                        result = Math.Tan(value * Math.PI / 180);
                        break;
                    case "log":
                        if (value <= 0) throw new Exception("Логарифм определён только для положительных чисел");
                        result = Math.Log10(value);
                        break;
                    case "ln":
                        if (value <= 0) throw new Exception("Натуральный логарифм определён только для положительных чисел");
                        result = Math.Log(value);
                        break;
                    case "10^x":
                        result = Math.Pow(10, value);
                        break;
                    default:
                        throw new Exception("Неизвестная функция");
                }

                string displayExpr = function + "(" + expr + ")";

                ResultDisplay.Text = result.ToString(System.Globalization.CultureInfo.InvariantCulture);
                ExpressionDisplay.Text = displayExpr;

                builder.Clear();
                builder.Append(result.ToString(System.Globalization.CultureInfo.InvariantCulture));
                resultDisplayed = true;
                isEquationDisplayed = true;
                error = false;
            }
            catch (Exception)
            {
                ResultDisplay.Text = "Ошибка";
                ExpressionDisplay.Text = "Ошибка";
                error = true;
                builder.Clear();
                isEquationDisplayed = false;
            }
        }

        private void ConstantButton_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            string constant = button.Content.ToString();

            if (constant == "π")
            {
                HandleInput(Math.PI.ToString(System.Globalization.CultureInfo.InvariantCulture));
            }
            else if (constant == "e")
            {
                HandleInput(Math.E.ToString(System.Globalization.CultureInfo.InvariantCulture));
            }
        }

        private void ParenthesisButton_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            string parenthesis = button.Content.ToString();
            HandleInput(parenthesis);
        }

        private void CommaButton_Click(object sender, RoutedEventArgs e)
        {
            HandleInput(",");
        }

        private void HandleInput(string value)
        {
            if (error)
            {
                builder.Clear();
                error = false;
                ExpressionDisplay.Text = "0";
            }

            if (isEquationDisplayed)
            {
                builder.Clear();
                isEquationDisplayed = false;
            }

            bool isDigit = value.Length == 1 && char.IsDigit(value[0]);
            bool isOperator = value == "+" || value == "-" || value == "*" || value == "/" || value == "^";

            if (resultDisplayed)
            {
                lastCalculationRepeated = false;

                if (isOperator)
                {
                    string currentResult = ResultDisplay.Text;

                    builder.Clear();
                    builder.Append(currentResult);
                    builder.Append(value);
                    UpdateExpressionDisplay();
                    resultDisplayed = false;
                    return;
                }
                else if (isDigit)
                {
                    builder.Clear();
                    builder.Append(value);
                    ExpressionDisplay.Text = builder.ToString();
                    resultDisplayed = false;
                    return;
                }
            }

            if (value == ",")
            {
                if (HasDecimalSeparatorInCurrentNumber())
                    return;
            }

            if ((ExpressionDisplay.Text == "0" || ExpressionDisplay.Text == "Ошибка") && (isDigit || value == ","))
            {
                builder.Clear();
                builder.Append(value);
                ExpressionDisplay.Text = builder.ToString();
            }
            else
            {
                if (value == "(")
                {
                    if (builder.Length > 0)
                    {
                        char lastChar = builder[builder.Length - 1];
                        if (char.IsDigit(lastChar) || lastChar == ')')
                        {
                            builder.Append("*");
                        }
                    }
                }
                builder.Append(value);
                UpdateExpressionDisplay();
            }
        }

        private bool HasDecimalSeparatorInCurrentNumber()
        {
            int i = builder.Length - 1;
            while (i >= 0)
            {
                char c = builder[i];
                if (c == ',') return true;
                if (!char.IsDigit(c)) break;
                i--;
            }
            return false;
        }

        private void UpdateExpressionDisplay()
        {
            if (builder.Length == 0)
            {
                ExpressionDisplay.Text = "0";
            }
            else
            {
                ExpressionDisplay.Text = builder.ToString();
            }
        }

        private void UpdateResultDisplay(string value)
        {
            ResultDisplay.Text = value;
            resultDisplayed = true;
        }

        private void CalculateResult(object sender, RoutedEventArgs e)
        {
            try
            {
                string expression = builder.ToString();

                if (string.IsNullOrWhiteSpace(expression))
                    return;

                expression = expression.Replace(',', '.');

                var table = new DataTable();
                var resultNull = table.Compute(expression, null);

                if (resultNull is double d && (double.IsInfinity(d) || double.IsNaN(d)))
                {
                    ResultDisplay.Text = "Деление на ноль";
                    ExpressionDisplay.Text = "Деление на ноль";
                    error = true;
                    return;
                }

                if (resultDisplayed && lastCalculationRepeated)
                {
                    string currentResult = ResultDisplay.Text;

                    if (lastOperator != null && lastOperand != null)
                    {
                        string repeatExpr = currentResult + lastOperator + lastOperand;
                        repeatExpr = repeatExpr.Replace(',', '.');

                        repeatExpr = ProcessFactorials(repeatExpr);

                        double repeatResult = EvaluateExpression(repeatExpr);

                        UpdateResultDisplay(repeatResult.ToString());

                        builder.Clear();
                        builder.Append(repeatResult.ToString());
                    }
                }
                else
                {
                    expression = ProcessFactorials(expression);

                    double result = EvaluateExpression(expression);

                    UpdateResultDisplay(result.ToString());

                    ParseLastOperation(expression);

                    lastCalculationRepeated = true;

                    builder.Clear();
                    builder.Append(result.ToString());

                    if (num())
                    {
                        ResultDisplay.Text = "Ошибка";
                        ExpressionDisplay.Text = "Деление на ноль";
                        error = true;
                        lastCalculationRepeated = false;
                        isEquationDisplayed = false;
                    }
                    else
                    {
                        ExpressionDisplay.Text = expression;
                        isEquationDisplayed = true;
                    }
                }
            }
            catch
            {
                ResultDisplay.Text = "Ошибка";
                ExpressionDisplay.Text = "Ошибка";
                error = true;
                lastCalculationRepeated = false;
                isEquationDisplayed = false;
            }
        }

        private bool num()
        {
            string expression = builder.ToString();

            for (int i = 0; i < expression.Length - 1; i++)
            {
                if (expression[i] == '/')
                {
                    int j = i + 1;
                    while (j < expression.Length && char.IsWhiteSpace(expression[j]))
                        j++;

                    if (j < expression.Length && expression[j] == '0')
                    {
                        if (j + 1 >= expression.Length || !(expression[j + 1] == '.' || char.IsDigit(expression[j + 1])))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        private void ParseLastOperation(string expression)
        {
            string[] operators = new string[] { "+", "-", "*", "/", "^" };
            lastOperator = null;
            lastOperand = null;

            for (int i = expression.Length - 1; i >= 0; i--)
            {
                char c = expression[i];
                if (Array.Exists(operators, op => op == c.ToString()))
                {
                    lastOperator = c.ToString();
                    lastOperand = expression.Substring(i + 1);
                    break;
                }
            }

            if (lastOperator == null || string.IsNullOrEmpty(lastOperand))
            {
                lastOperator = null;
                lastOperand = null;
                lastCalculationRepeated = false;
            }
        }

        private double EvaluateExpression(string expression)
        {
            expression = expression.Trim();

            while (expression.Contains("("))
            {
                int closeIndex = expression.IndexOf(')');
                if (closeIndex == -1) throw new Exception("Несбалансированные скобки");
                int openIndex = expression.LastIndexOf('(', closeIndex);
                if (openIndex == -1) throw new Exception("Несбалансированные скобки");

                string innerExpr = expression.Substring(openIndex + 1, closeIndex - openIndex - 1);
                double innerVal = EvaluateExpression(innerExpr);

                expression = expression.Substring(0, openIndex) + innerVal.ToString(System.Globalization.CultureInfo.InvariantCulture) + expression.Substring(closeIndex + 1);
            }

            int powIndex = FindOperatorOutsideParentheses(expression, '^');
            if (powIndex != -1)
            {
                string leftPart = expression.Substring(0, powIndex);
                string rightPart = expression.Substring(powIndex + 1);

                double baseVal = EvaluateExpression(leftPart);
                double exponent = EvaluateExpression(rightPart);

                return Math.Pow(baseVal, exponent);
            }

            if (expression.StartsWith("sin"))
            {
                double angle = double.Parse(expression.Substring(4, expression.Length - 5), System.Globalization.CultureInfo.InvariantCulture);
                return Math.Sin(angle * Math.PI / 180);
            }
            else if (expression.StartsWith("cos"))
            {
                double angle = double.Parse(expression.Substring(4, expression.Length - 5), System.Globalization.CultureInfo.InvariantCulture);
                return Math.Cos(angle * Math.PI / 180);
            }
            else if (expression.StartsWith("tg"))
            {
                double angle = double.Parse(expression.Substring(3, expression.Length - 4), System.Globalization.CultureInfo.InvariantCulture);
                return Math.Tan(angle * Math.PI / 180);
            }
            else if (expression.StartsWith("log"))
            {
                double value = double.Parse(expression.Substring(4, expression.Length - 5), System.Globalization.CultureInfo.InvariantCulture);
                return Math.Log10(value);
            }
            else if (expression.StartsWith("ln"))
            {
                double value = double.Parse(expression.Substring(3, expression.Length - 4), System.Globalization.CultureInfo.InvariantCulture);
                return Math.Log(value);
            }
            else if (expression.StartsWith("sqrt"))
            {
                double value = double.Parse(expression.Substring(5, expression.Length - 6), System.Globalization.CultureInfo.InvariantCulture);
                return Math.Sqrt(value);
            }
            else if (expression.StartsWith("abs"))
            {
                double value = double.Parse(expression.Substring(4, expression.Length - 5), System.Globalization.CultureInfo.InvariantCulture);
                return Math.Abs(value);
            }
            else if (expression.StartsWith("1/"))
            {
                double value = double.Parse(expression.Substring(2), System.Globalization.CultureInfo.InvariantCulture);
                return 1 / value;
            }
            else if (expression.Contains("!"))
            {
                int index = expression.IndexOf('!');
                string numberPart = expression.Substring(0, index);
                int value = int.Parse(numberPart, System.Globalization.CultureInfo.InvariantCulture);
                return Factorial(value);
            }
            else
            {
                var table = new DataTable();
                var value = table.Compute(expression, "");
                return Convert.ToDouble(value);
            }
        }

        private int FindOperatorOutsideParentheses(string expr, char op)
        {
            int depth = 0;
            for (int i = 0; i < expr.Length; i++)
            {
                if (expr[i] == '(') depth++;
                else if (expr[i] == ')') depth--;
                else if (expr[i] == op && depth == 0) return i;
            }
            return -1;
        }

        private long Factorial(int n)
        {
            if (n < 0) throw new Exception("Факториал отрицательного числа");
            long result = 1;
            for (int i = 2; i <= n; i++)
                result *= i;
            return result;
        }

        private string ProcessFactorials(string expression)
        {
            while (expression.Contains("!"))
            {
                int index = expression.IndexOf('!');
                int start = index - 1;
                while (start >= 0 && (char.IsDigit(expression[start]) || expression[start] == '.'))
                    start--;
                start++;
                string numberStr = expression.Substring(start, index - start);
                if (!int.TryParse(numberStr, out int number))
                    throw new Exception("Некорректный факториал");
                long fact = Factorial(number);
                expression = expression.Substring(0, start) + fact.ToString() + expression.Substring(index + 1);
            }
            return expression;
        }
    }
}
