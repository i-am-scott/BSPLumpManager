using BSPLumpManager.KVP;
using System;
using System.IO;
using System.Text;
using System.ComponentModel;

namespace BSPLumpManager.BSPReader
{
    public class BSP
    {
        protected bool headerReady;
        protected Header header;
        protected string FileName;
        protected string FilePath;

        public BindingList<KeyValueGroup> entities;

        public BSP(string file_path)
        {
            if (!File.Exists(file_path))
                return;

            FilePath = file_path;
            FileName = Path.GetFileName(file_path);

            CreateHeader(file_path);
        }

        private void CreateHeader(string file_path)
        {
            using (BinaryReader br = new BinaryReader(File.Open(file_path, FileMode.Open, FileAccess.Read)))
            {
                string identity = Encoding.ASCII.GetString(br.ReadBytes(4));
                if (identity != "VBSP")
                    throw new InvalidDataException("File is not a BSP or is malformed.");

                header = new Header()
                {
                    ident = identity,
                    version = br.ReadInt32(),
                };

                lump_t lump = new lump_t()
                {
                    fileoffset = br.ReadInt32(),
                    filelength = br.ReadInt32(),
                    version = br.ReadInt32(),
                    uncompressedLength = br.ReadBytes(4)
                };

                if (lump.fileoffset > 0 && lump.filelength > 0)
                {
                    long curPosition = br.BaseStream.Position;
                    br.BaseStream.Position = lump.fileoffset;
                    lump.chunk = br.ReadBytes(lump.filelength - 1);
                    br.BaseStream.Position = curPosition;
                }

                header.mapRevision = br.ReadInt32();
                header.entlump = lump;

                br.Close();
                headerReady = true;
            }
        }

        public BindingList<KeyValueGroup> GetEntities()
        {
            if (entities != null && entities.Count > 0)
                return entities;

            var ents = Parser.Parse(Encoding.ASCII.GetString(header.entlump.chunk));
            entities = new BindingList<KeyValueGroup>(ents);

            return entities;
        }

        private byte[] GetNewLumps()
        {
            string keep_text = "";
            for (int i = 0; i < entities.Count; i++)
            {
                var ent    = entities[i];
                keep_text += ent.enabled  ? ent.raw : "";
            }
            return Encoding.ASCII.GetBytes(keep_text);
        }

        public void SplitEntities()
        {
            using (FileStream f = File.OpenRead(FilePath))
            {
                using (FileStream nf = File.Create(FilePath.Replace(".bsp", "_new.bsp")))
                {
                    f.CopyTo(nf);
                    f.Close();

                    lump_t ent_lump = header.entlump;

                    byte[] clean_chunk = new byte[ent_lump.chunk.Length];
                    Array.Clear(clean_chunk, 0, clean_chunk.Length);

                    byte[] keep = GetNewLumps();
                    keep.CopyTo(clean_chunk,0);

                    using (BinaryWriter lmp_br = new BinaryWriter(File.Open(FilePath.Replace(".bsp", "_new_l_0.lmp"), FileMode.Create)))
                    {
                        lmp_br.Write(0x14);
                        lmp_br.Write(0);
                        lmp_br.Write(ent_lump.version);
                        lmp_br.Write(ent_lump.filelength);
                        lmp_br.Write(header.mapRevision);

                        lmp_br.BaseStream.Position = 0x14;
                        lmp_br.BaseStream.Write(ent_lump.chunk,0,ent_lump.chunk.Length);
                        lmp_br.Close();
                    }

                    nf.Position = ent_lump.fileoffset;
                    nf.Write(clean_chunk, 0, clean_chunk.Length);
                    nf.Close();
                }
            }
        }
 
        public override string ToString() =>
            string.IsNullOrEmpty(FileName) ?  "[BSPObject Empty]" :
            string.Format("[BSPObject: {0}, {1}, v{2}, r{3}]",
                FileName,
                header.ident,
                header.version,
                header.mapRevision);

    }
}
