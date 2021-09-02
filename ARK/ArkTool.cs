using System;
using System.Collections.Generic;
using System.Text;

namespace ARK
{
	class ArkTool
	{
		char[] prefix = new char[3];
		int prefixID;

		char subType;
		int id;

		string output;

		public int setString(Type prefix, int prefixID, Category subType, int ID)
		{
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

				case _:
					return null;
			}
			return null;

		}

	}


	public enum Type
	{
		SCP,
		DEPARTMENTS,
		EXTERNAL,
		ARCHIVEONLY,
		REDACTED
		
	}

	public enum Category
	{
		CORE,
		ADDENDUM,
		MEDIA,

	}
}
