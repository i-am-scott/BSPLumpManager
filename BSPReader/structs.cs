namespace BSPLumpManager.BSPReader
{
	public struct Header
	{
		public string ident;
		public int version;
		public lump_t[] lumps;             // 64
		public lump_t entlump;
		public int mapRevision;
	}

	public class lump_t
	{
		public int fileoffset;
		public int filelength;
		public int version;
		public byte[] uncompressedLength;   // 4
		public byte[] chunk;
	}
}