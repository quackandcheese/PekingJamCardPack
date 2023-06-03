Shader "Hidden/SFSoftShadows/FogLayer" {
	Properties {
		_FogColor ("Fog color and alpha.", Vector) = (1,1,1,0)
		_Scatter ("Light scattering color (RGB), Hard/soft mix (A)", Vector) = (1,1,1,0.15)
	}
	//DummyShaderTextExporter
	SubShader{
		Tags { "RenderType" = "Opaque" }
		LOD 200
		CGPROGRAM
#pragma surface surf Standard
#pragma target 3.0

		struct Input
		{
			float2 uv_MainTex;
		};

		void surf(Input IN, inout SurfaceOutputStandard o)
		{
			o.Albedo = 1;
		}
		ENDCG
	}
}