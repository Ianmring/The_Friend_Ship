// Shader created with Shader Forge v1.38 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:3,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:1,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:33889,y:32475,varname:node_3138,prsc:2|emission-2741-OUT;n:type:ShaderForge.SFN_Panner,id:1888,x:32094,y:32837,varname:node_1888,prsc:2,spu:1,spv:1|UVIN-5764-UVOUT,DIST-5902-OUT;n:type:ShaderForge.SFN_TexCoord,id:5764,x:31832,y:32691,varname:node_5764,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Time,id:7739,x:31662,y:32908,varname:node_7739,prsc:2;n:type:ShaderForge.SFN_Multiply,id:5902,x:31900,y:32987,varname:node_5902,prsc:2|A-7739-TSL,B-2401-OUT;n:type:ShaderForge.SFN_Tex2d,id:4554,x:33005,y:32759,ptovrint:False,ptlb:CausticPattern,ptin:_CausticPattern,varname:node_4554,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:8aaa18f3fe53a434498630ce125718e5,ntxv:0,isnm:False|UVIN-9574-OUT;n:type:ShaderForge.SFN_Tex2d,id:9866,x:32381,y:32928,ptovrint:False,ptlb:DistortionClouds,ptin:_DistortionClouds,varname:node_9866,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:5a9db5f1cb473584f9892e86a5d00c05,ntxv:0,isnm:False|UVIN-1888-UVOUT;n:type:ShaderForge.SFN_Lerp,id:9574,x:32765,y:32943,varname:node_9574,prsc:2|A-71-UVOUT,B-9866-R,T-8124-OUT;n:type:ShaderForge.SFN_Slider,id:8124,x:32287,y:33127,ptovrint:False,ptlb:Distortion,ptin:_Distortion,varname:node_8124,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.02564103,max:1;n:type:ShaderForge.SFN_TexCoord,id:8179,x:32208,y:32319,varname:node_8179,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Tex2d,id:6499,x:33066,y:32438,ptovrint:False,ptlb:WaterColor,ptin:_WaterColor,varname:node_6499,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:d669184718888c5419faaabdabae603c,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Add,id:2741,x:33605,y:32549,varname:node_2741,prsc:2|A-9519-OUT,B-4549-OUT;n:type:ShaderForge.SFN_Subtract,id:8391,x:33267,y:32773,varname:node_8391,prsc:2|A-4554-RGB,B-1347-OUT;n:type:ShaderForge.SFN_Vector1,id:1347,x:33051,y:32944,varname:node_1347,prsc:2,v1:0.6;n:type:ShaderForge.SFN_Clamp01,id:4549,x:33439,y:32706,varname:node_4549,prsc:2|IN-8391-OUT;n:type:ShaderForge.SFN_Panner,id:71,x:32505,y:32411,varname:node_71,prsc:2,spu:1,spv:1|UVIN-8179-UVOUT,DIST-5839-OUT;n:type:ShaderForge.SFN_Time,id:2667,x:32073,y:32482,varname:node_2667,prsc:2;n:type:ShaderForge.SFN_Multiply,id:5839,x:32311,y:32561,varname:node_5839,prsc:2|A-2667-TSL,B-6773-OUT;n:type:ShaderForge.SFN_ValueProperty,id:6773,x:32094,y:32677,ptovrint:False,ptlb:WaterSpeed,ptin:_WaterSpeed,varname:node_6773,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:-0.3;n:type:ShaderForge.SFN_ValueProperty,id:2401,x:31662,y:33070,ptovrint:False,ptlb:DistortionSpeed,ptin:_DistortionSpeed,varname:node_2401,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.5;n:type:ShaderForge.SFN_Multiply,id:9519,x:33370,y:32325,varname:node_9519,prsc:2|A-9069-RGB,B-6499-RGB;n:type:ShaderForge.SFN_Color,id:9069,x:33009,y:32217,ptovrint:False,ptlb:ColorAdjust,ptin:_ColorAdjust,varname:node_9069,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:0;proporder:4554-9866-8124-6499-6773-2401-9069;pass:END;sub:END;*/

Shader "Shader Forge/Water2" {
    Properties {
        _CausticPattern ("CausticPattern", 2D) = "white" {}
        _DistortionClouds ("DistortionClouds", 2D) = "white" {}
        _Distortion ("Distortion", Range(0, 1)) = 0.02564103
        _WaterColor ("WaterColor", 2D) = "white" {}
        _WaterSpeed ("WaterSpeed", Float ) = -0.3
        _DistortionSpeed ("DistortionSpeed", Float ) = 0.5
        _ColorAdjust ("ColorAdjust", Color) = (1,1,1,0)
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "DEFERRED"
            Tags {
                "LightMode"="Deferred"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_DEFERRED
            #include "UnityCG.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile ___ UNITY_HDR_ON
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _CausticPattern; uniform float4 _CausticPattern_ST;
            uniform sampler2D _DistortionClouds; uniform float4 _DistortionClouds_ST;
            uniform float _Distortion;
            uniform sampler2D _WaterColor; uniform float4 _WaterColor_ST;
            uniform float _WaterSpeed;
            uniform float _DistortionSpeed;
            uniform float4 _ColorAdjust;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                return o;
            }
            void frag(
                VertexOutput i,
                out half4 outDiffuse : SV_Target0,
                out half4 outSpecSmoothness : SV_Target1,
                out half4 outNormal : SV_Target2,
                out half4 outEmission : SV_Target3 )
            {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
////// Lighting:
////// Emissive:
                float4 _WaterColor_var = tex2D(_WaterColor,TRANSFORM_TEX(i.uv0, _WaterColor));
                float4 node_2667 = _Time;
                float4 node_7739 = _Time;
                float2 node_1888 = (i.uv0+(node_7739.r*_DistortionSpeed)*float2(1,1));
                float4 _DistortionClouds_var = tex2D(_DistortionClouds,TRANSFORM_TEX(node_1888, _DistortionClouds));
                float2 node_9574 = lerp((i.uv0+(node_2667.r*_WaterSpeed)*float2(1,1)),float2(_DistortionClouds_var.r,_DistortionClouds_var.r),_Distortion);
                float4 _CausticPattern_var = tex2D(_CausticPattern,TRANSFORM_TEX(node_9574, _CausticPattern));
                float3 emissive = ((_ColorAdjust.rgb*_WaterColor_var.rgb)+saturate((_CausticPattern_var.rgb-0.6)));
                float3 finalColor = emissive;
                outDiffuse = half4( 0, 0, 0, 1 );
                outSpecSmoothness = half4(0,0,0,0);
                outNormal = half4( normalDirection * 0.5 + 0.5, 1 );
                outEmission = half4( ((_ColorAdjust.rgb*_WaterColor_var.rgb)+saturate((_CausticPattern_var.rgb-0.6))), 1 );
                #ifndef UNITY_HDR_ON
                    outEmission.rgb = exp2(-outEmission.rgb);
                #endif
            }
            ENDCG
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _CausticPattern; uniform float4 _CausticPattern_ST;
            uniform sampler2D _DistortionClouds; uniform float4 _DistortionClouds_ST;
            uniform float _Distortion;
            uniform sampler2D _WaterColor; uniform float4 _WaterColor_ST;
            uniform float _WaterSpeed;
            uniform float _DistortionSpeed;
            uniform float4 _ColorAdjust;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
////// Lighting:
////// Emissive:
                float4 _WaterColor_var = tex2D(_WaterColor,TRANSFORM_TEX(i.uv0, _WaterColor));
                float4 node_2667 = _Time;
                float4 node_7739 = _Time;
                float2 node_1888 = (i.uv0+(node_7739.r*_DistortionSpeed)*float2(1,1));
                float4 _DistortionClouds_var = tex2D(_DistortionClouds,TRANSFORM_TEX(node_1888, _DistortionClouds));
                float2 node_9574 = lerp((i.uv0+(node_2667.r*_WaterSpeed)*float2(1,1)),float2(_DistortionClouds_var.r,_DistortionClouds_var.r),_Distortion);
                float4 _CausticPattern_var = tex2D(_CausticPattern,TRANSFORM_TEX(node_9574, _CausticPattern));
                float3 emissive = ((_ColorAdjust.rgb*_WaterColor_var.rgb)+saturate((_CausticPattern_var.rgb-0.6)));
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
