using GLTF.Schema;
using Newtonsoft.Json.Linq;

namespace GLTF.Schema
{
	/// <summary>
	/// A GLTF Extension that serializes material information as an extension in the GLTF file.
	/// </summary>
	public class MSFT_packing_normalRoughnessMetallic : IExtension
	{
		public static readonly string EXTENSION_NAME = "MSFT_packing_normalRoughnessMetallic";
		public TextureInfo NormalRoughnessMetallicTexture;

		public MSFT_packing_normalRoughnessMetallic(TextureInfo textureInfo)
		{
			NormalRoughnessMetallicTexture = textureInfo;
		}

		public IExtension Clone(GLTFRoot root)
		{
			return new MSFT_packing_normalRoughnessMetallic(new TextureInfo(NormalRoughnessMetallicTexture, root));
		}

		public JProperty Serialize()
		{
			JProperty jProperty =
				new JProperty(EXTENSION_NAME,
					new JObject(
						new JProperty("normalRoughnessMetallicTexture",
							new JObject(
								new JProperty("index", NormalRoughnessMetallicTexture.Index.Id)
								)
							)
						)
					);

			return jProperty;
		}
	}
}
