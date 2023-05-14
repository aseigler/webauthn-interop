﻿namespace DSInternals.Win32.WebAuthn.Interop
{
    /// <summary>
    /// Relying Party Information Structure Version Information.
    /// </summary>
    internal enum RelyingPartyInformationVersion : int
    {
        /// <summary>
        /// Current version
        /// </summary>
        /// <remarks>
        /// Corresponds to WEBAUTHN_RP_ENTITY_INFORMATION_CURRENT_VERSION.
        /// </remarks>
        Current = ApiConstants.RpEntityInformationCurrentVersion
    }
}