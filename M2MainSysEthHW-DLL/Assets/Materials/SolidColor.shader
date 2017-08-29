
Shader "Solid Color"
{
   	SubShader 
   	{
		Lighting Off
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