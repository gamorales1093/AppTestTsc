using Acr.UserDialogs;
using AppTestTsc.Validators;
using AppTestTsc.Validators.Rules;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace AppTestTsc.ViewModels
{
    /// <summary>
    /// ViewModel for login with social icon page.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class LoginWithSocialIconViewModel : LoginViewModel
    {
        #region Fields

        private ValidatableObject<string> password;
        private ValidatableObject<string> email;
        public string textButtonLogin;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="LoginWithSocialIconViewModel" /> class.
        /// </summary>
        public LoginWithSocialIconViewModel()
        {
            this.InitializeProperties();
            this.AddValidationRules();
            this.LoginCommand = new Command(this.LoginClicked);
            this.SignUpCommand = new Command(this.SignUpClicked);
            this.ForgotPasswordCommand = new Command(this.ForgotPasswordClicked);
            this.FaceBookLoginCommand = new Command(this.FaceBookClicked);
            this.TwitterLoginCommand = new Command(this.TwitterClicked);
            this.GmailLoginCommand = new Command(this.GmailClicked);
            TextButtonLogin = "Ingresar";
        }

        #endregion

        #region property

        /// <summary>
        /// Gets or sets the property that is bound with an entry that gets the password from user in the login page.
        /// </summary>
        public ValidatableObject<string> Password
        {
            get
            {

                return this.password;
            }

            set
            {
                if (this.password == value)
                {
                    return;
                }
       

                this.SetProperty(ref this.password, value);

            }
        }

        public ValidatableObject<string> Email
        {
            get
            {
                return this.email;
            }

            set
            {
                if (this.email == value)
                {
                    return;
                }
                this.SetProperty(ref this.email, value);
            }
        }

        public string TextButtonLogin
        {
            get
            {
                return this.textButtonLogin;
            }

            set
            {
                if (this.textButtonLogin == value)
                {
                    return;
                }

                this.SetProperty(ref this.textButtonLogin, value);

            }

        }

        public string EmailExample
        {

            get
            {
                return "test@domain.com";
            }
        }

        public string PasswordExample
        {

            get
            {
                return "abc123";
            }
        }

        #endregion

        #region Command

        /// <summary>
        /// Gets or sets the command that is executed when the Log In button is clicked.
        /// </summary>
        public Command LoginCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that is executed when the Sign Up button is clicked.
        /// </summary>
        public Command SignUpCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that is executed when the Forgot Password button is clicked.
        /// </summary>
        public Command ForgotPasswordCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that is executed when the facebook login button is clicked.
        /// </summary>
        public Command FaceBookLoginCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that is executed when the twitter login button is clicked.
        /// </summary>
        public Command TwitterLoginCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that is executed when the gmail login button is clicked.
        /// </summary>
        public Command GmailLoginCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that is executed when the gmail login button is clicked.
        /// </summary>
        public Command EmailEntryCommand { get; set; }

        #endregion

        #region methods

        /// <summary>
        /// check the validation
        /// </summary>
        /// <returns>returns bool value</returns>
        public bool AreFieldsValid()
        {
            bool isEmailValid = this.Email.Validate();
            bool isPassword = this.Password.Validate();
            return isEmailValid && isPassword;
        }

        /// <summary>
        /// Initializing the properties.
        /// </summary>
        private void InitializeProperties()
        {
            this.Password = new ValidatableObject<string>();
            this.Email = new ValidatableObject<string>();
        }

        /// <summary>
        /// Validation rules for password
        /// </summary>
        private void AddValidationRules()
        {
            this.Password.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Password requerido" });
            this.Email.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Email requerido" });
        }

        /// <summary>
        /// Invoked when the Log In button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void LoginClicked(object obj)
        {

            if (this.AreFieldsValid())
            {


                if(Email.Value == EmailExample && Password.Value == PasswordExample)
                {
                    App.Current.MainPage = new AppShell();
                }
                else
                {
                    UserDialogs.Instance.AlertAsync("Usuario o contraseña incorrecto ", "Alerta", "Aceptar");
                }
                
            }

        }


        /// <summary>
        /// Invoked when the Sign Up button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void SignUpClicked(object obj)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when the Forgot Password button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void ForgotPasswordClicked(object obj)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when facebook login button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void FaceBookClicked(object obj)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when twitter login button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void TwitterClicked(object obj)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when gmail login button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void GmailClicked(object obj)
        {
            // Do something
        }

        #endregion
    }
}
