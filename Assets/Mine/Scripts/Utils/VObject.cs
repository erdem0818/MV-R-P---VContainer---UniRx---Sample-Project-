using VContainer;
using VContainer.Unity;

namespace Assets.Mine.Scripts.Utils
{
    public class VObject<T> where T : LifetimeScope
    {
        [Inject] protected LifetimeScope context { private get; set; }

        protected T Context => context as T;
    }
}

