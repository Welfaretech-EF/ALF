/**
 * Copyright (C) 2025 Eyeware Tech SA
 *
 * All rights reserved
 */
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace BeamEyeTracker
{
    public static class Constants
    {
        public const double NullDataTimestamp = -1.0;
    }

    #region Enums and Structs
    public enum TrackingDataReceptionStatus : Int32
    {
        NotReceivingTrackingData = 0,
        ReceivingTrackingData = 1,
        AttemptingTrackingAutoStart = 2
    }

    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct Version
    {
        public UInt32 Major;
        public UInt32 Minor;
        public UInt32 Patch;
        public UInt32 Padding;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct Point
    {
        public Int32 X;
        public Int32 Y;

        public Point(Int32 x, Int32 y)
        {
            X = x;
            Y = y;
        }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct PointF
    {
        public float X;
        public float Y;

        public PointF(float x, float y)
        {
            X = x;
            Y = y;
        }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct ViewportGeometry
    {
        public Point Point00;
        public Point Point11;

        public ViewportGeometry(Point point00, Point point11)
        {
            Point00 = point00;
            Point11 = point11;
        }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct Vector3D
    {
        public float X;
        public float Y;
        public float Z;
        UInt32 _Padding;
    }

    public enum TrackingConfidence : Int32
    {
        LostTracking = 0,
        Low = 1,
        Medium = 2,
        High = 3
    }

    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct UnifiedScreenGaze
    {
        public TrackingConfidence Confidence;
        UInt32 _Padding;
        public Point PointOfRegard;
        public Point UnboundedPointOfRegard;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct ViewportGaze
    {
        public TrackingConfidence Confidence;
        UInt32 _Padding;
        public PointF NormalizedPointOfRegard;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct HeadPose
    {
        public TrackingConfidence Confidence;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 9)]
        public float[] RotationFromHcsToWcs; // 3x3 matrix stored as 1D array
        public Vector3D TranslationFromHcsToWcs;
        public ulong TrackSessionUid;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct UserState
    {
        public UInt64 StructVersion;
        public double TimestampInSeconds;
        public HeadPose HeadPose;
        public UnifiedScreenGaze UnifiedScreenGaze;
        public ViewportGaze ViewportGaze;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] Reserved;

        public static UserState Create()
        {
            return new UserState
            {
                StructVersion = 1,
                TimestampInSeconds = Constants.NullDataTimestamp,
                HeadPose = new HeadPose(),
                UnifiedScreenGaze = new UnifiedScreenGaze(),
                ViewportGaze = new ViewportGaze(),
                Reserved = new byte[128]
            };
        }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct SimCameraTransform3D
    {
        public float RollInRadians;
        public float PitchInRadians;
        public float YawInRadians;
        public float XInMeters;
        public float YInMeters;
        public float ZInMeters;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct SimGameCameraState
    {
        public UInt64 StructVersion;
        public double TimestampInSeconds;
        public SimCameraTransform3D EyeTrackingPoseComponent;
        public SimCameraTransform3D HeadTrackingPoseComponent;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public ulong[] Reserved;

        public static SimGameCameraState Create()
        {
            return new SimGameCameraState
            {
                StructVersion = 1,
                TimestampInSeconds = Constants.NullDataTimestamp,
                EyeTrackingPoseComponent = new SimCameraTransform3D(),
                HeadTrackingPoseComponent = new SimCameraTransform3D(),
                Reserved = new ulong[128]
            };
        }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct GameImmersiveHUDState
    {
        public UInt64 StructVersion;
        public double TimestampInSeconds;
        public float LookingAtViewportTopLeft;
        public float LookingAtViewportTopMiddle;
        public float LookingAtViewportTopRight;
        public float LookingAtViewportCenterLeft;
        public float LookingAtViewportCenterRight;
        public float LookingAtViewportBottomLeft;
        public float LookingAtViewportBottomMiddle;
        public float LookingAtViewportBottomRight;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] Reserved;

        public static GameImmersiveHUDState Create()
        {
            return new GameImmersiveHUDState
            {
                StructVersion = 1,
                TimestampInSeconds = Constants.NullDataTimestamp,
                LookingAtViewportTopLeft = 0,
                LookingAtViewportTopMiddle = 0,
                LookingAtViewportTopRight = 0,
                LookingAtViewportCenterLeft = 0,
                LookingAtViewportCenterRight = 0,
                LookingAtViewportBottomLeft = 0,
                LookingAtViewportBottomMiddle = 0,
                LookingAtViewportBottomRight = 0,
                Reserved = new byte[128]
            };
        }
    }
    #endregion

    internal delegate void TrackingDataReceptionStatusCallback(
        TrackingDataReceptionStatus status,
        IntPtr userData
    );

    internal delegate void TrackingDataCallback(
        IntPtr trackingStateSetHandle,
        double timestamp,
        IntPtr userData
    );

    public class TrackingStateSet
    {
        private readonly UserState _userState;
        private readonly SimGameCameraState _simGameCameraState;
        private readonly GameImmersiveHUDState _gameImmersiveHUDState;

        internal TrackingStateSet(IntPtr trackingStateSetHandle)
        {
            if (trackingStateSetHandle == IntPtr.Zero)
                throw new ArgumentException("Invalid handle", nameof(trackingStateSetHandle));

            // Read all states immediately from the handle
            IntPtr userStatePtr = EW_BET_API_GetUserState(trackingStateSetHandle);
            IntPtr cameraStatePtr = EW_BET_API_GetSimGameCameraState(trackingStateSetHandle);
            IntPtr hudStatePtr = EW_BET_API_GetGameImmersiveHUDState(trackingStateSetHandle);

            _userState = Marshal.PtrToStructure<UserState>(userStatePtr);
            _simGameCameraState = Marshal.PtrToStructure<SimGameCameraState>(cameraStatePtr);
            _gameImmersiveHUDState = Marshal.PtrToStructure<GameImmersiveHUDState>(hudStatePtr);
        }

        public UserState UserState => _userState;
        public SimGameCameraState SimGameCameraState => _simGameCameraState;
        public GameImmersiveHUDState GameImmersiveHUDState => _gameImmersiveHUDState;

        [DllImport("beam_eye_tracker_client")]
        private static extern IntPtr EW_BET_API_GetUserState(IntPtr trackingStateSetHandle);

        [DllImport("beam_eye_tracker_client")]
        private static extern IntPtr EW_BET_API_GetSimGameCameraState(
            IntPtr trackingStateSetHandle
        );

        [DllImport("beam_eye_tracker_client")]
        private static extern IntPtr EW_BET_API_GetGameImmersiveHUDState(
            IntPtr trackingStateSetHandle
        );
    }

    public class TrackingListener : IDisposable
    {
        private volatile bool _isDisposed;
        internal IntPtr CallbacksHandle = IntPtr.Zero;
        internal TrackingDataReceptionStatusCallback StatusCallback;
        internal TrackingDataCallback DataCallback;
        public bool IsDisposed => _isDisposed;

        [DllImport("beam_eye_tracker_client")]
        private static extern void EW_BET_API_UnregisterTrackingCallbacks(
            IntPtr apiHandle,
            ref IntPtr callbacksHandle
        );

        // We make a weak reference to the API to avoid circular references, but
        // also because we need the API handle to dispose of the listener.
        private WeakReference<API> _owningApi;

        internal void SetOwningApi(API api)
        {
            _owningApi = new WeakReference<API>(api);
        }

        public virtual void OnTrackingDataReceptionStatusChanged(
            TrackingDataReceptionStatus status
        )
        { }

        public virtual void OnTrackingStateSetUpdate(
            TrackingStateSet trackingStateSet,
            double timestamp
        )
        { }

        ~TrackingListener()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                if (CallbacksHandle != IntPtr.Zero)
                {
                    API api;
                    if (_owningApi != null && _owningApi.TryGetTarget(out api) && !api.IsDisposed)
                    {
                        try
                        {
                            api.StopReceivingTrackingDataOnListener(this);
                        }
                        catch (ObjectDisposedException)
                        {
                            // API was disposed
                        }
                    }
                    else
                    {
                        // We destroy the listener without the API handle, which is safe in the C API,
                        // but only if the C API
                        EW_BET_API_UnregisterTrackingCallbacks(IntPtr.Zero, ref CallbacksHandle);
                    }
                }
                if (CallbacksHandle != IntPtr.Zero)
                {
                    CallbacksHandle = IntPtr.Zero;
                }
                StatusCallback = null;
                DataCallback = null;
                _isDisposed = true;
                _owningApi = null;
            }
        }
    }

    public class API : IDisposable
    {
        private IntPtr apiHandle = IntPtr.Zero;
        private bool disposed = false;

        public bool IsDisposed => disposed;

        #region DllImports
        [DllImport("beam_eye_tracker_client")]
        private static extern int EW_BET_API_Create(
            string friendlyName,
            ViewportGeometry initialViewportGeometry,
            out IntPtr apiHandle
        );

        [DllImport("beam_eye_tracker_client")]
        private static extern void EW_BET_API_Destroy(IntPtr apiHandle);

        [DllImport("beam_eye_tracker_client")]
        private static extern void EW_BET_API_GetVersion(IntPtr apiHandle, out Version version);

        [DllImport("beam_eye_tracker_client")]
        private static extern void EW_BET_API_DestroyTrackingStateSet(
            IntPtr trackingStateSetHandle
        );

        [DllImport("beam_eye_tracker_client")]
        private static extern void EW_BET_API_UpdateViewportGeometry(
            IntPtr apiHandle,
            ViewportGeometry newViewportGeometry
        );

        [DllImport("beam_eye_tracker_client")]
        private static extern void EW_BET_API_AttemptStartingTheBeamEyeTracker(IntPtr apiHandle);

        [DllImport("beam_eye_tracker_client")]
        private static extern bool EW_BET_API_WaitForNewTrackingStateSet(
            IntPtr apiHandle,
            ref double lastReceivedTimestamp,
            uint timeoutMs
        );

        [DllImport("beam_eye_tracker_client")]
        private static extern int EW_BET_API_CreateAndFillLatestTrackingStateSet(
            IntPtr apiHandle,
            out IntPtr trackingStateSetHandle
        );

        [DllImport("beam_eye_tracker_client")]
        private static extern TrackingDataReceptionStatus EW_BET_API_GetTrackingDataReceptionStatus(
            IntPtr apiHandle
        );

        [DllImport("beam_eye_tracker_client")]
        private static extern IntPtr EW_BET_API_GetUserState(IntPtr trackingStateSetHandle);

        [DllImport("beam_eye_tracker_client")]
        private static extern IntPtr EW_BET_API_GetSimGameCameraState(
            IntPtr trackingStateSetHandle
        );

        [DllImport("beam_eye_tracker_client")]
        private static extern IntPtr EW_BET_API_GetGameImmersiveHUDState(
            IntPtr trackingStateSetHandle
        );

        [DllImport("beam_eye_tracker_client")]
        private static extern int EW_BET_API_RegisterTrackingCallbacks(
            IntPtr apiHandle,
            TrackingDataReceptionStatusCallback statusCallback,
            TrackingDataCallback dataCallback,
            IntPtr userData,
            out IntPtr callbacksHandle
        );

        [DllImport("beam_eye_tracker_client")]
        private static extern void EW_BET_API_UnregisterTrackingCallbacks(
            IntPtr apiHandle,
            ref IntPtr callbacksHandle
        );

        [DllImport("beam_eye_tracker_client")]
        private static extern SimCameraTransform3D EW_BET_API_ComputeSimGameCameraTransformParameters(
            SimGameCameraState cameraState,
            float eyeTrackingWeight,
            float headTrackingWeight
        );

        [DllImport("beam_eye_tracker_client")]
        private static extern bool EW_BET_API_RecenterSimGameCameraStart(IntPtr apiHandle);

        [DllImport("beam_eye_tracker_client")]
        private static extern void EW_BET_API_RecenterSimGameCameraEnd(IntPtr apiHandle);
        #endregion

        public const uint DefaultTrackingDataTimeoutMs = 1000;

        public API(string friendlyName, ViewportGeometry initialViewportGeometry)
        {
            if (string.IsNullOrEmpty(friendlyName))
                throw new ArgumentNullException(nameof(friendlyName));

            if (friendlyName.Length > 200)
                throw new ArgumentException(
                    "Friendly name must not exceed 200 bytes",
                    nameof(friendlyName)
                );

            int result = EW_BET_API_Create(friendlyName, initialViewportGeometry, out apiHandle);
            if (result != 0)
                throw new Exception($"Failed to create Beam Eye Tracker API. Error code: {result}");
        }

        public Version GetVersion()
        {
            ThrowIfDisposed();
            EW_BET_API_GetVersion(apiHandle, out Version version);
            return version;
        }

        public void UpdateViewportGeometry(ViewportGeometry newViewportGeometry)
        {
            ThrowIfDisposed();
            EW_BET_API_UpdateViewportGeometry(apiHandle, newViewportGeometry);
        }

        public void AttemptStartingTheBeamEyeTracker()
        {
            ThrowIfDisposed();
            EW_BET_API_AttemptStartingTheBeamEyeTracker(apiHandle);
        }

        public bool WaitForNewTrackingData(
            ref double lastReceivedTimestamp,
            uint timeoutMs = DefaultTrackingDataTimeoutMs
        )
        {
            ThrowIfDisposed();
            return EW_BET_API_WaitForNewTrackingStateSet(
                apiHandle,
                ref lastReceivedTimestamp,
                timeoutMs
            );
        }

        public TrackingDataReceptionStatus GetTrackingDataReceptionStatus()
        {
            ThrowIfDisposed();
            return EW_BET_API_GetTrackingDataReceptionStatus(apiHandle);
        }

        public TrackingStateSet GetLatestTrackingStateSet()
        {
            ThrowIfDisposed();

            int result = EW_BET_API_CreateAndFillLatestTrackingStateSet(
                apiHandle,
                out IntPtr trackingStateSetHandle
            );

            if (result != 0)
                throw new Exception(
                    $"Failed to get latest tracking state set. Error code: {result}"
                );

            try
            {
                return new TrackingStateSet(trackingStateSetHandle);
            }
            finally
            {
                EW_BET_API_DestroyTrackingStateSet(trackingStateSetHandle);
            }
        }

        public void StartReceivingTrackingDataOnListener(TrackingListener listener)
        {
            ThrowIfDisposed();
            if (listener == null)
                throw new ArgumentNullException(nameof(listener));

            if (listener.CallbacksHandle != IntPtr.Zero)
                throw new InvalidOperationException("This listener is already registered");

            // Allows to release the listener without the API handle if the API is disposed first.
            listener.SetOwningApi(this);

            listener.StatusCallback = (TrackingDataReceptionStatus status, IntPtr userData) =>
            {
                if (!listener.IsDisposed)
                {
                    try
                    {
                        listener.OnTrackingDataReceptionStatusChanged(status);
                    }
                    catch (ObjectDisposedException)
                    {
                        Console.WriteLine("Listener ObjectDisposedException");
                    }
                }
            };

            listener.DataCallback = (
                IntPtr trackingStateSetHandle,
                double timestamp,
                IntPtr userData
            ) =>
            {
                if (!listener.IsDisposed)
                {
                    try
                    {
                        listener.OnTrackingStateSetUpdate(
                            new TrackingStateSet(trackingStateSetHandle),
                            timestamp
                        );
                    }
                    catch (ObjectDisposedException)
                    {
                        Console.WriteLine("Listener ObjectDisposedException");
                    }
                }
            };

            int result = EW_BET_API_RegisterTrackingCallbacks(
                apiHandle,
                listener.StatusCallback,
                listener.DataCallback,
                IntPtr.Zero,
                out listener.CallbacksHandle
            );

            if (result != 0)
                throw new Exception($"Failed to register tracking callbacks. Error code: {result}");
        }

        public void StopReceivingTrackingDataOnListener(TrackingListener listener)
        {
            ThrowIfDisposed();
            if (listener == null)
                throw new ArgumentNullException(nameof(listener));

            if (listener.CallbacksHandle == IntPtr.Zero)
                throw new ArgumentException("The provided listener is not currently registered");

            EW_BET_API_UnregisterTrackingCallbacks(apiHandle, ref listener.CallbacksHandle);
            listener.StatusCallback = null;
            listener.DataCallback = null;
        }

        public static SimCameraTransform3D ComputeSimGameCameraTransformParameters(
            SimGameCameraState cameraState,
            float eyeTrackingWeight = 1.0f,
            float headTrackingWeight = 1.0f
        )
        {
            return EW_BET_API_ComputeSimGameCameraTransformParameters(
                cameraState,
                eyeTrackingWeight,
                headTrackingWeight
            );
        }

        public bool StartRecenterSimGameCamera()
        {
            ThrowIfDisposed();
            return EW_BET_API_RecenterSimGameCameraStart(apiHandle);
        }

        public void StopRecenterSimGameCamera()
        {
            ThrowIfDisposed();
            EW_BET_API_RecenterSimGameCameraEnd(apiHandle);
        }

        private void ThrowIfDisposed()
        {
            if (disposed)
                throw new ObjectDisposedException(nameof(API));
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // No managed resources to dispose in this case.
                }

                // Dispose unmanaged resources
                if (apiHandle != IntPtr.Zero)
                {
                    EW_BET_API_Destroy(apiHandle);
                    apiHandle = IntPtr.Zero;
                }

                disposed = true;
            }
        }

        ~API()
        {
            Dispose(false);
        }
    }
}
