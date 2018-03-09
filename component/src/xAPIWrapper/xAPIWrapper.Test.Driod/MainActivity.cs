
using Android.App;
using Android.OS;
using TestDemo;

namespace xAPIWrapper.Test.Driod
{
    [Activity(Label = "xAPIWrapper.Test.Driod", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity 
    {
        protected void OnCreate(Bundle bundle)
        {
            // tests can be inside the main assembly
            //AddTestAssembly(typeof(TestsAreGood).Assembly);
            // or in any reference assemblies
            // AddTest (typeof (Your.Library.TestClass).Assembly);
        }
    }
}

