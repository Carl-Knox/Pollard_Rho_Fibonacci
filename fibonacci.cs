using System;       // MicroSoft Visual Studio Express 2015 for Windows Desktop
using System.Numerics;              // needed for BigInteger
using System.Windows.Forms;         // needed for Clipboard

namespace Pollard_Rho_Fibonacci
{   class Program
    {   [STAThread]                 // needed for Clipboard
        static void Main()
        {
            /* Variables ********************************************************************/
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            BigInteger a, b, c, g, n, r, s, t;
            
            /* Assign Data ******************************************************************/
            n = 339850094323758691;                 // 764567807 444499613 (~11:13 minutes)
            s = 1;                                  // default factor
            a = 0; b = 1;                           // fibonacci seeds
            g = 0;                                  // offset
            Console.WriteLine("\n\t Pollard's Rho Parallel Fibonacci Factoring\n\n {0}", n);
            
            /* Algorithm ********************************************************************/
            do
            {   c = a + b; a = b; b = c;                                // fibonacci sequencer
                s = c + g;                                              // add any offset
                if(s > n) { g = s = s % n; a = 0; b = 1;}               // assign offset to 'g'
                for (t = n; t != 0; t = r) { r = s % t; s = t;}         // s = GCD(s, n)
            } while (s == 1);
            
            /* Output Data ******************************************************************/
            Console.WriteLine("\n factor = {0}\n", s);
            Console.WriteLine(" Press <Enter> to write to Clipboard");
            Console.Read(); Console.Read();
            sb.Append(n / s + "\n"); sb.Append(s + "\n");               // store in a string
            Clipboard.SetText(sb.ToString());                           // output to clipboard
            Console.Read();
        } // end of Main
    } // end Program
} // end namespace
