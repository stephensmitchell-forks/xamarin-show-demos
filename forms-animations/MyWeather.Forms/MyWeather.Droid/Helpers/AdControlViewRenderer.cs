﻿using Android.Widget;
using Android.Gms.Ads;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using MyWeather.Controls;

[assembly: ExportRenderer(typeof(MyWeather.Controls.AdControlView), typeof(MyWeather.Droid.Helpers.AdControlViewRenderer))]
namespace MyWeather.Droid.Helpers
{
    public class AdControlViewRenderer : ViewRenderer<Controls.AdControlView, AdView>
    {
        string adUnitId = string.Empty;
        AdSize adSize = AdSize.Banner;
        AdView adView;
        AdView CreateAdNativeControl()
        {
            if (adView != null)
                return adView;

            adUnitId = "ca-app-pub-7532700630276589/4189426333";
            adView = new AdView(Forms.Context);
            adView.AdSize = adSize;
            adView.AdUnitId = adUnitId;

            var adParams = new LinearLayout.LayoutParams(LayoutParams.WrapContent, LayoutParams.WrapContent);

            adView.LayoutParameters = adParams;

            adView.LoadAd(new AdRequest
                            .Builder()
                            .Build());
            return adView;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<AdControlView> e)
        {
            base.OnElementChanged(e);
            if (Control == null)
            {
                CreateAdNativeControl();
                SetNativeControl(adView);
            }
        }

    }
}