using System;

using UIKit;

namespace Workhours2
{
    public partial class ViewController : UIViewController
    {
        partial void ClearBtn_TouchUpInside(UIButton sender)
        {
            HoursTxt.Text = "";
            MinutesTxt.Text = "";
            ResultLabel.Text = "";
        }

        partial void CalculateBtn_TouchUpInside(UIButton sender)
        {
            AddHours calc = new AddHours();
            ResultLabel.Text = calc.ToNumber(HoursTxt.Text, MinutesTxt.Text);
        }


        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            var g = new UITapGestureRecognizer(() => View.EndEditing(true));
            g.CancelsTouchesInView = false; //for iOS5

            View.AddGestureRecognizer(g);

            HoursTxt.ShouldReturn = (textField) => {
                textField.ResignFirstResponder();
                return true;

            };

            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}
