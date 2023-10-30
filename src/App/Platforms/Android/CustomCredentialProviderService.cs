using System;
using Android.App;
using Android.Content;
using Android.Credentials;
using Android.OS;
using Android.Runtime;
using Android.Util;
using AndroidX.Credentials.Provider;
using AndroidX.Credentials.WebAuthn;
using Java.Time;
using static Microsoft.Maui.ApplicationModel.Platform;

namespace Bit.Droid
{
    [Service(
        Enabled = true,
        Exported = true,
        Label = "Bitwarden Credentials Provider",
        Icon = "@drawable/login",
        Permission = Android.Manifest.Permission.BindCredentialProviderService)]
    [IntentFilter(new string[] { "android.service.credentials.CredentialProviderService" })]
    [MetaData("android.credentials.provider", Resource = "@xml/provider")]
    [Register("com.x8bit.bitwarden.CustomCredentialProviderService")]
    public class CustomCredentialProviderService : AndroidX.Credentials.Provider.CredentialProviderService
    {
        private const string GET_PASSWORD_INTENT_ACTION = "com.x8bit.bitwarden.GET_PASSWORD";

        public CustomCredentialProviderService()
        {
        }

        public override void OnBeginCreateCredentialRequest(BeginCreateCredentialRequest request, CancellationSignal cancellationSignal, IOutcomeReceiver callback)
        {
            
        }

        public override void OnBeginGetCredentialRequest(BeginGetCredentialRequest request, CancellationSignal cancellationSignal, IOutcomeReceiver callback)
        {
            if (request.CallingAppInfo?.PackageName is null)
            {
                Log.Info("BITWARDEN", "OnBeginGetCredentialRequest -> No calling package");
                callback.OnError((Java.Lang.Object)(Android.Runtime.IJavaObject)new AndroidX.Credentials.Exceptions.NoCredentialException());
                return;
            }



            Log.Info("BITWARDEN", "OnBeginGetCredentialRequest");
            try
            {
                var responseBuilder = new BeginGetCredentialResponse.Builder();

                Log.Info("BITWARDEN", "credential options count: " + request.BeginGetCredentialOptions.Count);
                foreach (var item in request.BeginGetCredentialOptions)
                {
                    if (item is BeginGetPasswordOption passwordOption)
                    {
                        Log.Info("BITWARDEN", "password option");

                        var intent = new Android.Content.Intent(GET_PASSWORD_INTENT_ACTION).SetPackage(Application.PackageName);
                        var pendIntent = PendingIntent.GetActivity(
                            ApplicationContext, 1234, intent,
                            (PendingIntentFlags.Mutable | PendingIntentFlags.UpdateCurrent));

                        var draw = Android.Graphics.Drawables.Icon.CreateWithResource(this, Core.Resource.Mipmap.ic_launcher);
                        responseBuilder.AddCredentialEntry(new PasswordCredentialEntry(
                            Application.ApplicationContext, "myUsername", pendIntent, passwordOption, "myUsername", null,
                            draw , false
                            ));
                    }
                    else if (item is BeginGetPublicKeyCredentialOption publicKeyCredentialOption)
                    {
                        Log.Info("BITWARDEN", "public key option");

                        //var requesqwet = new PublicKeyCredentialRequestOptions(publicKeyCredentialOption.RequestJson);
                        var data = new Bundle();
                        data.PutString("requestJson", publicKeyCredentialOption.RequestJson);
                        data.PutString("credId", "1");

                        var intentpass = new Android.Content.Intent(GET_PASSWORD_INTENT_ACTION).SetPackage(Application.PackageName);
                        var pendIntentPass = PendingIntent.GetActivity(
                            ApplicationContext, 1234, intentpass,
                            (PendingIntentFlags.Mutable | PendingIntentFlags.UpdateCurrent));

                        var entryPK = new PublicKeyCredentialEntry.Builder(this, "myUsername", pendIntentPass, publicKeyCredentialOption)
                            .SetDisplayName("Bitwarden Passkey 1")
                            //.SetLastUsedTime(Instant.Min)
                            .SetIcon(Android.Graphics.Drawables.Icon.CreateWithResource(this, Core.Resource.Mipmap.ic_launcher))
                            .Build();

                        responseBuilder.AddCredentialEntry(entryPK);

                        //val pendingIntent = createNewPendingIntent("",
                        //    GET_PASSKEY_INTENT, data)
                        //val entryBuilder = PublicKeyCredentialEntry.Builder(applicationContext,
                        //    passkey.username, pendingIntent, option)
                        //    .setDisplayName(passkey.displayName)
                        //    .setLastUsedTime(Instant.ofEpochMilli(passkey.lastUsedTimeMs))


                        //entryBuilder.setIcon(Graph.providerIcon!!)

                        //val entry = entryBuilder
                        //    .build()
                        //responseBuilder.addCredentialEntry(entry)

                    }
                }

                Log.Info("BITWARDEN", "Before response builder build");
                callback.OnResult(responseBuilder.Build());
            }
            catch (Exception ex)
            {
                Log.Info("BITWARDEN", "an exception: " + ex.Message);
                callback.OnError((Java.Lang.Object)(Android.Runtime.IJavaObject)new AndroidX.Credentials.Exceptions.NoCredentialException());
            }
        }

        public override void OnClearCredentialStateRequest(ProviderClearCredentialStateRequest request, CancellationSignal cancellationSignal, IOutcomeReceiver callback)
        {
            
        }

        //public override void OnBeginCreateCredential(BeginCreateCredentialRequest request, CancellationSignal cancellationSignal, IOutcomeReceiver callback)
        //{
        //    throw new NotImplementedException();
        //}

        //public override void OnBeginGetCredential(BeginGetCredentialRequest request, CancellationSignal cancellationSignal, IOutcomeReceiver callback)
        //{
        //    try
        //    {
        //        var responseBuilder = new AndroidX.Credentials.Provider.BeginGetCredentialResponse.Builder();

        //        foreach (var item in request.BeginGetCredentialOptions)
        //        {
        //            if (item is AndroidX.Credentials.Provider.BeginGetPasswordOption passwordOption)
        //            {
        //                responseBuilder.AddCredentialEntry(new AndroidX.Credentials.Provider.PasswordCredentialEntry(
        //                    Application.ApplicationContext, "myUsername", GetPasswordIntent, passwordOption, "myUsername", null, Resources.GetDrawable(Bit.Droid.resource), false
        //                    ));
        //            }
        //        }

        //        callback.OnResult(responseBuilder.Build());
        //    }
        //    catch (Exception ex)
        //    {
        //        //callback.OnError(new GetCredentialException(GetCredentialException.TypeNoCredential));
        //    }
        //}

        //public override void OnClearCredentialState(Android.Service.Credentials.ClearCredentialStateRequest request, CancellationSignal cancellationSignal, IOutcomeReceiver callback)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
