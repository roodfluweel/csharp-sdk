using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using PayNlSdk.Api;
using PayNlSdk.Exceptions;
using PayNlSdk.Utilities;

namespace PayNlSdk.Api.Alliance.Document.Add;

/// <summary>
/// Alliance specific implementation for uploading documents.
/// </summary>
public class Request : RequestBase
{
    /// <summary>
    /// Base64 encoded content blocks that should be uploaded.
    /// </summary>
    public IList<string> Contents { get; } = new List<string>();

    /// <summary>
    /// Identifier of the document that should receive the upload.
    /// </summary>
    public string DocumentId { get; set; } = string.Empty;

    /// <summary>
    /// Optional file name to register.
    /// </summary>
    public string? FileName { get; set; }

    /// <inheritdoc />
    protected override int Version => 1;

    /// <inheritdoc />
    protected override string Controller => "document";

    /// <inheritdoc />
    protected override string Method => "add";

    /// <inheritdoc />
    public override NameValueCollection GetParameters()
    {
        var parameters = new NameValueCollection();

        if (string.IsNullOrWhiteSpace(DocumentId))
        {
            throw new ValidationException("DocumentId is required");
        }

        if (string.IsNullOrWhiteSpace(FileName))
        {
            throw new ValidationException("FileName is required");
        }

        if (Contents.Count == 0)
        {
            throw new ValidationException("At least one document content block must be supplied");
        }

        parameters.Add("documentId", DocumentId);
        parameters.Add("filename", FileName);

        if (Contents.Count == 1)
        {
            parameters.Add("documentFile", Contents[0]);
        }
        else
        {
            for (var index = 0; index < Contents.Count; index++)
            {
                parameters.Add($"documentFile[{index}]", Contents[index]);
            }
        }

        return parameters;
    }

    /// <summary>
    /// Helper method to append raw file content which will be converted to Base64.
    /// </summary>
    public void AddFile(byte[] bytes)
    {
        if (bytes == null)
        {
            throw new ArgumentNullException(nameof(bytes));
        }

        Contents.Add(Convert.ToBase64String(bytes));
    }

    /// <summary>
    /// Helper method to append already encoded content blocks.
    /// </summary>
    /// <param name="base64Content">Base64 encoded data.</param>
    public void AddBase64Content(string base64Content)
    {
        if (string.IsNullOrWhiteSpace(base64Content))
        {
            throw new ArgumentException("Content cannot be empty", nameof(base64Content));
        }

        Contents.Add(base64Content);
    }

    /// <inheritdoc />
    protected override void PrepareAndSetResponse()
    {
        if (ParameterValidator.IsEmpty(rawResponse))
        {
            throw new PayNlException("rawResponse is empty!");
        }

        response = JsonSerialization.Deserialize<Response>(RawResponse);
    }
}
