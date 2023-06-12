using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using PayNLSdk.API;

namespace PayNLSdk.API.Document.Add
{
    /// <summary>
    /// The result whether the Upload of one or multiple files to a document for a merchant or account has completed
    /// </summary>
    public class Response : ResponseBase
    {
        /// <summary>
        /// If true the call was successful
        /// </summary>
        [JsonProperty("result")] public bool Result { get; set; }

        /// <summary>
        /// ID of the error (if an error occurred)
        /// </summary>
        [JsonProperty("errorId")] public string ErrorId { get; set; }

        /// <summary>
        /// Description of the error (if an error occurred)
        /// </summary>
        [JsonProperty("errorMessage")] public string ErrorMessage { get; set; }
    }
}
