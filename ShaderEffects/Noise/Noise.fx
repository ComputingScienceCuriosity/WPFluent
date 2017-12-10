//--------------------------------------------------------------------------------------
// 
// WPF ShaderEffect HLSL -- NoisEffect
//
//--------------------------------------------------------------------------------------

sampler2D input : register(s0);

sampler2D randomInput : register(s1);

float Ratio : register(C0);
float4 main(float2 uv : TEXCOORD) : COLOR 
{ 
	float4 inputTex = tex2D(input, uv); 
	float4 randomTex = tex2D(randomInput, uv); 
	float4 noisedTex = inputTex + (inputTex * randomTex*Ratio);
	return noisedTex;
}
