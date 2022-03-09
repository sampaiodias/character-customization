using UnityEngine;

namespace Customization
{
    public class SpriteAndParticleCustomization : MonoBehaviour, ICustomization
    {
        [field: SerializeField]
        private Sprite Sprite { get; set; }
        [field: SerializeField]

        private GameObject Particle { get; set; }
        private SpriteRenderer Renderer { get; set; }

        private GameObject _instantiatedParticle;
        
        public void Activate(GameObject target)
        {
            Renderer = target.GetComponent<SpriteRenderer>();
            Renderer.sprite = Sprite;
            _instantiatedParticle = Instantiate(Particle, Renderer.transform.position, Quaternion.identity, Renderer.transform);
        }

        public void Deactivate(GameObject target)
        {
            Renderer.sprite = null;
            Destroy(_instantiatedParticle);
        }
    }
}