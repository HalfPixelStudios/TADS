Shader "Custom/Cel" {
	Properties{
		_Color("Tint", Color) = (1,1,1,1)
		_MainTex("Texture", 2D) = "white" {}
		[HDR] _AmbientColor("Ambient Color", Color) = (0.4,0.4,0.4,1)

		//lighting ooptions
		_MinLight("Min Light",float) = 0.5
		_LightingScale("Lighting Scale",float) = 1
		_LightingSteps("Lighting Steps",int) = 4
		_LightingOffset("Lighting Offset",float) = 0.25
		
	}
	Subshader{
		Pass {
			Tags {

				"LightMode" = "ForwardBase"
				"PassFlags" = "OnlyDirectional"

			}

			CGPROGRAM

			#pragma vertex vert
			#pragma fragment frag
			#pragma multi_compile_fwdbase
			//#pragma surface surf Standard fullforwardshadows

			#include "UnityCG.cginc"
			#include "Lighting.cginc"
			#include "AutoLight.cginc"

			float4 _Color;
			sampler2D _MainTex;
			float4 _MainTex_ST;
			float4 _AmbientColor;

			float _MinLight;
			float _LightingScale;
			int _LightingSteps;
			float _LightingOffset;

			struct appdata {
				float4 vertex: POSITION;
				float2 uv: TEXCOORD0;
				float3 normal: NORMAL;
			};

			struct v2f {
				float4 pos: SV_POSITION;
				float2 uv: TEXCOORD0;
				float3 worldNormal: NORMAL;
				float3 viewDir: TEXCOORD1;
				SHADOW_COORDS(2)
			};

			v2f vert(appdata v) {
				v2f o;
				o.pos = UnityObjectToClipPos(v.vertex);
				o.worldNormal = UnityObjectToWorldNormal(v.normal);
				o.viewDir = WorldSpaceViewDir(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				TRANSFER_SHADOW(o)
				return o;
			}

			fixed4 frag(v2f i) : SV_TARGET{
				float4 sample = tex2D(_MainTex, i.uv);

				//calculate how much light is being recieved
				float3 normal = normalize(i.worldNormal);
				float NdotL = dot(_WorldSpaceLightPos0, normal);

				//float intensity = (NdotL > 0) ? 1 : 0; //only if light hits head on
				//float intensity = smoothstep(0, 0.1, NdotL);
				float shadow = SHADOW_ATTENUATION(i); //handles wether or not directional light casts shadows
				float intensity = lerp(_MinLight, 1, ceil(NdotL * shadow * _LightingScale + _LightingOffset)/_LightingSteps);

				return _Color * sample * (intensity * _LightColor0 + _AmbientColor);
			}

			ENDCG
		}
		UsePass "Legacy Shaders/VertexLit/SHADOWCASTER"
	}

}