using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyExtension
{
	public static class ColorExtensions
	{
		public static Color GetColorAlpha(this Color col, float alpha)
		{
			return new Color(col.r, col.g, col.b, alpha);
		}

		public static void SetColor(this SpriteRenderer spriteRen, Color color)
		{
			spriteRen.color = color;
		}

		public static void SetColorAlpha(this SpriteRenderer spriteRen, float alpha)
		{
			spriteRen.color =
				new Color(spriteRen.color.r, spriteRen.color.g, spriteRen.color.b, alpha);
		}

		public static Color SetColorAlpha(this Color color, float alpha)
		{
			return new Color(color.r, color.g, color.b, alpha);
		}

		public static void SetColorAlpha(this TextMesh txtMesh, float alpha)
		{
			Color col = txtMesh.color;
			txtMesh.color = new Color(col.r, col.g, col.b, alpha);
		}

		// https://en.wikipedia.org/wiki/Subtractive_color
		public static Color MixColorCMY(Color color1, Color color2)
		{
			return new Color((color1.r * color2.r), (color1.g * color2.g), (color1.b * color2.b));
		}

		// https://en.wikipedia.org/wiki/Additive_color
		public static Color MixColorRGB(Color color1, Color color2)
		{
			return new Color((color1.r + color2.r) / 2, (color1.g + color2.g) / 2, (color1.b + color2.b) / 2);
		}
	}
}