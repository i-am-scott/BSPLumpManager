using System;
using System.Runtime.InteropServices;

namespace BSPLumpManager.BSPReader
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    public class SetLumpType : Attribute
    {
        public LumpType lump_t;
        public int bytes;
        public SetLumpType(LumpType lump_t, int bytesPerBlock)
        {
            this.lump_t = lump_t;
            this.bytes = bytesPerBlock;
        }
    }

    public struct Header
    {
        public string ident;
        public int version;
        public lump_t[] lumps;             // 64
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

    public class BrushObject
    {

    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct Vector
    {
        [MarshalAs(UnmanagedType.R4)]
        public float X;
        [MarshalAs(UnmanagedType.R4)]
        public float Y;
        [MarshalAs(UnmanagedType.R4)]
        public float Z;
    }
    
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi), SetLumpType(LumpType.PLANES, 20)]
    public struct dplane_t
    {
        [MarshalAs(UnmanagedType.Struct)]
        public Vector normal;
        [MarshalAs(UnmanagedType.R4)]
        public float dist;
        [MarshalAs(UnmanagedType.I4)]
        public int type;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi), SetLumpType(LumpType.VERTEXES, 12)]
    public struct vertext
    {
        [MarshalAs(UnmanagedType.Struct)]
        public Vector pos;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi), SetLumpType(LumpType.EDGES, 4)]
    public struct dedge_t
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public ushort[] v;
    }

    // Positive - First to second edge index. Negative - Second to first edge index. Absolute number is the index of the edge.
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi), SetLumpType(LumpType.SURFEDGES, 4)]
    public struct surfedge
    {
        [MarshalAs(UnmanagedType.I4)]
        public int indexAndDirection;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi), SetLumpType(LumpType.FACES, 56)]
    public struct dface_t
    {
        [MarshalAs(UnmanagedType.U2)]
        public ushort planenum;                         // the plane number

        public byte side;                               // faces opposite to the node's plane direction
        public byte onNode;                             // 1 of on node, 0 if in leaf

        [MarshalAs(UnmanagedType.I4)]
        public int firstedge;                           // index into surfedges

        [MarshalAs(UnmanagedType.I2)]
        public short numedges;                          // number of surfedges

        [MarshalAs(UnmanagedType.I2)]
        public short texinfo;                           // texture info

        [MarshalAs(UnmanagedType.I2)]
        public short dispinfo;                          // displacement info

        [MarshalAs(UnmanagedType.I2)]
        public short surfaceFogVolumeID;                // ?

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] styles;                          // switchable lighting info, 4

        [MarshalAs(UnmanagedType.I4)]
        public int lightofs;                            // offset into lightmap lump

        [MarshalAs(UnmanagedType.R4)]
        public float area;                              // face area in units^2

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public int[] LightmapTextureMinsInLuxels;       // texture lighting info, 2

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public int[] LightmapTextureSizeInLuxels;       // texture lighting info, 2

        [MarshalAs(UnmanagedType.I4)]
        public int origFace;                            // original face this was split from

        [MarshalAs(UnmanagedType.U2)]
        public ushort numPrims;                         // primitives

        [MarshalAs(UnmanagedType.U2)]
        public ushort firstPrimID;

        [MarshalAs(UnmanagedType.U4)]
        public uint smoothingGroups;                    // lightmap smoothing group
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi), SetLumpType(LumpType.BRUSHES, 12)]
    public struct dbrush_t
    {
        [MarshalAs(UnmanagedType.I4)]
        public int firstside;

        [MarshalAs(UnmanagedType.I4)]
        public int numsides;

        [MarshalAs(UnmanagedType.I4)]
        public int contents;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi), SetLumpType(LumpType.BRUSHSIDES, 8)]
    public struct dbrushside_t
    {
        [MarshalAs(UnmanagedType.U2)]
        public ushort planenum;      // facing out of the leaf

        [MarshalAs(UnmanagedType.U2)]
        public short texinfo;      // texture info

        [MarshalAs(UnmanagedType.U2)]
        public short dispinfo;     // displacement info

        [MarshalAs(UnmanagedType.U2)]
        public short bevel;     // is the side a bevel plane?
    }
}
