
using Android.Graphics;
using Android.Text.Method;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Color = Android.Graphics.Color;
using View = Android.Views.View;

[assembly: ResolutionGroupName("Xamarin")]
[assembly: ExportEffect(typeof(AppTestTsc.Droid.Renderers.ShowHidePassEffect), "ShowHidePassEffect")]
namespace AppTestTsc.Droid.Renderers
{
    /// <summary>
    ///  
    /// </summary>
    public class ShowHidePassEffect : PlatformEffect
    {

        /// <summary>
        ///  
        /// </summary>
        protected override void OnAttached()
        {
            ConfigureControl();
        }
        /// <summary>
        ///  
        /// </summary>
        protected override void OnDetached()
        {
        }

        private void ConfigureControl()
        {
            EditText editText = ((EditText)Control);
            editText.SetCompoundDrawablesRelativeWithIntrinsicBounds(0, 0, Resource.Drawable.esconderojo, 0);
            editText.SetOnTouchListener(new OnDrawableTouchListener());




        }
    }
    /// <summary>
    ///  
    /// </summary>
    public class OnDrawableTouchListener : Java.Lang.Object, View.IOnTouchListener
    {
        /// <summary>
        ///  
        /// </summary>
        public bool OnTouch(View v, MotionEvent e)
        {
            if (v is EditText && e.Action == MotionEventActions.Up)
            {
                EditText editText = (EditText)v;
                if (e.RawX >= (editText.Right - editText.GetCompoundDrawables()[2].Bounds.Width()))
                {
                    if (editText.TransformationMethod == null)
                    {
                        editText.TransformationMethod = PasswordTransformationMethod.Instance;
                        editText.SetCompoundDrawablesRelativeWithIntrinsicBounds(0, 0, Resource.Drawable.esconderojo, 0);


                    }
                    else
                    {
                        editText.TransformationMethod = null;
                        editText.SetCompoundDrawablesRelativeWithIntrinsicBounds(0, 0, Resource.Drawable.ojover, 0);


                    }

                    return true;
                }
            }

            return false;
        }
    }
}