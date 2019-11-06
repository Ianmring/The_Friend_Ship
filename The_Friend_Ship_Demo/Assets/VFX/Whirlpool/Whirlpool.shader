// Shader created with Shader Forge v1.38 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:34459,y:33024,varname:node_3138,prsc:2|emission-5077-OUT,alpha-255-R;n:type:ShaderForge.SFN_Rotator,id:6226,x:32390,y:32844,varname:node_6226,prsc:2|UVIN-8013-OUT,SPD-7636-OUT;n:type:ShaderForge.SFN_Tex2d,id:6768,x:31934,y:32775,ptovrint:False,ptlb:UVFlowMap,ptin:_UVFlowMap,varname:node_6768,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:552f96f3fad0c3540b73052c9ebe2b07,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Append,id:8013,x:32160,y:32795,varname:node_8013,prsc:2|A-6768-R,B-6768-G;n:type:ShaderForge.SFN_ValueProperty,id:7636,x:32045,y:33010,ptovrint:False,ptlb:SpinSpeed,ptin:_SpinSpeed,varname:node_7636,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:-2.5;n:type:ShaderForge.SFN_Multiply,id:3582,x:33308,y:32975,varname:node_3582,prsc:2|A-6000-OUT,B-255-RGB;n:type:ShaderForge.SFN_Tex2d,id:3612,x:32580,y:33073,ptovrint:False,ptlb:BarTexture,ptin:_BarTexture,varname:node_3612,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:6c34cf2cb7cece74596b18a750c060c1,ntxv:0,isnm:False|UVIN-6226-UVOUT;n:type:ShaderForge.SFN_Add,id:5077,x:33518,y:33050,varname:node_5077,prsc:2|A-3582-OUT,B-4868-RGB;n:type:ShaderForge.SFN_Color,id:4868,x:33235,y:33132,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_4868,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0,c2:0.667409,c3:0.754717,c4:1;n:type:ShaderForge.SFN_Tex2d,id:255,x:32815,y:33307,ptovrint:False,ptlb:RadialMask,ptin:_RadialMask,varname:node_255,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:6d6573a3310170e4cb1ed4105a13c7e3,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:6000,x:32894,y:32957,varname:node_6000,prsc:2|A-7519-OUT,B-3612-RGB;n:type:ShaderForge.SFN_ValueProperty,id:7519,x:32619,y:32913,ptovrint:False,ptlb:Brightness,ptin:_Brightness,varname:node_7519,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.8;proporder:6768-7636-3612-4868-255-7519;pass:END;sub:END;*/

Shader "Shader Forge/Whirlpool" {
    Properties {
        _UVFlowMap ("UVFlowMap", 2D) = "white" {}
        _SpinSpeed ("SpinSpeed", Float ) = -2.5
        _BarTexture ("BarTexture", 2D) = "white" {}
        _Color ("Color", Color) = (0,0.667409,0.754717,1)
        _RadialMask ("RadialMask", 2D) = "white" {}
        _Brightness ("Brightness", Float ) = 0.8
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
            uniform sampler2D _UVFlowMap; uniform float4 _UVFlowMap_ST;
            uniform float _SpinSpeed;
            uniform sampler2D _BarTexture; uniform float4 _BarTexture_ST;
            uniform float4 _Color;
            uniform sampler2D _RadialMask; uniform float4 _RadialMask_ST;
            uniform float _Brightness;
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
                float4 node_487 = _Time;
                float node_6226_ang = node_487.g;
                float node_6226_spd = _SpinSpeed;
                float node_6226_cos = cos(node_6226_spd*node_6226_ang);
                float node_6226_sin = sin(node_6226_spd*node_6226_ang);
                float2 node_6226_piv = float2(0.5,0.5);
                float4 _UVFlowMap_var = tex2D(_UVFlowMap,TRANSFORM_TEX(i.uv0, _UVFlowMap));
                float2 node_6226 = (mul(float2(_UVFlowMap_var.r,_UVFlowMap_var.g)-node_6226_piv,float2x2( node_6226_cos, -node_6226_sin, node_6226_sin, node_6226_cos))+node_6226_piv);
                float4 _BarTexture_var = tex2D(_BarTexture,TRANSFORM_TEX(node_6226, _BarTexture));
                float4 _RadialMask_var = tex2D(_RadialMask,TRANSFORM_TEX(i.uv0, _RadialMask));
                float3 node_5077 = (((_Brightness*_BarTexture_var.rgb)*_RadialMask_var.rgb)+_Color.rgb);
                float3 emissive = node_5077;
                float3 finalColor = emissive;
                return fixed4(finalColor,_RadialMask_var.r);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
