using BanksPortfolio.Class;
using BanksPortfolio.Objects;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

namespace BanksPortfolio
{
    class Program
    {
        static void Main(string[] args)
        {
            string tmp;
            DateTime dt = DateTime.Now, refDt = DateTime.Now;
            int num, loop;
            ConsoleColor c;
            try
            {
                WriteMessage("Input the reference date (MM/DD/YYYY): ", false);

                tmp = ReadMessage();
                if (!DateTime.TryParse(tmp, CultureInfo.CreateSpecificCulture("en-US"), DateTimeStyles.None, out refDt))
                {
                    WriteMessage($"Ivalid given date: {tmp}", true, ConsoleColor.Red);
                    return;
                }

                WriteMessage("Input the number of trades in the portfolio: ", false);
                tmp = ReadMessage();
                if (Regex.IsMatch(tmp, @"^[0-9]+$"))
                    num = Int32.Parse(tmp);
                else
                {
                    WriteMessage("The given value is Not a Number.", true, ConsoleColor.Red);
                    return;
                }

                WriteMessage($"Input 3 elements each(separated by a space) {num} times: ", true);
                WriteMessage("# 1) a double that represents trade amount", true);
                WriteMessage("# 2) a string that represents the client’s sector", true);
                WriteMessage("# 3) a date that represents the next pending payment (mm/dd/yyyy)", true);
                loop = 0;
                List<Trade> trades = new List<Trade>();
                while (loop < num)
                {
                    WriteMessage($"# Input {loop + 1}: ", false);
                    tmp = ReadMessage();
                    var values = tmp.Split(" ");
                    if (!Validate(values, ref dt))
                        WriteMessage($"## Ivalid given values: '{tmp}', please do it again.", true, ConsoleColor.Red);
                    else
                    {
                        trades.Add(new Trade()
                        {
                            Value = Convert.ToDouble(values[0]),
                            ClientSector = values[1],
                            NextPaymentDate = dt,
                            Category = ValidateCategory(values, refDt, dt),
                            IsPoliticalExposed = true
                        });
                        loop++;
                    }
                }

                WriteMessage("", true);
                WriteMessage($"{num} lines with the category of each one of the {num} trades", true);
                for (int i = 0; i < num; i++)
                {
                    WriteMessage($" Output {i + 1}: ", false, ConsoleColor.Yellow);
                    c = (trades[i].Category == eCategories.HIGHRISK ? ConsoleColor.DarkRed : (trades[i].Category == eCategories.MEDIUMRISK ? ConsoleColor.DarkYellow : (trades[i].Category == eCategories.EXPIRED ? ConsoleColor.DarkBlue : ConsoleColor.Blue)));
                    WriteMessage(trades[i].Category.ToString(), true, c);
                }

                WriteMessage("", true);
                //Print IsExposed
                if (trades[0].IsPoliticalExposed)
                {
                    var person = trades[0].GetPerson(1);
                    WriteMessage("Exposed Sample: ", true, ConsoleColor.Green);
                    WriteMessage($"# Id: {person.Id}", true, ConsoleColor.DarkGreen);
                    WriteMessage($"# Name: {person.Name}", true, ConsoleColor.DarkGreen);
                    WriteMessage($"# Email: {person.Email}", true, ConsoleColor.DarkGreen);
                    WriteMessage($"# Phone: {person.Phone}", true, ConsoleColor.DarkGreen);
                }
                WriteMessage("", true);
                WriteMessage("", true);
            }
            catch (Exception e) { throw e; }
        }

        private static string ReadMessage()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            return System.Console.ReadLine();
        }

        private static void WriteMessage(string v, bool writeLine, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            if (writeLine)
                Console.WriteLine(v);
            else
                Console.Write(v);
        }

        private static eCategories ValidateCategory(string[] values, DateTime refDt, DateTime dt)
        {
            double dbl;
            double.TryParse(values[0], out dbl);

            if (DateTime.Compare(refDt, dt) >= 0)
                return eCategories.EXPIRED;

            if (values[1].Trim().ToLower().Equals("public"))
                if (dbl > Constants.BaseValue)
                    return eCategories.MEDIUMRISK;

            if (values[1].Trim().ToLower().Equals("private"))
                if (dbl > Constants.BaseValue)
                    return eCategories.HIGHRISK;

            return eCategories.NONE;
        }

        private static bool Validate(string[] values, ref DateTime dt)
        {
            if (values.Length < 3)
                return false;
            if (!double.TryParse(values[0], out _))
                return false;
            if (!values[1].Trim().ToLower().Equals("private") && (!values[1].Trim().ToLower().Equals("public")))
                return false;
            //dt = Convert.ToDateTime(values[2]);
            if (!DateTime.TryParse(values[2], CultureInfo.CreateSpecificCulture("en-US"), DateTimeStyles.None, out dt))
                return false;
            return true;
        }
    }
}
