# CustomKeyInformation class

Represents the CUSTOM_KEY_INFORMATION structure.

```csharp
public class CustomKeyInformation
```

## Public Members

| name | description |
| --- | --- |
| [CustomKeyInformation](CustomKeyInformation/CustomKeyInformation.md)(…) |  (2 constructors) |
| [EncodedExtendedCKI](CustomKeyInformation/EncodedExtendedCKI.md) { get; } | Extended custom key information. |
| [FekKeyVersion](CustomKeyInformation/FekKeyVersion.md) { get; } | Specifies the version of the File Encryption Key (FEK), if applicable. |
| [Flags](CustomKeyInformation/Flags.md) { get; } | Gets the key creation flags. |
| [Reserved](CustomKeyInformation/Reserved.md) { get; } | Reserved for future use. |
| [Strength](CustomKeyInformation/Strength.md) { get; } | Specifies the strength of the NGC key, if applicable. |
| [SupportsNotification](CustomKeyInformation/SupportsNotification.md) { get; } | Specifies whether the device associated with this credential supports notification. |
| [Version](CustomKeyInformation/Version.md) { get; } | Gets the version of the data structure. |
| [VolumeType](CustomKeyInformation/VolumeType.md) { get; } | Gets the type of encrypted volume, if applicable. |
| [ToByteArray](CustomKeyInformation/ToByteArray.md)() | Serializes the data structure. |

## See Also

* namespace [DSInternals.Win32.WebAuthn.ActiveDirectory](../DSInternals.Win32.WebAuthn.md)
* [CustomKeyInformation.cs](https://github.com/MichaelGrafnetter/webauthn-interop/tree/master/Src/DSInternals.Win32.WebAuthn/ActiveDirectory/CustomKeyInformation.cs)

<!-- DO NOT EDIT: generated by xmldocmd for DSInternals.Win32.WebAuthn.dll -->