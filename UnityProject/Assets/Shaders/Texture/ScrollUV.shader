﻿Shader "Custom/ScrollUV"
{
    Properties
    {
	 _MainTint("Diffuse Tint", Color) = (1,1,1,1)
	 _MainTex("Base(RGB)", 2D) = "white"{}
	 _ScrollXSpeed ("X Scroll Speed", Range(0, 10)) = 2
	 _ScrollYSpeed ("Y Scroll Speed", Range(0, 10)) = 2


    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

		struct Input
        {
            float2 uv_MainTex;
        };

		fixed _MainTint;
		fixed _ScrollXSpeed;
		fixed _ScrollYSpeed;
		sampler2D _MainTex;


        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutputStandard o)
        {

		//Создаем отдельную переменную для хранения наших UV
		//Перед тем как передать их в Tex2d
		fixed2 scrolledUV = IN.uv_MainTex;

		//Добавляем переменный для хранения сдвига по x y
		fixed xScrollValue = _ScrollXSpeed * _Time.x;
		fixed yScrollValue = _ScrollYSpeed * _Time.x;

		//Применяем итоговый сдвиг uv
		scrolledUV += fixed2(xScrollValue,yScrollValue);

		//Применяем текстуру и цвет
		half4 c = tex2D(_MainTex, scrolledUV);
		o.Albedo = c.rgb ;
		o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
