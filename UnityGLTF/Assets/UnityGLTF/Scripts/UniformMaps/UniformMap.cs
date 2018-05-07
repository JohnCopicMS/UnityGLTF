using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace UnityGLTF
{
    interface IUniformMap
    {
        Material Material { get; }

        Texture NormalTexture { get; set; }
        int NormalTextureID { get; }
        int NormalTexCoord { get; set; }
        double NormalTexScale { get; set; }

        Texture OcclusionTexture { get; set; }
        int OcclusionTextureID { get; }
        int OcclusionTexCoord { get; set; }
        double OcclusionTexStrength { get; set; }

        Texture EmissiveTexture { get; set; }
        int EmissiveTextureID { get; }
        int EmissiveTexCoord { get; set; }
        Color EmissiveFactor { get; set; }

        GLTF.Schema.AlphaMode AlphaMode { get; set; }
        double AlphaCutoff { get; set; }
        bool DoubleSided { get; set; }
        bool VertexColorsEnabled { get; set; }

        IUniformMap Clone();
    }

    interface IMetalRoughUniformMap : IUniformMap
    {
        Texture BaseColorTexture { get; set; }
        int BaseColorTextureID { get; }
        int BaseColorTexCoord { get; set; }
        Color BaseColorFactor { get; set; }
        Texture MetallicRoughnessTexture { get; set; }
        int MetallicRoughnessTextureID { get; }
        int MetallicRoughnessTexCoord { get; set; }
        double MetallicFactor { get; set; }
        double RoughnessFactor { get; set; }
    }

    interface ISpecGlossUniformMap : IUniformMap
    {
        Texture DiffuseTexture { get; set; }
        int DiffuseTextureID { get; }
        int DiffuseTexCoord { get; set; }
        Color DiffuseFactor { get; set; }
        Texture SpecularGlossinessTexture { get; set; }
        int SpecularGlossinessTextureID { get; }
        int SpecularGlossinessTexCoord { get; set; }
        Vector3 SpecularFactor { get; set; }
        double GlossinessFactor { get; set; }
    }

    interface IUnlitUniformMap : IUniformMap
    {
        Texture BaseColorTexture { get; set; }
        int BaseColorTextureID { get; }
        int BaseColorTexCoord { get; set; }
        Color BaseColorFactor { get; set; }
    }
}
