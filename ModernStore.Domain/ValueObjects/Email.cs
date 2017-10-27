using FluentValidator;

namespace ModernStore.Domain.ValueObjects
{
    public class Email : Notifiable
    {
        #region Constructors
        public Email(string address)
        {
            Address = address;

            Validations();
        }
        #endregion

        #region Attributes
        public string Address { get; private set; }
        #endregion

        #region Methods
        private void Validations()
        {
            new ValidationContract<Email>(this)
              .IsEmail(x => x.Address, "E-mail inválido");
        }
        #endregion
    }
}