using Android.App;
using Android.Content;
using Android.OS;
using Android.Util;
using AndroidX.Activity;
using AndroidX.Credentials;
using AndroidX.Credentials.Provider;

namespace Bit.App.Platforms.Android;

[Activity(
    Label = "GetPasswordActivity",
    Exported = true,
    Enabled = true,
    Theme = "@android:style/Theme.Translucent.NoTitleBar")]
[IntentFilter(
    new string[] { "com.x8bit.bitwarden.GET_PASSWORD" },
    Categories = new string[] { "android.intent.category.DEFAULT" })]
public class GetPasswordActivity : ComponentActivity
{
    protected override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);

        Log.Info("BITWARDEN", "onCreate ConfirmPasswordActivity keyvault");

        var getRequest = PendingIntentHandler.RetrieveProviderGetCredentialRequest(Intent);
        if (getRequest is null)
        {
            Log.Info("BITWARDEN", "getRequest is null");
            return;
        }

        Log.Info("BITWARDEN", "getRequest is NOT null");

        if (getRequest.CredentialOptions[0] is GetPasswordOption option)
        {
            //val username = intent.getStringExtra("username")
            try
            {
                var callingInfo = getRequest.CallingAppInfo?.PackageName;

                var resultIntent = new Intent();
                var response = new PasswordCredential("myUsername", "myPassword");
                PendingIntentHandler.SetGetCredentialResponse(resultIntent, new GetCredentialResponse(response));

                SetResult(Result.Ok, resultIntent);
                Finish();
            }
            catch (Exception ex)
            {
                Log.Info("BITWARDEN", "Ex: " + ex.Message);
            }
        }
    }
}

