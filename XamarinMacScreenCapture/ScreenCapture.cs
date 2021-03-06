﻿using System;
using System.Runtime.InteropServices;
using CoreGraphics;

namespace XamarinMacScreenCapture
{
    public static class ScreenCapture
    {
        public const string DllName = "/System/Library/Frameworks/CoreGraphics.framework/CoreGraphics";

        [DllImport(DllName)]
        extern static IntPtr CGDisplayCreateImage(UInt32 displayId);

        [DllImport(DllName)]
        extern static void CFRelease(IntPtr handle);

        public static CGImage CreateImage(UInt32 displayId)
        {
            IntPtr handle = IntPtr.Zero;

            try
            {
                handle = CGDisplayCreateImage(displayId);
                return new CGImage(handle);
            }
            finally
            {
                if (handle != IntPtr.Zero)
                {
                    CFRelease(handle);
                }
            }
        }
    }
}
