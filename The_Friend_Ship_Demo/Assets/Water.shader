// Shader created with Shader Forge v1.38 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:33749,y:32661,varname:node_3138,prsc:2|emission-5573-OUT,alpha-1010-OUT;n:type:ShaderForge.SFN_Add,id:5573,x:33365,y:32770,varname:node_5573,prsc:2|A-6178-RGB,B-7863-OUT;n:type:ShaderForge.SFN_Tex2d,id:3415,x:32024,y:32910,ptovrint:False,ptlb:node_3415,ptin:_node_3415,varname:node_3415,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:82118b7a582f7f449af45b301a1f0fa8,ntxv:0,isnm:False|UVIN-9516-OUT;n:type:ShaderForge.SFN_Tex2d,id:9806,x:32313,y:33172,ptovrint:False,ptlb:node_3415_copy,ptin:_node_3415_copy,varname:_node_3415_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:82118b7a582f7f449af45b301a1f0fa8,ntxv:0,isnm:False|UVIN-8275-OUT;n:type:ShaderForge.SFN_Panner,id:6118,x:32108,y:33130,varname:node_6118,prsc:2,spu:1,spv:1|UVIN-131-OUT,DIST-466-OUT;n:type:ShaderForge.SFN_TexCoord,id:9848,x:31683,y:33068,varname:node_9848,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Multiply,id:131,x:31926,y:33130,varname:node_131,prsc:2|A-9848-UVOUT,B-4568-OUT;n:type:ShaderForge.SFN_Vector1,id:4568,x:31699,y:33246,varname:node_4568,prsc:2,v1:2;n:type:ShaderForge.SFN_Time,id:4965,x:31787,y:33473,varname:node_4965,prsc:2;n:type:ShaderForge.SFN_Vector1,id:4610,x:31787,y:33404,varname:node_4610,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Multiply,id:466,x:31991,y:33416,varname:node_466,prsc:2|A-4610-OUT,B-4965-TSL;n:type:ShaderForge.SFN_Multiply,id:2230,x:32561,y:33022,varname:node_2230,prsc:2|A-1945-OUT,B-9806-RGB;n:type:ShaderForge.SFN_Tex2d,id:939,x:32106,y:32688,ptovrint:False,ptlb:node_939,ptin:_node_939,varname:node_939,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:54b28ffc72981634e86d424bc91b7271,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Add,id:5269,x:32232,y:32877,varname:node_5269,prsc:2|A-3415-RGB,B-3415-RGB;n:type:ShaderForge.SFN_ValueProperty,id:5040,x:32179,y:33061,ptovrint:False,ptlb:Wave Brightness,ptin:_WaveBrightness,varname:node_5040,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.7;n:type:ShaderForge.SFN_Multiply,id:1945,x:32384,y:32977,varname:node_1945,prsc:2|A-5269-OUT,B-5040-OUT;n:type:ShaderForge.SFN_ValueProperty,id:1010,x:33023,y:33283,ptovrint:False,ptlb:Transparency,ptin:_Transparency,varname:node_1010,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.7;n:type:ShaderForge.SFN_Tex2d,id:6178,x:32264,y:32546,ptovrint:False,ptlb:node_6178,ptin:_node_6178,varname:node_6178,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:d669184718888c5419faaabdabae603c,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Lerp,id:9516,x:31839,y:32669,varname:node_9516,prsc:2|A-5839-UVOUT,B-8517-R,T-8735-OUT;n:type:ShaderForge.SFN_Tex2d,id:8517,x:31585,y:32768,ptovrint:False,ptlb:node_8517,ptin:_node_8517,varname:node_8517,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:5a9db5f1cb473584f9892e86a5d00c05,ntxv:0,isnm:False|UVIN-5117-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:5839,x:31557,y:32600,varname:node_5839,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Slider,id:8735,x:31485,y:32950,ptovrint:False,ptlb:Distortion,ptin:_Distortion,varname:node_8735,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.05307711,max:1;n:type:ShaderForge.SFN_Panner,id:5117,x:31229,y:32715,varname:node_5117,prsc:2,spu:1,spv:1|UVIN-7337-UVOUT,DIST-9363-OUT;n:type:ShaderForge.SFN_TexCoord,id:7337,x:31010,y:32644,varname:node_7337,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Time,id:4318,x:30838,y:32898,varname:node_4318,prsc:2;n:type:ShaderForge.SFN_ValueProperty,id:8304,x:30857,y:32828,ptovrint:False,ptlb:D_Flow_Speed,ptin:_D_Flow_Speed,varname:node_8304,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.5;n:type:ShaderForge.SFN_Multiply,id:9363,x:31072,y:32848,varname:node_9363,prsc:2|A-8304-OUT,B-4318-TSL;n:type:ShaderForge.SFN_Lerp,id:8275,x:31495,y:33410,varname:node_8275,prsc:2|A-7018-OUT,B-6384-R,T-8960-OUT;n:type:ShaderForge.SFN_Tex2d,id:6384,x:31241,y:33509,ptovrint:False,ptlb:node_8517_copy,ptin:_node_8517_copy,varname:_node_8517_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:5a9db5f1cb473584f9892e86a5d00c05,ntxv:0,isnm:False|UVIN-6548-UVOUT;n:type:ShaderForge.SFN_Slider,id:8960,x:31141,y:33691,ptovrint:False,ptlb:DistortionPanning,ptin:_DistortionPanning,varname:_Distortion_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.05307711,max:1;n:type:ShaderForge.SFN_Panner,id:6548,x:30885,y:33456,varname:node_6548,prsc:2,spu:1,spv:1|UVIN-6197-UVOUT,DIST-4581-OUT;n:type:ShaderForge.SFN_TexCoord,id:6197,x:30666,y:33385,varname:node_6197,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Time,id:28,x:30494,y:33639,varname:node_28,prsc:2;n:type:ShaderForge.SFN_ValueProperty,id:6592,x:30513,y:33569,ptovrint:False,ptlb:D_Flow_Speed_Panning,ptin:_D_Flow_Speed_Panning,varname:_D_Flow_Speed_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.5;n:type:ShaderForge.SFN_Multiply,id:4581,x:30728,y:33589,varname:node_4581,prsc:2|A-6592-OUT,B-28-TSL;n:type:ShaderForge.SFN_TexCoord,id:5127,x:30848,y:33079,varname:node_5127,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Multiply,id:7018,x:31091,y:33141,varname:node_7018,prsc:2|A-5127-UVOUT,B-4042-OUT;n:type:ShaderForge.SFN_Vector1,id:4042,x:30864,y:33257,varname:node_4042,prsc:2,v1:2;n:type:ShaderForge.SFN_Subtract,id:4942,x:32716,y:33118,varname:node_4942,prsc:2|A-2230-OUT,B-7982-OUT;n:type:ShaderForge.SFN_Multiply,id:2680,x:32884,y:33223,varname:node_2680,prsc:2|A-4942-OUT,B-6146-OUT;n:type:ShaderForge.SFN_Clamp01,id:5261,x:32997,y:32927,varname:node_5261,prsc:2|IN-2680-OUT;n:type:ShaderForge.SFN_Subtract,id:4276,x:33161,y:32928,varname:node_4276,prsc:2|A-5261-OUT,B-1681-OUT;n:type:ShaderForge.SFN_Vector1,id:1681,x:33008,y:33134,varname:node_1681,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Clamp01,id:7863,x:33314,y:32907,varname:node_7863,prsc:2|IN-4276-OUT;n:type:ShaderForge.SFN_Vector1,id:6146,x:32549,y:33329,varname:node_6146,prsc:2,v1:10;n:type:ShaderForge.SFN_ValueProperty,id:7982,x:32470,y:33260,ptovrint:False,ptlb:Treshold,ptin:_Treshold,varname:node_7982,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.15;proporder:3415-9806-939-5040-1010-6178-8517-8735-8304-6384-8960-6592-7982;pass:END;sub:END;*/

Shader "Shader Forge/Water" {
    Properties {
        _node_3415 ("node_3415", 2D) = "white" {}
        _node_3415_copy ("node_3415_copy", 2D) = "white" {}
        _node_939 ("node_939", 2D) = "white" {}
        _WaveBrightness ("Wave Brightness", Float ) = 0.7
        _Transparency ("Transparency", Float ) = 0.7
        _node_6178 ("node_6178", 2D) = "white" {}
        _node_8517 ("node_8517", 2D) = "white" {}
        _Distortion ("Distortion", Range(0, 1)) = 0.05307711
        _D_Flow_Speed ("D_Flow_Speed", Float ) = 0.5
        _node_8517_copy ("node_8517_copy", 2D) = "white" {}
        _DistortionPanning ("DistortionPanning", Range(0, 1)) = 0.05307711
        _D_Flow_Speed_Panning ("D_Flow_Speed_Panning", Float ) = 0.5
        _Treshold ("Treshold", Float ) = 0.15
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
            uniform sampler2D _node_3415; uniform float4 _node_3415_ST;
            uniform sampler2D _node_3415_copy; uniform float4 _node_3415_copy_ST;
            uniform float _WaveBrightness;
            uniform float _Transparency;
            uniform sampler2D _node_6178; uniform float4 _node_6178_ST;
            uniform sampler2D _node_8517; uniform float4 _node_8517_ST;
            uniform float _Distortion;
            uniform float _D_Flow_Speed;
            uniform sampler2D _node_8517_copy; uniform float4 _node_8517_copy_ST;
            uniform float _DistortionPanning;
            uniform float _D_Flow_Speed_Panning;
            uniform float _Treshold;
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
                float4 _node_6178_var = tex2D(_node_6178,TRANSFORM_TEX(i.uv0, _node_6178));
                float4 node_4318 = _Time;
                float2 node_5117 = (i.uv0+(_D_Flow_Speed*node_4318.r)*float2(1,1));
                float4 _node_8517_var = tex2D(_node_8517,TRANSFORM_TEX(node_5117, _node_8517));
                float2 node_9516 = lerp(i.uv0,float2(_node_8517_var.r,_node_8517_var.r),_Distortion);
                float4 _node_3415_var = tex2D(_node_3415,TRANSFORM_TEX(node_9516, _node_3415));
                float4 node_28 = _Time;
                float2 node_6548 = (i.uv0+(_D_Flow_Speed_Panning*node_28.r)*float2(1,1));
                float4 _node_8517_copy_var = tex2D(_node_8517_copy,TRANSFORM_TEX(node_6548, _node_8517_copy));
                float2 node_8275 = lerp((i.uv0*2.0),float2(_node_8517_copy_var.r,_node_8517_copy_var.r),_DistortionPanning);
                float4 _node_3415_copy_var = tex2D(_node_3415_copy,TRANSFORM_TEX(node_8275, _node_3415_copy));
                float3 emissive = (_node_6178_var.rgb+saturate((saturate((((((_node_3415_var.rgb+_node_3415_var.rgb)*_WaveBrightness)*_node_3415_copy_var.rgb)-_Treshold)*10.0))-0.5)));
                float3 finalColor = emissive;
                return fixed4(finalColor,_Transparency);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
