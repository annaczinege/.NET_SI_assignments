using System.ComponentModel;

namespace HandsOnLab1.ClientEntities
{
    /// <summary>
    /// Australian states contains current states of Australia.
    /// </summary>
    public enum AustralianStates
    {
#pragma warning disable SA1602 // Enumeration items should be documented
        [Description("Australian Capital Terriory")]
        AustralianCapitalTerriory,

        [Description("New South Wales")]
        NewSouthWales,

        [Description("Northern Territory")]
        NorthernTerritory,

        [Description("Queensland")]
        Queensland,

        [Description("South Australia")]
        SouthAustralia,

        [Description("Tasmania")]
        Tasmania,

        [Description("Victoria")]
        Victoria,

        [Description("West Australia")]
        WestAustralia,
#pragma warning restore SA1602 // Enumeration items should be documented
    }
}
