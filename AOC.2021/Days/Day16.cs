using System.Text;

namespace AOC._2021.Days;

public class Day16
{
    public List<Packet> Packets = new();

    public long Part1(string input)
    {
        var binary = HexToBinary(input);
        Parse(binary);

        return Packets.Sum(p => p.VersionSum);
    }

    public int Part2(string[] input)
    {    
        throw new NotImplementedException();
    }

    private void Parse(string binary)
    {
        var data = binary;
        while (data.Any())
        {
            data = ParsePacket(data);
        }
    }

    private string ParsePacket(string data, long versionSum = 0, Packet? parent = null)
    {
        if (data.Length < 6)
        {
            return string.Empty;
        }

        var version = (int)BinaryToLong(data.Substring(0, 3));
        var type = (int)BinaryToLong(data.Substring(3, 3));
        versionSum += Convert.ToInt32(version);
        data = data.Substring(6);

        if (data.All(x => x == '0'))
        {
            return string.Empty;
        }

        var packet = new Packet
        {
            Version = version,
            VersionSum = versionSum,
            Type = type,
        };

        if (type == 4)
        {
            var literalBuilder = new StringBuilder();
            while(data.Substring(0, 1) != "0")
            {
                literalBuilder.Append(data.Substring(1, 4));
                data = data.Substring(5);
            }
            literalBuilder.Append(data.Substring(1, 4));
            data = data.Substring(5);

            var literalValue = BinaryToLong(literalBuilder.ToString());

            if (parent != null)
            {
                parent.Children.Add(new Packet
                {
                    Version = parent.Version,
                    VersionSum = versionSum,
                    Type = type,
                    LiteralValues = new List<long> { literalValue }
                });
            }
            else
            {
                packet.LiteralValues = new List<long> { literalValue };
                Packets.Add(packet);
            }
        }
        else
        {
            if (data.Length < 1)
            {
                return string.Empty;
            }

            var lengthTypeId = data.Substring(0, 1);
            data = data.Substring(1);

            packet.Type = int.Parse(data.Substring(0, 1));

            if (packet.Type == 0)
            {
                if (data.Length < 15)
                {
                    return string.Empty;
                }

                var length = (int)BinaryToLong(data.Substring(0, 15));
                data = data.Substring(15);

                var childData = data.Substring(0, length);
                data = data.Substring(length);

                var newPacket = new Packet
                {
                    Version = packet.Version,
                    Type = type                    
                };

                if (parent != null)
                {
                    parent.Children.Add(newPacket);
                }
                else
                {
                    Packets.Add(newPacket);
                }

                while(childData.Any(c => c == '1'))
                {
                    ParsePacket(childData, versionSum, newPacket);
                }

                return data;
            }

            if (packet.Type == 1)
            {
                if (data.Length < 11)
                {
                    return string.Empty;
                }

                var number = (int)BinaryToLong(data.Substring(0, 11));
                data = data.Substring(11);

                var parentOfChild = new Packet
                {
                    Version = version,
                    Type = type
                };

                if (parent == null)
                {
                    Packets.Add(parentOfChild);
                }
                else
                {
                    parent.Children.Add(parentOfChild);
                }

                for(var i = 0; i < number; i++)
                {
                    data = ParsePacket(data, versionSum, parentOfChild);
                }

                return data;
            }
        }

        return data;

    }

    private static string HexToBinary(string input)
    {
        return string.Join(string.Empty,
                input.Select(
                    c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2)
                        .PadLeft(4, '0')
                )
            );
    }

    private static long BinaryToLong(string input)
    {
        return Convert.ToInt64(input, 2);
    }

    private static bool HasNextLiteralPart(string data)
    {
        return data.Substring(0, 1) == "1";
    }

    public class Packet
    {
        public int Version { get; set; }
        public long VersionSum { get; set; }
        public int Type { get; set; }
        public List<long> LiteralValues { get; set; } = new List<long>();
        public List<Packet> Children { get; set; } = new List<Packet>();
    }
}

