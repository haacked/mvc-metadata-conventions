using System;
using ModelMetadataExtensions.Extensions;
using Xunit;

namespace UnitTests
{
    public class ReflectionExtensionsTests
    {
        public class ThePropertyExistsMethod
        {
            [Fact]
            public void ReturnsFalseForNullTypeOrPropertyName()
            {
                Type t = null;
                Assert.False(t.PropertyExists("PropertyName"));
                t = typeof (object);
                Assert.False(t.PropertyExists("PropertyName"));
            }

            [Fact]
            public void ReturnsTrueForPublicAndInternalProperties()
            {
                var type = typeof(SomeClass);

                Assert.True(type.PropertyExists("PublicProperty"));
                Assert.True(type.PropertyExists("InternalProperty"));
                Assert.True(type.PropertyExists("ProtectedOrInternalProperty"));
                Assert.False(type.PropertyExists("ProtectedProperty")); 
                Assert.False(type.PropertyExists("PrivateProperty"));
                Assert.False(type.PropertyExists("NonExistentProperty"));
            }

            public class SomeClass
            {
                public int PublicProperty { get; set; }
                internal int InternalProperty { get; set; }
                protected int ProtectedProperty { get; set; }
                protected internal int ProtectedOrInternalProperty { get; set; }
// ReSharper disable once UnusedMember.Local
                int PrivateProperty { get; set; }
            }

        }
    }
}
