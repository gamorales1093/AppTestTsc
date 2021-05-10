using AppTestTsc.Renderers;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace AppTestTsc.Views
{
    /// <summary>
    /// Page to login with user name and password
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginwithSocialIconPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LoginwithSocialIconPage" /> class.
        /// </summary>
        public LoginwithSocialIconPage()
        {
            this.InitializeComponent();
            //add effect to show/hide password text
            PasswordEntry.Effects.Add(new ShowHidePassEffect());

        }
    }
}