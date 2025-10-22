using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using PAYNLSDK.Exceptions;
using PAYNLSDK.Utilities;

namespace PAYNLSDK.API.Alliance.AddDocument
{
    /// <summary>
    /// Request to upload a document
    /// </summary>
    public class Request : RequestBase
    {
        /// <inheritdoc />
        protected override int Version => 1;
        /// <inheritdoc />
        protected override string Controller => "Document";
        /// <inheritdoc />
        protected override string Method => "add";

        /// <summary>
        /// The document ID
        /// </summary>
        public string DocumentId { get; set; }

        /// <summary>
        /// The filename
        /// </summary>
        public string Filename { get; set; }

        /// <summary>
        /// Base64 encoded document content(s)
        /// </summary>
        public List<string> Content { get; set; } = new List<string>();

        /// <summary>
        /// Add base64 encoded content
        /// </summary>
        /// <param name="base64Content">Base64 encoded document content</param>
        public void AddContent(string base64Content)
        {
            Content.Add(base64Content);
        }

        /// <inheritdoc />
        public override NameValueCollection GetParameters()
        {
            if (ParameterValidator.IsEmpty(DocumentId))
            {
                throw new PayNlException("DocumentId is required");
            }
            if (ParameterValidator.IsEmpty(Filename))
            {
                throw new PayNlException("Filename is required");
            }
            if (Content == null || Content.Count == 0)
            {
                throw new PayNlException("Content is required");
            }

            var retval = new NameValueCollection 
            { 
                { "documentId", DocumentId },
                { "filename", Filename }
            };

            if (Content.Count == 1)
            {
                retval.Add("documentFile", Content[0]);
            }
            else
            {
                for (int i = 0; i < Content.Count; i++)
                {
                    retval.Add($"documentFile[{i}]", Content[i]);
                }
            }

            return retval;
        }

        /// <inheritdoc />
        protected override void PrepareAndSetResponse()
        {
            // do nothing
        }
    }
}
