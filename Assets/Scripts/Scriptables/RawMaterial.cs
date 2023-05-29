using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RawMaterial", menuName = "Material")]
public class RawMaterial : ScriptableObject
{
    public List<Material> materials;

    [System.Serializable]
    public class Material
    {
        public string materialName;
        public int price;
        public int craftQuantity;
        public Sprite icon;
        [TextArea(0, 10)]
        public string info;

        public Material(string materialName, int price, int craftQuantity, Sprite icon, string info)
        {
            this.materialName = materialName;
            this.price = price;
            this.craftQuantity = craftQuantity;
            this.icon = icon;
            this.info = info;
        }
    }    
}
