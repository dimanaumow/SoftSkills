using System.Runtime.InteropServices;
using System.Text;

namespace TransformToIEEE754
{
    public static class Converter
    {
        public static string ConvertToIeee754(this double number)
        {
            UnionMemory union = new UnionMemory();
            union.number = number;
            long item = union.item;

            long mask = 1; 
            StringBuilder sb = new StringBuilder();




            string temp; 
            for (int i = 63; i >= 0; i--)
            {
                item = (mask >> i) & 1;
                temp = item.ToString();

                sb.Append(temp);

            }

            return sb.ToString();

        }
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct UnionMemory
    {
        [FieldOffset(0)] public double number;
        [FieldOffset(0)] public long item;
    }
}