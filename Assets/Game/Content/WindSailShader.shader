Shader "Custom/WindyFabricJitter"
{
    Properties
    {
        _MainTex ("Base Texture", 2D) = "white" {}
        _Color ("Color", Color) = (1,1,1,1)
        _WindSpeed ("Wind Speed", Range(0, 5)) = 1.0
        _WindStrength ("Wind Strength", Range(0, 0.5)) = 0.1
        _JitterFrequency ("Jitter Frequency", Range(0, 10)) = 3.0
        _JitterAmount ("Jitter Amount", Range(0, 0.3)) = 0.05
    }

    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        #pragma surface surf Standard vertex:vert addshadow
        #pragma target 3.0

        #include "UnityCG.cginc"
        #include "noiseSimplex.cginc"

        sampler2D _MainTex;
        fixed4 _Color;
        float _WindSpeed;
        float _WindStrength;
        float _JitterFrequency;
        float _JitterAmount;

        struct Input
        {
            float2 uv_MainTex;
        };

        // Функция шума для ветра
        float3 windNoise(float3 vertex)
        {
            float windTime = _Time.y * _WindSpeed;
            
            // Основной ветер (большие волны)
            float windWave = snoise(float3(vertex.x * 0.2, vertex.z * 0.2, windTime)) * _WindStrength;
            
            // Дёргающийся шум (малые частоты)
            float jitter = snoise(float3(vertex.x * _JitterFrequency, 
                                  vertex.z * _JitterFrequency, 
                                  windTime * 2.0)) * _JitterAmount;
            
            // Комбинируем эффекты
            return float3(
                jitter * 0.3, 
                windWave + jitter * 0.5, 
                jitter * 0.3
            );
        }

        void vert(inout appdata_full v, out Input o)
        {
            UNITY_INITIALIZE_OUTPUT(Input, o);
            
            // Смещаем только вершины выше центра (имитация ткани)
            float movementFactor = saturate(v.vertex.y * 2.0);
            
            // Применяем шум
            float3 windOffset = windNoise(v.vertex.xyz) * movementFactor;
            
            // Смещаем вершины
            v.vertex.xyz += windOffset;
            
            // Немного изменяем нормали для лучшего освещения
            v.normal = normalize(v.normal + windOffset * 0.3);
        }

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
            o.Albedo = c.rgb;
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}