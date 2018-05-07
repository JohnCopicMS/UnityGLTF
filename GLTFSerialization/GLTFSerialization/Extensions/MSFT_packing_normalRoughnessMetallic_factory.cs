using System;
using GLTF.Schema;
using Newtonsoft.Json.Linq;

namespace GLTF.Schema
{
	/// <summary>
	/// A GLTF extension factory, required to create a gltf extension.
	/// The factory reads in the GLTF file and picks out the custom material info we've added in.
	/// 
	/// This is the Microsoft extension to the standard gltf PBR material.
	/// We're packing it into 2 textures for better HoloLens performance
	/// </summary>
	public class MSFT_packing_normalRoughnessMetallic_factory : ExtensionFactory
	{
		public MSFT_packing_normalRoughnessMetallic_factory()
		{
			ExtensionName = MSFT_packing_normalRoughnessMetallic.EXTENSION_NAME;
		}

		public override IExtension Deserialize(GLTFRoot root, JProperty extensionToken)
		{
			var textureInfo = new TextureInfo();
			if (extensionToken != null && extensionToken.Value["normalRoughnessMetallicTexture"] != null)
			{
				System.Diagnostics.Debug.WriteLine(extensionToken.Value.ToString());
				System.Diagnostics.Debug.WriteLine(extensionToken.Value.Type);
				JObject normalRoughnessMetallicTexture = extensionToken.Value["normalRoughnessMetallicTexture"] as JObject;
				if (normalRoughnessMetallicTexture == null)
				{
					throw new Exception();
				}

				System.Diagnostics.Debug.WriteLine("normalRoughnessMetallicTexutre is " + normalRoughnessMetallicTexture.Type + " with a value of: " + normalRoughnessMetallicTexture["index"].Type + " " + normalRoughnessMetallicTexture.ToString());

				int indexVal = (int)(normalRoughnessMetallicTexture["index"]);
				textureInfo = new TextureInfo()
				{
					Index = new TextureId()
					{
						Id = indexVal,
						Root = root
					}
				};
			}

			return new MSFT_packing_normalRoughnessMetallic(textureInfo);
		}
	}
}
