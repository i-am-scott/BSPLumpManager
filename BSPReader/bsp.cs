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

        public BSP(string fileName)
        {
            if (!File.Exists(fileName))
                return;

            Directory.CreateDirectory("data/" + fileName.Substring(0, fileName.Length - 3));
            CreateHeader(fileName);
        }

        private void CreateHeader(string fileName)
        {
            using (BinaryReader br = new BinaryReader(File.Open(fileName, FileMode.Open, FileAccess.Read)))
            {
                FileName = fileName;
                header   = new Header()
                {
                    ident = Encoding.ASCII.GetString(br.ReadBytes(4)),
                    version = br.ReadInt32(),
                    lumps = new lump_t[64]
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
            string file_path = "data/" + FileName.Substring(0, FileName.Length - 3) + "/" + typeof(T).Name + ".json";
            string data;

            data = JsonConvert.SerializeObject(lumpdata);
            File.WriteAllText(file_path, data, Encoding.Default);
            return lumpdata;
        }

        public List<KeyValueGroup> GetEntities()
            => Parser.Parse(Encoding.ASCII.GetString(header.lumps[0].chunk));
 
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
