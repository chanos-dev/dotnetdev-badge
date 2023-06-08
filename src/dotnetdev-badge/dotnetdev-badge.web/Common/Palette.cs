namespace DotNetDevBadgeWeb.Common
{
    internal static class Palette
    {
        private static readonly Dictionary<ETheme, ColorSet> _colorSets;

        static Palette()
        {
            _colorSets = new()
            {
                { ETheme.Light, new ColorSet("222222", "FFFFFF") },
                { ETheme.Dark, new ColorSet("FFFFFF", "222222") },
                { ETheme.Dotnet, new ColorSet("FFFFFF", "6E20A0") },
            };
        }

        public static ColorSet GetColorSet(ETheme theme) => _colorSets[theme];

        public static string GetTrustColor(ELevel level) => level switch
        {
            ELevel.Bronze => "CD7F32",
            ELevel.Silver => "C0C0C0",
            ELevel.Gold => "E7C300",
            _ => "CD7F32",
        };
    }

    internal class ColorSet
    {
        internal string FontColor { get; private set; }
        internal string BackgroundColor { get; private set; }

        internal ColorSet(string fontColor, string backgroundColor)
        {
            FontColor = fontColor;
            BackgroundColor = backgroundColor;
        }
    }
}
