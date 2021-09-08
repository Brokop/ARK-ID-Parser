using System;

namespace ARK
{
    class Program
    {
        static void Main(string[] args)
        {
            ArkTool at = new ArkTool();

            at.setString(Type.REDACTED, 0001, Category.CORE, 0);
            at.getBarcode();
            Console.WriteLine("End");

        }
    }
}
