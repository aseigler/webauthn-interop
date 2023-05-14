﻿namespace DSInternals.Win32.WebAuthn.Interop
{
    /// <summary>
    /// The current version of the WEBAUTHN_CREDENTIAL_EX structure, to allow for modifications in the future.
    /// </summary>
    internal enum CredentialExVersion : int
    {
        /// <remarks>Corresponds to WEBAUTHN_CREDENTIAL_EX_CURRENT_VERSION.</remarks>
        Current = ApiConstants.CredentialExCurrentVersion
    }
}