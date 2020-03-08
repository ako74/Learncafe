using Learcafe.TestUtilities;
using System;
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace Learncafe.TestUtilities
{
    public abstract class LearncafeTestBase<T>: IClassFixture<T>
        where T : LearncafeWebApplicationFactoryBase
    {
        protected LearncafeTestBase([NotNull] T factory)
        {
            Factory = factory ?? throw new ArgumentNullException(nameof(factory));
        }
        
        protected T Factory { get; private set; }
    }
}
