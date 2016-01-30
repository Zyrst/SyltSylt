Shader "Hidden/ChromaticAbberrations"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_Intensity("Intensity", Range(0,1)) = 0
		_RandRX("RandRX", float) = 0
		_RandRY("RandRY", float) = 0
		_RandGX("RandGX", float) = 0
		_RandGY("RandGY", float) = 0
		_RandBX("RandBX", float) = 0
		_RandBY("RandBY", float) = 0
		_Zoom("Zoom", float) = 0
	}
	SubShader
	{
		// No culling or depth
		Cull Off ZWrite Off ZTest Always

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
			};


			float _Intensity;
			float _Zoom;

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
				o.vertex.xy *= _Zoom;
				o.uv = v.uv;
				return o;
			}
			
			sampler2D _MainTex;


			float _RandRX;
			float _RandRY;
			float _RandGX;
			float _RandGY;
			float _RandBX;
			float _RandBY;

			fixed4 frag (v2f i) : SV_Target
			{
				fixed r = tex2D(_MainTex, i.uv + float2((_RandRX - 0.5) * _Intensity, (_RandRY - 0.5) * _Intensity)).r;
				fixed g = tex2D(_MainTex, i.uv + float2((_RandGX - 0.5) * _Intensity, (_RandBY - 0.5) * _Intensity)).g;
				fixed b = tex2D(_MainTex, i.uv + float2((_RandBX - 0.5) * _Intensity, (_RandBY - 0.5) * _Intensity)).b;
				fixed alpha = tex2D(_MainTex, i.uv).a;

				fixed4 col = fixed4(r, g, b, alpha);

				return col;
			}
			ENDCG
		}
	}
}
