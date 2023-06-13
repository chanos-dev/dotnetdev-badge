using DotNetDevBadgeWeb.Interfaces;

namespace DotNetDevBadgeWeb.Core.MeasureText
{ 
    internal class MeasureTextV1 : IMeasureTextV1
    {
        private const float HANGUL_WIDTH = 10f;
        private const float NUMBER_WIDTH = 5.5078125f;

        private readonly Dictionary<char, float> SPECIFIC_CHAR_WIDTH;

        private readonly float[] LOWERCASE_WIDTH;
        private readonly float[] UPPERCASE_WIDTH;

        public MeasureTextV1()
        {
            SPECIFIC_CHAR_WIDTH = new()
            {
                { '_',  4.150390625f },
                { '-',  4.072265625f },
                { '.',  3.1982421875f },
            };

            LOWERCASE_WIDTH = new[]
            {
                5.6103515625f,
                6.4208984375f,
                4.951171875f,
                6.4208984375f,
                5.6005859375f,
                4.3115234375f,
                6.4208984375f,
                6.171875f,
                3.0810546875f,
                3.0810546875f,
                5.927734375f,
                3.0810546875f,
                9.501953125f,
                6.259765625f,
                6.337890625f,
                6.4208984375f,
                6.4208984375f,
                4.3603515625f,
                4.8291015625f,
                4.169921875f,
                6.259765625f,
                5.87890625f,
                8.4521484375f,
                6.2109375f,
                5.7421875f,
                5.087890625f
            };

            UPPERCASE_WIDTH = new[]
            {
                7.5f,
                6.9091796875f,
                6.298828125f,
                7.587890625f,
                5.517578125f,
                5.41015625f,
                7.2705078125f,
                8.0224609375f,
                3.486328125f,
                5.1123046875f,
                6.8994140625f,
                5.41015625f,
                9.8681640625f,
                8.1201171875f,
                7.6513671875f,
                6.5576171875f,
                7.6513671875f,
                6.8212890625f,
                5.7177734375f,
                6.3623046875f,
                7.40234375f,
                7.021484375f,
                10.5322265625f,
                7.021484375f,
                6.4990234375f,
                6.4111328125f
            };
        }

        public bool IsMediumIdWidthGreater(string id, out float idWidth)
        {
            idWidth = 0f;

            if (id.Length <= 8) 
                return false;

            idWidth = id.Sum(c =>
            {
                if (char.IsNumber(c))
                    return NUMBER_WIDTH;

                if (char.IsUpper(c))
                    return UPPERCASE_WIDTH[c - 'A'];

                if (char.IsLower(c))
                    return LOWERCASE_WIDTH[c - 'a'];

                if (SPECIFIC_CHAR_WIDTH.ContainsKey(c))
                    return SPECIFIC_CHAR_WIDTH[c];

                return HANGUL_WIDTH;
            }); 

            return true;
        } 
    }
} 