using GLTF.Schema;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GLTF.Schema
{
	/// <summary>
	/// A GLTF Extension that serializes dds texture information as an extension in the GLTF file.
	/// </summary>
	public class MSFT_texture_dds : IExtension
	{
		public static readonly string EXTENSION_NAME = "MSFT_texture_dds";
		public ImageId DdsImageIndex;

		public MSFT_texture_dds(int index, GLTFRoot root)
		{
			DdsImageIndex = new ImageId
			{
				Id = index,
				Root = root
			};
		}

		public IExtension Clone(GLTFRoot root)
		{
			return new MSFT_texture_dds(DdsImageIndex.Id, root);
		}

		public JProperty Serialize()
		{
			return new JProperty(EXTENSION_NAME, new JObject(new JProperty("source", DdsImageIndex.Id)));
		}
	}
}
