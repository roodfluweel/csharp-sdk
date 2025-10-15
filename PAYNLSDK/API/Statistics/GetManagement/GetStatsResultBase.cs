using System.Text.Json;
using System.Text.Json.Serialization;
using System;
using System.Globalization;

namespace PayNLSdk.Api.Statistics.GetManagement;

/// <summary>
/// Class GetStatsResultBase.
/// </summary>
public abstract class GetStatsResultBase
{
    /// <summary>
    /// Gets or sets the login.
    /// </summary>
    /// <value>The login.</value>
    [JsonPropertyName("login")]
    public string Login { get; set; }

    /// <summary>
    /// Gets or sets the arr label list.
    /// </summary>
    /// <value>The arr label list.</value>
    [JsonPropertyName("arrLabelList")]
    public LabelList ArrLabelList { get; set; }

    /// <summary>
    /// Gets or sets the total.
    /// </summary>
    /// <value>The total.</value>
    [JsonPropertyName("totals")]
    public Totals Total { get; set; }

    /// <summary>
    /// Gets or sets the total rows.
    /// </summary>
    /// <value>The total rows.</value>
    [JsonPropertyName("totalRows")]
    public int TotalRows { get; set; }

    /// <summary>
    /// Gets or sets the page.
    /// </summary>
    /// <value>The page.</value>
    [JsonPropertyName("page")]
    public int Page { get; set; }

    /// <summary>
    /// Gets or sets the page data.
    /// </summary>
    /// <value>The page data.</value>
    [JsonPropertyName("pageData")]
    public Pagedata PageData { get; set; }

    /// <summary>
    /// Gets or sets the currency symbol.
    /// </summary>
    /// <value>The currency symbol.</value>
    [JsonPropertyName("currency_symbol")]
    public string CurrencySymbol { get; set; }

    /// <summary>
    /// Class LabelList.
    /// </summary>
    public class LabelList
    {
        /// <summary>
        /// Gets or sets the 4.
        /// </summary>
        /// <value>The 4.</value>
        [JsonPropertyName("4")]
        public _4 _4 { get; set; }
    }

    /// <summary>
    /// Class _4.
    /// </summary>
    public class _4
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [JsonPropertyName("name")]
        public string name { get; set; }

        /// <summary>
        /// Gets or sets the cols.
        /// </summary>
        /// <value>The cols.</value>
        [JsonPropertyName("cols")]
        public ColumnLabels ColumnLabels { get; set; }
    }

    /// <summary>
    /// Class Cols.
    /// </summary>
    public class ColumnLabels
    {
        /// <summary>
        /// Gets or sets the number.
        /// </summary>
        /// <value>The number.</value>
        [JsonPropertyName("num")]
        public string num { get; set; }

        /// <summary>
        /// Gets or sets the average pay.
        /// </summary>
        /// <value>The average pay.</value>
        [JsonPropertyName("avg_pay")]
        public string avg_pay { get; set; }

        /// <summary>
        /// Gets or sets the org.
        /// </summary>
        /// <value>The org.</value>
        [JsonPropertyName("org")]
        public string org { get; set; }

        /// <summary>
        /// Gets or sets the org vat.
        /// </summary>
        /// <value>The org vat.</value>
        [JsonPropertyName("org_vat")]
        public string org_vat { get; set; }

        /// <summary>
        /// Gets or sets the org ext.
        /// </summary>
        /// <value>The org ext.</value>
        [JsonPropertyName("org_ext")]
        public string org_ext { get; set; }

        /// <summary>
        /// Gets or sets the org tot.
        /// </summary>
        /// <value>The org tot.</value>
        [JsonPropertyName("org_tot")]
        public string org_tot { get; set; }

        /// <summary>
        /// Gets or sets the CST.
        /// </summary>
        /// <value>The CST.</value>
        [JsonPropertyName("cst")]
        public string cst { get; set; }

        /// <summary>
        /// Gets or sets the pay.
        /// </summary>
        /// <value>The pay.</value>
        [JsonPropertyName("pay")]
        public string pay { get; set; }
    }

    /// <summary>
    /// Class ColumnValues.
    /// </summary>
    public class ColumnValues
    {
        /// <summary>
        /// Gets or sets the number.
        /// </summary>
        /// <value>The number.</value>
        [JsonPropertyName("num")]
        public string num { get; set; }

        /// <summary>
        /// Gets or sets the average pay.
        /// </summary>
        /// <value>The average pay.</value>
        [JsonPropertyName("avg_pay")]
        public string avg_pay { get; set; }

        /// <summary>
        /// Gets or sets the org.
        /// </summary>
        /// <value>The org.</value>
        [JsonPropertyName("org")]
        public string org { get; set; }

        /// <summary>
        /// Gets or sets the org vat.
        /// </summary>
        /// <value>The org vat.</value>
        [JsonPropertyName("org_vat")]
        public string org_vat { get; set; }

        /// <summary>
        /// Gets or sets the org ext.
        /// </summary>
        /// <value>The org ext.</value>
        [JsonPropertyName("org_ext")]
        public string org_ext { get; set; }

        /// <summary>
        /// Gets or sets the org tot.
        /// </summary>
        /// <value>The org tot.</value>
        [JsonPropertyName("org_tot")]
        public string org_tot { get; set; }

        /// <summary>
        /// Gets or sets the CST.
        /// </summary>
        /// <value>The CST.</value>
        [JsonPropertyName("cst")]
        public string cst { get; set; }

        /// <summary>
        /// Gets or sets the pay.
        /// </summary>
        /// <value>The pay.</value>
        [JsonPropertyName("pay")]
        public string pay { get; set; }
    }

    /// <summary>
    /// Class Totals.
    /// </summary>
    public class Totals
    {
        /// <summary>
        /// Gets or sets the sub data - which is oddly called "4"
        /// </summary>
        /// <value>The 4.</value>
        [JsonPropertyName("4")] public Data _4 { get; set; }
    }

    /// <summary>
    /// Class Pagedata.
    /// </summary>
    public class Pagedata
    {
        /// <summary>
        /// Gets or sets the colors.
        /// </summary>
        /// <value>The colors.</value>
        [JsonPropertyName("pay")] public Colors colors { get; set; }
    }

    /// <summary>
    /// Class Colors.
    /// </summary>
    public class Colors
    {
        /// <summary>
        /// Gets or sets the color 1.
        /// </summary>
        /// <value>The color 1.</value>
        [JsonPropertyName("COLOR_1")] public string COLOR_1 { get; set; }
        /// <summary>
        /// Gets or sets the color 2.
        /// </summary>
        /// <value>The color 2.</value>
        [JsonPropertyName("COLOR_2")] public string COLOR_2 { get; set; }
        /// <summary>
        /// Gets or sets the color 3.
        /// </summary>
        /// <value>The color 3.</value>
        [JsonPropertyName("COLOR_3")] public string COLOR_3 { get; set; }
        /// <summary>
        /// Gets or sets the color 4.
        /// </summary>
        /// <value>The color 4.</value>
        [JsonPropertyName("COLOR_4")] public string COLOR_4 { get; set; }
        /// <summary>
        /// Gets or sets the color 5.
        /// </summary>
        /// <value>The color 5.</value>
        [JsonPropertyName("COLOR_5")] public string COLOR_5 { get; set; }
        /// <summary>
        /// Gets or sets the color 6.
        /// </summary>
        /// <value>The color 6.</value>
        [JsonPropertyName("COLOR_6")] public string COLOR_6 { get; set; }
        /// <summary>
        /// Gets or sets the color 7.
        /// </summary>
        /// <value>The color 7.</value>
        [JsonPropertyName("COLOR_7")] public string COLOR_7 { get; set; }
        /// <summary>
        /// Gets or sets the color 8.
        /// </summary>
        /// <value>The color 8.</value>
        [JsonPropertyName("COLOR_8")] public string COLOR_8 { get; set; }
        /// <summary>
        /// Gets or sets the color 9.
        /// </summary>
        /// <value>The color 9.</value>
        [JsonPropertyName("COLOR_9")] public string COLOR_9 { get; set; }
        /// <summary>
        /// Gets or sets the color 10.
        /// </summary>
        /// <value>The color 10.</value>
        [JsonPropertyName("COLOR_10")] public string COLOR_10 { get; set; }
        /// <summary>
        /// Gets or sets the color 11.
        /// </summary>
        /// <value>The color 11.</value>
        [JsonPropertyName("COLOR_11")] public string COLOR_11 { get; set; }
        /// <summary>
        /// Gets or sets the color 12.
        /// </summary>
        /// <value>The color 12.</value>
        [JsonPropertyName("COLOR_12")] public string COLOR_12 { get; set; }
        /// <summary>
        /// Gets or sets the color 13.
        /// </summary>
        /// <value>The color 13.</value>
        [JsonPropertyName("COLOR_13")] public string COLOR_13 { get; set; }
        /// <summary>
        /// Gets or sets the color 14.
        /// </summary>
        /// <value>The color 14.</value>
        [JsonPropertyName("COLOR_14")] public string COLOR_14 { get; set; }
        /// <summary>
        /// Gets or sets the color 15.
        /// </summary>
        /// <value>The color 15.</value>
        [JsonPropertyName("COLOR_15")] public string COLOR_15 { get; set; }
        /// <summary>
        /// Gets or sets the color 16.
        /// </summary>
        /// <value>The color 16.</value>
        [JsonPropertyName("COLOR_16")] public string COLOR_16 { get; set; }
        /// <summary>
        /// Gets or sets the color 17.
        /// </summary>
        /// <value>The color 17.</value>
        [JsonPropertyName("COLOR_17")] public string COLOR_17 { get; set; }
        /// <summary>
        /// Gets or sets the color 18.
        /// </summary>
        /// <value>The color 18.</value>
        [JsonPropertyName("COLOR_18")] public string COLOR_18 { get; set; }
        /// <summary>
        /// Gets or sets the color 19.
        /// </summary>
        /// <value>The color 19.</value>
        [JsonPropertyName("COLOR_19")] public string COLOR_19 { get; set; }
        /// <summary>
        /// Gets or sets the color 20.
        /// </summary>
        /// <value>The color 20.</value>
        [JsonPropertyName("COLOR_20")] public string COLOR_20 { get; set; }
        /// <summary>
        /// Gets or sets the color 21.
        /// </summary>
        /// <value>The color 21.</value>
        [JsonPropertyName("COLOR_21")] public string COLOR_21 { get; set; }
        /// <summary>
        /// Gets or sets the color 22.
        /// </summary>
        /// <value>The color 22.</value>
        [JsonPropertyName("COLOR_22")] public string COLOR_22 { get; set; }
        /// <summary>
        /// Gets or sets the color 23.
        /// </summary>
        /// <value>The color 23.</value>
        [JsonPropertyName("COLOR_23")] public string COLOR_23 { get; set; }
        /// <summary>
        /// Gets or sets the color 24.
        /// </summary>
        /// <value>The color 24.</value>
        [JsonPropertyName("COLOR_24")] public string COLOR_24 { get; set; }
        /// <summary>
        /// Gets or sets the color 25.
        /// </summary>
        /// <value>The color 25.</value>
        [JsonPropertyName("COLOR_25")] public string COLOR_25 { get; set; }
        /// <summary>
        /// Gets or sets the color 26.
        /// </summary>
        /// <value>The color 26.</value>
        [JsonPropertyName("COLOR_26")] public string COLOR_26 { get; set; }
        /// <summary>
        /// Gets or sets the color 27.
        /// </summary>
        /// <value>The color 27.</value>
        [JsonPropertyName("COLOR_27")] public string COLOR_27 { get; set; }
        /// <summary>
        /// Gets or sets the color 28.
        /// </summary>
        /// <value>The color 28.</value>
        [JsonPropertyName("COLOR_28")] public string COLOR_28 { get; set; }
        /// <summary>
        /// Gets or sets the color 29.
        /// </summary>
        /// <value>The color 29.</value>
        [JsonPropertyName("COLOR_29")] public string COLOR_29 { get; set; }
        /// <summary>
        /// Gets or sets the color 30.
        /// </summary>
        /// <value>The color 30.</value>
        [JsonPropertyName("COLOR_30")] public string COLOR_30 { get; set; }
        /// <summary>
        /// Gets or sets the color 31.
        /// </summary>
        /// <value>The color 31.</value>
        [JsonPropertyName("COLOR_31")] public string COLOR_31 { get; set; }
        /// <summary>
        /// Gets or sets the color 32.
        /// </summary>
        /// <value>The color 32.</value>
        [JsonPropertyName("COLOR_32")] public string COLOR_32 { get; set; }
        /// <summary>
        /// Gets or sets the color 33.
        /// </summary>
        /// <value>The color 33.</value>
        [JsonPropertyName("COLOR_33")] public string COLOR_33 { get; set; }
        /// <summary>
        /// Gets or sets the color 34.
        /// </summary>
        /// <value>The color 34.</value>
        [JsonPropertyName("COLOR_34")] public string COLOR_34 { get; set; }
        /// <summary>
        /// Gets or sets the color 35.
        /// </summary>
        /// <value>The color 35.</value>
        [JsonPropertyName("COLOR_35")] public string COLOR_35 { get; set; }
        /// <summary>
        /// Gets or sets the color 36.
        /// </summary>
        /// <value>The color 36.</value>
        [JsonPropertyName("COLOR_36")] public string COLOR_36 { get; set; }
    }

    /// <summary>
    /// Class StatsData.
    /// </summary>
    public class StatsData
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        [JsonPropertyName("Id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the grouped by.
        /// </summary>
        /// <value>The grouped by.</value>
        [JsonPropertyName("Label")]
        public string GroupedBy { get; set; }

        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>The data.</value>
        [JsonPropertyName("Data")]
        public StatsLine[] Data { get; set; }
    }

    /// <summary>
    /// Class StatsLine.
    /// </summary>
    public class StatsLine
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        [JsonPropertyName("Label")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>The data.</value>
        public Data Data { get; set; }
    }

    /// <summary>
    /// Class Data.
    /// </summary>
    public class Data
    {
        /// <summary>
        /// Gets or sets the sum.
        /// </summary>
        /// <value>The sum.</value>
        [JsonPropertyName("sum")]
        public decimal sum { get; set; }

        /// <summary>
        /// Gets or sets the costs
        /// </summary>
        /// <value>The CST.</value>
        [JsonPropertyName("cst")]
        public decimal cst { get; set; }

        /// <summary>
        /// Gets or sets the number of transactions
        /// </summary>
        /// <value>The number.</value>
        [JsonPropertyName("num")]
        public decimal num { get; set; }

        /// <summary>
        /// Gets or sets the average duration.  Probably the average duration of seconds in a transaction.
        /// </summary>
        /// <value>The average dur.</value>
        [JsonPropertyName("avg_dur")]
        public decimal avg_dur { get; set; }

        /// <summary>
        /// Gets or sets the average payout amount
        /// </summary>
        /// <value>The average pay.</value>
        [JsonPropertyName("avg_pay")]
        public decimal avg_pay { get; set; }

        /// <summary>
        /// Gets or sets the paid costs. <seealso cref="cst"/>
        /// </summary>
        /// <value>The pay.</value>
        [JsonPropertyName("pay")]
        public decimal pay { get; set; }

        /// <summary>
        /// Gets or sets the organization total.  Same as org_tot
        /// </summary>
        /// <value>The org.</value>
        [JsonPropertyName("org")]
        public string org { get; set; }

        /// <summary>
        /// Gets or sets the org vat.
        /// </summary>
        /// <value>The org vat.</value>
        [JsonPropertyName("org_vat")]
        public string org_vat { get; set; }

        /// <summary>
        /// Gets or sets the org ext.
        /// </summary>
        /// <value>The org ext.</value>
        [JsonPropertyName("org_ext")]
        public string org_ext { get; set; }

        /// <summary>
        /// Gets or sets the org tot.
        /// </summary>
        /// <value>The org tot.</value>
        [JsonPropertyName("org_tot")]
        public decimal org_tot { get; set; }
    }
}
