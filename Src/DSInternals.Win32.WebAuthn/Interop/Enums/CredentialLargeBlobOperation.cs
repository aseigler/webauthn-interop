﻿namespace DSInternals.Win32.WebAuthn.Interop
{
    /// <summary>
    /// The operation to perform on the large blob.
    /// </summary>
    internal enum CredentialLargeBlobOperation : int
    {
        /// <remarks>
        /// Corresponds to WEBAUTHN_CRED_LARGE_BLOB_OPERATION_NONE.
        /// </remarks>
        None = ApiConstants.CredLargeBlobOperationNone,

        /// <remarks>
        /// Corresponds to WEBAUTHN_CRED_LARGE_BLOB_OPERATION_GET.
        /// </remarks>
        Get = ApiConstants.CredLargeBlobOperationGet,

        /// <remarks>
        /// Corresponds to WEBAUTHN_CRED_LARGE_BLOB_OPERATION_SET.
        /// </remarks>
        Set = ApiConstants.CredLargeBlobOperationSet,

        /// <remarks>
        /// Corresponds to WEBAUTHN_CRED_LARGE_BLOB_OPERATION_DELETE.
        /// </remarks>
        Delete = ApiConstants.CredLargeBlobOperationDelete
}
}