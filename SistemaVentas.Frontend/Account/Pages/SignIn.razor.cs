namespace SistemaVentas.Frontend.Account.Pages
{
    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Authorization;
    using Microsoft.AspNetCore.DataProtection;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.JSInterop;
    using SistemaVentas.Model.Auth;
    using SistemaVentas.Services.Auth;
    using System;
    using System.Threading.Tasks;

    public class SignInBase : ComponentBase
    {
        [Inject]
        protected IJSRuntime JSRuntime { get; set; }

        [Inject]
        protected NavigationManager _navigationManager { get; set; }

        [Inject]
        protected AuthenticationStateProvider authenticationStateProvider { get; set; }

        [Inject]
        protected ApplicationSignInManager _signInManager { get; set; }

        [Inject]
        protected ApplicationUserManager _userManager { get; set; }

        [Inject]
        protected IDataProtectionProvider _dataProtectionProvider { get; set; }

        public Login Login { get; set; } = new Login();
        public string ValidationStatus { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var state = await authenticationStateProvider.GetAuthenticationStateAsync();

            if (state.User.Identity.IsAuthenticated)
            {
                _navigationManager.NavigateTo("/");
            }
        }

        protected override Task OnAfterRenderAsync(bool firstRender)
        {
            JSRuntime.InvokeVoidAsync("functions.util.iCheck", "#isRememberMe");

            //if (!await ApplicationRoleManager.RoleExistsAsync("Administrator"))
            //{
            //    var rol = new ApplicationRole()
            //    {
            //        Name = "Administrator"
            //    };
            //    var resultRol = await ApplicationRoleManager.CreateAsync(rol);
            //}

            //var user = new ApplicationUser()
            //{
            //    Email = "admin@gmail.com",
            //    UserName = "admin"
            //};

            //var resultUser = await ApplicationUserManager.CreateAsync(user, "P@ssw0rd2020+++");
            //var resultAddRol = await ApplicationUserManager.AddToRoleAsync(user, "Administrator");

            return base.OnAfterRenderAsync(firstRender);
        }

        public async void SubmitLoginForm()
        {
            var user = await _userManager.FindByNameAsync(Login.UserName);

            if (user != null && await _signInManager.UserManager.CheckPasswordAsync(user, Login.Password))
            {
                var token = await _userManager.GenerateUserTokenAsync(user, TokenOptions.DefaultProvider, "SignIn");
                var parsedQuery = System.Web.HttpUtility.ParseQueryString(new Uri(_navigationManager.Uri).Query);

                var data = $"{user.Id}|{token}";

                var returnUrl = parsedQuery["returnUrl"];

                if (!string.IsNullOrWhiteSpace(returnUrl))
                {
                    data += $"|{returnUrl}";
                }

                var protector = _dataProtectionProvider.CreateProtector("SignIn");

                var pdata = protector.Protect(data);

                _navigationManager.NavigateTo("/account/signinactual?t=" + pdata, forceLoad: true);
            }
            else
            {
                ValidationStatus = "Usuario y Contraseña Incorrecto!";
                Login.Password = string.Empty;
            }
        }

    }
}
