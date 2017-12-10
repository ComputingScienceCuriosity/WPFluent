
using WPFluent.UriPack;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
namespace WPFluent.ShaderEffects
{
    public class NoiseEffect : ShaderEffect
    {
        #region Variables

        private static Type _typeOfThis              = typeof(NoiseEffect);

        private static double _viewPortWidthDefault  = 500;

        private static double _viewPortHeightDefault = 500;

        #endregion 

        #region DependencyProperties

        public static readonly DependencyProperty InputProperty          = ShaderEffect.RegisterPixelShaderSamplerProperty("Input", _typeOfThis, 0);

        public static readonly DependencyProperty RandomInputProperty    = ShaderEffect.RegisterPixelShaderSamplerProperty("RandomInput", _typeOfThis, 1);

        public static readonly DependencyProperty RatioProperty          = DependencyProperty.Register("Ratio", typeof(double), _typeOfThis, new UIPropertyMetadata(((double)(0.5d)), PixelShaderConstantCallback(0)));

        public static readonly DependencyProperty ViewPortWidthProperty  = DependencyProperty.Register("InputViewPort", typeof(Rect), _typeOfThis, new UIPropertyMetadata(new Rect(0, 0, _viewPortWidthDefault, _viewPortHeightDefault), PropertyChangedCallback));

        public static readonly DependencyProperty ViewPortHeightProperty = DependencyProperty.Register("ViewPortHeight", typeof(double), _typeOfThis, new UIPropertyMetadata(_viewPortHeightDefault));
       
        #endregion DependencyProperties

        #region Properties

        public Rect InputViewPort
        {
            get
            {
                return ((Rect)(this.GetValue(ViewPortWidthProperty)));
            }
            set
            {
                this.SetValue(ViewPortWidthProperty, value);
            }
        }

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

        public Brush RandomInput
        {
            get
            {
                return ((Brush)(this.GetValue(RandomInputProperty)));
            }
            set
            {
                this.SetValue(RandomInputProperty, value);
            }
        }

        public double Ratio
        {
            get
            {
                return ((double)(this.GetValue(RatioProperty)));
            }
            set
            {
                this.SetValue(RatioProperty, value);
            }
        }

        #endregion 

        #region Ctor

        public NoiseEffect()
        {
            PixelShader        = new PixelShader { UriSource = "/ShaderEffects/Noise/Noise.ps".ExtractResourceFileUri() };

            BitmapImage bitmap = new BitmapImage("/ShaderEffects/Noise/noise.png".ExtractResourceFileUri());

            RandomInput        = new ImageBrush(bitmap)
                                 {
                                     TileMode      = System.Windows.Media.TileMode.Tile,
                                     Viewport      = new Rect(0, 0, _viewPortWidthDefault, _viewPortHeightDefault),
                                     ViewportUnits = BrushMappingMode.Absolute
                                 };
         
            UpdateShaderValue(InputProperty);
            UpdateShaderValue(RandomInputProperty);
            UpdateShaderValue(RatioProperty);
        }

        #endregion 

        #region CallBacks

        private static void PropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            var obj = dependencyObject as NoiseEffect;
            if (obj != null)
            {
                ((ImageBrush)obj.GetValue(NoiseEffect.RandomInputProperty)).SetValue(ImageBrush.ViewportProperty, dependencyPropertyChangedEventArgs.NewValue);
            }
        }

        #endregion 
    }
}
