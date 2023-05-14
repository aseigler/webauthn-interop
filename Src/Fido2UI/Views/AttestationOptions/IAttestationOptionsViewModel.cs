﻿using System.Collections.Generic;
using DSInternals.Win32.WebAuthn.COSE;
using DSInternals.Win32.WebAuthn.FIDO;
using DSInternals.Win32.WebAuthn.Interop;

namespace DSInternals.Win32.WebAuthn.Fido2UI
{
    public interface IAttestationOptionsViewModel
    {
        RelyingPartyInformation RelyingPartyEntity { get; set; }

        UserInformation UserEntity { get; set; }

        byte[] Challenge { get; set; }

        bool RequireResidentKey { get; set; }

        AuthenticationExtensionsClientInputs ClientExtensions { get; set; }

        AuthenticatorAttachment AuthenticatorAttachment { get; set; }

        UserVerificationRequirement UserVerificationRequirement { get; set; }

        Algorithm[] PublicKeyCredentialParameters { get; set; }

        AttestationConveyancePreference AttestationConveyancePreference { get; set; }

        int Timeout { get; set; }
    }
}
