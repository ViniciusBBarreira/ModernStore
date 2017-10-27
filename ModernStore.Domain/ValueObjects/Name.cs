using FluentValidator;

namespace ModernStore.Domain.ValueObjects
{
    public class Name : Notifiable
    {
        #region Constructors
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            Validations();
        }
        #endregion

        #region Attributes
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        #endregion

        #region Methods
        public override string ToString() => $"{FirstName} {LastName}";

        private void Validations()
        {
            new ValidationContract<Name>(this)
              .IsRequired(x => x.FirstName, "Nome é obrigatório")
              .HasMaxLenght(x => x.FirstName, 60, "Maximo 60")
              .HasMinLenght(x => x.FirstName, 3, "Nome pequeno, tem que ter no mínimo 3 caracteres")

              .IsRequired(x => x.LastName, "Sobrenome é obrigatório")
              .HasMaxLenght(x => x.LastName, 60, "Maximo 60")
              .HasMinLenght(x => x.LastName, 3, "Sobrenome pequeno, tem que ter no mínimo 3 caracteres");
        }
        #endregion
    }
}