#region License
/* FNA - XNA4 Reimplementation for Desktop Platforms
 * Copyright 2009-2016 Ethan Lee and the MonoGame Team
 *
 * Released under the Microsoft Public License.
 * See LICENSE for details.
 */
#endregion

#region Using Statements
using System;
using System.IO;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
#endregion

namespace Microsoft.Xna.Framework
{
	internal static class FNAPlatform
	{
		#region Static Constructor

		static FNAPlatform()
		{
			/* I suspect you may have an urge to put an #if in here for new
			 * FNAPlatform implementations.
			 *
			 * DON'T.
			 *
			 * Determine this at runtime, or load dynamically.
			 * No amount of whining will get me to budge on this.
			 * -flibit
			 */

			// Environment.GetEnvironmentVariable("FNA_PLATFORM_BACKEND");

			Init =				SDL2_FNAPlatform.Init;
			Dispose =			SDL2_FNAPlatform.Dispose;
			BeforeInitialize =		SDL2_FNAPlatform.BeforeInitialize;
			RunLoop =			SDL2_FNAPlatform.RunLoop;
			SetPresentationInterval =	SDL2_FNAPlatform.SetPresentationInterval;
			GetGraphicsAdapters =		SDL2_FNAPlatform.GetGraphicsAdapters;
			GetKeyFromScancode =		SDL2_FNAPlatform.GetKeyFromScancode;
			GetMouseState =			SDL2_FNAPlatform.GetMouseState;
			SetMousePosition =		SDL2_FNAPlatform.SetMousePosition;
			OnIsMouseVisibleChanged =	SDL2_FNAPlatform.OnIsMouseVisibleChanged;
			GetStorageRoot =		SDL2_FNAPlatform.GetStorageRoot;
			IsStoragePathConnected =	SDL2_FNAPlatform.IsStoragePathConnected;
			Log =				SDL2_FNAPlatform.Log;
			ShowRuntimeError =		SDL2_FNAPlatform.ShowRuntimeError;
			TextureDataFromStream =		SDL2_FNAPlatform.TextureDataFromStream;
			SavePNG =			SDL2_FNAPlatform.SavePNG;
		}

		#endregion

		#region Public Static Methods

		public delegate void InitFunc(Game game);
		public static InitFunc Init;

		public delegate void DisposeFunc(Game game);
		public static DisposeFunc Dispose;

		public delegate void BeforeInitializeFunc();
		public static BeforeInitializeFunc BeforeInitialize;

		public delegate void RunLoopFunc(Game game);
		public static RunLoopFunc RunLoop;

		public delegate void SetPresentationIntervalFunc(PresentInterval interval);
		public static SetPresentationIntervalFunc SetPresentationInterval;

		public delegate GraphicsAdapter[] GetGraphicsAdaptersFunc();
		public static GetGraphicsAdaptersFunc GetGraphicsAdapters;

		public delegate Keys GetKeyFromScancodeFunc(Keys scancode);
		public static GetKeyFromScancodeFunc GetKeyFromScancode;

		public delegate void GetMouseStateFunc(
			out int x,
			out int y,
			out ButtonState left,
			out ButtonState middle,
			out ButtonState right,
			out ButtonState x1,
			out ButtonState x2
		);
		public static GetMouseStateFunc GetMouseState;

		public delegate void SetMousePositionFunc(
			IntPtr window,
			int x,
			int y
		);
		public static SetMousePositionFunc SetMousePosition;

		public delegate void OnIsMouseVisibleChangedFunc(bool visible);
		public static OnIsMouseVisibleChangedFunc OnIsMouseVisibleChanged;

		public delegate string GetStorageRootFunc();
		public static GetStorageRootFunc GetStorageRoot;

		public delegate bool IsStoragePathConnectedFunc(string path);
		public static IsStoragePathConnectedFunc IsStoragePathConnected;

		public delegate void LogFunc(string message);
		public static LogFunc Log;

		public delegate void ShowRuntimeErrorFunc(string title, string message);
		public static ShowRuntimeErrorFunc ShowRuntimeError;

		public delegate void TextureDataFromStreamFunc(
			Stream stream,
			out int width,
			out int height,
			out byte[] pixels,
			int reqWidth = -1,
			int reqHeight = -1,
			bool zoom = false
		);
		public static TextureDataFromStreamFunc TextureDataFromStream;

		public delegate void SavePNGFunc(
			Stream stream,
			int width,
			int height,
			int imgWidth,
			int imgHeight,
			byte[] data
		);
		public static SavePNGFunc SavePNG;

		#endregion
	}
}