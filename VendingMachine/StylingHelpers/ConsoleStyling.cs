using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.StylingHelpers
{
    class ConsoleStyling
    {
        static readonly int DisplayWidth = Console.WindowWidth;
        
        public static void HorizontalLine()
        {
            string ToWrite = new string('-', DisplayWidth);
            Console.WriteLine(ToWrite);
        }

        internal static void VerticalSpace()
        {
            Console.WriteLine();
        }

        internal static void CenteredText(string text)
        {
            int PaddingSize = (DisplayWidth / 2) - (text.Length / 2);
            string Padding = new string(' ', PaddingSize);
            string ToWrite = string.Format("{0}{1}{2}", Padding, text, Padding);
            Console.WriteLine(ToWrite);
        }
    }
}
