using UnityEngine;

namespace Managers.Initializer
{
    public class ScriptableManagerInitializer<T> : AbstractScriptableBaseManagerInitializer 
        where T:ScriptableManagerInitializer<T>
    {
        public static T Instance;
        public override void Initialize()
        {
            base.Initialize();
            Instance = this as T;
        }

        public override void Destroy()
        {
            base.Destroy();
        }
    }
}
