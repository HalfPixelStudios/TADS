Shader "Unlit/VertexWater" {
	Properties{
		_Color("Tint",Color) = (1,1,1,1)
		_WaveStrength("Wave Strength",float) = 1.0
		_WaveSpeed("Wave Speed",float) = 100
	}
	SubShader{
		Pass {
			Tags {
				"RenderType" = "transparent"

			}
			//Cull Off

			CGPROGRAM

			//#pragma surface surf Standard fullfowardshadows vertex:vert
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"
			float4 _Color;
			float _WaveStrength;
			float _WaveSpeed;

			struct appdata {
				float4 vertex : POSITION;
			};

			struct v2f {
				float4 pos: SV_POSITION;
			};
			
			v2f vert(appdata v) {
				v2f o;
				//o.pos = UnityObjectToClipPos(v.vertex);

				
				float4 worldPos = mul(unity_ObjectToWorld, v.vertex);

				float displacement = (cos(worldPos.y) + cos(worldPos.x + (_WaveSpeed * _Time)));
				worldPos.y += displacement * _WaveStrength;

				o.pos = mul(UNITY_MATRIX_VP, worldPos);
				
				

				return o;
			}

			float4 frag(v2f i) : SV_TARGET{
				return _Color;
			}

			ENDCG
		}




	}
}
