// Upgrade NOTE: replaced '_World2Object' with 'unity_WorldToObject'


Shader "My/tube" {
	properties
	{
		_MainTex("_MainTex", 2D) = ""{}
		_F("F", range(0, 10)) = 1
		_A("A", range(0, 1)) = 0.1
		_R("R", range(0, 1)) = 0.1
	}
	SubShader
	{
		pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "unitycg.cginc"
			float4 _MainTex_ST;
			float _F;
			float _A;
			float _R;
			struct v2f
			{
				float4 pos:POSITION;
				float2 uv:TEXCOORD0;
			};
			sampler2D _MainTex;
			sampler2D WaveTex;
			v2f vert(appdata_base v)
			{
				v2f o;

				o.pos = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.texcoord.xy, _MainTex);
//			
				return o;
			}

			fixed4 frag(v2f IN):COLOR
			{
				float4 color = tex2D(_MainTex, IN.uv);
				return color;
			}
			ENDCG
		}
	}
}