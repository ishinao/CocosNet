// CocosNet, Cocos2D in C#
// Copyright 2009 Matthew Greer
// See LICENSE file for license, and README and AUTHORS for more info

using MonoTouch.UIKit;
using OpenTK.Platform;
using MonoTouch.OpenGLES;
using CocosNet;
using CocosNet.Layers;
using CocosNet.Support;
using Color = CocosNet.Base.Color;
using System.Drawing;

namespace CocosNetTests {
	public partial class AppDelegate : UIApplicationDelegate {
		static void Main(string[] args) {
			using (var c = Utilities.CreateGraphicsContext(EAGLRenderingAPI.OpenGLES1)) {
				UIApplication.Main(args, null, "AppDelegate");
			}
		}

		public override void FinishedLaunching(UIApplication app) {
			// all images are found in the Images directory,
			// so all images can now be loaded by just their name, not "Images\foo.png"
			TextureMgr.Instance.ImageRoot = "Images";
			
			window.BackgroundColor = UIColor.Red;
			
			window.UserInteractionEnabled = true;
			window.MultipleTouchEnabled = false;
			window.Bounds = new System.Drawing.RectangleF(0, 0, 768, 1024);
			
			Director.Instance.DeviceOrientation = DeviceOrientation.Portrait;
			Director.Instance.AnimationInterval = 1.0 / 60.0;
			Director.Instance.IsDisplayFPS = true;
			
			Director.Instance.AttachInView(window);
			
			window.MakeKeyAndVisible();
			
			// To run a different test, instantiate a different class here
			// SpriteTest -- SpriteManual
			// ParallaxTest -- Parallax1
			// ParticleTest -- DemoFirework
			// PrimitivesTest -- HorizontalDrawPrimitives
			Scene scene = new Scene(new DemoFirework());
			
			Director.Instance.RunScene(scene);
		}

		// This method is required in iPhoneOS 3.0
		public override void OnActivated(UIApplication application) {
		}
	}
}
