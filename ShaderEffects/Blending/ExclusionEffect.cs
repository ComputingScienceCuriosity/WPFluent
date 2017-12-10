using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;

using WPFluent.UriPack;
namespace WPFluent.ShaderEffects.Blending
{
	public class ExclusionEffect : BlendModeEffect
	{
		static ExclusionEffect()
		{
			_pixelShader.UriSource ="ShaderSource/ExclusionEffect.ps".ExtractResourceFileUri();
		}

		public ExclusionEffect()
		{
			this.PixelShader = _pixelShader;
		}

		private static PixelShader _pixelShader = new PixelShader();
	}
}
