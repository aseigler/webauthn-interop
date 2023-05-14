﻿namespace DSInternals.Win32.WebAuthn.Interop
{
    /// <summary>
    /// The current version of the WEBAUTHN_COSE_CREDENTIAL_PARAMETER structure, to allow for modifications in the future.
    /// </summary>
    internal enum CoseCredentialParameterVersion : int
    {
        /// <summary>
        /// Current version
        /// </summary>
        /// <remarks>Corresponds to WEBAUTHN_COSE_CREDENTIAL_PARAMETER_CURRENT_VERSION.</remarks>
        Current = ApiConstants.CoseCredentialParameterCurrentVersion
    }
}