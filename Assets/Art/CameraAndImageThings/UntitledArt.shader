﻿Shader "Unlit/UntitledArt"
{
	Properties{
		// _MainTex("Base (RGB)", 2D) = "white" {}

		 _MainTex("Texture", 2D) = "white" {}

		_Color("Color", COLOR) = (1,1,1,1)
	}

		SubShader{
			ZWrite Off

			Pass {
				Tags {"Queue" = "Transparent" "IgnoreProjector" = "True" "LightMode" = "ForwardBase"}
				CGPROGRAM
				#pragma vertex vert 
				#pragma fragment frag 
				#include "UnityCG.cginc" 
				#pragma multi_compile_fwdbase 
				#include "AutoLight.cginc" 
				sampler2D _MainTex;
				float4 _MainTex_ST;

				struct v2f {
					float4 pos : SV_POSITION;
					LIGHTING_COORDS(0,1)
					float2 uv : TEXCOORD2;
				};

				v2f vert(appdata_base v) {
					v2f o;
					o.pos = UnityObjectToClipPos(v.vertex);
					o.uv = TRANSFORM_TEX(v.texcoord, _MainTex);
					TRANSFER_VERTEX_TO_FRAGMENT(o);
					return o;
				}
				float4 _Color;
				fixed4 frag(v2f i) : COLOR
				{
					float attenuation = LIGHT_ATTENUATION(i);
					return tex2D(_MainTex, i.uv) * attenuation * _Color;
				}
				ENDCG
			}
			/*
			Pass {
				Blend One One
				Tags { "LightMode" = "ForwardAdd" "RenderType" = "Opaque" }
				CGPROGRAM
				#pragma vertex vert 
				#pragma fragment frag 
				#include "UnityCG.cginc" 
				#pragma multi_compile_fwdadd_fullshadows 
				#include "AutoLight.cginc" 
				sampler2D _MainTex;
				float4 _MainTex_ST;

				struct v2f {
					float4 pos : SV_POSITION;
					LIGHTING_COORDS(0,1)
					float2 uv : TEXCOORD2;
				};



				v2f vert(appdata_base v) {
					v2f o;
					o.pos = UnityObjectToClipPos(v.vertex);
					o.uv = TRANSFORM_TEX(v.texcoord, _MainTex);
					TRANSFER_VERTEX_TO_FRAGMENT(o);
					return o;
				}



				fixed4 frag(v2f i) : COLOR
				{
					float attenuation = LIGHT_ATTENUATION(i);
					return ((tex2D(_MainTex, i.uv)) * attenuation) * _Color;

				}


				ENDCG
			}
			*/
		}
			Fallback "VertexLit"
}
