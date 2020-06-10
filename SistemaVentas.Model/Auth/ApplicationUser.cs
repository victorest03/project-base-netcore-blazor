namespace SistemaVentas.Model.Auth
{
    using System.ComponentModel.DataAnnotations;
    using FluentValidation;
    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser
    {
        public string cNombres { get; set; }
        public string cApellidos { get; set; }
        public string cFullName => $"{cNombres} {cApellidos}";
    }

    #region Login
    public class Login
    {
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "¿Recordar cuenta?")]
        public bool RememberMe { get; set; }
    }

    public class LoginValidator : AbstractValidator<Login>
    {
        public LoginValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Ingrese un Usuario!!!")
                .Matches(@"^(?=.*\S).*$").WithMessage("Ingrese un Usuario Valido!!!");

            RuleFor(x => x.Password).NotEmpty().WithMessage("Ingrese un Password!!!")
                .Matches(@"^(?=.*\S).*$").WithMessage("Ingrese un Password Valido!!!");
        }
    }
    #endregion

    #region Change Password
    public class ChangePassword
    {
        [DataType(DataType.Password)]
        [StringLength(200, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 6)]
        [Display(Name = "Nueva Contraseña")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar contraseña")]
        public string ConfirmPassword { get; set; }
    }

    public class ChangePasswordValidator : AbstractValidator<ChangePassword>
    {
        public ChangePasswordValidator()
        {
            RuleFor(x => x.NewPassword).NotEmpty().WithMessage("Ingrese un Nuevo Password!!!");

            RuleFor(x => x.ConfirmPassword).Equal(x => x.NewPassword)
                .WithMessage("No ha ingresado la misma contraseña nueva!!!");
        }
    }
    #endregion
}
