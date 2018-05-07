using UnityEngine;

namespace UnityGLTF
{
    class MetalRough2StandardMap : StandardMap, IMetalRoughUniformMap
    {
        public MetalRough2StandardMap(int MaxLOD = 1000) : base("Standard", MaxLOD) { }
        protected MetalRough2StandardMap(string shaderName, int MaxLOD = 1000) : base(shaderName, MaxLOD) { }
        protected MetalRough2StandardMap(Material m, int MaxLOD = 1000) : base(m, MaxLOD) { }


        private static int _baseColorMapID = Shader.PropertyToID("_MainTex");
        protected static int _metallicRoughnessTextureID = Shader.PropertyToID("_MetallicGlossMap");

        public virtual Texture BaseColorTexture
        {
            get { return _material.GetTexture(_baseColorMapID); }
            set { _material.SetTexture(_baseColorMapID, value); }
        }

        public virtual int BaseColorTextureID
        {
            get { return _baseColorMapID; }
        }

        // not implemented by the Standard shader
        public virtual int BaseColorTexCoord
        {
            get { return 0; }
            set { return; }
        }

        public virtual Color BaseColorFactor
        {
            get { return _material.GetColor("_Color"); }
            set { _material.SetColor("_Color", value); }
        }

        public virtual Texture MetallicRoughnessTexture
        {
            get { return null; }
            set
            {
                // cap metalness at 0.5 to compensate for lack of texture
                MetallicFactor = Mathf.Min(0.5f, (float)MetallicFactor);
            }
        }

        public virtual int MetallicRoughnessTextureID
        {
            get { return _metallicRoughnessTextureID; }
        }

        // not implemented by the Standard shader
        public virtual int MetallicRoughnessTexCoord
        {
            get { return 0; }
            set { return; }
        }

        public virtual double MetallicFactor
        {
            get { return _material.GetFloat("_Metallic"); }
            set { _material.SetFloat("_Metallic", (float)value); }
        }

        // not supported by the Standard shader
        public virtual double RoughnessFactor
        {
            get { return 0.5; }
            set { return; }
        }

        public override IUniformMap Clone()
        {
            var copy = new MetalRough2StandardMap(new Material(_material));
            base.Copy(copy);
            return copy;
        }
    }
}
