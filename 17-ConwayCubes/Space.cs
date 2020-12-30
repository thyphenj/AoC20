using System.Drawing;
using System;

namespace _17_ConwayCubes
{
    public class Space
    {
        readonly int OFFSET = 12;
        private bool[,,] XYZ;
        int MinX, MaxX, MinY, MaxY, MinZ, MaxZ;

        public Space()
        {
            XYZ = new bool[25, 25, 25];

            MinX = OFFSET;
            MinY = OFFSET;
            MinZ = OFFSET;
            MaxX = OFFSET;
            MaxY = OFFSET;
            MaxZ = OFFSET;
        }

        internal void Set(int x, int y, int z, char ch)
        {
            int X = x + OFFSET, Y = y + OFFSET, Z = z + OFFSET;
            XYZ[X, Y, Z] = (ch == '#');
            if (XYZ[X, Y, Z])
            {
                if (X < MinX) MinX = X;
                if (Y < MinY) MinY = Y;
                if (Z < MinZ) MinZ = Z;
                if (X > MaxX) MaxX = X;
                if (Y > MaxY) MaxY = Y;
                if (Z > MaxZ) MaxZ = Z;
            }
        }

        internal void Set(int x, int y, int z, bool bVal)
        {
            XYZ[x, y, z] = bVal; ;
            if (XYZ[x, y, z])
            {
                if (x < MinX) MinX = z;
                if (y < MinY) MinY = y;
                if (z < MinZ) MinZ = z;
                if (x > MaxX) MaxX = x;
                if (y > MaxY) MaxY = y;
                if (z > MaxZ) MaxZ = z;
            }
        }
        internal void Iterate()
        {
            bool[,,] next = new bool[25, 25, 25];

            for (int z = 0; z < 25; z++)
            {
                for (int y = 0; y < 25; y++)
                {
                    for (int x = 0; x < 25; x++)
                    {
                        int n = CountNeighbours(x, y, z);
                        next[x, y, z] = (XYZ[x, y, z]) ? (n == 2 || n == 3) : (n == 3);
                    }
                }
            }

            for (int z = 0; z < 25; z++)
            {
                for (int y = 0; y < 25; y++)
                {
                    for (int x = 0; x < 25; x++)
                    {
                        Set(x, y, z, next[x, y, z]);
                    }
                }
            }
        }

        internal int CountNeighbours(int x, int y, int z)
        {
            int count = 0;
            foreach (var k in new int[] { -1, 0, 1 })
            {
                int zk = z + k;
                foreach (var j in new int[] { -1, 0, 1 })
                {
                    int yj = j + j;
                    foreach (var i in new int[] { -1, 0, 1 })
                    {
                        if (i != 0 || j != 0 || k != 0)
                        {
                            int xi = x + i;
                            if (xi >= 0 && yj >= 0 && zk >= 0 && xi < 25 && yj < 25 && zk < 25)
                                if (XYZ[xi, yj, zk])
                                    count++;
                        }
                    }
                }
            }
            return count;
        }

        internal int Accumulate()
        {
            int sum = 0;
            for (int z = 0; z < 25; z++)
            {
                for (int y = 0; y < 25; y++)
                {
                    for (int x = 0; x < 25; x++)
                    {
                        if (XYZ[x, y, z])
                            sum++;
                    }
                }
            }
            return sum;
        }

        public override string ToString()
        {
            string retval = "";

            for (int z = MinZ; z <= MaxZ; z++)
            {
                for (int y = MinY; y <= MaxY; y++)
                {
                    for (int x = MinX; x <= MaxX; x++)
                    {
                        retval += XYZ[x, y, z] ? "#" : ".";
                    }
                    retval += "\n";
                }
                retval += "\n";
            }

            return retval;
        }
    }
}
