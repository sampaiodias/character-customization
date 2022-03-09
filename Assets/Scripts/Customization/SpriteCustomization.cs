using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Customization
{
    public class SpriteCustomization : MonoBehaviour, ICustomization
    {
        [field: SerializeField]
        private AssetReferenceSprite Sprite { get; set; }

        private SpriteRenderer _renderer;
        
        public void Activate(GameObject target)
        {
            _renderer = target.GetComponent<SpriteRenderer>();
            _renderer.sprite = Sprite.LoadAssetAsync().WaitForCompletion();
        }

        public void Deactivate(GameObject target)
        {
            _renderer.sprite = null;
            Sprite.ReleaseAsset();
        }
    }
}