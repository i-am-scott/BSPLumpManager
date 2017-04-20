using BSPLumpManager.KVP;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace BSPLumpManager.BSPReader
{
    public class BSP
    {
        protected bool headerReady;
        protected Header header;
        protected string FileName;
        protected string FilePath;

        public List<KeyValueGroup> entities = new List<KeyValueGroup>();

        public BSP(string file_path)
        {
            if (!File.Exists(file_path))
                return;

            FilePath = file_path;
            FileName = Path.GetFileName(file_path);

            Directory.CreateDirectory("data/" + FileName);
            CreateHeader(file_path);
        }

        private void CreateHeader(string file_path)
        {
            using (BinaryReader br = new BinaryReader(File.Open(file_path, FileMode.Open, FileAccess.Read)))
            {

                string identity = Encoding.ASCII.GetString(br.ReadBytes(4));
                if(identity != "VBSP")
                {
                    throw new InvalidDataException("File is not a BSP or is malformed.");
                }

                header   = new Header()
                {
                    ident   = identity,
                    version = br.ReadInt32(),
                    lumps   = new lump_t[64]
                };

                for (int I = 0; I < header.lumps.Length; I++)
                {
                    lump_t lump = new lump_t()
                    {
                        fileoffset         = br.ReadInt32(),
                        filelength         = br.ReadInt32(),
                        version            = br.ReadInt32(),
                        uncompressedLength = br.ReadBytes(4)
                    };

                    if (lump.fileoffset > 0 && lump.filelength > 0)
                    {
                        long curPosition       = br.BaseStream.Position;
                        br.BaseStream.Position = lump.fileoffset;
                        lump.chunk             = br.ReadBytes(lump.filelength-1);
                        br.BaseStream.Position = curPosition;
                    }
                    header.lumps[I] = lump;
                }

                header.mapRevision = br.ReadInt32();
                br.Close();
                headerReady = true;
            }
        }

        public T[] GetLump<T>() where T : new()
        {
            if (!headerReady) return default(T[]);

            LumpType lt   = typeof(T).GetCustomAttribute<SetLumpType>().lump_t;
            int chunkSize = typeof(T).GetCustomAttribute<SetLumpType>().bytes;

            lump_t lumpdefinition = header.lumps[(int)lt];

            if (lumpdefinition.chunk.Length == 0)
                return default(T[]);

            byte[] chunk   = lumpdefinition.chunk;
            int chunkCount = chunk.Length / chunkSize;
            T[] chunks     = new T[chunkCount];

            using (BinaryReader br = new BinaryReader(new MemoryStream()))
            {
                br.BaseStream.Write(chunk, 0, chunk.Length);
                br.BaseStream.Position = 0;

                for (int I = 0; I < chunkCount; I++)
                {
                    byte[] curBuffer = br.ReadBytes(chunkSize);

                    IntPtr intPtr = Marshal.AllocHGlobal(curBuffer.Length);
                    Marshal.Copy(curBuffer, 0, intPtr, curBuffer.Length);

                    T LumpStruct = (T)Marshal.PtrToStructure(intPtr, typeof(T));
                    chunks[I] = LumpStruct;

                    Marshal.FreeHGlobal(intPtr);
                }
                br.Close();
            }
            return chunks;
        }

        public T[] DumpLump<T>() where T : new()
        {
            T[] lumpdata     = GetLump<T>();
            string file_path = "data/" + FileName + "/" + typeof(T).Name + ".json";
            string data;

            data = JsonConvert.SerializeObject(lumpdata);
            File.WriteAllText(file_path, data, Encoding.Default);
            return lumpdata;
        }

        public List<KeyValueGroup> GetEntities()
        {
            if (entities.Count > 0)
                return entities;

            entities = Parser.Parse(Encoding.ASCII.GetString(header.lumps[0].chunk));
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

                    lump_t ent_lump = header.lumps[0];

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
                        lmp_br.Write(this.header.mapRevision);

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
 
        public override string ToString()
        {
            if (string.IsNullOrEmpty(FileName)) return "[BSPObject Empty]";

            return string.Format("[BSPObject: {0}, {1}, v{2}, r{3}]",
                FileName,
                header.ident,
                header.version,
                header.mapRevision);
        }
    }
}
