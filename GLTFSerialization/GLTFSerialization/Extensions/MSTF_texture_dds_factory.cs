using GLTF.Schema;
using Newtonsoft.Json.Linq;

namespace GLTF.Schema
{
	/// <summary>
	/// A GLTF extension factory, required to create a gltf extension.
	/// The factory reads in the GLTF file and picks out the dds texture info we've added in.
	/// 
	/// This is the Microsoft extension to the standard gltf texture to allow dds images.
	/// </summary>
	public class MSFT_texture_dds_factory : ExtensionFactory
	{
		public MSFT_texture_dds_factory()
		{
			ExtensionName = MSFT_texture_dds.EXTENSION_NAME;
		}

		public override IExtension Deserialize(GLTFRoot root, JProperty extensionToken)
		{
			if (extensionToken != null && extensionToken.Value["source"] != null)
			{
				return new MSFT_texture_dds((int)extensionToken.Value["source"], root);
			}

			return null;
		}
	}
}
