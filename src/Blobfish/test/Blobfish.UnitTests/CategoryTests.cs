namespace Blobfish.UnitTests
{
    using System;

    using FluentAssertions;

    using Xunit;

    public class CategoryTests
    {
        [Fact]
        public void CategoryConstructorThrowsOnInvalidName()
        {
            Action constructorCallWithInvalidName = () => new Category(null);

            constructorCallWithInvalidName.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void CategoryConstructorAndInitializersWorkCorrectlyWithValidParameters()
        {
            Category category = new Category("CategoryName");
            category.Name.Should().Be("CategoryName");
            category.Categories.Should().NotBeNull();
            category.Parameters.Should().NotBeNull();
            category.SeriesSets.Should().NotBeNull();
        }
    }
}
