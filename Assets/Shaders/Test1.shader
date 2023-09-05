Shader "Unlit/Test1"
{
   Properties{}

	SubShader{

		Tags {
			"RenderType" = "Opaque"
		}

		Pass {
			ZWrite Off
		}
	}
}
