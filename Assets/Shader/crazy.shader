// Shader created with Shader Forge v1.38 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:34159,y:32686,varname:node_3138,prsc:2|emission-7476-OUT,custl-7728-OUT,alpha-1717-OUT;n:type:ShaderForge.SFN_TexCoord,id:3198,x:32102,y:32988,varname:node_3198,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_RemapRange,id:927,x:32345,y:33045,varname:node_927,prsc:2,frmn:0,frmx:1,tomn:-1,tomx:1|IN-3198-UVOUT;n:type:ShaderForge.SFN_Length,id:1138,x:32635,y:32989,varname:node_1138,prsc:2|IN-927-OUT;n:type:ShaderForge.SFN_ComponentMask,id:1151,x:32604,y:33155,varname:node_1151,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-927-OUT;n:type:ShaderForge.SFN_ArcTan2,id:3230,x:32832,y:33169,varname:node_3230,prsc:2,attp:2|A-1151-R,B-1151-G;n:type:ShaderForge.SFN_Append,id:5228,x:33038,y:32874,varname:node_5228,prsc:2|A-755-OUT,B-7763-OUT;n:type:ShaderForge.SFN_Time,id:7706,x:32191,y:32792,varname:node_7706,prsc:2;n:type:ShaderForge.SFN_Slider,id:3676,x:32045,y:32702,ptovrint:False,ptlb:speed,ptin:_speed,varname:node_3676,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.4786325,max:1;n:type:ShaderForge.SFN_Multiply,id:1225,x:32445,y:32779,varname:node_1225,prsc:2|A-3676-OUT,B-7706-T;n:type:ShaderForge.SFN_Add,id:755,x:32810,y:32841,varname:node_755,prsc:2|A-529-OUT,B-1138-OUT;n:type:ShaderForge.SFN_OneMinus,id:529,x:32622,y:32779,varname:node_529,prsc:2|IN-1225-OUT;n:type:ShaderForge.SFN_Color,id:901,x:33575,y:32282,ptovrint:False,ptlb:color1,ptin:_color1,varname:node_901,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Color,id:1645,x:33343,y:32359,ptovrint:False,ptlb:color2,ptin:_color2,varname:node_1645,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Lerp,id:7476,x:33751,y:32575,varname:node_7476,prsc:2|A-901-RGB,B-1645-RGB,T-9701-OUT;n:type:ShaderForge.SFN_Tex2d,id:1571,x:33236,y:32715,ptovrint:False,ptlb:rainbow,ptin:_rainbow,varname:node_1571,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:4504f2f3a82099046b4e2421c486196c,ntxv:2,isnm:False|UVIN-5228-OUT;n:type:ShaderForge.SFN_Color,id:9445,x:33353,y:32928,ptovrint:False,ptlb:hue,ptin:_hue,varname:node_9445,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0,c2:1,c3:0.1673267,c4:1;n:type:ShaderForge.SFN_Add,id:6141,x:33694,y:32757,varname:node_6141,prsc:2|A-1571-RGB,B-9445-RGB;n:type:ShaderForge.SFN_Floor,id:7763,x:33006,y:33155,varname:node_7763,prsc:2|IN-3230-OUT;n:type:ShaderForge.SFN_ProjectionParameters,id:3694,x:33533,y:33248,varname:node_3694,prsc:2;n:type:ShaderForge.SFN_Append,id:5028,x:33753,y:33218,varname:node_5028,prsc:2|A-2862-OUT,B-3694-SGN;n:type:ShaderForge.SFN_Vector1,id:2862,x:33516,y:33180,varname:node_2862,prsc:2,v1:1;n:type:ShaderForge.SFN_TexCoord,id:2770,x:33516,y:33020,varname:node_2770,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_RemapRange,id:3252,x:33733,y:33042,varname:node_3252,prsc:2,frmn:0,frmx:1,tomn:-1,tomx:1|IN-2770-UVOUT;n:type:ShaderForge.SFN_Multiply,id:1322,x:33956,y:33149,varname:node_1322,prsc:2|A-3252-OUT,B-5028-OUT;n:type:ShaderForge.SFN_Slider,id:1717,x:33560,y:32937,ptovrint:False,ptlb:node_1717,ptin:_node_1717,varname:node_1717,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Multiply,id:7728,x:33908,y:32835,varname:node_7728,prsc:2|A-6141-OUT,B-1717-OUT;n:type:ShaderForge.SFN_Slider,id:9701,x:32933,y:32618,ptovrint:False,ptlb:node_9701,ptin:_node_9701,varname:node_9701,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;proporder:3676-901-1645-1571-9445-1717-9701;pass:END;sub:END;*/

Shader "Shader Forge/crazy" {
    Properties {
        _speed ("speed", Range(0, 1)) = 0.4786325
        _color1 ("color1", Color) = (0.5,0.5,0.5,1)
        _color2 ("color2", Color) = (0.5,0.5,0.5,1)
        _rainbow ("rainbow", 2D) = "black" {}
        _hue ("hue", Color) = (0,1,0.1673267,1)
        _node_1717 ("node_1717", Range(0, 1)) = 1
        _node_9701 ("node_9701", Range(0, 1)) = 0
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
            uniform float _speed;
            uniform float4 _color1;
            uniform float4 _color2;
            uniform sampler2D _rainbow; uniform float4 _rainbow_ST;
            uniform float4 _hue;
            uniform float _node_1717;
            uniform float _node_9701;
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
                float3 emissive = lerp(_color1.rgb,_color2.rgb,_node_9701);
                float4 node_7706 = _Time;
                float2 node_927 = (i.uv0*2.0+-1.0);
                float2 node_1151 = node_927.rg;
                float2 node_5228 = float2(((1.0 - (_speed*node_7706.g))+length(node_927)),floor(((atan2(node_1151.r,node_1151.g)/6.28318530718)+0.5)));
                float4 _rainbow_var = tex2D(_rainbow,TRANSFORM_TEX(node_5228, _rainbow));
                float3 finalColor = emissive + ((_rainbow_var.rgb+_hue.rgb)*_node_1717);
                return fixed4(finalColor,_node_1717);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
