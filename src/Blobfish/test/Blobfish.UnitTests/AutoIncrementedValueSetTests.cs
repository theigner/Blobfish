namespace Blobfish.UnitTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using FluentAssertions;

    using Xunit;

    public class AutoIncrementedValueSetTests
    {
        [Fact]
        public void AutoIncrementedValueSetConstructorThrowsOnInvalidParameterType()
        {
            Action constructorCallWithNullValue = () => new AutoIncrementedValueSet((dynamic)null, (dynamic)1f);
            Action constructorCallWithInvalidTypeValue = () => new AutoIncrementedValueSet((dynamic)"Test", (dynamic)1f);

            constructorCallWithNullValue.Should().Throw<ArgumentNullException>();
            constructorCallWithInvalidTypeValue.Should().Throw<TypeNotAllowedException>();
        }

        [Fact]
        public void AutoIncrementedValueSetToListGeneratesCorrectValues()
        {
            AutoIncrementedValueSet autoIncValueSet = new AutoIncrementedValueSet(0, 2);

            autoIncValueSet.ToList(5).Cast<int>().Should().BeEquivalentTo(new List<int>() { 0, 2, 4, 6, 8 });
        }
    }
}
