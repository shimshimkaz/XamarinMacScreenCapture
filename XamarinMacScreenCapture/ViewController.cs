﻿using System;
using System.Drawing;
using AppKit;
using Foundation;

namespace XamarinMacScreenCapture
{
    public partial class ViewController : NSViewController
    {
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
        }

        public override NSObject RepresentedObject
        {
            get
            {
                return base.RepresentedObject;
            }
            set
            {
                base.RepresentedObject = value;
            }
        }

        partial void ClickedCaptureButton(NSObject sender)
        {
            var id1 = (NSNumber)NSScreen.MainScreen.DeviceDescription["NSScreenNumber"];

            using (var cgImage = ScreenCapture.CreateImage(id1.UInt32Value))
            using (var nsImage = new NSImage(cgImage, new SizeF(cgImage.Width, cgImage.Height)))
            {
                ImageView.Image = nsImage;
            }
        }
    }
}
