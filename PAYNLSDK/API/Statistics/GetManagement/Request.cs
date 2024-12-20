﻿using PayNLSdk.ExtentionMethods;
using PAYNLSDK.API;
using PAYNLSDK.Exceptions;
using PAYNLSDK.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics.CodeAnalysis;

namespace PayNLSdk.API.Statistics.GetManagement
{
    /// <summary>
    /// The parameters to be requested when requesting the management statistics
    /// </summary>
    public class Request : RequestBase
    {
        /// <summary>
        /// A predefined period to request statistics
        /// </summary>
        public enum StatsPeriod
        {
            /// <summary>
            /// Last week
            /// </summary>
            LastWeek,
            /// <summary>
            /// Current week
            /// </summary>
            ThisWeek,
            /// <summary>
            /// Last month
            /// </summary>
            LastMonth,
            /// <summary>
            /// Current month
            /// </summary>
            ThisMonth
        }

        /// <summary>
        /// Creates a new instance of a stats request
        /// </summary>
        /// <param name="dateTime">a current time implementation</param>
        /// <param name="period">The period for the request</param>
        public static Request Create(IDateTime dateTime, StatsPeriod period)
        {
            var retval = new Request();

            switch (period)
            {
                case StatsPeriod.LastWeek:
                    retval.StartDate = dateTime.Now.LastWeek(DayOfWeek.Monday);
                    retval.EndDate = retval.StartDate.AddDays(6);
                    break;
                case StatsPeriod.ThisWeek:
                    retval.StartDate = dateTime.Now.ThisWeek(DayOfWeek.Monday);
                    retval.EndDate = retval.StartDate.AddDays(6);
                    break;
                case StatsPeriod.LastMonth:
                    retval.StartDate = dateTime.Now.LastMonthFirstDay();
                    retval.EndDate = dateTime.Now.LastMonthLastDay();
                    break;
                case StatsPeriod.ThisMonth:
                    retval.StartDate = new DateTime(dateTime.Now.Year, dateTime.Now.Month, 1);
                    retval.EndDate = dateTime.Now;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(period), period, null);
            }

            return retval;
        }

        /// <summary>
        /// Creates a new instance of a stats request
        /// </summary>
        public Request()
        {
            ExcludeSandbox = true;
            Filters = new List<FilterItem>();
            GroupByFieldNames = new HashSet<string>();
        }

        /// <inheritdocs />
        protected override int Version => 5;
        /// <inheritdocs />
        protected override string Controller => "Statistics";
        /// <inheritdocs />
        protected override string Method => "management";

        /// <summary>
        /// the first date to be included in the report
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// The last date to be included in the Report
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Use this parameter to indicate whether to take your volume discount into account
        /// (note that this is an estimate based on your transactions this month. Default=false).
        /// </summary>
        public bool Staffels { get; set; }

        /// <summary>
        /// The currency in which the data is returned (default=1 : EUR)
        /// </summary>
        public int? CurrencyId { get; set; }

        /// <summary>
        /// This property can be used to filter events
        /// </summary>
        public List<FilterItem> Filters { get; set; }

        /// <summary>
        /// Use this field to sort the results
        /// </summary>
        internal HashSet<string> GroupByFieldNames { get; set; }

        /// <summary>
        /// Exclude calls from the sandbox.  Default = true
        /// </summary>
        public bool ExcludeSandbox { get; set; }

        /// <summary>
        /// Show turnover for: Own merchant, submerchants or all
        /// </summary>
        public CompanySelectEnum CompanySelect { get; set; }

        /// <inheritdocs />
        public override NameValueCollection GetParameters()
        {
            var retval = new NameValueCollection
            {
                { "startDate", StartDate.ToString("yyyy-MM-dd")},
                { "endDate", EndDate.ToString("yyyy-MM-dd")},
                { "staffels", Staffels.ToString()},
                { "CurrencyId", CurrencyId?.ToString()},
                { "company_select", CompanySelect.ToString().ToLower()}
            };

            retval.Add(GenerateFiltersNameValueCollection());
            retval.Add(GenerateGroupByClause());
            return retval;
        }

        private NameValueCollection GenerateGroupByClause()
        {
            var groupByNvc = new NameValueCollection();

            var i = 0;
            foreach (var sortByFieldName in GroupByFieldNames)
            {
                groupByNvc.Add($"groupBy[{i}]", sortByFieldName);
                i++;
            }

            return groupByNvc;
        }

        private NameValueCollection GenerateFiltersNameValueCollection()
        {
            var filterNvc = new NameValueCollection();

            var i = 0;

            if (ExcludeSandbox)
            {
                // from the PHP source
                // https://github.com/paynl/sdk-alliance/blob/master/src/Statistics.php#L36
                // $api->addFilter('payment_profile_id', 613, 'neq');

                filterNvc.Add($"filterType[{i}]", "payment_profile_id");
                filterNvc.Add($"filterOperator[{i}]", "neq");
                filterNvc.Add($"filterValue[{i}]", 613.ToString());
                i++;
            }

            if (Filters == null)
            {
                return filterNvc;
            }

            foreach (var filterItem in Filters)
            {
                filterNvc.Add($"filterType[{i}]", filterItem.Key);
                filterNvc.Add($"filterOperator[{i}]", filterItem.Operator?.ToString() ?? ValidOperators.Eq.ToString().ToLowerInvariant());
                filterNvc.Add($"filterValue[{i}]", filterItem.Value);
                i++;
            }

            return filterNvc;
        }


        /// <inheritdoc />
        protected override void PrepareAndSetResponse()
        {
            if (ParameterValidator.IsEmpty(rawResponse))
            {
                throw new PayNlException("rawResponse is empty!");
            }
        }

        /// <summary>
        /// A filter for statistics
        /// </summary>
        public struct FilterItem
        {
            /// <summary>
            /// the field to filter upon
            /// </summary>
            public string Key { get; set; }
            /// <summary>
            /// the operator for the filter on the specified field
            /// </summary>
            public ValidOperators? Operator { get; set; }
            /// <summary>
            /// The value to compare against
            /// </summary>
            public string Value { get; set; }
        }

        /// <summary>
        /// The operators for filtering management statistics
        /// </summary>
        [SuppressMessage("ReSharper", "UnusedMember.Global")]
        public enum ValidOperators
        {
            /// <summary>
            /// Equals
            /// </summary>
            Eq,
            /// <summary>
            /// Not equals
            /// </summary>
            Neq,
            /// <summary>
            /// Greater
            /// </summary>
            Gt,
            /// <summary>
            /// Smaller
            /// </summary>
            Lt,
            /// <summary>
            /// Like
            /// </summary>
            Like
        }

    }

    /// <summary>
    /// Filter the turnover on the Statistics export
    /// </summary>
    public enum CompanySelectEnum
    {
        /// <summary>
        /// Own merchant and sub merchants
        /// </summary>
        All,
        /// <summary>
        /// Only the current merchant
        /// </summary>
        Self,
        /// <summary>
        /// Only sub merchants
        /// </summary>
        Other
    }
}
