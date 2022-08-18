using System;


namespace IPConverter
{
    internal class Berechnung
    {
        string _Ip;
        string _BinärIp;
        string _DecimalBroadcast;
        string _BinärBroadcast;
        string _DecimalMask;
        string _BinärMask;
        string _DecimalNetId;
        string _BinärNetId;
        string _DecimalMinIp;
        string _BinärMinIp;
        string _DecimalMaxIp;
        string _BinärMaxIp;
        int _Prefix;
        public Berechnung(string ip, int prefix)
        {
            Ip = ip;
            Prefix = prefix;
            BinärIp = BinIPv4(ip);
            BinärBroadcast = BinBroadcast(BinärIp, Prefix);
            DecimalBroadcast = BinToDecimal(BinärBroadcast);
            BinärMask = BinMask(Prefix);
            DecimalMask = BinToDecimal(BinärMask);
            BinärNetId = BinNet(BinärIp, Prefix);
            DecimalNetId = BinToDecimal(BinärNetId);
            BinärMaxIp = LastIp(BinärBroadcast);
            DecimalMaxIp = BinToDecimal(BinärMaxIp);
            BinärMinIp = FirstIp(BinärNetId);
            DecimalMinIp = BinToDecimal(BinärMinIp);

        }


        //Getter und Setter
        public string Ip { get  => _Ip; set => _Ip = value; }
        public string BinärIp { get => _BinärIp; set => _BinärIp = value; }
        public string DecimalBroadcast { get => _DecimalBroadcast; set => _DecimalBroadcast = value; }
        public string BinärBroadcast { get => _BinärBroadcast; set => _BinärBroadcast = value; }
        public string DecimalMask { get => _DecimalMask; set => _DecimalMask = value; }
        public string BinärMask { get => _BinärMask; set => _BinärMask = value; }
        public string DecimalNetId { get => _DecimalNetId; set => _DecimalNetId = value; }
        public string BinärNetId { get => _BinärNetId; set => _BinärNetId = value; }
        public string DecimalMinIp { get => _DecimalMinIp; set => _DecimalMinIp = value; }
        public string BinärMinIp { get => _BinärMinIp; set => _BinärMinIp = value; }
        public string DecimalMaxIp { get => _DecimalMaxIp; set => _DecimalMaxIp = value; }
        public string BinärMaxIp { get => _BinärMaxIp; set => _BinärMaxIp = value; }
        public int Prefix { get => _Prefix; set => _Prefix = value; }

        //Umwandlung der eingegebenen Ip in eine Binärip
        string BinIPv4(string ip)
        {
            string[] ipArr = ip.Split('.');
            int[] intArr = new int[4];
            string[] binArr = new string[4];

            for (int i = 0; i <= ipArr.Length - 1; i++)
            {
                intArr[i] = Convert.ToInt32(ipArr[i]);
            }
            for (int i = 0; i < intArr.Length; i++)
            {
                //Umwandlug in Binär
                binArr[i] = Convert.ToString(intArr[i], 2);
            }
            for (int i = 0; i < binArr.Length; i++)
            {
                if (binArr[i].Length < 8)
                {
                    string temp = new string('0', 8 - binArr[i].Length) + binArr[i]; // Füllt leere Stellen im Oktet auf
                    binArr[i] = temp;
                }
            }
            return string.Join(" ", binArr);
        }

        // Umwandlung von Binärer Ip und Prefix zu einer Binären Broadcast
        string BinBroadcast(string binIp, int prefix)
        {
            string subBinIP = binIp.Replace(" ", "");
            string _subBinIp = new string('1', 32 - prefix);
            subBinIP = subBinIP.Substring(0, prefix) + _subBinIp;
            for (int i = 8; i <= subBinIP.Length; i += 8)
            {
                subBinIP = subBinIP.Insert(i, " "); //fügt alle 8 zeichen ein Leerzeichen hinzu
                i++;
            }
            return subBinIP;
        }

        //Allgemeine umwandlung von Binär zu Dezimal
        string BinToDecimal(string bin)
        {
            var binArr = bin.Split(' ');
            int[] _decimal = new int[4];
            for (int i = 0; i <= 3; i++)
            {
                _decimal[i] = Convert.ToInt32(binArr[i], 2);
            }
            return string.Join(' ', _decimal);

        }

        //SubnetMask in Binär anhand des Prefix
        string BinMask(int prefix)
        {
            int maxPrefix = 32;
            int mask = maxPrefix - prefix;

            // Prefix mal die 0 und der rest 11 im bereich von 32
            string prefixStr = new string('1', prefix) + new string('0', mask); ;

            for (int i = 8; i <= prefixStr.Length; i += 8)
            {
                prefixStr = prefixStr.Insert(i, " "); //fügt alle 8 zeichen ein Leerzeichen hinzu
                i++;
            }
            return prefixStr;
        }
        string BinNet(string binIp, int prefix)
        {
            string subNetId = binIp.Replace(" ", "");
            string _subNetId = new string('0', 32 - prefix);
            subNetId = subNetId.Substring(0, prefix) + _subNetId;
            for (int i = 8; i <= subNetId.Length; i += 8)
            {
                subNetId = subNetId.Insert(i, " "); //fügt alle 8 zeichen ein Leerzeichen hinzu
                i++;
            }
            return subNetId;
        }

        //
        string LastIp(string binBroadcast)
        {
            string lastIp = binBroadcast.Substring(0, binBroadcast.Length - 2) + "0";

            return lastIp;
        }

        //
        string FirstIp(string binNetId)
        {
            string firstIp = binNetId.Substring(0, binNetId.Length - 2) + "1";

            return firstIp;
        }

    }



}
