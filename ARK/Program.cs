using System;
using System.Drawing;
using System.IO;

namespace ARK
{
    class Program
    {
        static void Main(string[] args)
        {
            ArkID aID = new ArkID(Type.REDACTED, 93, Category.ADDENDUM, 81);
            Console.WriteLine(aID.ToString());
            Image ex = ArkTool.getMatrix(aID);
            ex.Save(Directory.GetCurrentDirectory() + "/" + "Arkid.png", System.Drawing.Imaging.ImageFormat.Png);        
        }
    }
}
