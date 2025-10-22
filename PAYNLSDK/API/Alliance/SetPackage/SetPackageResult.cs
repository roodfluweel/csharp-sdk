namespace PAYNLSDK.API.Alliance.SetPackage
{
    /// <summary>
    /// Result class for SetPackage call
    /// </summary>
    public class SetPackageResult : ResponseBase
    {
        /// <summary>
        /// Returns true if the package was successfully set
        /// </summary>
        public bool Success => Request?.Result == true;
    }
}
