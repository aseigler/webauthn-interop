﻿using System;
using System.Runtime.InteropServices;
using DSInternals.Win32.WebAuthn.FIDO;

namespace DSInternals.Win32.WebAuthn.Interop
{
    /// <summary>
    /// A structure that contains the data needed to get an assertion.
    /// </summary>
    /// <remarks>Corresponds to WEBAUTHN_AUTHENTICATOR_GET_ASSERTION_OPTIONS.</remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    internal class AuthenticatorGetAssertionOptions : IDisposable
    {
        /// <summary>
        /// The version of this structure.
        /// </summary>
        private AuthenticatorGetAssertionOptionsVersion _version = AuthenticatorGetAssertionOptionsVersion.Version6;

        /// <summary>
        /// Time that the operation is expected to complete within.
        /// </summary>
        /// <remarks>This is used as guidance, and can be overridden by the platform.</remarks>
        public int TimeoutMilliseconds { get; set; } = ApiConstants.DefaultTimeoutMilliseconds;

        /// <summary>
        /// The list of allowed credentials to be used in the assertion.
        /// </summary>
        private Credentials _allowCredentials;

        /// <summary>
        /// A CBOR map from extension identifiers to their authenticator extension inputs,
        /// created by the client based on the extensions requested by the Relying Party.
        /// These are optional extensions to parse when performing the operation.
        /// </summary>
        private ExtensionsIn _extensions;

        /// <summary>
        /// Platform vs Cross-Platform Authenticators. (Optional)
        /// </summary>
        public AuthenticatorAttachment AuthenticatorAttachment { get; set; }

        /// <summary>
        /// The effective user verification requirement.
        /// </summary>
        public UserVerificationRequirement UserVerificationRequirement { get; set; }

        /// <summary>
        /// Reserved for future Use.
        /// </summary>
        private uint Flags;

        // The following fields have been added in WEBAUTHN_AUTHENTICATOR_GET_ASSERTION_OPTIONS_VERSION_2

        /// <summary>
        /// Optional identifier for the U2F AppId. Converted to UTF8 before being hashed. Not lower-cased.
        /// </summary>
        [MarshalAs(UnmanagedType.LPUTF8Str)]
        private string _u2fAppId;

        /// <summary>
        /// If the following is non-NULL, then, set to TRUE if the above U2fAppid was used instead of RpId
        /// Note that this value is modified by WebAuthNAuthenticatorGetAssertion
        /// </summary>
        private IntPtr _isU2fAppIdUsed = IntPtr.Zero;

        //
        // The following fields have been added in WEBAUTHN_AUTHENTICATOR_GET_ASSERTION_OPTIONS_VERSION_3
        //

        /// <summary>
        /// Cancellation Id (Optional).
        /// </summary>
        private IntPtr _cancellationId = IntPtr.Zero;

        //
        // The following fields have been added in WEBAUTHN_AUTHENTICATOR_GET_ASSERTION_OPTIONS_VERSION_4
        //

        /// <summary>
        /// An optional list of public key credential descriptors describing credentials acceptable to the Relying Party (possibly filtered by the client), if any.
        /// If present, CredentialList will be ignored.
        /// </summary>
        private IntPtr _allowCredentialList = IntPtr.Zero;

        //
        // The following fields have been added in WEBAUTHN_AUTHENTICATOR_GET_ASSERTION_OPTIONS_VERSION_5
        //

        /// <summary>
        /// The large blob operation.
        /// </summary>
        public CredentialLargeBlobOperation LargeBlobOperation { get; set; }

        /// <summary>
        /// Size of _largeBlob.
        /// </summary>
        private int _largeBlobLength;

        /// <summary>
        /// A pointer to the large credential blob.
        /// </summary>
        private ByteArrayIn _largeBlob;

        //
        // The following fields have been added in WEBAUTHN_AUTHENTICATOR_GET_ASSERTION_OPTIONS_VERSION_6
        //

        /// <summary>
        /// PRF values which will be converted into HMAC-SECRET values according to WebAuthn Spec.
        /// </summary>
        private HmacSecretSaltValuesIn _hmacSecretSaltValues;

        /// <summary>
        /// Indicates whether the browser is in private mode. Defaulting to false.
        /// </summary>
        public bool BrowserInPrivateMode { get; set; }

        /// <summary>
        /// Optional identifier for the U2F AppId. Converted to UTF8 before being hashed. Not lower cased.
        /// </summary>
        public string U2fAppId
        {
            get
            {
                return _u2fAppId;
            }
            set
            {
                _u2fAppId = value;
                if (_isU2fAppIdUsed == IntPtr.Zero)
                {
                    _isU2fAppIdUsed = Marshal.AllocHGlobal(sizeof(int));
                }

                Marshal.WriteInt32(_isU2fAppIdUsed, Convert.ToInt32(value != null));
            }
        }

        /// <summary>
        /// Cancellation Id (Optional)
        /// </summary>
        public Guid? CancellationId
        {
            set
            {
                if (value.HasValue)
                {
                    if (_cancellationId == IntPtr.Zero)
                    {
                        _cancellationId = Marshal.AllocHGlobal(Marshal.SizeOf<Guid>());
                    }

                    Marshal.StructureToPtr<Guid>(value.Value, _cancellationId, false);
                }
                else
                {
                    if (_cancellationId != IntPtr.Zero)
                    {
                        Marshal.FreeHGlobal(_cancellationId);
                        _cancellationId = IntPtr.Zero;
                    }
                }
            }
        }

        /// <summary>
        /// Allowed Credentials List.
        /// </summary>
        public Credentials AllowCredentials
        {
            set
            {
                _allowCredentials?.Dispose();
                _allowCredentials = value;
            }
        }

        /// <summary>
        /// Allow Credential List. If present, "AllowCredentials" will be ignored.
        /// </summary>
        public CredentialList AllowCredentialsEx
        {
            set
            {
                if (value != null)
                {
                    if (_allowCredentialList == IntPtr.Zero)
                    {
                        _allowCredentialList = Marshal.AllocHGlobal(Marshal.SizeOf<CredentialList>());
                    }

                    Marshal.StructureToPtr<CredentialList>(value, _allowCredentialList, false);
                }
                else
                {
                    if (_allowCredentialList != IntPtr.Zero)
                    {
                        Marshal.FreeHGlobal(_allowCredentialList);
                        _allowCredentialList = IntPtr.Zero;
                    }
                }
            }
        }

        /// <summary>
        /// Version of this structure, to allow for modifications in the future.
        /// </summary>
        /// <remarks>This is a V6 struct. If V7 arrives, new fields will need to be added.</remarks>
        public AuthenticatorGetAssertionOptionsVersion Version
        {
            get
            {
                return _version;
            }
            set
            {
                if (value > AuthenticatorGetAssertionOptionsVersion.Version6)
                {
                    // We only support older struct versions.
                    throw new ArgumentOutOfRangeException(nameof(value), "The requested data structure version is not yet supported.");
                }

                _version = value;
            }
        }

        /// <summary>
        /// Extensions to parse when performing the operation. (Optional)
        /// </summary>
        public ExtensionsIn Extensions
        {
            set
            {
                _extensions?.Dispose();
                _extensions = value;
            }
        }

        /// <summary>
        /// Credential Large Blob.
        /// </summary>
        public byte[] LargeBlob
        {
            get
            {
                return _largeBlob?.Read(_largeBlobLength);
            }
            set
            {
                // Get rid of any previous blob first
                _largeBlob?.Dispose();

                // Now replace the previous value with a new one
                _largeBlobLength = value?.Length ?? 0;
                _largeBlob = new ByteArrayIn(value);
            }
        }

        public HmacSecretSaltValuesIn HmacSecretSaltValues
        {
            set
            {
                _hmacSecretSaltValues?.Dispose();
                _hmacSecretSaltValues = value;
            }
        }

        public void Dispose()
        {
            _extensions?.Dispose();
            _extensions = null;

            _allowCredentials?.Dispose();
            _allowCredentials = null;

            _largeBlob?.Dispose();
            _largeBlob = null;

            if (_allowCredentialList != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(_allowCredentialList);
                _allowCredentialList = IntPtr.Zero;
            }

            _hmacSecretSaltValues?.Dispose();
            _hmacSecretSaltValues = null;

            if (_isU2fAppIdUsed != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(_isU2fAppIdUsed);
                _isU2fAppIdUsed = IntPtr.Zero;
            }

            if (_cancellationId != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(_cancellationId);
                _cancellationId = IntPtr.Zero;
            }
        }
    }
}