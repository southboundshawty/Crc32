using System.Text;

namespace Crc32;

public static class Crc32Extensions
{
    private static readonly object Lock = new ();
    private static uint[]? _crc32Table;

    public static string ToCrc32(this string input)
    {
        if (_crc32Table == null)
        {
            lock (Lock)
            {
                _crc32Table ??= GenerateCrc32Table();
            }
        }

        var inputBytes = Encoding.UTF8.GetBytes(input);
        var inputLength = inputBytes.Length;
        var crc = 0xffffffff;

        for (var i = 0; i < inputLength; i++)
        {
            crc = (crc >> 8) ^ _crc32Table[inputBytes[i] ^ (crc & 0xff)];
        }

        crc ^= 0xffffffff;

        return crc.ToString("x8");
    }

    private static uint[] GenerateCrc32Table()
    {
        var table = new uint[256];

        for (var i = 0; i < 256; i++)
        {
            var c = (uint)i;
            
            for (var j = 0; j < 8; j++)
            {
                c = (c & 1) == 1 ? (c >> 1) ^ 0xedb88320 : c >> 1;
            }
            
            table[i] = c;
        }

        return table;
    }
}