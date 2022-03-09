using UnityEngine;

namespace Customization
{
    public class SpriteCustomization : MonoBehaviour, ICustomization
    {
        [field: SerializeField]
        private Sprite Sprite { get; set; }
        private SpriteRenderer Renderer { get; set; }
        
        public void Activate(GameObject target)
        {
            Renderer = target.GetComponent<SpriteRenderer>();
            Renderer.sprite = Sprite;
        }

        public void Deactivate(GameObject target)
        {
            Renderer.sprite = null;
        }
    }
}