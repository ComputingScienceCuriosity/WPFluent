using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;
using WPFluent.UriPack;

namespace WPFluent.ShaderEffects.Transparency
{
  public class TransparencyEffect : ShaderEffect 
  {

      #region Variables

        private static System.Type _typeOfThis              = typeof(TransparencyEffect);

        private static double _viewPortWidthDefault  = 500;

        private static double _viewPortHeightDefault = 500;

        #endregion 

        #region DependencyProperties

        public static readonly DependencyProperty InputProperty   = ShaderEffect.RegisterPixelShaderSamplerProperty("Input", _typeOfThis, 0);

        public static readonly DependencyProperty OpacityProperty = DependencyProperty.Register("Opacity", typeof(double), _typeOfThis, new UIPropertyMetadata(1.0d, PixelShaderConstantCallback(0)));
        #endregion DependencyProperties

        #region Properties

        public Brush Input
        {
            get
            {
                return ((Brush)(this.GetValue(InputProperty)));
            }
            set
            {
                this.SetValue(InputProperty, value);
            }
        }

        public double Opacity
        {
            get
            {
                return ((double)(this.GetValue(OpacityProperty)));
            }
            set
            {
                this.SetValue(OpacityProperty, value);
            }
        }

        #endregion 

        #region Ctor

        public TransparencyEffect()
        {
            PixelShader        = new PixelShader { UriSource = "/ShaderEffects/Transparency/Transparency.ps".ExtractResourceFileUri() };

            UpdateShaderValue(InputProperty);
            UpdateShaderValue(OpacityProperty);
        }

        #endregion 

  }
}
