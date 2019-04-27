// Shader created with Shader Forge v1.38 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:34790,y:32311,varname:node_3138,prsc:2|emission-7476-OUT,custl-7728-OUT,alpha-1717-OUT;n:type:ShaderForge.SFN_TexCoord,id:3198,x:32652,y:32804,varname:node_3198,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_RemapRange,id:927,x:32883,y:32833,varname:node_927,prsc:2,frmn:0,frmx:1,tomn:-1,tomx:1|IN-3198-UVOUT;n:type:ShaderForge.SFN_Length,id:1138,x:33108,y:32766,varname:node_1138,prsc:2|IN-927-OUT;n:type:ShaderForge.SFN_ComponentMask,id:1151,x:33077,y:32932,varname:node_1151,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-927-OUT;n:type:ShaderForge.SFN_ArcTan2,id:3230,x:33305,y:32946,varname:node_3230,prsc:2,attp:2|A-1151-R,B-1151-G;n:type:ShaderForge.SFN_Append,id:5228,x:33545,y:32755,varname:node_5228,prsc:2|A-755-OUT,B-7763-OUT;n:type:ShaderForge.SFN_Time,id:7706,x:32664,y:32569,varname:node_7706,prsc:2;n:type:ShaderForge.SFN_Slider,id:3676,x:32518,y:32479,ptovrint:False,ptlb:speed,ptin:_speed,varname:node_3676,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.4786325,max:1;n:type:ShaderForge.SFN_Multiply,id:1225,x:32918,y:32556,varname:node_1225,prsc:2|A-3676-OUT,B-7706-T;n:type:ShaderForge.SFN_Add,id:755,x:33283,y:32618,varname:node_755,prsc:2|A-529-OUT,B-1138-OUT;n:type:ShaderForge.SFN_OneMinus,id:529,x:33116,y:32490,varname:node_529,prsc:2|IN-1225-OUT;n:type:ShaderForge.SFN_Lerp,id:7476,x:34444,y:32247,varname:node_7476,prsc:2|A-3711-RGB,B-9762-RGB,T-9701-OUT;n:type:ShaderForge.SFN_Tex2d,id:1571,x:34022,y:32753,ptovrint:False,ptlb:rainbow,ptin:_rainbow,varname:node_1571,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:4504f2f3a82099046b4e2421c486196c,ntxv:2,isnm:False|UVIN-5228-OUT;n:type:ShaderForge.SFN_Floor,id:7763,x:33490,y:32946,varname:node_7763,prsc:2|IN-3230-OUT;n:type:ShaderForge.SFN_Slider,id:1717,x:34229,y:32813,ptovrint:False,ptlb:alpha,ptin:_alpha,varname:node_1717,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.7969418,max:1;n:type:ShaderForge.SFN_Multiply,id:7728,x:34467,y:32628,varname:node_7728,prsc:2|A-1571-RGB,B-1717-OUT;n:type:ShaderForge.SFN_Slider,id:9701,x:33963,y:32352,ptovrint:False,ptlb:changecolor,ptin:_changecolor,varname:node_9701,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Color,id:3711,x:34204,y:31971,ptovrint:False,ptlb:color01,ptin:_color01,varname:node_3711,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:0,c3:0,c4:1;n:type:ShaderForge.SFN_Color,id:9762,x:34192,y:32139,ptovrint:False,ptlb:color02,ptin:_color02,varname:node_9762,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0,c2:0.07107735,c3:1,c4:1;proporder:3676-1717-9701-1571-3711-9762;pass:END;sub:END;*/

Shader "Shader Forge/crazy" {
    Properties {
        _speed ("speed", Range(0, 1)) = 0.4786325
        _alpha ("alpha", Range(0, 1)) = 0.7969418
        _changecolor ("changecolor", Range(0, 1)) = 0
        _rainbow ("rainbow", 2D) = "black" {}
        _color01 ("color01", Color) = (1,0,0,1)
        _color02 ("color02", Color) = (0,0.07107735,1,1)
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
            uniform sampler2D _rainbow; uniform float4 _rainbow_ST;
            uniform float _alpha;
            uniform float _changecolor;
            uniform float4 _color01;
            uniform float4 _color02;
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
                float3 emissive = lerp(_color01.rgb,_color02.rgb,_changecolor);
                float4 node_7706 = _Time;
                float2 node_927 = (i.uv0*2.0+-1.0);
                float2 node_1151 = node_927.rg;
                float2 node_5228 = float2(((1.0 - (_speed*node_7706.g))+length(node_927)),floor(((atan2(node_1151.r,node_1151.g)/6.28318530718)+0.5)));
                float4 _rainbow_var = tex2D(_rainbow,TRANSFORM_TEX(node_5228, _rainbow));
                float3 finalColor = emissive + (_rainbow_var.rgb*_alpha);
                return fixed4(finalColor,_alpha);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
