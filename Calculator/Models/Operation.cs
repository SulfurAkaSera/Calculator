﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Calculator.ViewModel;

namespace Calculator.Models
{
    class Operation
    {
        public static long Fact(long n)
        {
            if (n == 0)
                return 1;
            else
                return n * Fact(n - 1);
        }

        public static string Derivative(string expression)
        {
            double result = 0;
            Regex findNum = new Regex(@"(\W*)(\d\.*\d)\^(\d+)");
            Regex findX = new Regex(@"(\W?)(\d+\.*\d*)([a-z]?x)\^(\d+)");
            Regex findSin = new Regex(@"(\W?)(\d+\.*\d*)([a-z]*sin)(...)\^(\d+)");
            Regex findCos = new Regex(@"(\W?)(\d+\.*\d*)([a-z]*cos)(...)\^(\d+)");
            Regex findE = new Regex(@"(\W?)(\d+\.*\d*)([a-z]*e\^[a-z]*x)");
            Regex findTg = new Regex(@"(\W?)(\d+\.*\d*)([a-z]*tg)(...)\^(\d+)");
            Regex findCtg = new Regex(@"(\W?)(\d+\.*\d*)([a-z]*ctg)(...)\^(\d+)");
            Regex findLn = new Regex(@"(\W)(\d+\.*\d*)([a-z]*ln)(.x.)\^(\d+)");
            Regex findLog = new Regex(@"(\W?)(\d+\.*\d*)([a-z]*log).(\w+)..(\w+).");
            Match mathNum = findNum.Match(expression);
            Match mathX = findX.Match(expression);
            Match mathSin = findSin.Match(expression);
            Match mathCos = findCos.Match(expression);
            Match mathE = findE.Match(expression);
            Match mathTg = findTg.Match(expression);
            Match mathCtg = findCtg.Match(expression);
            Match mathLn = findLn.Match(expression);
            Match mathLog = findLog.Match(expression);

            expression = "";
            if (double.TryParse(mathNum.Groups[2].Value, out result) is true)
            {
                expression += "";
            }
            if(mathX.Groups[3].Value == "x")
            {
                if (double.Parse(mathX.Groups[2].Value) == 1 && double.Parse(mathX.Groups[4].Value) == 1)
                {
                    expression += $"{mathX.Groups[1].Value}1";
                }
                else if(double.Parse(mathX.Groups[4].Value) == 1)
                {
                    expression += $"{mathX.Groups[1]}{mathX.Groups[2].Value}";
                }
                else
                {
                    expression += $"{mathX.Groups[1].Value}{double.Parse(mathX.Groups[4].Value)*double.Parse(mathX.Groups[2].Value)}x^{double.Parse(mathX.Groups[4].Value) - 1}";
                }
            }
            if(mathSin.Groups[3].Value == "sin")
            {
                if(double.Parse(mathSin.Groups[5].Value) == 1)
                {
                    expression += $"{mathSin.Groups[1].Value}{mathSin.Groups[2].Value}cos(x)";
                }
                else
                {
                    expression += $"{mathSin.Groups[1].Value}{double.Parse(mathSin.Groups[5].Value) * double.Parse(mathSin.Groups[2].Value)}sin(x)^{double.Parse(mathSin.Groups[5].Value) - 1}*cos(x)";
                }
            }
            if (mathCos.Groups[3].Value == "cos")
            {
                if (double.Parse(mathCos.Groups[5].Value) == 1)
                {
                    if(mathCos.Groups[1].Value == "-")
                    {
                        expression += $"+{mathCos.Groups[2].Value}sin(x)";
                    }
                    else
                    {
                        expression += $"-{mathCos.Groups[2].Value}sin(x)";
                    }
                    
                }
                else
                {
                    if(mathCos.Groups[1].Value == "-")
                    {
                        expression += $"+{double.Parse(mathCos.Groups[5].Value) * double.Parse(mathCos.Groups[2].Value)}sin(x)^{double.Parse(mathCos.Groups[5].Value) - 1}*cos(x)";
                    }
                    else
                    {
                        expression += $"-{double.Parse(mathCos.Groups[5].Value) * double.Parse(mathCos.Groups[2].Value)}sin(x)^{double.Parse(mathCos.Groups[5].Value) - 1}*cos(x)";
                    }
                }
            }
            if (mathE.Groups[3].Value == "e^x")
            {
                expression += $"{mathE.Value}";
            }
            if(mathTg.Groups[3].Value == "tg")
            {
                if(double.Parse(mathTg.Groups[5].Value) == 1)
                {
                    expression += $"{mathTg.Groups[1].Value}*({mathTg.Groups[2].Value}/cos(x)^2)";
                }
                else
                {
                    if(mathTg.Groups[1].Value == "-")
                    {
                        expression += $"(+{mathTg.Groups[2].Value}*(-{mathTg.Groups[2].Value}+(1/cos(x)^2)))/cos(x)^2";
                    }
                    else
                    {
                        expression += $"(+{mathTg.Groups[2].Value}*({mathTg.Groups[2].Value}-(1/cos(x)^2)))/cos(x)^2";
                    }
                }
            }
            if(mathCtg.Groups[3].Value == "ctg")
            {
                if(double.Parse(mathCtg.Groups[1].Value) == 1)
                {
                    if(mathCtg.Groups[1].Value == "-")
                    {
                        expression += $"+{mathCtg.Groups[2].Value}ctg(x)^2+{mathCtg.Groups[2].Value}";
                    }
                    else
                    {
                        expression += $"-{mathCtg.Groups[2].Value}ctg(x)^2-{mathCtg.Groups[2].Value}";
                    }
                }
                else
                {
                    expression += $"{mathCtg.Groups[1].Value}{mathCtg.Groups[2].Value}*(-3·ctg(x)^2-3)·ctg(x)^2";
                }
            }
            if (mathLn.Groups[3].Value == "ln")
            {
                if(double.Parse(mathLn.Groups[5].Value) == 1)
                {
                    expression += $"{mathLn.Groups[1].Value}({mathLn.Groups[2].Value}/x)";
                }
                else
                {
                    expression += $"{mathLn.Groups[1].Value}{double.Parse(mathLn.Groups[5].Value) * double.Parse(mathLn.Groups[2].Value)}*(ln(x)^{double.Parse(mathLn.Groups[5].Value) - 1}/x)";
                }
            }
            if(mathLog.Groups[3].Value == "log")
            {
                expression += $"{mathLog.Groups[1].Value}({mathLog.Groups[2].Value}/{mathLog.Groups[5].Value}ln({mathLog.Groups[4].Value}))";
            }
            return expression;
        }

        public static string Sum(string expression)
        {
            return expression;
        }
    }
}
