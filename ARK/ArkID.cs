using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using BarcodeLib;
using BarcodeStandard;

namespace ARK
{
	class ArkID
	{

		/*	
		 *	The ARK ID is an UNIQUE access key which is NOT to be changed during lifetime of a document.
		 *	
		 *	If you wish to change the Prefix of a document, please file a new entry into the system. The old entry may remain for archival purposes or can be removed.
		 *	
		 *	Classification level is stored in META and may change during lifetime of the entity, thus its not part of the unique ARK ID
		*/

		// Prefix Three letters
		public string prefix;
		// Additional ID elaborating on the prefix, can be SCP number, department ID and alike
		public int prefixID;
		// Type of entry specifying document type (Possibly in relation to the PrefixID (Addendum, Core etc.))
		public char subType;
		// Unique auto-generated key
		public int id;


		string output;

		public ArkID(Type prefix, int prefixID, Category subType, int id)
		{
			// To-do Add proper validation

			// Assign prefix
			this.prefix = getTypePrefix(prefix);

			// Assign PrefID
			this.prefixID = prefixID;

			// Assign Category
			this.subType = getCategoryPrefix(subType);

			// Assign CategorzID
			this.id = id;
		}

		public override string ToString()
		{
			output = prefix.ToString() + prefixID.ToString("D4") + subType + id.ToString("D8");
			return output;
		}

		public void getBarcode()
		{
			try
			{
				Barcode DataMatrix = new Barcode(output, TYPE.CODE128);
				DataMatrix.SaveImage("ARKID_" + output, SaveTypes.PNG);
			}
			catch (Exception we)
			{
				throw (we);
			}
		}

		public void getMatrix()
		{
			try
			{
				Console.WriteLine("BEGIN");
				BarcodeStandard.SaveData sD = new SaveData();
				sD.EncodedValue = output;
				sD.IncludeLabel = true;
				Console.WriteLine(sD.RawData.Length);
				Console.WriteLine(sD.Image.Length);
			
			}
			catch (Exception we)
			{
				throw (we);
			}
		}


		public string getTypePrefix(Type type)
		{
			switch (type)
			{
				case Type.SCP:
					{
						return "SCP";
					}
				case Type.DEPARTMENTS:
					{
						return "DEP";
					}
				case Type.REDACTED:
					{
						return "RED";
					}
				case Type.ARCHIVEONLY:
					{
						return "ARC";
					}
				case Type.EXTERNAL:
					{
						return "EXT";
					}
				case Type.NOCLASS:
					{
						return "NOC";
					}

			}
			return null;
		}

		public char getCategoryPrefix(Category cat)
		{
			switch (cat)
			{
				case Category.CORE:
					{
						return 'C';
					}
				case Category.ADDENDUM:
					{
						return 'A';
					}
				case Category.MEDIA:
					{
						return 'M';
					}
			}
			return ' ';
		}

		/*
		public Image getBarcode()
		{
			BarcodeLib.Barcode b = new BarcodeLib.Barcode();
			return b.Encode(BarcodeLib.TYPE.UPCA, "038000356216", Color.Black, Color.White, 290, 120);
		}
		*/







	}
}
