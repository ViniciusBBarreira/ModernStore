using FluentValidator;
using ModernStore.Shared.Entities;
using System.Text;

namespace ModernStore.Domain.Entities
{
    public class User : Entity
    {
        #region Constructors
        public User(string userName, string password, string confirmPassword)
        {
            UserName = userName;
            Password = EncryptPassword(password);
            Active = true;
            ConfirmPassword = EncryptPassword(confirmPassword);

            Validations();
        }
        #endregion

        #region Attributes
        public string UserName { get; private set; }
        public string Password { get; private set; }
        private string ConfirmPassword;
        public bool Active { get; private set; }
        #endregion

        #region Methods
        public void Activate() => Active = true;

        public void Deactivate() => Active = false;

        private void Validations() {
            new ValidationContract<User>(this)
                .IsRequired(x => x.UserName)
                .HasMinLenght(x => x.UserName, 3)

                .IsRequired(x => x.Password)
                .HasMinLenght(x => x.Password, 6)
                .AreEquals(x=> x.Password, ConfirmPassword, "As senhas não coincidem")
                ;
        }

        private string EncryptPassword(string pass)
        {
            if (string.IsNullOrEmpty(pass)) return "";
            var password = (pass += "|2d331cca-f6c0-40c0-bb43-6e32989c2881");
            var md5 = System.Security.Cryptography.MD5.Create();
            var data = md5.ComputeHash(Encoding.Default.GetBytes(password));
            var sbString = new StringBuilder();
            foreach (var t in data)
                sbString.Append(t.ToString("x2"));

            return sbString.ToString();
        }
        #endregion
    }
}
