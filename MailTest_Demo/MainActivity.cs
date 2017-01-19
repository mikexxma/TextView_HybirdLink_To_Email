using Android.App;
using Android.Widget;
using Android.OS;
using Android.Text;
using Java.Lang;
using Android.Text.Method;
using Android.Text.Style;
using Android.Views;
using System;
using Android.Content;
using Android.Runtime;
using Android.Text.Util;
using static Android.Views.View;

namespace MailTest_Demo
{
    [Activity(Label = "MailTest_Demo", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        TextView mailTV;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
             SetContentView (Resource.Layout.Main);
            mailTV = (TextView)FindViewById(Resource.Id.textView2);
            mailTV.SetText(getClickableSpan(), TextView.BufferType.Spannable);         
            mailTV.MovementMethod = LinkMovementMethod.Instance;
        }

      

        private SpannableString getClickableSpan()
        {
            string s = "contact me";
            SpannableString sp = new SpannableString(s);
            sp.SetSpan(new MyURLSpan(this), 0, s.Length, SpanTypes.InclusiveInclusive);
            return sp;
        }

        class MyURLSpan : ClickableSpan
        {
            MainActivity mActivity;

            public MyURLSpan(MainActivity activity)
            {
                mActivity = activity;
            }
            public override void OnClick(View widget)
            {
                Intent email = new Intent(Intent.ActionSend);
                email.SetType("text/plain");
               // real device SetType("message/rfc822");
                email.PutExtra(Intent.ExtraEmail, "mikexxma@outlook.com");  
                email.PutExtra(Intent.ExtraSubject, "hello");    
                email.PutExtra(Intent.ExtraText, "hello mike ma");
                mActivity.StartActivity(email);
            }
        }
    }

   

   


}

