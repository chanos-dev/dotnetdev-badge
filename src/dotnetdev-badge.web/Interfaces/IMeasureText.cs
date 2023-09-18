namespace DotNetDevBadgeWeb.Interfaces
{
    interface IMeasureText
    {
        bool IsMediumIdWidthGreater(string id, out float addedWidth);
    }

    interface IMeasureTextV1 : IMeasureText { }
}
