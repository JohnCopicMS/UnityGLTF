using UnityEngine;

namespace UnityGLTF
{
    class SpecGloss2StandardMap : StandardMap, ISpecGlossUniformMap
    {
        public SpecGloss2StandardMap(int MaxLOD = 1000) : base("Standard (Specular setup)", MaxLOD) { }
        protected SpecGloss2StandardMap(string shaderName, int MaxLOD = 1000) : base(shaderName, MaxLOD) { }
        protected SpecGloss2StandardMap(Material m, int MaxLOD = 1000) : base(m, MaxLOD) { }

        private static int _baseColorMapID = Shader.PropertyToID("_MainTex");
        private static int _specGlossMapID = Shader.PropertyToID("_SpecGlossMap");

        public virtual Texture DiffuseTexture
        {
            get { return _material.GetTexture("_MainTex"); }
            set { _material.SetTexture("_MainTex", value); }
        }

        public virtual int DiffuseTextureID
        {
            get { return _baseColorMapID; }
        }

        // not implemented by the Standard shader
        public virtual int DiffuseTexCoord
        {
            get { return 0; }
            set { return; }
        }

        public virtual Color DiffuseFactor
        {
            get { return _material.GetColor("_Color"); }
            set { _material.SetColor("_Color", value); }
        }

        public virtual Texture SpecularGlossinessTexture
        {
            get { return _material.GetTexture(_specGlossMapID); }
            set
            {
                _material.SetTexture(_specGlossMapID, value);
                _material.SetFloat("_SmoothnessTextureChannel", 0);
                _material.EnableKeyword("_SPECGLOSSMAP");
            }
        }

        public virtual int SpecularGlossinessTextureID
        {
            get { return _specGlossMapID; }
        }

        // not implemented by the Standard shader
        public virtual int SpecularGlossinessTexCoord
        {
            get { return 0; }
            set { return; }
        }

        public virtual Vector3 SpecularFactor
        {
            get { return _material.GetVector("_SpecColor"); }
            set { _material.SetVector("_SpecColor", value); }
        }

        public virtual double GlossinessFactor
        {
            get { return _material.GetFloat("_GlossMapScale"); }
            set
            {
                _material.SetFloat("_GlossMapScale", (float)value);
                _material.SetFloat("_Glossiness", (float)value);
            }
        }

        public override IUniformMap Clone()
        {
            var copy = new SpecGloss2StandardMap(new Material(_material));
            base.Copy(copy);
            return copy;
        }
    }
}
