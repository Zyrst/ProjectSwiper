Shader "Custom/SpellCooldownShader"
{
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}
	}
		SubShader
	{
		Tags{ "Queue" = "Overlay" }

		Cull Off
		ZWrite Off
		ZTest Off
		Blend SrcAlpha OneMinusSrcAlpha

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
				float4 color : COLOR;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
				float4 color : COLOR;
			};

			v2f vert(appdata v)
			{
				v2f o;
				o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
				o.uv = v.uv;
				o.color = v.color;
				return o;
			}

			sampler2D _MainTex;
			uniform float timer;
			uniform float blingTimer;
			float _InactiveColorA;

			fixed4 frag(v2f i) : SV_Target
			{
				float2 uv = i.uv;
				fixed4 col = tex2D(_MainTex, uv);
				fixed4 outCol = col * i.color;

				// Grey scale
				//float avg = (outCol.r + outCol.g + outCol.b) / 3.0;
				//avg -= 0.2;
				float avg = dot(outCol.rgb, float3(0.2125, 0.7154, 0.0721));
				avg -= 0.2;
				fixed4 inactiveColor = float4(avg, avg, avg, outCol.a * 0.3);

				// Gradually light up button
				fixed4 gradLerp = lerp(inactiveColor, outCol, smoothstep(uv.y, uv.y + 0.075, timer));

				// Add white gradient
				float fx = smoothstep(uv.y, uv.y + 0.075, timer) - smoothstep(uv.y, uv.y + 0.3, timer);
				float f = 1-smoothstep(0.95, 1, timer);
				gradLerp += lerp(float4(0, 0, 0, 0), float4(f, f, f, gradLerp.a), fx * (timer < 1));


				float btt = blingTimer * 2;
				float fxx = smoothstep(0, 0.5, btt) - smoothstep(0.5, 1, btt);
				gradLerp.rgb += lerp(float3(0, 0, 0), float3(0.05, 0.05, 0.05), fxx);

				return gradLerp;
			}
			ENDCG
		}
	}
}