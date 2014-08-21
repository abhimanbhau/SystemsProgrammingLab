using System;
using System.IO;
using System.Linq;

namespace MacroAssembler
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("TYPE      | Size    | Adress    | Identifier ");
            Console.WriteLine();
            if (args.Length == 0) return;
            string[] codeLines = File.ReadAllLines(args[0]);
            int i = codeLines.TakeWhile(line => line != "int main()" && line != "void main()").Count();
            i++;
            long address = 1000;
            while (i < codeLines.Length)
            {
                codeLines[i] += "        ";
                if (codeLines[i].Substring(0, 5).Contains("int"))
                {
                    string[] vars = codeLines[i].Substring(4).Replace(';', ' ').Split(',');
                    foreach (string x in vars)
                    {
                        if (x.Contains("="))
                        {
                            Console.WriteLine("INTEGER   | " + "4 Bytes | " + (address += 4) + "      | " +
                                              x.Remove(x.IndexOf('=')).Trim());
                        }
                        else
                        {
                            Console.WriteLine("INTEGER   | " + "4 Bytes | " + (address += 4) + "      | " + x.Trim());
                        }
                    }
                }
                else if (codeLines[i].Substring(0, 5).Contains("char"))
                {
                    string[] vars = codeLines[i].Substring(5).Replace(';', ' ').Split(',');
                    foreach (string x in vars)
                    {
                        if (x.Contains("="))
                        {
                            Console.WriteLine("CHAR      | " + "1 Bytes | " + (address += 1) + "      | " +
                                              x.Remove(x.IndexOf('=')).Trim());
                        }
                        else
                        {
                            Console.WriteLine("CHAR      | " + "1 Bytes | " + (address += 1) + "      | " + x.Trim());
                        }
                    }
                }
                else if (codeLines[i].Substring(0, 7).Contains("float"))
                {
                    string[] vars = codeLines[i].Substring(6).Replace(';', ' ').Split(',');
                    foreach (string x in vars)
                    {
                        if (x.Contains("="))
                        {
                            Console.WriteLine("FLOAT     | " + "4 Bytes | " + (address += 4) + "      | " +
                                              x.Remove(x.IndexOf('=')).Trim());
                        }
                        else
                        {
                            Console.WriteLine("FLOAT     | " + "4 Bytes | " + (address += 4) + "      | " + x.Trim());
                        }
                    }
                }
                else if (codeLines[i].Substring(0, 7).Contains("double"))
                {
                    string[] vars = codeLines[i].Substring(7).Replace(';', ' ').Split(',');
                    foreach (string x in vars)
                    {
                        if (x.Contains("="))
                        {
                            Console.WriteLine("DOUBLE    | " + "8 Bytes | " + (address += 8) + "      | " +
                                              x.Remove(x.IndexOf('=')).Trim());
                        }
                        else
                        {
                            Console.WriteLine("DOUBLE    | " + "8 Bytes | " + (address += 8) + "      | " + x.Trim());
                        }
                    }
                }
                i++;
            }
        }
    }
}