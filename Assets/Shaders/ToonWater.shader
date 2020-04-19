Shader "Custom/ToonWater" {
	Properties {
		_Color("Color", Color) = (0.5, 0.65, 1, 1)

		_SurfaceNoise("Surface Noise Texture", 2D) = "white" {}
		_SurfaceNoiseCutoff("Surface Noise Cutoff", Range(0,1)) = 0.777
		_SurfaceNoiseScroll("Surface Noise Scroll", Vector) = (0.03,0.03,0,0)

		_SurfaceDistortionNoise("Surface Distortion Noise", 2D) = "white" {}
		_SurfaceDistortionScale("Surface Distortion Scale", float) = 0.27
	}
	SubShader {
		Pass {
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"


			float4 _Color;

			sampler2D _SurfaceNoise;
			float4 _SurfaceNoise_ST;
			float _SurfaceNoiseCutoff;
			float2 _SurfaceNoiseScroll;

			sampler2D _SurfaceDistortionNoise;
			float4 _SurfaceDistortionNoise_ST;
			float _SurfaceDistortionScale;

			struct appdata {
				float4 vertex : POSITION;
				float4 uv : TEXCOORD0;
			};

			struct v2f {
				float4 pos : SV_POSITION;
				float2 noiseUV: TEXCOORD0;
				float2 distortUV: TEXCOORD1;
			};


			v2f vert(appdata v) {
				v2f o;
				o.pos = UnityObjectToClipPos(v.vertex);
				o.noiseUV = TRANSFORM_TEX(v.uv, _SurfaceNoise);
				o.distortUV = TRANSFORM_TEX(v.uv, _SurfaceDistortionNoise);
				return o;
			}


			float4 frag(v2f i) : SV_Target{
				float2 distortSample = (tex2D(_SurfaceDistortionNoise, i.distortUV).xy) * _SurfaceDistortionScale;

				float2 samplePos = float2(i.noiseUV.x + _Time.y * _SurfaceNoiseScroll.x + distortSample.x, i.noiseUV.y + _Time.y * _SurfaceNoiseScroll.y + distortSample.y);
				float surfaceNoiseSample = tex2D(_SurfaceNoise, samplePos).r;

				float surfaceNoise = surfaceNoiseSample > _SurfaceNoiseCutoff ? 1 : 0;
				return _Color + surfaceNoise;
			}
			ENDCG
		}
	}
}