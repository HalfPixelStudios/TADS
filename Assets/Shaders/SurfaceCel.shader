Shader "Custom/SurfaceCel" {
	Properties{
		_Color("Tint", Color) = (1,1,1,1)
		_MainTex("Texture", 2D) = "white" {}

		_ShadowTint("Shadow Color", Color) = (0,0,0,1)
		//lighting options
		_MinLight("Min Light",float) = 0.5
		_LightingSteps("Lighting Steps",int) = 4
		_LightingOffset("Lighting Offset",float) = 0.25
	}
	Subshader{

		Tags {

			"RenderType" = "Opaque"
			"Queue" = "Geometry"
		}

		CGPROGRAM

		#pragma surface surf Custom fullforwardshadows
		#pragma target 3.0


		float4 _Color;
		sampler2D _MainTex;
		float3 _ShadowTint;

		float _MinLight;
		int _LightingSteps;
		float _LightingOffset;

		struct Input {
			float2 uv_MainTex;
		};

		float4 LightingCustom(SurfaceOutput s, float3 lightDir, half3 viewDir, float atten) {
			float NdotL = dot(s.Normal, lightDir);
			float intensity = lerp(_MinLight, 1, ceil(NdotL * _LightingSteps + _LightingOffset) / _LightingSteps);

			
			float3 shadowCol = s.Albedo * _ShadowTint;
			float4 color;
			color.rgb = lerp(shadowCol, s.Albedo, intensity) * _LightColor0.rgb;
			color.a = s.Alpha;
			/*
			//shadows
			//float attenChange = fwdith(atten)
			
			float4 col;
			col.rgb = intensity * s.Albedo * atten * _LightColor0.rgb;
			*/
			return intensity;
		}

		void surf(Input i, inout SurfaceOutput o) {
			fixed4 col = tex2D(_MainTex, i.uv_MainTex);
			col *= _Color;
			o.Albedo = col.rgb;
		}

		ENDCG
		

	}
	FallBack "Standard"
}