using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MacroAssembler
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("TYPE      | Size    | Adress    | Identifier ");
            Console.WriteLine();
            string[] codeLines = File.ReadAllLines("test.c");
            int i = 0;
            foreach (var line in codeLines)
            {
                if (line == "int main()" || line == "void main()")
                {
                    break;
                }
                i++;
            }
            i++;
            long address = 1000;
            while (i < codeLines.Length)
            {
                // Console.WriteLine(codeLines[i]);
                codeLines[i] += "        ";
                if (codeLines[i].Substring(0, 5).Contains("int"))
                {
                    string[] vars = codeLines[i].Substring(4).Replace(';', ' ').Split(',');
                    foreach (var x in vars)
                    {
                        Console.WriteLine("INTEGER   | " + "4 Bytes | " + (address += 4).ToString() + "      | " + x.Trim());
                    }
                }
                else if (codeLines[i].Substring(0, 5).Contains("char"))
                {
                    string[] vars = codeLines[i].Substring(5).Replace(';', ' ').Split(',');
                    foreach (var x in vars)
                    {
                        Console.WriteLine("CHAR      | " + "1 Bytes | " + (address += 1).ToString() + "      | " + x.Trim());
                    }
                }
                else if (codeLines[i].Substring(0, 7).Contains("float"))
                {
                    string[] vars = codeLines[i].Substring(6).Replace(';', ' ').Split(',');
                    foreach (var x in vars)
                    {
                        Console.WriteLine("FLOAT     | " + "4 Bytes | " + (address += 4).ToString() + "      | " + x.Trim());
                    }
                }
                else if (codeLines[i].Substring(0, 7).Contains("double"))
                {
                    string[] vars = codeLines[i].Substring(7).Replace(';', ' ').Split(',');
                    foreach (var x in vars)
                    {
                        Console.WriteLine("DOUBLE    | " + "8 Bytes | " + (address += 8).ToString() + "      | " + x.Trim());
                    }
                }
                i++;
            }
        }
    }
}
