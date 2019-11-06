// Shader created with Shader Forge v1.38 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:33287,y:32761,varname:node_3138,prsc:2|emission-3599-OUT,alpha-5590-OUT;n:type:ShaderForge.SFN_Panner,id:8467,x:32173,y:32728,varname:node_8467,prsc:2,spu:1,spv:0|UVIN-5778-OUT;n:type:ShaderForge.SFN_TexCoord,id:3070,x:31502,y:32583,varname:node_3070,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Tex2d,id:5071,x:32384,y:32728,ptovrint:False,ptlb:node_5071,ptin:_node_5071,varname:node_5071,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:e1a05ae9da7a98547bc1c3fab2210c27,ntxv:0,isnm:False|UVIN-8467-UVOUT;n:type:ShaderForge.SFN_Tex2d,id:4344,x:32215,y:33102,ptovrint:False,ptlb:node_4344,ptin:_node_4344,varname:node_4344,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:2716da30fdfdbeb40b94a94a8e5c0ba3,ntxv:0,isnm:False|UVIN-954-UVOUT;n:type:ShaderForge.SFN_Multiply,id:5590,x:32853,y:32982,varname:node_5590,prsc:2|A-4380-OUT,B-6757-OUT;n:type:ShaderForge.SFN_Color,id:4298,x:32231,y:32914,ptovrint:False,ptlb:node_4298,ptin:_node_4298,varname:node_4298,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Subtract,id:4380,x:32547,y:32891,varname:node_4380,prsc:2|A-4298-R,B-5071-R;n:type:ShaderForge.SFN_Subtract,id:6757,x:32501,y:33038,varname:node_6757,prsc:2|A-4298-R,B-4344-R;n:type:ShaderForge.SFN_TexCoord,id:6828,x:31448,y:32961,varname:node_6828,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Panner,id:954,x:32020,y:33089,varname:node_954,prsc:2,spu:1,spv:0|UVIN-9641-OUT,DIST-3904-OUT;n:type:ShaderForge.SFN_Multiply,id:3904,x:31675,y:33350,varname:node_3904,prsc:2|A-3636-OUT,B-5608-T;n:type:ShaderForge.SFN_Time,id:5608,x:31489,y:33373,varname:node_5608,prsc:2;n:type:ShaderForge.SFN_ValueProperty,id:3636,x:31489,y:33306,ptovrint:False,ptlb:ChunkSpeed,ptin:_ChunkSpeed,varname:node_3636,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.5;n:type:ShaderForge.SFN_Multiply,id:135,x:31733,y:32732,varname:node_135,prsc:2|A-3070-V,B-3160-OUT;n:type:ShaderForge.SFN_ValueProperty,id:3160,x:31564,y:32809,ptovrint:False,ptlb:WindTiling,ptin:_WindTiling,varname:node_3160,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:4;n:type:ShaderForge.SFN_Append,id:5778,x:31914,y:32699,varname:node_5778,prsc:2|A-3070-U,B-135-OUT;n:type:ShaderForge.SFN_ValueProperty,id:3163,x:31448,y:33164,ptovrint:False,ptlb:ChunkTiling,ptin:_ChunkTiling,varname:node_3163,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:4;n:type:ShaderForge.SFN_Multiply,id:8477,x:31642,y:33081,varname:node_8477,prsc:2|A-6828-V,B-3163-OUT;n:type:ShaderForge.SFN_Append,id:9641,x:31801,y:33044,varname:node_9641,prsc:2|A-6828-U,B-8477-OUT;n:type:ShaderForge.SFN_Color,id:2871,x:32562,y:32556,ptovrint:False,ptlb:node_2871,ptin:_node_2871,varname:node_2871,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.4386792,c2:0.5388903,c3:0.5849056,c4:1;n:type:ShaderForge.SFN_Multiply,id:7417,x:33053,y:32713,varname:node_7417,prsc:2|A-2871-RGB,B-5590-OUT;n:type:ShaderForge.SFN_Add,id:1405,x:32903,y:32433,varname:node_1405,prsc:2|A-827-RGB,B-7417-OUT;n:type:ShaderForge.SFN_Color,id:827,x:32520,y:32363,ptovrint:False,ptlb:node_827,ptin:_node_827,varname:node_827,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.04503383,c2:0.3625968,c3:0.4150943,c4:1;n:type:ShaderForge.SFN_Clamp01,id:3599,x:33080,y:32490,varname:node_3599,prsc:2|IN-1405-OUT;proporder:5071-4298-4344-3636-3160-3163-2871-827;pass:END;sub:END;*/

Shader "Shader Forge/CycloneInner" {
    Properties {
        _node_5071 ("node_5071", 2D) = "white" {}
        _node_4298 ("node_4298", Color) = (1,1,1,1)
        _node_4344 ("node_4344", 2D) = "white" {}
        _ChunkSpeed ("ChunkSpeed", Float ) = 0.5
        _WindTiling ("WindTiling", Float ) = 4
        _ChunkTiling ("ChunkTiling", Float ) = 4
        _node_2871 ("node_2871", Color) = (0.4386792,0.5388903,0.5849056,1)
        _node_827 ("node_827", Color) = (0.04503383,0.3625968,0.4150943,1)
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _node_5071; uniform float4 _node_5071_ST;
            uniform sampler2D _node_4344; uniform float4 _node_4344_ST;
            uniform float4 _node_4298;
            uniform float _ChunkSpeed;
            uniform float _WindTiling;
            uniform float _ChunkTiling;
            uniform float4 _node_2871;
            uniform float4 _node_827;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = UnityObjectToClipPos( v.vertex );
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
////// Lighting:
////// Emissive:
                float4 node_9214 = _Time;
                float2 node_8467 = (float2(i.uv0.r,(i.uv0.g*_WindTiling))+node_9214.g*float2(1,0));
                float4 _node_5071_var = tex2D(_node_5071,TRANSFORM_TEX(node_8467, _node_5071));
                float4 node_5608 = _Time;
                float2 node_954 = (float2(i.uv0.r,(i.uv0.g*_ChunkTiling))+(_ChunkSpeed*node_5608.g)*float2(1,0));
                float4 _node_4344_var = tex2D(_node_4344,TRANSFORM_TEX(node_954, _node_4344));
                float node_5590 = ((_node_4298.r-_node_5071_var.r)*(_node_4298.r-_node_4344_var.r));
                float3 emissive = saturate((_node_827.rgb+(_node_2871.rgb*node_5590)));
                float3 finalColor = emissive;
                return fixed4(finalColor,node_5590);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
