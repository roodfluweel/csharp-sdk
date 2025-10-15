using System.Text.Json;
using System.Text.Json.Serialization;
using PayNLSdk.Exceptions;
using PayNLSdk.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;

namespace PayNLSdk.Api.Document.Add;

/// <summary>
/// Upload one or multiple files to a document for a merchant or account.
/// </summary>
public class Request : RequestBase
{
    /// <inheritdoc />
    protected override int Version => 1;
    /// <inheritdoc />
    protected override string Controller => "document";
    /// <inheritdoc />
    protected override string Method => "add";

    /// <summary>
    /// The id of the document
    /// </summary>
    [Required]
    public string DocumentId { get; set; }

    /// <summary>
    /// the name (and extension) of the file you're adding.
    /// </summary>
    [Required]
    public string FileName { get; set; }

    /// <summary>
    /// The content of the file which should be uploaded
    /// </summary>
    [Required]
    public List<byte[]> FileBytes { get; set; }

    /// <inheritdoc />
    public override NameValueCollection GetParameters()
    {
        NameValueCollection nvc = new NameValueCollection();
        ParameterValidator.IsNotEmpty(DocumentId, "DocumentId");
        ParameterValidator.IsNotEmpty(FileName, "DocumentId");
        ParameterValidator.IsNotNull(FileBytes, "FileBytes");

        nvc.Add("documentId", DocumentId);
        nvc.Add("filename", FileName);

        //nvc.Add("documentFile", Convert.ToBase64String(FileBytes));
        for (var i = 0; i < FileBytes.Count; i++)
        {
            var fileBytes = FileBytes[i];
            nvc.Add($"documentFile[{i}]", Convert.ToBase64String(fileBytes));
        }

        return nvc;
    }

    /// <inheritdoc />
    protected override void PrepareAndSetResponse()
    {
        if (ParameterValidator.IsEmpty(rawResponse))
        {
            throw new PayNlException("rawResponse is empty!");
        }

        var r = JsonSerialization.Deserialize<Response>(RawResponse);
        response = r;
    }
}