namespace Blobfish.Builders
{
    public class AuthorBuilder
    {
        private Author author;

        public AuthorBuilder(string name, UserType userType)
        {
            this.author = new Author(name, userType);
        }

        public Author Build() => this.author;

        public AuthorBuilder WithAffiliation(string affiliation)
        {
            this.author.Affiliation = affiliation;
            return this;
        }

        public AuthorBuilder WithEmail(string email)
        {
            this.author.Email = email;
            return this;
        }

        public AuthorBuilder WithLocation(string location)
        {
            this.author.Location = location;
            return this;
        }

        public AuthorBuilder WithPhone(string phone)
        {
            this.author.Phone = phone;
            return this;
        }

        public AuthorBuilder WithRole(string role)
        {
            this.author.Role = role;
            return this;
        }
    }
}
