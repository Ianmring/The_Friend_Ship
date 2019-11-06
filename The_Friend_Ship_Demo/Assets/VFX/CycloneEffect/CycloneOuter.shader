// Shader created with Shader Forge v1.38 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:33216,y:32870,varname:node_3138,prsc:2|emission-234-OUT,alpha-1945-OUT;n:type:ShaderForge.SFN_Tex2d,id:2689,x:32074,y:32705,ptovrint:False,ptlb:node_2689,ptin:_node_2689,varname:node_2689,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:aa536582c56562044bace412eff4e0b9,ntxv:0,isnm:False|UVIN-72-UVOUT;n:type:ShaderForge.SFN_Panner,id:72,x:31876,y:32682,varname:node_72,prsc:2,spu:1,spv:0|UVIN-9492-UVOUT,DIST-70-OUT;n:type:ShaderForge.SFN_TexCoord,id:9492,x:31672,y:32663,varname:node_9492,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Tex2d,id:9382,x:32086,y:33031,ptovrint:False,ptlb:node_9382,ptin:_node_9382,varname:node_9382,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:4e020603735ec4e4bad47ecdaeafc2ff,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:1945,x:32389,y:33085,varname:node_1945,prsc:2|A-2689-R,B-9382-R;n:type:ShaderForge.SFN_Time,id:8571,x:31487,y:32911,varname:node_8571,prsc:2;n:type:ShaderForge.SFN_Multiply,id:70,x:31703,y:32837,varname:node_70,prsc:2|A-4501-OUT,B-8571-TSL;n:type:ShaderForge.SFN_ValueProperty,id:4501,x:31487,y:32852,ptovrint:False,ptlb:OuterSpeed,ptin:_OuterSpeed,varname:node_4501,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:10;n:type:ShaderForge.SFN_Color,id:7564,x:32362,y:32920,ptovrint:False,ptlb:node_7564,ptin:_node_7564,varname:node_7564,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.2783019,c2:0.6953546,c3:1,c4:1;n:type:ShaderForge.SFN_Multiply,id:5320,x:32598,y:32920,varname:node_5320,prsc:2|A-7564-RGB,B-1945-OUT;n:type:ShaderForge.SFN_Add,id:1365,x:32766,y:32857,varname:node_1365,prsc:2|A-8145-RGB,B-5320-OUT;n:type:ShaderForge.SFN_Color,id:8145,x:32312,y:32644,ptovrint:False,ptlb:node_8145,ptin:_node_8145,varname:node_8145,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.01432895,c2:0.3561992,c3:0.4339623,c4:1;n:type:ShaderForge.SFN_Clamp01,id:234,x:32945,y:32857,varname:node_234,prsc:2|IN-1365-OUT;proporder:2689-9382-4501-7564-8145;pass:END;sub:END;*/

Shader "Shader Forge/CycloneOuter" {
    Properties {
        _node_2689 ("node_2689", 2D) = "white" {}
        _node_9382 ("node_9382", 2D) = "white" {}
        _OuterSpeed ("OuterSpeed", Float ) = 10
        _node_7564 ("node_7564", Color) = (0.2783019,0.6953546,1,1)
        _node_8145 ("node_8145", Color) = (0.01432895,0.3561992,0.4339623,1)
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
            uniform sampler2D _node_2689; uniform float4 _node_2689_ST;
            uniform sampler2D _node_9382; uniform float4 _node_9382_ST;
            uniform float _OuterSpeed;
            uniform float4 _node_7564;
            uniform float4 _node_8145;
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
                float4 node_8571 = _Time;
                float2 node_72 = (i.uv0+(_OuterSpeed*node_8571.r)*float2(1,0));
                float4 _node_2689_var = tex2D(_node_2689,TRANSFORM_TEX(node_72, _node_2689));
                float4 _node_9382_var = tex2D(_node_9382,TRANSFORM_TEX(i.uv0, _node_9382));
                float node_1945 = (_node_2689_var.r*_node_9382_var.r);
                float3 emissive = saturate((_node_8145.rgb+(_node_7564.rgb*node_1945)));
                float3 finalColor = emissive;
                return fixed4(finalColor,node_1945);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
