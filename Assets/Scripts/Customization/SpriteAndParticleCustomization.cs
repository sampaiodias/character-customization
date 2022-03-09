using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Customization
{
    public class SpriteAndParticleCustomization : MonoBehaviour, ICustomization
    {
        [field: SerializeField]
        private AssetReferenceSprite Sprite { get; set; }
        [field: SerializeField]

        private AssetReferenceGameObject Particle { get; set; }

        private SpriteRenderer _renderer;

        private GameObject _instantiatedParticle;
        
        public void Activate(GameObject target)
        {
            _renderer = target.GetComponent<SpriteRenderer>();
            _renderer.sprite = Sprite.LoadAssetAsync().WaitForCompletion();
            _instantiatedParticle = Particle.InstantiateAsync(_renderer.transform.position, Quaternion.identity, _renderer.transform).WaitForCompletion();
        }

        public void Deactivate(GameObject target)
        {
            _renderer.sprite = null;
            Destroy(_instantiatedParticle);
            Sprite.ReleaseAsset();
        }
    }
}