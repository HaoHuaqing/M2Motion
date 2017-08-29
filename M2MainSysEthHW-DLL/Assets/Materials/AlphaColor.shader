
Shader "Alpha Color"
{
   	SubShader 
   	{
		Lighting Off
		ZWrite Off
		Alphatest Greater 0
		Blend SrcAlpha OneMinusSrcAlpha
		
		Pass 
		{
			BindChannels 
			{
				Bind "Color", color
				Bind "Vertex", vertex
			}
		}
   	}
} 