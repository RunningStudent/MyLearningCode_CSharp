using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 计算器
{
    public class Calculator
    {
        public double _number1 { get; set; }
        public double _number2 { get; set; }
        public double calculate(string operate)
        { 
            switch (operate)
            {
                case "+":
                    return _number1 + _number2;
                case "-":
                    return _number1 - _number2;
                case "*":
                    return _number1 * _number2;
                case"/":
                    return _number1 / _number2;
                default:
                    throw new Exception("未知错误");
            }
        }
    }
}
