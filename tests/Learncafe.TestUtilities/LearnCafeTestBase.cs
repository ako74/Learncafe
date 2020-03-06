using Learcafe.TestUtilities;
using System;
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace Learncafe.TestUtilities
{
    public abstract class LearnCafeTestBase<T>: IClassFixture<T>
        where T : LearncafeWebApplicationFactoryBase
    {
        protected LearnCafeTestBase([NotNull] T factory)
        {
            Factory = factory ?? throw new ArgumentNullException(nameof(factory));
        }
        
        protected T Factory { get; private set; }
    }
}
