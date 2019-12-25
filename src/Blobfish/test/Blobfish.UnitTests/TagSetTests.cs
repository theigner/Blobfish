namespace Blobfish.UnitTests
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using FluentAssertions;

    using Xunit;

    public class TagSetTests
    {
        [Fact]
        public void TagSetTagCollectionIsInitialized()
        {
            TagSet tagSet = new TagSet();
            tagSet.Tags.Should().NotBeNull();
        }
    }
}
