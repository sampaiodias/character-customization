using UnityEngine;

namespace Customization
{
    public interface ICustomization
    {
        void Activate(GameObject target);
        void Deactivate(GameObject target);
    }
}
