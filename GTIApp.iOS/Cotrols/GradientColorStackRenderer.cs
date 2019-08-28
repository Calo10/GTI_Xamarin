using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using gradient;
using CoreGraphics;
using CoreAnimation;
using GTIApp.iOS.Cotrols;

[assembly: ExportRenderer(typeof(GradientColorStack), typeof(GradientColorStackRenderer))]
namespace GTIApp.iOS.Cotrols
{

    public class GradientColorStackRenderer : VisualElementRenderer<StackLayout>
    {
        public static CGColor ToCGColor(Color color)
        {
            return new CGColor(CGColorSpace.CreateSrgb(), new nfloat[] { (float)color.R, (float)color.G, (float)color.B, (float)color.A });
        }
        public override void Draw(CGRect rect)
        {
            base.Draw(rect);
            GradientColorStack stack = (GradientColorStack)this.Element;

            //CGColor startColor = stack.StartColor.ToCGColor();
            //CGColor endColor = stack.EndColor.ToCGColor();

            CGColor startColor = ToCGColor(stack.StartColor);
            CGColor endColor = ToCGColor(stack.EndColor);

            #region for Vertical Gradient

            //var gradientLayer = new CAGradientLayer();

            #endregion

            #region for Horizontal Gradient

            var gradientLayer = new CAGradientLayer()
            {
                StartPoint = new CGPoint(0, 0.5),
                EndPoint = new CGPoint(1, 0.5)
            };

            #endregion

            gradientLayer.Frame = rect;
            gradientLayer.Colors = new CGColor[] { startColor, endColor };

            NativeView.Layer.InsertSublayer(gradientLayer, 0);
        }
    }
}
