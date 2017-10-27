using ModernStore.Domain.ValueObjects;
using ModernStore.Shared.Entities;
using System;

namespace ModernStore.Domain.Entities
{
    public class Customer : Entity
    {
        #region Constructors
        public Customer(Name name, Email email, Document document, User user)
        {
            Name = name;
            BirthDate = null;
            User = user;
            Email = email;
            Document = document;

            Validations();
        }
        #endregion

        #region Attributes
        public Name Name { get; private set; }
        public Email Email { get; private set; }
        public Document Document { get; private set; }
        public DateTime? BirthDate { get; private set; }
        public User User { get; private set; }
        #endregion

        #region Methods
        public void Update(Name name, DateTime birthDate)
        {
            Name = name;
            BirthDate = birthDate;
        }

        public void UpdateBirthDate(DateTime birthDate)
        {
            BirthDate = birthDate;
        }

        public void Validations()
        {
            AddNotifications(Name.Notifications);
            AddNotifications(Email.Notifications);
            AddNotifications(Document.Notifications);
        }
        #endregion
    }
}
