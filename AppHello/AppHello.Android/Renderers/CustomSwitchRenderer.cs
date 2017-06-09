using AppHello.Controls;
using AppHello.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomSwitch), typeof(CustomSwitchRenderer))]
namespace AppHello.Droid.Renderers
{
	public class CustomSwitchRenderer : SwitchRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Switch> e)
		{
			base.OnElementChanged(e);

			//Control.SetBackgroundColor(Android.Graphics.Color.Blue);
		}
	}
}