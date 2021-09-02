using System;
using System.Collections.Generic;
using System.Text;

namespace ARK
{
	class ArkTool
	{

		/*	
		 *	The ARK ID is an UNIQUE access key which is NOT to be changed during lifetime of a document.
		 *	
		 *	If you wish to change the Prefix of a document, please file a new entry into the system. The old entry may remain for archival purposes or can be removed.
		 *	
		 *	Classification level is stored in META and may change during lifetime of the entity, thus its not part of the unique ARK ID
		*/


		// Prefix Three letters
		char[] prefix = new char[3];
		// Additional ID elaborating on the prefix, can be SCP number, department ID and alike
		int prefixID;
		// Type of entry specifying document type (Possibly in relation to the PrefixID (Addendum, Core etc.))
		char subType;
		// Unique auto-generated key
		int id;


		string output;

		public int setString(Type prefix, int prefixID, Category subType, int id)
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

			return 0;
		}

		public string toString()
		{

			return "";
		}


		public char[] getTypePrefix(Type type)
		{
			switch (type)
			{
				case Type.SCP:
					{
						return new char[] { 'S', 'C', 'P' };
					}
				case Type.DEPARTMENTS:
					{
						return new char[] { 'D', 'E', 'P' };
					}
				case Type.REDACTED:
					{
						return new char[] { 'R', 'E', 'D' };
					}
				case Type.ARCHIVEONLY:
					{
						return new char[] { 'A', 'R', 'C' };
					}
				case Type.EXTERNAL:
					{
						return new char[] { 'E', 'X', 'T' };
					}
				case Type.NOCLASS:
					{
						return new char[] { 'N', 'O', 'C' };
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
