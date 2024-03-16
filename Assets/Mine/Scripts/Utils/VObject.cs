using VContainer;
using VContainer.Unity;

namespace Mine.Scripts.Utils
{
    public class VObject<T> where T : LifetimeScope
    {
        [Inject] protected LifetimeScope Ctx { private get; set; }

        protected T Context => Ctx as T;
    }
}

