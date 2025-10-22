using Newtonsoft.Json;

namespace PAYNLSDK.API.Alliance.AddDocument
{
    /// <summary>
    /// Result class for AddDocument call
    /// </summary>
    public class AddDocumentResult : ResponseBase
    {
        /// <summary>
        /// Returns true if document was successfully uploaded
        /// </summary>
        [JsonProperty("result")]
        public bool Result { get; set; }

        /// <summary>
        /// Document ID if successful
        /// </summary>
        [JsonProperty("documentId")]
        public string DocumentId { get; set; }
    }
}
