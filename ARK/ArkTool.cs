using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using BarcodeLib;


namespace ARK
{
	static class ArkTool
	{

		/*	
		 *	The ARK ID is an UNIQUE access key which is NOT to be changed during lifetime of a document.
		 *	
		 *	If you wish to change the Prefix of a document, please file a new entry into the system. The old entry may remain for archival purposes or can be removed.
		 *	
		 *	Classification level is stored in META and may change during lifetime of the entity, thus its not part of the unique ARK ID
		*/

		static public Image getBarcode(ArkID key)
		{

			BarcodeLib.Barcode b = new BarcodeLib.Barcode();
			return b.Encode(BarcodeLib.TYPE.CODE128, key.ToString(), Color.Black, Color.White, 290, 120);

		}

		static public Image getMatrix(ArkID key)
		{
			try
			{

				DataMatrix.net.DmtxImageEncoder DIE = new DataMatrix.net.DmtxImageEncoder();
				DataMatrix.net.DmtxImageEncoderOptions DIEO = new DataMatrix.net.DmtxImageEncoderOptions();
				Bitmap btm = DIE.EncodeImage(key.ToString(), DIEO);
				return btm;

			}
			catch (Exception we)
			{
				throw (we);
			}
		}


	}


	public enum Type
	{
		// Documents treating SCP as a leading topic
		SCP,

		// Documentns treating Foundation departments as a leading topic
		DEPARTMENTS,

		// Documents which are directed outside of the foundation 
		EXTERNAL,

		// Documents stored only for the purpose of preservation
		ARCHIVEONLY,

		// Documents so confidential its topic is deemed redacted
		REDACTED,

		// NOT FOR CLASSIFICATION
		NOCLASS
	}

	public enum Category
	{
		// Main document regarding topic in type
		CORE,

		// Additional document spanning from CORE
		ADDENDUM,

		// Accompanying media
		MEDIA,

		// Presentating type
		PRESENTATION,

	}


}
