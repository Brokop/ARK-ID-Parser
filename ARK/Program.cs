using System;
using System.Drawing;
using System.IO;
namespace ARK
{
    class Program
    {
        static void Main(string[] args)
        {
            ArkID aID = new ArkID(Type.SCP, 93, Category.CORE, 1);
            Console.WriteLine(aID.ToString());
            Image ex = ArkTool.getBarcode(aID);
            ex.Save(Directory.GetCurrentDirectory() + "/" + "Arkid.png", System.Drawing.Imaging.ImageFormat.Png);
        }
    }
}
