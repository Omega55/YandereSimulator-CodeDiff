using System;
using UnityEngine;

public class CameraFilterScript : MonoBehaviour
{
	private CameraFilterPack_3D_Anomaly Anomaly;

	private CameraFilterPack_3D_Binary Binary;

	private CameraFilterPack_3D_BlackHole BlackHole3D;

	private CameraFilterPack_3D_Computer Computer;

	private CameraFilterPack_3D_Distortion Distortion;

	private CameraFilterPack_3D_Fog_Smoke FogSmoke;

	private CameraFilterPack_3D_Ghost Ghost;

	private CameraFilterPack_3D_Inverse Inverse;

	private CameraFilterPack_3D_Matrix Matrix;

	private CameraFilterPack_3D_Mirror Mirror3D;

	private CameraFilterPack_3D_Myst Myst;

	private CameraFilterPack_3D_Scan_Scene ScanScene;

	private CameraFilterPack_3D_Shield Shield;

	private CameraFilterPack_3D_Snow Snow;

	private CameraFilterPack_AAA_Blood AAABlood;

	private CameraFilterPack_AAA_BloodOnScreen AAABloodOnScreen;

	private CameraFilterPack_AAA_Blood_Hit AAABloodHit;

	private CameraFilterPack_AAA_Blood_Plus AAABloodPlus;

	private CameraFilterPack_AAA_SuperComputer SuperComputer;

	private CameraFilterPack_AAA_SuperHexagon SuperHexagon;

	private CameraFilterPack_AAA_WaterDrop WaterDrop;

	private CameraFilterPack_AAA_WaterDropPro WaterDropPro;

	private CameraFilterPack_Alien_Vision AlienVision;

	private CameraFilterPack_Antialiasing_FXAA FXAA;

	private CameraFilterPack_Atmosphere_Fog Fog;

	private CameraFilterPack_Atmosphere_Rain Rain;

	private CameraFilterPack_Atmosphere_Rain_Pro RainPro;

	private CameraFilterPack_Atmosphere_Rain_Pro_3D RainPro3D;

	private CameraFilterPack_Atmosphere_Snow_8bits Snow8bits;

	private CameraFilterPack_Blend2Camera_Blend Blend;

	private CameraFilterPack_Blend2Camera_BlueScreen BlueScreen;

	private CameraFilterPack_Blend2Camera_Color Color;

	private CameraFilterPack_Blend2Camera_ColorBurn ColorBurn;

	private CameraFilterPack_Blend2Camera_ColorDodge ColorDodge;

	private CameraFilterPack_Blend2Camera_ColorKey ColorKey;

	private CameraFilterPack_Blend2Camera_Darken Darken;

	private CameraFilterPack_Blend2Camera_DarkerColor DarkerColor;

	private CameraFilterPack_Blend2Camera_Difference Difference;

	private CameraFilterPack_Blend2Camera_Divide Divide;

	private CameraFilterPack_Blend2Camera_Exclusion Exclusion;

	private CameraFilterPack_Blend2Camera_GreenScreen GreenScreen;

	private CameraFilterPack_Blend2Camera_HardLight HardLight;

	private CameraFilterPack_Blend2Camera_HardMix HardMix;

	private CameraFilterPack_Blend2Camera_Hue Blend2CameraHue;

	private CameraFilterPack_Blend2Camera_Lighten Lighten;

	private CameraFilterPack_Blend2Camera_LighterColor LighterColor;

	private CameraFilterPack_Blend2Camera_LinearBurn LinearBurn;

	private CameraFilterPack_Blend2Camera_LinearDodge LinearDodge;

	private CameraFilterPack_Blend2Camera_LinearLight LinearLight;

	private CameraFilterPack_Blend2Camera_Luminosity Luminosity;

	private CameraFilterPack_Blend2Camera_Multiply Multiply;

	private CameraFilterPack_Blend2Camera_Overlay Overlay;

	private CameraFilterPack_Blend2Camera_PhotoshopFilters PhotoshopFilters;

	private CameraFilterPack_Blend2Camera_PinLight PinLight;

	private CameraFilterPack_Blend2Camera_Saturation Saturation;

	private CameraFilterPack_Blend2Camera_Screen Screen;

	private CameraFilterPack_Blend2Camera_SoftLight SoftLight;

	private CameraFilterPack_Blend2Camera_SplitScreen SplitScreen;

	private CameraFilterPack_Blend2Camera_SplitScreen3D SplitScreen3D;

	private CameraFilterPack_Blend2Camera_Subtract Subtract;

	private CameraFilterPack_Blend2Camera_VividLight VividLight;

	private CameraFilterPack_Blizzard Blizzard;

	private CameraFilterPack_Blur_Bloom Bloom;

	private CameraFilterPack_Blur_BlurHole BlurHole;

	private CameraFilterPack_Blur_Blurry Blurry;

	private CameraFilterPack_Blur_Dithering2x2 Dithering2x2;

	private CameraFilterPack_Blur_DitherOffset DitherOffset;

	private CameraFilterPack_Blur_Focus Focus;

	private CameraFilterPack_Blur_GaussianBlur GaussianBlur;

	private CameraFilterPack_Blur_Movie Movie;

	private CameraFilterPack_Blur_Noise BlurNoise;

	private CameraFilterPack_Blur_Radial Radial;

	private CameraFilterPack_Blur_Radial_Fast RadialFast;

	private CameraFilterPack_Blur_Regular Regular;

	private CameraFilterPack_Blur_Steam Steam;

	private CameraFilterPack_Blur_Tilt_Shift TiltShift;

	private CameraFilterPack_Blur_Tilt_Shift_Hole TiltShiftHole;

	private CameraFilterPack_Blur_Tilt_Shift_V TiltShiftV;

	private CameraFilterPack_Broken_Screen BrokenScreen;

	private CameraFilterPack_Broken_Simple BrokenSimple;

	private CameraFilterPack_Broken_Spliter Spliter;

	private CameraFilterPack_Classic_ThermalVision ThermalVision;

	private CameraFilterPack_Colors_Adjust_ColorRGB AdjustColorRGB;

	private CameraFilterPack_Colors_Adjust_FullColors AdjustFullColors;

	private CameraFilterPack_Colors_Adjust_PreFilters AdjustPreFilters;

	private CameraFilterPack_Colors_BleachBypass BleachBypass;

	private CameraFilterPack_Colors_Brightness Brightness;

	private CameraFilterPack_Colors_DarkColor DarkColor;

	private CameraFilterPack_Colors_HSV HSV;

	private CameraFilterPack_Colors_HUE_Rotate HUERotate;

	private CameraFilterPack_Colors_NewPosterize NewPosterize;

	private CameraFilterPack_Colors_RgbClamp RgbClamp;

	private CameraFilterPack_Colors_Threshold Threshold;

	private CameraFilterPack_Color_Adjust_Levels AdjustLevels;

	private CameraFilterPack_Color_BrightContrastSaturation BrightContrastSaturation;

	private CameraFilterPack_Color_Chromatic_Aberration ChromaticAberration;

	private CameraFilterPack_Color_Chromatic_Plus ChromaticPlus;

	private CameraFilterPack_Color_Contrast Contrast;

	private CameraFilterPack_Color_GrayScale GrayScale;

	private CameraFilterPack_Color_Invert Invert;

	private CameraFilterPack_Color_Noise ColorNoise;

	private CameraFilterPack_Color_RGB ColorRGB;

	private CameraFilterPack_Color_Sepia Sepia;

	private CameraFilterPack_Color_Switching Switching;

	private CameraFilterPack_Color_YUV YUV;

	private CameraFilterPack_Convert_Normal Normal;

	private CameraFilterPack_Distortion_Aspiration Aspiration;

	private CameraFilterPack_Distortion_BigFace BigFace;

	private CameraFilterPack_Distortion_BlackHole BlackHole;

	private CameraFilterPack_Distortion_Dissipation Dissipation;

	private CameraFilterPack_Distortion_Dream Dream;

	private CameraFilterPack_Distortion_Dream2 Dream2;

	private CameraFilterPack_Distortion_FishEye FishEye;

	private CameraFilterPack_Distortion_Flag Flag;

	private CameraFilterPack_Distortion_Flush Flush;

	private CameraFilterPack_Distortion_Half_Sphere HalfSphere;

	private CameraFilterPack_Distortion_Heat Heat;

	private CameraFilterPack_Distortion_Lens Lens;

	private CameraFilterPack_Distortion_Noise DistortionNoise;

	private CameraFilterPack_Distortion_ShockWave ShockWave;

	private CameraFilterPack_Distortion_ShockWaveManual ShockWaveManual;

	private CameraFilterPack_Distortion_Twist Twist;

	private CameraFilterPack_Distortion_Twist_Square TwistSquare;

	private CameraFilterPack_Distortion_Water_Drop DistortionWaterDrop;

	private CameraFilterPack_Distortion_Wave_Horizontal WaveHorizontal;

	private CameraFilterPack_Drawing_BluePrint BluePrint;

	private CameraFilterPack_Drawing_CellShading CellShading;

	private CameraFilterPack_Drawing_CellShading2 CellShading2;

	private CameraFilterPack_Drawing_Comics Comics;

	private CameraFilterPack_Drawing_Crosshatch Crosshatch;

	private CameraFilterPack_Drawing_Curve Curve;

	private CameraFilterPack_Drawing_EnhancedComics EnhancedComics;

	private CameraFilterPack_Drawing_Halftone Halftone;

	private CameraFilterPack_Drawing_Laplacian Laplacian;

	private CameraFilterPack_Drawing_Lines Lines;

	private CameraFilterPack_Drawing_Manga Manga;

	private CameraFilterPack_Drawing_Manga2 Manga2;

	private CameraFilterPack_Drawing_Manga3 Manga3;

	private CameraFilterPack_Drawing_Manga4 Manga4;

	private CameraFilterPack_Drawing_Manga5 Manga5;

	private CameraFilterPack_Drawing_Manga_Color MangaColor;

	private CameraFilterPack_Drawing_Manga_Flash MangaFlash;

	private CameraFilterPack_Drawing_Manga_FlashWhite MangaFlashWhite;

	private CameraFilterPack_Drawing_Manga_Flash_Color MangaFlashColor;

	private CameraFilterPack_Drawing_NewCellShading NewCellShading;

	private CameraFilterPack_Drawing_Paper Paper;

	private CameraFilterPack_Drawing_Paper2 Paper2;

	private CameraFilterPack_Drawing_Paper3 Paper3;

	private CameraFilterPack_Drawing_Toon Toon;

	private CameraFilterPack_Edge_BlackLine BlackLine;

	private CameraFilterPack_Edge_Edge_filter Edgefilter;

	private CameraFilterPack_Edge_Golden Golden;

	private CameraFilterPack_Edge_Neon Neon;

	private CameraFilterPack_Edge_Sigmoid Sigmoid;

	private CameraFilterPack_Edge_Sobel Sobel;

	private CameraFilterPack_EXTRA_Rotation Rotation;

	private CameraFilterPack_EXTRA_SHOWFPS SHOWFPS;

	private CameraFilterPack_EyesVision_1 EyesVision1;

	private CameraFilterPack_EyesVision_2 EyesVision2;

	private CameraFilterPack_Film_ColorPerfection ColorPerfection;

	private CameraFilterPack_Film_Grain Grain;

	private CameraFilterPack_Fly_Vision FlyVision;

	private CameraFilterPack_FX_8bits FX8bits;

	private CameraFilterPack_FX_8bits_gb FX8bitsgb;

	private CameraFilterPack_FX_Ascii Ascii;

	private CameraFilterPack_FX_DarkMatter DarkMatter;

	private CameraFilterPack_FX_DigitalMatrix DigitalMatrix;

	private CameraFilterPack_FX_DigitalMatrixDistortion DigitalMatrixDistortion;

	private CameraFilterPack_FX_Dot_Circle DotCircle;

	private CameraFilterPack_FX_Drunk Drunk;

	private CameraFilterPack_FX_Drunk2 Drunk2;

	private CameraFilterPack_FX_EarthQuake EarthQuake;

	private CameraFilterPack_FX_Funk Funk;

	private CameraFilterPack_FX_Glitch1 Glitch1;

	private CameraFilterPack_FX_Glitch2 Glitch2;

	private CameraFilterPack_FX_Glitch3 Glitch3;

	private CameraFilterPack_FX_Grid Grid;

	private CameraFilterPack_FX_Hexagon Hexagon;

	private CameraFilterPack_FX_Hexagon_Black HexagonBlack;

	private CameraFilterPack_FX_Hypno Hypno;

	private CameraFilterPack_FX_InverChromiLum InverChromiLum;

	private CameraFilterPack_FX_Mirror FXMirror;

	private CameraFilterPack_FX_Plasma FXPlasma;

	private CameraFilterPack_FX_Psycho FXPsycho;

	private CameraFilterPack_FX_Scan Scan;

	private CameraFilterPack_FX_Screens Screens;

	private CameraFilterPack_FX_Spot Spot;

	private CameraFilterPack_FX_superDot superDot;

	private CameraFilterPack_FX_ZebraColor ZebraColor;

	private CameraFilterPack_Glasses_On GlassesOn;

	private CameraFilterPack_Glasses_On_2 GlassesOn2;

	private CameraFilterPack_Glasses_On_3 GlassesOn3;

	private CameraFilterPack_Glasses_On_4 GlassesOn4;

	private CameraFilterPack_Glasses_On_5 GlassesOn5;

	private CameraFilterPack_Glasses_On_6 GlassesOn6;

	private CameraFilterPack_Glitch_Mozaic Mozaic;

	private CameraFilterPack_Glow_Glow Glow;

	private CameraFilterPack_Glow_Glow_Color GlowColor;

	private CameraFilterPack_Gradients_Ansi Ansi;

	private CameraFilterPack_Gradients_Desert Desert;

	private CameraFilterPack_Gradients_ElectricGradient ElectricGradient;

	private CameraFilterPack_Gradients_FireGradient FireGradient;

	private CameraFilterPack_Gradients_Hue GradientsHue;

	private CameraFilterPack_Gradients_NeonGradient NeonGradient;

	private CameraFilterPack_Gradients_Rainbow GradientsRainbow;

	private CameraFilterPack_Gradients_Stripe Stripe;

	private CameraFilterPack_Gradients_Tech Tech;

	private CameraFilterPack_Gradients_Therma Therma;

	private CameraFilterPack_Light_Rainbow LightRainbow;

	private CameraFilterPack_Light_Rainbow2 LightRainbow2;

	private CameraFilterPack_Light_Water Water;

	private CameraFilterPack_Light_Water2 Water2;

	private CameraFilterPack_Lut_2_Lut Lut;

	private CameraFilterPack_Lut_2_Lut_Extra LutExtra;

	private CameraFilterPack_Lut_Mask Mask;

	private CameraFilterPack_Lut_PlayWith PlayWith;

	private CameraFilterPack_Lut_Plus Plus;

	private CameraFilterPack_Lut_Simple LutSimple;

	private CameraFilterPack_Lut_TestMode TestMode;

	private CameraFilterPack_NewGlitch1 NewGlitch1;

	private CameraFilterPack_NewGlitch2 NewGlitch2;

	private CameraFilterPack_NewGlitch3 NewGlitch3;

	private CameraFilterPack_NewGlitch4 NewGlitch4;

	private CameraFilterPack_NewGlitch5 NewGlitch5;

	private CameraFilterPack_NewGlitch6 NewGlitch6;

	private CameraFilterPack_NewGlitch7 NewGlitch7;

	private CameraFilterPack_NightVisionFX NightVisionFX;

	private CameraFilterPack_NightVision_4 NightVision4;

	private CameraFilterPack_Noise_TV TV;

	private CameraFilterPack_Noise_TV_2 TV2;

	private CameraFilterPack_Noise_TV_3 TV3;

	private CameraFilterPack_Oculus_NightVision1 NightVision1;

	private CameraFilterPack_Oculus_NightVision2 NightVision2;

	private CameraFilterPack_Oculus_NightVision3 NightVision3;

	private CameraFilterPack_Oculus_NightVision5 NightVision5;

	private CameraFilterPack_Oculus_ThermaVision ThermaVision;

	private CameraFilterPack_OldFilm_Cutting1 Cutting1;

	private CameraFilterPack_OldFilm_Cutting2 Cutting2;

	private CameraFilterPack_Pixelisation_DeepOilPaintHQ DeepOilPaintHQ;

	private CameraFilterPack_Pixelisation_Dot Dot;

	private CameraFilterPack_Pixelisation_OilPaint OilPaint;

	private CameraFilterPack_Pixelisation_OilPaintHQ OilPaintHQ;

	private CameraFilterPack_Pixelisation_Sweater Sweater;

	private CameraFilterPack_Pixel_Pixelisation Pixelisation;

	private CameraFilterPack_Rain_RainFX RainFX;

	private CameraFilterPack_Real_VHS RealVHS;

	private CameraFilterPack_Retro_Loading Loading;

	private CameraFilterPack_Sharpen_Sharpen Sharpen;

	private CameraFilterPack_Special_Bubble Bubble;

	private CameraFilterPack_TV_50 TV50;

	private CameraFilterPack_TV_80 TV80;

	private CameraFilterPack_TV_ARCADE ARCADE;

	private CameraFilterPack_TV_ARCADE_2 ARCADE2;

	private CameraFilterPack_TV_ARCADE_Fast ARCADEFast;

	private CameraFilterPack_TV_Artefact Artefact;

	private CameraFilterPack_TV_BrokenGlass BrokenGlass;

	private CameraFilterPack_TV_BrokenGlass2 BrokenGlass2;

	private CameraFilterPack_TV_Chromatical Chromatical;

	private CameraFilterPack_TV_Chromatical2 Chromatical2;

	private CameraFilterPack_TV_CompressionFX CompressionFX;

	private CameraFilterPack_TV_Distorted Distorted;

	private CameraFilterPack_TV_Horror Horror;

	private CameraFilterPack_TV_LED LED;

	private CameraFilterPack_TV_MovieNoise MovieNoise;

	private CameraFilterPack_TV_Noise TVNoise;

	private CameraFilterPack_TV_Old Old;

	private CameraFilterPack_TV_Old_Movie OldMovie;

	private CameraFilterPack_TV_Old_Movie_2 OldMovie2;

	private CameraFilterPack_TV_PlanetMars PlanetMars;

	private CameraFilterPack_TV_Posterize Posterize;

	private CameraFilterPack_TV_Rgb TVRgb;

	private CameraFilterPack_TV_Tiles Tiles;

	private CameraFilterPack_TV_Vcr Vcr;

	private CameraFilterPack_TV_VHS TVVHS;

	private CameraFilterPack_TV_VHS_Rewind VHSRewind;

	private CameraFilterPack_TV_Video3D Video3D;

	private CameraFilterPack_TV_Videoflip Videoflip;

	private CameraFilterPack_TV_Vignetting Vignetting;

	private CameraFilterPack_TV_Vintage Vintage;

	private CameraFilterPack_TV_WideScreenCircle WideScreenCircle;

	private CameraFilterPack_TV_WideScreenHorizontal WideScreenHorizontal;

	private CameraFilterPack_TV_WideScreenHV WideScreenHV;

	private CameraFilterPack_TV_WideScreenVertical WideScreenVertical;

	private CameraFilterPack_VHS_Tracking Tracking;

	private CameraFilterPack_Vision_Aura Aura;

	private CameraFilterPack_Vision_AuraDistortion AuraDistortion;

	private CameraFilterPack_Vision_Blood VisionBlood;

	private CameraFilterPack_Vision_Blood_Fast VisionBloodFast;

	private CameraFilterPack_Vision_Crystal Crystal;

	private CameraFilterPack_Vision_Drost Drost;

	private CameraFilterPack_Vision_Hell_Blood VisionHellBlood;

	private CameraFilterPack_Vision_Plasma VisionPlasma;

	private CameraFilterPack_Vision_Psycho VisionPsycho;

	private CameraFilterPack_Vision_Rainbow VisionRainbow;

	private CameraFilterPack_Vision_SniperScore SniperScore;

	private CameraFilterPack_Vision_Tunnel Tunnel;

	private CameraFilterPack_Vision_Warp Warp;

	private CameraFilterPack_Vision_Warp2 Warp2;

	public UILabel NameLabel;

	public float DisplayTimer;

	public float Speed;

	public int FilterMax;

	private int FilterID;

	public string[] FilterNames;

	public bool[] FilterSkips;

	private void Start()
	{
		this.Anomaly = base.gameObject.AddComponent<CameraFilterPack_3D_Anomaly>();
		this.Anomaly.enabled = false;
		this.Binary = base.gameObject.AddComponent<CameraFilterPack_3D_Binary>();
		this.Binary.enabled = false;
		this.BlackHole3D = base.gameObject.AddComponent<CameraFilterPack_3D_BlackHole>();
		this.BlackHole3D.enabled = false;
		this.Computer = base.gameObject.AddComponent<CameraFilterPack_3D_Computer>();
		this.Computer.enabled = false;
		this.Distortion = base.gameObject.AddComponent<CameraFilterPack_3D_Distortion>();
		this.Distortion.enabled = false;
		this.FogSmoke = base.gameObject.AddComponent<CameraFilterPack_3D_Fog_Smoke>();
		this.FogSmoke.enabled = false;
		this.Ghost = base.gameObject.AddComponent<CameraFilterPack_3D_Ghost>();
		this.Ghost.enabled = false;
		this.Inverse = base.gameObject.AddComponent<CameraFilterPack_3D_Inverse>();
		this.Inverse.enabled = false;
		this.Matrix = base.gameObject.AddComponent<CameraFilterPack_3D_Matrix>();
		this.Matrix.enabled = false;
		this.Mirror3D = base.gameObject.AddComponent<CameraFilterPack_3D_Mirror>();
		this.Mirror3D.enabled = false;
		this.Myst = base.gameObject.AddComponent<CameraFilterPack_3D_Myst>();
		this.Myst.enabled = false;
		this.ScanScene = base.gameObject.AddComponent<CameraFilterPack_3D_Scan_Scene>();
		this.ScanScene.enabled = false;
		this.Shield = base.gameObject.AddComponent<CameraFilterPack_3D_Shield>();
		this.Shield.enabled = false;
		this.Snow = base.gameObject.AddComponent<CameraFilterPack_3D_Snow>();
		this.Snow.enabled = false;
		this.AAABlood = base.gameObject.AddComponent<CameraFilterPack_AAA_Blood>();
		this.AAABlood.enabled = false;
		this.AAABloodOnScreen = base.gameObject.AddComponent<CameraFilterPack_AAA_BloodOnScreen>();
		this.AAABloodOnScreen.enabled = false;
		this.AAABloodHit = base.gameObject.AddComponent<CameraFilterPack_AAA_Blood_Hit>();
		this.AAABloodHit.enabled = false;
		this.AAABloodPlus = base.gameObject.AddComponent<CameraFilterPack_AAA_Blood_Plus>();
		this.AAABloodPlus.enabled = false;
		this.SuperComputer = base.gameObject.AddComponent<CameraFilterPack_AAA_SuperComputer>();
		this.SuperComputer.enabled = false;
		this.SuperHexagon = base.gameObject.AddComponent<CameraFilterPack_AAA_SuperHexagon>();
		this.SuperHexagon.enabled = false;
		this.WaterDrop = base.gameObject.AddComponent<CameraFilterPack_AAA_WaterDrop>();
		this.WaterDrop.enabled = false;
		this.WaterDropPro = base.gameObject.AddComponent<CameraFilterPack_AAA_WaterDropPro>();
		this.WaterDropPro.enabled = false;
		this.AlienVision = base.gameObject.AddComponent<CameraFilterPack_Alien_Vision>();
		this.AlienVision.enabled = false;
		this.FXAA = base.gameObject.AddComponent<CameraFilterPack_Antialiasing_FXAA>();
		this.FXAA.enabled = false;
		this.Fog = base.gameObject.AddComponent<CameraFilterPack_Atmosphere_Fog>();
		this.Fog.enabled = false;
		this.Rain = base.gameObject.AddComponent<CameraFilterPack_Atmosphere_Rain>();
		this.Rain.enabled = false;
		this.RainPro = base.gameObject.AddComponent<CameraFilterPack_Atmosphere_Rain_Pro>();
		this.RainPro.enabled = false;
		this.RainPro3D = base.gameObject.AddComponent<CameraFilterPack_Atmosphere_Rain_Pro_3D>();
		this.RainPro3D.enabled = false;
		this.Snow8bits = base.gameObject.AddComponent<CameraFilterPack_Atmosphere_Snow_8bits>();
		this.Snow8bits.enabled = false;
		this.Blend = base.gameObject.AddComponent<CameraFilterPack_Blend2Camera_Blend>();
		this.Blend.enabled = false;
		this.BlueScreen = base.gameObject.AddComponent<CameraFilterPack_Blend2Camera_BlueScreen>();
		this.BlueScreen.enabled = false;
		this.Color = base.gameObject.AddComponent<CameraFilterPack_Blend2Camera_Color>();
		this.Color.enabled = false;
		this.ColorBurn = base.gameObject.AddComponent<CameraFilterPack_Blend2Camera_ColorBurn>();
		this.ColorBurn.enabled = false;
		this.ColorDodge = base.gameObject.AddComponent<CameraFilterPack_Blend2Camera_ColorDodge>();
		this.ColorDodge.enabled = false;
		this.ColorKey = base.gameObject.AddComponent<CameraFilterPack_Blend2Camera_ColorKey>();
		this.ColorKey.enabled = false;
		this.Darken = base.gameObject.AddComponent<CameraFilterPack_Blend2Camera_Darken>();
		this.Darken.enabled = false;
		this.DarkerColor = base.gameObject.AddComponent<CameraFilterPack_Blend2Camera_DarkerColor>();
		this.DarkerColor.enabled = false;
		this.Difference = base.gameObject.AddComponent<CameraFilterPack_Blend2Camera_Difference>();
		this.Difference.enabled = false;
		this.Divide = base.gameObject.AddComponent<CameraFilterPack_Blend2Camera_Divide>();
		this.Divide.enabled = false;
		this.Exclusion = base.gameObject.AddComponent<CameraFilterPack_Blend2Camera_Exclusion>();
		this.Exclusion.enabled = false;
		this.GreenScreen = base.gameObject.AddComponent<CameraFilterPack_Blend2Camera_GreenScreen>();
		this.GreenScreen.enabled = false;
		this.HardLight = base.gameObject.AddComponent<CameraFilterPack_Blend2Camera_HardLight>();
		this.HardLight.enabled = false;
		this.HardMix = base.gameObject.AddComponent<CameraFilterPack_Blend2Camera_HardMix>();
		this.HardMix.enabled = false;
		this.Blend2CameraHue = base.gameObject.AddComponent<CameraFilterPack_Blend2Camera_Hue>();
		this.Blend2CameraHue.enabled = false;
		this.Lighten = base.gameObject.AddComponent<CameraFilterPack_Blend2Camera_Lighten>();
		this.Lighten.enabled = false;
		this.LighterColor = base.gameObject.AddComponent<CameraFilterPack_Blend2Camera_LighterColor>();
		this.LighterColor.enabled = false;
		this.LinearBurn = base.gameObject.AddComponent<CameraFilterPack_Blend2Camera_LinearBurn>();
		this.LinearBurn.enabled = false;
		this.LinearDodge = base.gameObject.AddComponent<CameraFilterPack_Blend2Camera_LinearDodge>();
		this.LinearDodge.enabled = false;
		this.LinearLight = base.gameObject.AddComponent<CameraFilterPack_Blend2Camera_LinearLight>();
		this.LinearLight.enabled = false;
		this.Luminosity = base.gameObject.AddComponent<CameraFilterPack_Blend2Camera_Luminosity>();
		this.Luminosity.enabled = false;
		this.Multiply = base.gameObject.AddComponent<CameraFilterPack_Blend2Camera_Multiply>();
		this.Multiply.enabled = false;
		this.Overlay = base.gameObject.AddComponent<CameraFilterPack_Blend2Camera_Overlay>();
		this.Overlay.enabled = false;
		this.PhotoshopFilters = base.gameObject.AddComponent<CameraFilterPack_Blend2Camera_PhotoshopFilters>();
		this.PhotoshopFilters.enabled = false;
		this.PinLight = base.gameObject.AddComponent<CameraFilterPack_Blend2Camera_PinLight>();
		this.PinLight.enabled = false;
		this.Saturation = base.gameObject.AddComponent<CameraFilterPack_Blend2Camera_Saturation>();
		this.Saturation.enabled = false;
		this.Screen = base.gameObject.AddComponent<CameraFilterPack_Blend2Camera_Screen>();
		this.Screen.enabled = false;
		this.SoftLight = base.gameObject.AddComponent<CameraFilterPack_Blend2Camera_SoftLight>();
		this.SoftLight.enabled = false;
		this.SplitScreen = base.gameObject.AddComponent<CameraFilterPack_Blend2Camera_SplitScreen>();
		this.SplitScreen.enabled = false;
		this.SplitScreen3D = base.gameObject.AddComponent<CameraFilterPack_Blend2Camera_SplitScreen3D>();
		this.SplitScreen3D.enabled = false;
		this.Subtract = base.gameObject.AddComponent<CameraFilterPack_Blend2Camera_Subtract>();
		this.Subtract.enabled = false;
		this.VividLight = base.gameObject.AddComponent<CameraFilterPack_Blend2Camera_VividLight>();
		this.VividLight.enabled = false;
		this.Blizzard = base.gameObject.AddComponent<CameraFilterPack_Blizzard>();
		this.Blizzard.enabled = false;
		this.Bloom = base.gameObject.AddComponent<CameraFilterPack_Blur_Bloom>();
		this.Bloom.enabled = false;
		this.BlurHole = base.gameObject.AddComponent<CameraFilterPack_Blur_BlurHole>();
		this.BlurHole.enabled = false;
		this.Blurry = base.gameObject.AddComponent<CameraFilterPack_Blur_Blurry>();
		this.Blurry.enabled = false;
		this.Dithering2x2 = base.gameObject.AddComponent<CameraFilterPack_Blur_Dithering2x2>();
		this.Dithering2x2.enabled = false;
		this.DitherOffset = base.gameObject.AddComponent<CameraFilterPack_Blur_DitherOffset>();
		this.DitherOffset.enabled = false;
		this.Focus = base.gameObject.AddComponent<CameraFilterPack_Blur_Focus>();
		this.Focus.enabled = false;
		this.GaussianBlur = base.gameObject.AddComponent<CameraFilterPack_Blur_GaussianBlur>();
		this.GaussianBlur.enabled = false;
		this.Movie = base.gameObject.AddComponent<CameraFilterPack_Blur_Movie>();
		this.Movie.enabled = false;
		this.BlurNoise = base.gameObject.AddComponent<CameraFilterPack_Blur_Noise>();
		this.BlurNoise.enabled = false;
		this.Radial = base.gameObject.AddComponent<CameraFilterPack_Blur_Radial>();
		this.Radial.enabled = false;
		this.RadialFast = base.gameObject.AddComponent<CameraFilterPack_Blur_Radial_Fast>();
		this.RadialFast.enabled = false;
		this.Regular = base.gameObject.AddComponent<CameraFilterPack_Blur_Regular>();
		this.Regular.enabled = false;
		this.Steam = base.gameObject.AddComponent<CameraFilterPack_Blur_Steam>();
		this.Steam.enabled = false;
		this.TiltShift = base.gameObject.AddComponent<CameraFilterPack_Blur_Tilt_Shift>();
		this.TiltShift.enabled = false;
		this.TiltShiftHole = base.gameObject.AddComponent<CameraFilterPack_Blur_Tilt_Shift_Hole>();
		this.TiltShiftHole.enabled = false;
		this.TiltShiftV = base.gameObject.AddComponent<CameraFilterPack_Blur_Tilt_Shift_V>();
		this.TiltShiftV.enabled = false;
		this.BrokenScreen = base.gameObject.AddComponent<CameraFilterPack_Broken_Screen>();
		this.BrokenScreen.enabled = false;
		this.BrokenSimple = base.gameObject.AddComponent<CameraFilterPack_Broken_Simple>();
		this.BrokenSimple.enabled = false;
		this.Spliter = base.gameObject.AddComponent<CameraFilterPack_Broken_Spliter>();
		this.Spliter.enabled = false;
		this.ThermalVision = base.gameObject.AddComponent<CameraFilterPack_Classic_ThermalVision>();
		this.ThermalVision.enabled = false;
		this.AdjustColorRGB = base.gameObject.AddComponent<CameraFilterPack_Colors_Adjust_ColorRGB>();
		this.AdjustColorRGB.enabled = false;
		this.AdjustFullColors = base.gameObject.AddComponent<CameraFilterPack_Colors_Adjust_FullColors>();
		this.AdjustFullColors.enabled = false;
		this.AdjustPreFilters = base.gameObject.AddComponent<CameraFilterPack_Colors_Adjust_PreFilters>();
		this.AdjustPreFilters.enabled = false;
		this.BleachBypass = base.gameObject.AddComponent<CameraFilterPack_Colors_BleachBypass>();
		this.BleachBypass.enabled = false;
		this.Brightness = base.gameObject.AddComponent<CameraFilterPack_Colors_Brightness>();
		this.Brightness.enabled = false;
		this.DarkColor = base.gameObject.AddComponent<CameraFilterPack_Colors_DarkColor>();
		this.DarkColor.enabled = false;
		this.HSV = base.gameObject.AddComponent<CameraFilterPack_Colors_HSV>();
		this.HSV.enabled = false;
		this.HUERotate = base.gameObject.AddComponent<CameraFilterPack_Colors_HUE_Rotate>();
		this.HUERotate.enabled = false;
		this.NewPosterize = base.gameObject.AddComponent<CameraFilterPack_Colors_NewPosterize>();
		this.NewPosterize.enabled = false;
		this.RgbClamp = base.gameObject.AddComponent<CameraFilterPack_Colors_RgbClamp>();
		this.RgbClamp.enabled = false;
		this.Threshold = base.gameObject.AddComponent<CameraFilterPack_Colors_Threshold>();
		this.Threshold.enabled = false;
		this.AdjustLevels = base.gameObject.AddComponent<CameraFilterPack_Color_Adjust_Levels>();
		this.AdjustLevels.enabled = false;
		this.BrightContrastSaturation = base.gameObject.AddComponent<CameraFilterPack_Color_BrightContrastSaturation>();
		this.BrightContrastSaturation.enabled = false;
		this.ChromaticAberration = base.gameObject.AddComponent<CameraFilterPack_Color_Chromatic_Aberration>();
		this.ChromaticAberration.enabled = false;
		this.ChromaticPlus = base.gameObject.AddComponent<CameraFilterPack_Color_Chromatic_Plus>();
		this.ChromaticPlus.enabled = false;
		this.Contrast = base.gameObject.AddComponent<CameraFilterPack_Color_Contrast>();
		this.Contrast.enabled = false;
		this.GrayScale = base.gameObject.AddComponent<CameraFilterPack_Color_GrayScale>();
		this.GrayScale.enabled = false;
		this.Invert = base.gameObject.AddComponent<CameraFilterPack_Color_Invert>();
		this.Invert.enabled = false;
		this.ColorNoise = base.gameObject.AddComponent<CameraFilterPack_Color_Noise>();
		this.ColorNoise.enabled = false;
		this.ColorRGB = base.gameObject.AddComponent<CameraFilterPack_Color_RGB>();
		this.ColorRGB.enabled = false;
		this.Sepia = base.gameObject.AddComponent<CameraFilterPack_Color_Sepia>();
		this.Sepia.enabled = false;
		this.Switching = base.gameObject.AddComponent<CameraFilterPack_Color_Switching>();
		this.Switching.enabled = false;
		this.YUV = base.gameObject.AddComponent<CameraFilterPack_Color_YUV>();
		this.YUV.enabled = false;
		this.Normal = base.gameObject.AddComponent<CameraFilterPack_Convert_Normal>();
		this.Normal.enabled = false;
		this.Aspiration = base.gameObject.AddComponent<CameraFilterPack_Distortion_Aspiration>();
		this.Aspiration.enabled = false;
		this.BigFace = base.gameObject.AddComponent<CameraFilterPack_Distortion_BigFace>();
		this.BigFace.enabled = false;
		this.BlackHole = base.gameObject.AddComponent<CameraFilterPack_Distortion_BlackHole>();
		this.BlackHole.enabled = false;
		this.Dissipation = base.gameObject.AddComponent<CameraFilterPack_Distortion_Dissipation>();
		this.Dissipation.enabled = false;
		this.Dream = base.gameObject.AddComponent<CameraFilterPack_Distortion_Dream>();
		this.Dream.enabled = false;
		this.Dream2 = base.gameObject.AddComponent<CameraFilterPack_Distortion_Dream2>();
		this.Dream2.enabled = false;
		this.FishEye = base.gameObject.AddComponent<CameraFilterPack_Distortion_FishEye>();
		this.FishEye.enabled = false;
		this.Flag = base.gameObject.AddComponent<CameraFilterPack_Distortion_Flag>();
		this.Flag.enabled = false;
		this.Flush = base.gameObject.AddComponent<CameraFilterPack_Distortion_Flush>();
		this.Flush.enabled = false;
		this.HalfSphere = base.gameObject.AddComponent<CameraFilterPack_Distortion_Half_Sphere>();
		this.HalfSphere.enabled = false;
		this.Heat = base.gameObject.AddComponent<CameraFilterPack_Distortion_Heat>();
		this.Heat.enabled = false;
		this.Lens = base.gameObject.AddComponent<CameraFilterPack_Distortion_Lens>();
		this.Lens.enabled = false;
		this.DistortionNoise = base.gameObject.AddComponent<CameraFilterPack_Distortion_Noise>();
		this.DistortionNoise.enabled = false;
		this.ShockWave = base.gameObject.AddComponent<CameraFilterPack_Distortion_ShockWave>();
		this.ShockWave.enabled = false;
		this.ShockWaveManual = base.gameObject.AddComponent<CameraFilterPack_Distortion_ShockWaveManual>();
		this.ShockWaveManual.enabled = false;
		this.Twist = base.gameObject.AddComponent<CameraFilterPack_Distortion_Twist>();
		this.Twist.enabled = false;
		this.TwistSquare = base.gameObject.AddComponent<CameraFilterPack_Distortion_Twist_Square>();
		this.TwistSquare.enabled = false;
		this.DistortionWaterDrop = base.gameObject.AddComponent<CameraFilterPack_Distortion_Water_Drop>();
		this.DistortionWaterDrop.enabled = false;
		this.WaveHorizontal = base.gameObject.AddComponent<CameraFilterPack_Distortion_Wave_Horizontal>();
		this.WaveHorizontal.enabled = false;
		this.BluePrint = base.gameObject.AddComponent<CameraFilterPack_Drawing_BluePrint>();
		this.BluePrint.enabled = false;
		this.CellShading = base.gameObject.AddComponent<CameraFilterPack_Drawing_CellShading>();
		this.CellShading.enabled = false;
		this.CellShading2 = base.gameObject.AddComponent<CameraFilterPack_Drawing_CellShading2>();
		this.CellShading2.enabled = false;
		this.Comics = base.gameObject.AddComponent<CameraFilterPack_Drawing_Comics>();
		this.Comics.enabled = false;
		this.Crosshatch = base.gameObject.AddComponent<CameraFilterPack_Drawing_Crosshatch>();
		this.Crosshatch.enabled = false;
		this.Curve = base.gameObject.AddComponent<CameraFilterPack_Drawing_Curve>();
		this.Curve.enabled = false;
		this.EnhancedComics = base.gameObject.AddComponent<CameraFilterPack_Drawing_EnhancedComics>();
		this.EnhancedComics.enabled = false;
		this.Halftone = base.gameObject.AddComponent<CameraFilterPack_Drawing_Halftone>();
		this.Halftone.enabled = false;
		this.Laplacian = base.gameObject.AddComponent<CameraFilterPack_Drawing_Laplacian>();
		this.Laplacian.enabled = false;
		this.Lines = base.gameObject.AddComponent<CameraFilterPack_Drawing_Lines>();
		this.Lines.enabled = false;
		this.Manga = base.gameObject.AddComponent<CameraFilterPack_Drawing_Manga>();
		this.Manga.enabled = false;
		this.Manga2 = base.gameObject.AddComponent<CameraFilterPack_Drawing_Manga2>();
		this.Manga2.enabled = false;
		this.Manga3 = base.gameObject.AddComponent<CameraFilterPack_Drawing_Manga3>();
		this.Manga3.enabled = false;
		this.Manga4 = base.gameObject.AddComponent<CameraFilterPack_Drawing_Manga4>();
		this.Manga4.enabled = false;
		this.Manga5 = base.gameObject.AddComponent<CameraFilterPack_Drawing_Manga5>();
		this.Manga5.enabled = false;
		this.MangaColor = base.gameObject.AddComponent<CameraFilterPack_Drawing_Manga_Color>();
		this.MangaColor.enabled = false;
		this.MangaFlash = base.gameObject.AddComponent<CameraFilterPack_Drawing_Manga_Flash>();
		this.MangaFlash.enabled = false;
		this.MangaFlashWhite = base.gameObject.AddComponent<CameraFilterPack_Drawing_Manga_FlashWhite>();
		this.MangaFlashWhite.enabled = false;
		this.MangaFlashColor = base.gameObject.AddComponent<CameraFilterPack_Drawing_Manga_Flash_Color>();
		this.MangaFlashColor.enabled = false;
		this.NewCellShading = base.gameObject.AddComponent<CameraFilterPack_Drawing_NewCellShading>();
		this.NewCellShading.enabled = false;
		this.Paper = base.gameObject.AddComponent<CameraFilterPack_Drawing_Paper>();
		this.Paper.enabled = false;
		this.Paper2 = base.gameObject.AddComponent<CameraFilterPack_Drawing_Paper2>();
		this.Paper2.enabled = false;
		this.Paper3 = base.gameObject.AddComponent<CameraFilterPack_Drawing_Paper3>();
		this.Paper3.enabled = false;
		this.Toon = base.gameObject.AddComponent<CameraFilterPack_Drawing_Toon>();
		this.Toon.enabled = false;
		this.BlackLine = base.gameObject.AddComponent<CameraFilterPack_Edge_BlackLine>();
		this.BlackLine.enabled = false;
		this.Edgefilter = base.gameObject.AddComponent<CameraFilterPack_Edge_Edge_filter>();
		this.Edgefilter.enabled = false;
		this.Golden = base.gameObject.AddComponent<CameraFilterPack_Edge_Golden>();
		this.Golden.enabled = false;
		this.Neon = base.gameObject.AddComponent<CameraFilterPack_Edge_Neon>();
		this.Neon.enabled = false;
		this.Sigmoid = base.gameObject.AddComponent<CameraFilterPack_Edge_Sigmoid>();
		this.Sigmoid.enabled = false;
		this.Sobel = base.gameObject.AddComponent<CameraFilterPack_Edge_Sobel>();
		this.Sobel.enabled = false;
		this.Rotation = base.gameObject.AddComponent<CameraFilterPack_EXTRA_Rotation>();
		this.Rotation.enabled = false;
		this.SHOWFPS = base.gameObject.AddComponent<CameraFilterPack_EXTRA_SHOWFPS>();
		this.SHOWFPS.enabled = false;
		this.EyesVision1 = base.gameObject.AddComponent<CameraFilterPack_EyesVision_1>();
		this.EyesVision1.enabled = false;
		this.EyesVision2 = base.gameObject.AddComponent<CameraFilterPack_EyesVision_2>();
		this.EyesVision2.enabled = false;
		this.ColorPerfection = base.gameObject.AddComponent<CameraFilterPack_Film_ColorPerfection>();
		this.ColorPerfection.enabled = false;
		this.Grain = base.gameObject.AddComponent<CameraFilterPack_Film_Grain>();
		this.Grain.enabled = false;
		this.FlyVision = base.gameObject.AddComponent<CameraFilterPack_Fly_Vision>();
		this.FlyVision.enabled = false;
		this.FX8bits = base.gameObject.AddComponent<CameraFilterPack_FX_8bits>();
		this.FX8bits.enabled = false;
		this.FX8bitsgb = base.gameObject.AddComponent<CameraFilterPack_FX_8bits_gb>();
		this.FX8bitsgb.enabled = false;
		this.Ascii = base.gameObject.AddComponent<CameraFilterPack_FX_Ascii>();
		this.Ascii.enabled = false;
		this.DarkMatter = base.gameObject.AddComponent<CameraFilterPack_FX_DarkMatter>();
		this.DarkMatter.enabled = false;
		this.DigitalMatrix = base.gameObject.AddComponent<CameraFilterPack_FX_DigitalMatrix>();
		this.DigitalMatrix.enabled = false;
		this.DigitalMatrixDistortion = base.gameObject.AddComponent<CameraFilterPack_FX_DigitalMatrixDistortion>();
		this.DigitalMatrixDistortion.enabled = false;
		this.DotCircle = base.gameObject.AddComponent<CameraFilterPack_FX_Dot_Circle>();
		this.DotCircle.enabled = false;
		this.Drunk = base.gameObject.AddComponent<CameraFilterPack_FX_Drunk>();
		this.Drunk.enabled = false;
		this.Drunk2 = base.gameObject.AddComponent<CameraFilterPack_FX_Drunk2>();
		this.Drunk2.enabled = false;
		this.EarthQuake = base.gameObject.AddComponent<CameraFilterPack_FX_EarthQuake>();
		this.EarthQuake.enabled = false;
		this.Funk = base.gameObject.AddComponent<CameraFilterPack_FX_Funk>();
		this.Funk.enabled = false;
		this.Glitch1 = base.gameObject.AddComponent<CameraFilterPack_FX_Glitch1>();
		this.Glitch1.enabled = false;
		this.Glitch2 = base.gameObject.AddComponent<CameraFilterPack_FX_Glitch2>();
		this.Glitch2.enabled = false;
		this.Glitch3 = base.gameObject.AddComponent<CameraFilterPack_FX_Glitch3>();
		this.Glitch3.enabled = false;
		this.Grid = base.gameObject.AddComponent<CameraFilterPack_FX_Grid>();
		this.Grid.enabled = false;
		this.Hexagon = base.gameObject.AddComponent<CameraFilterPack_FX_Hexagon>();
		this.Hexagon.enabled = false;
		this.HexagonBlack = base.gameObject.AddComponent<CameraFilterPack_FX_Hexagon_Black>();
		this.HexagonBlack.enabled = false;
		this.Hypno = base.gameObject.AddComponent<CameraFilterPack_FX_Hypno>();
		this.Hypno.enabled = false;
		this.InverChromiLum = base.gameObject.AddComponent<CameraFilterPack_FX_InverChromiLum>();
		this.InverChromiLum.enabled = false;
		this.FXMirror = base.gameObject.AddComponent<CameraFilterPack_FX_Mirror>();
		this.FXMirror.enabled = false;
		this.FXPlasma = base.gameObject.AddComponent<CameraFilterPack_FX_Plasma>();
		this.FXPlasma.enabled = false;
		this.FXPsycho = base.gameObject.AddComponent<CameraFilterPack_FX_Psycho>();
		this.FXPsycho.enabled = false;
		this.Scan = base.gameObject.AddComponent<CameraFilterPack_FX_Scan>();
		this.Scan.enabled = false;
		this.Screens = base.gameObject.AddComponent<CameraFilterPack_FX_Screens>();
		this.Screens.enabled = false;
		this.Spot = base.gameObject.AddComponent<CameraFilterPack_FX_Spot>();
		this.Spot.enabled = false;
		this.superDot = base.gameObject.AddComponent<CameraFilterPack_FX_superDot>();
		this.superDot.enabled = false;
		this.ZebraColor = base.gameObject.AddComponent<CameraFilterPack_FX_ZebraColor>();
		this.ZebraColor.enabled = false;
		this.GlassesOn = base.gameObject.AddComponent<CameraFilterPack_Glasses_On>();
		this.GlassesOn.enabled = false;
		this.GlassesOn2 = base.gameObject.AddComponent<CameraFilterPack_Glasses_On_2>();
		this.GlassesOn2.enabled = false;
		this.GlassesOn3 = base.gameObject.AddComponent<CameraFilterPack_Glasses_On_3>();
		this.GlassesOn3.enabled = false;
		this.GlassesOn4 = base.gameObject.AddComponent<CameraFilterPack_Glasses_On_4>();
		this.GlassesOn4.enabled = false;
		this.GlassesOn5 = base.gameObject.AddComponent<CameraFilterPack_Glasses_On_5>();
		this.GlassesOn5.enabled = false;
		this.GlassesOn6 = base.gameObject.AddComponent<CameraFilterPack_Glasses_On_6>();
		this.GlassesOn6.enabled = false;
		this.Mozaic = base.gameObject.AddComponent<CameraFilterPack_Glitch_Mozaic>();
		this.Mozaic.enabled = false;
		this.Glow = base.gameObject.AddComponent<CameraFilterPack_Glow_Glow>();
		this.Glow.enabled = false;
		this.GlowColor = base.gameObject.AddComponent<CameraFilterPack_Glow_Glow_Color>();
		this.GlowColor.enabled = false;
		this.Ansi = base.gameObject.AddComponent<CameraFilterPack_Gradients_Ansi>();
		this.Ansi.enabled = false;
		this.Desert = base.gameObject.AddComponent<CameraFilterPack_Gradients_Desert>();
		this.Desert.enabled = false;
		this.ElectricGradient = base.gameObject.AddComponent<CameraFilterPack_Gradients_ElectricGradient>();
		this.ElectricGradient.enabled = false;
		this.FireGradient = base.gameObject.AddComponent<CameraFilterPack_Gradients_FireGradient>();
		this.FireGradient.enabled = false;
		this.GradientsHue = base.gameObject.AddComponent<CameraFilterPack_Gradients_Hue>();
		this.GradientsHue.enabled = false;
		this.NeonGradient = base.gameObject.AddComponent<CameraFilterPack_Gradients_NeonGradient>();
		this.NeonGradient.enabled = false;
		this.GradientsRainbow = base.gameObject.AddComponent<CameraFilterPack_Gradients_Rainbow>();
		this.GradientsRainbow.enabled = false;
		this.Stripe = base.gameObject.AddComponent<CameraFilterPack_Gradients_Stripe>();
		this.Stripe.enabled = false;
		this.Tech = base.gameObject.AddComponent<CameraFilterPack_Gradients_Tech>();
		this.Tech.enabled = false;
		this.Therma = base.gameObject.AddComponent<CameraFilterPack_Gradients_Therma>();
		this.Therma.enabled = false;
		this.LightRainbow = base.gameObject.AddComponent<CameraFilterPack_Light_Rainbow>();
		this.LightRainbow.enabled = false;
		this.LightRainbow2 = base.gameObject.AddComponent<CameraFilterPack_Light_Rainbow2>();
		this.LightRainbow2.enabled = false;
		this.Water = base.gameObject.AddComponent<CameraFilterPack_Light_Water>();
		this.Water.enabled = false;
		this.Water2 = base.gameObject.AddComponent<CameraFilterPack_Light_Water2>();
		this.Water2.enabled = false;
		this.Lut = base.gameObject.AddComponent<CameraFilterPack_Lut_2_Lut>();
		this.Lut.enabled = false;
		this.LutExtra = base.gameObject.AddComponent<CameraFilterPack_Lut_2_Lut_Extra>();
		this.LutExtra.enabled = false;
		this.Mask = base.gameObject.AddComponent<CameraFilterPack_Lut_Mask>();
		this.Mask.enabled = false;
		this.PlayWith = base.gameObject.AddComponent<CameraFilterPack_Lut_PlayWith>();
		this.PlayWith.enabled = false;
		this.Plus = base.gameObject.AddComponent<CameraFilterPack_Lut_Plus>();
		this.Plus.enabled = false;
		this.LutSimple = base.gameObject.AddComponent<CameraFilterPack_Lut_Simple>();
		this.LutSimple.enabled = false;
		this.TestMode = base.gameObject.AddComponent<CameraFilterPack_Lut_TestMode>();
		this.TestMode.enabled = false;
		this.NewGlitch1 = base.gameObject.AddComponent<CameraFilterPack_NewGlitch1>();
		this.NewGlitch1.enabled = false;
		this.NewGlitch2 = base.gameObject.AddComponent<CameraFilterPack_NewGlitch2>();
		this.NewGlitch2.enabled = false;
		this.NewGlitch3 = base.gameObject.AddComponent<CameraFilterPack_NewGlitch3>();
		this.NewGlitch3.enabled = false;
		this.NewGlitch4 = base.gameObject.AddComponent<CameraFilterPack_NewGlitch4>();
		this.NewGlitch4.enabled = false;
		this.NewGlitch5 = base.gameObject.AddComponent<CameraFilterPack_NewGlitch5>();
		this.NewGlitch5.enabled = false;
		this.NewGlitch6 = base.gameObject.AddComponent<CameraFilterPack_NewGlitch6>();
		this.NewGlitch6.enabled = false;
		this.NewGlitch7 = base.gameObject.AddComponent<CameraFilterPack_NewGlitch7>();
		this.NewGlitch7.enabled = false;
		this.NightVisionFX = base.gameObject.AddComponent<CameraFilterPack_NightVisionFX>();
		this.NightVisionFX.enabled = false;
		this.NightVision4 = base.gameObject.AddComponent<CameraFilterPack_NightVision_4>();
		this.NightVision4.enabled = false;
		this.TV = base.gameObject.AddComponent<CameraFilterPack_Noise_TV>();
		this.TV.enabled = false;
		this.TV2 = base.gameObject.AddComponent<CameraFilterPack_Noise_TV_2>();
		this.TV2.enabled = false;
		this.TV3 = base.gameObject.AddComponent<CameraFilterPack_Noise_TV_3>();
		this.TV3.enabled = false;
		this.NightVision1 = base.gameObject.AddComponent<CameraFilterPack_Oculus_NightVision1>();
		this.NightVision1.enabled = false;
		this.NightVision2 = base.gameObject.AddComponent<CameraFilterPack_Oculus_NightVision2>();
		this.NightVision2.enabled = false;
		this.NightVision3 = base.gameObject.AddComponent<CameraFilterPack_Oculus_NightVision3>();
		this.NightVision3.enabled = false;
		this.NightVision5 = base.gameObject.AddComponent<CameraFilterPack_Oculus_NightVision5>();
		this.NightVision5.enabled = false;
		this.ThermaVision = base.gameObject.AddComponent<CameraFilterPack_Oculus_ThermaVision>();
		this.ThermaVision.enabled = false;
		this.Cutting1 = base.gameObject.AddComponent<CameraFilterPack_OldFilm_Cutting1>();
		this.Cutting1.enabled = false;
		this.Cutting2 = base.gameObject.AddComponent<CameraFilterPack_OldFilm_Cutting2>();
		this.Cutting2.enabled = false;
		this.DeepOilPaintHQ = base.gameObject.AddComponent<CameraFilterPack_Pixelisation_DeepOilPaintHQ>();
		this.DeepOilPaintHQ.enabled = false;
		this.Dot = base.gameObject.AddComponent<CameraFilterPack_Pixelisation_Dot>();
		this.Dot.enabled = false;
		this.OilPaint = base.gameObject.AddComponent<CameraFilterPack_Pixelisation_OilPaint>();
		this.OilPaint.enabled = false;
		this.OilPaintHQ = base.gameObject.AddComponent<CameraFilterPack_Pixelisation_OilPaintHQ>();
		this.OilPaintHQ.enabled = false;
		this.Sweater = base.gameObject.AddComponent<CameraFilterPack_Pixelisation_Sweater>();
		this.Sweater.enabled = false;
		this.Pixelisation = base.gameObject.AddComponent<CameraFilterPack_Pixel_Pixelisation>();
		this.Pixelisation.enabled = false;
		this.RainFX = base.gameObject.AddComponent<CameraFilterPack_Rain_RainFX>();
		this.RainFX.enabled = false;
		this.RealVHS = base.gameObject.AddComponent<CameraFilterPack_Real_VHS>();
		this.RealVHS.enabled = false;
		this.Loading = base.gameObject.AddComponent<CameraFilterPack_Retro_Loading>();
		this.Loading.enabled = false;
		this.Sharpen = base.gameObject.AddComponent<CameraFilterPack_Sharpen_Sharpen>();
		this.Sharpen.enabled = false;
		this.Bubble = base.gameObject.AddComponent<CameraFilterPack_Special_Bubble>();
		this.Bubble.enabled = false;
		this.TV50 = base.gameObject.AddComponent<CameraFilterPack_TV_50>();
		this.TV50.enabled = false;
		this.TV80 = base.gameObject.AddComponent<CameraFilterPack_TV_80>();
		this.TV80.enabled = false;
		this.ARCADE = base.gameObject.AddComponent<CameraFilterPack_TV_ARCADE>();
		this.ARCADE.enabled = false;
		this.ARCADE2 = base.gameObject.AddComponent<CameraFilterPack_TV_ARCADE_2>();
		this.ARCADE2.enabled = false;
		this.ARCADEFast = base.gameObject.AddComponent<CameraFilterPack_TV_ARCADE_Fast>();
		this.ARCADEFast.enabled = false;
		this.Artefact = base.gameObject.AddComponent<CameraFilterPack_TV_Artefact>();
		this.Artefact.enabled = false;
		this.BrokenGlass = base.gameObject.AddComponent<CameraFilterPack_TV_BrokenGlass>();
		this.BrokenGlass.enabled = false;
		this.BrokenGlass2 = base.gameObject.AddComponent<CameraFilterPack_TV_BrokenGlass2>();
		this.BrokenGlass2.enabled = false;
		this.Chromatical = base.gameObject.AddComponent<CameraFilterPack_TV_Chromatical>();
		this.Chromatical.enabled = false;
		this.Chromatical2 = base.gameObject.AddComponent<CameraFilterPack_TV_Chromatical2>();
		this.Chromatical2.enabled = false;
		this.CompressionFX = base.gameObject.AddComponent<CameraFilterPack_TV_CompressionFX>();
		this.CompressionFX.enabled = false;
		this.Distorted = base.gameObject.AddComponent<CameraFilterPack_TV_Distorted>();
		this.Distorted.enabled = false;
		this.Horror = base.gameObject.AddComponent<CameraFilterPack_TV_Horror>();
		this.Horror.enabled = false;
		this.LED = base.gameObject.AddComponent<CameraFilterPack_TV_LED>();
		this.LED.enabled = false;
		this.MovieNoise = base.gameObject.AddComponent<CameraFilterPack_TV_MovieNoise>();
		this.MovieNoise.enabled = false;
		this.TVNoise = base.gameObject.AddComponent<CameraFilterPack_TV_Noise>();
		this.TVNoise.enabled = false;
		this.Old = base.gameObject.AddComponent<CameraFilterPack_TV_Old>();
		this.Old.enabled = false;
		this.OldMovie = base.gameObject.AddComponent<CameraFilterPack_TV_Old_Movie>();
		this.OldMovie.enabled = false;
		this.OldMovie2 = base.gameObject.AddComponent<CameraFilterPack_TV_Old_Movie_2>();
		this.OldMovie2.enabled = false;
		this.PlanetMars = base.gameObject.AddComponent<CameraFilterPack_TV_PlanetMars>();
		this.PlanetMars.enabled = false;
		this.Posterize = base.gameObject.AddComponent<CameraFilterPack_TV_Posterize>();
		this.Posterize.enabled = false;
		this.TVRgb = base.gameObject.AddComponent<CameraFilterPack_TV_Rgb>();
		this.TVRgb.enabled = false;
		this.Tiles = base.gameObject.AddComponent<CameraFilterPack_TV_Tiles>();
		this.Tiles.enabled = false;
		this.Vcr = base.gameObject.AddComponent<CameraFilterPack_TV_Vcr>();
		this.Vcr.enabled = false;
		this.TVVHS = base.gameObject.AddComponent<CameraFilterPack_TV_VHS>();
		this.TVVHS.enabled = false;
		this.VHSRewind = base.gameObject.AddComponent<CameraFilterPack_TV_VHS_Rewind>();
		this.VHSRewind.enabled = false;
		this.Video3D = base.gameObject.AddComponent<CameraFilterPack_TV_Video3D>();
		this.Video3D.enabled = false;
		this.Videoflip = base.gameObject.AddComponent<CameraFilterPack_TV_Videoflip>();
		this.Videoflip.enabled = false;
		this.Vignetting = base.gameObject.AddComponent<CameraFilterPack_TV_Vignetting>();
		this.Vignetting.enabled = false;
		this.Vintage = base.gameObject.AddComponent<CameraFilterPack_TV_Vintage>();
		this.Vintage.enabled = false;
		this.WideScreenCircle = base.gameObject.AddComponent<CameraFilterPack_TV_WideScreenCircle>();
		this.WideScreenCircle.enabled = false;
		this.WideScreenHorizontal = base.gameObject.AddComponent<CameraFilterPack_TV_WideScreenHorizontal>();
		this.WideScreenHorizontal.enabled = false;
		this.WideScreenHV = base.gameObject.AddComponent<CameraFilterPack_TV_WideScreenHV>();
		this.WideScreenHV.enabled = false;
		this.WideScreenVertical = base.gameObject.AddComponent<CameraFilterPack_TV_WideScreenVertical>();
		this.WideScreenVertical.enabled = false;
		this.Tracking = base.gameObject.AddComponent<CameraFilterPack_VHS_Tracking>();
		this.Tracking.enabled = false;
		this.Aura = base.gameObject.AddComponent<CameraFilterPack_Vision_Aura>();
		this.Aura.enabled = false;
		this.AuraDistortion = base.gameObject.AddComponent<CameraFilterPack_Vision_AuraDistortion>();
		this.AuraDistortion.enabled = false;
		this.VisionBlood = base.gameObject.AddComponent<CameraFilterPack_Vision_Blood>();
		this.VisionBlood.enabled = false;
		this.VisionBloodFast = base.gameObject.AddComponent<CameraFilterPack_Vision_Blood_Fast>();
		this.VisionBloodFast.enabled = false;
		this.Crystal = base.gameObject.AddComponent<CameraFilterPack_Vision_Crystal>();
		this.Crystal.enabled = false;
		this.Drost = base.gameObject.AddComponent<CameraFilterPack_Vision_Drost>();
		this.Drost.enabled = false;
		this.VisionHellBlood = base.gameObject.AddComponent<CameraFilterPack_Vision_Hell_Blood>();
		this.VisionHellBlood.enabled = false;
		this.VisionPlasma = base.gameObject.AddComponent<CameraFilterPack_Vision_Plasma>();
		this.VisionPlasma.enabled = false;
		this.VisionPsycho = base.gameObject.AddComponent<CameraFilterPack_Vision_Psycho>();
		this.VisionPsycho.enabled = false;
		this.VisionRainbow = base.gameObject.AddComponent<CameraFilterPack_Vision_Rainbow>();
		this.VisionRainbow.enabled = false;
		this.SniperScore = base.gameObject.AddComponent<CameraFilterPack_Vision_SniperScore>();
		this.SniperScore.enabled = false;
		this.Tunnel = base.gameObject.AddComponent<CameraFilterPack_Vision_Tunnel>();
		this.Tunnel.enabled = false;
		this.Warp = base.gameObject.AddComponent<CameraFilterPack_Vision_Warp>();
		this.Warp.enabled = false;
		this.Warp2 = base.gameObject.AddComponent<CameraFilterPack_Vision_Warp2>();
		this.Warp2.enabled = false;
		this.ScanScene.AutoAnimatedNear = true;
	}

	private void Update()
	{
		if (Input.GetKey(KeyCode.LeftShift))
		{
			if (Input.GetKeyDown("z"))
			{
				this.FilterID -= 10;
				this.UpdateFilter();
			}
			if (Input.GetKeyDown("x"))
			{
				this.FilterID += 10;
				this.UpdateFilter();
			}
		}
		else
		{
			if (Input.GetKeyDown("z"))
			{
				this.FilterID--;
				this.UpdateFilter();
			}
			if (Input.GetKeyDown("x"))
			{
				this.FilterID++;
				this.UpdateFilter();
			}
		}
		if (this.DisplayTimer < 2f)
		{
			this.DisplayTimer += Time.deltaTime;
			this.NameLabel.transform.localPosition = Vector3.Lerp(this.NameLabel.transform.localPosition, new Vector3(1245f, 0f, 0f), Time.deltaTime * 10f);
		}
		else
		{
			this.Speed += Time.deltaTime * 10f;
			this.NameLabel.transform.localPosition = Vector3.MoveTowards(this.NameLabel.transform.localPosition, Vector3.zero, this.Speed);
		}
	}

	private void UpdateFilter()
	{
		this.NameLabel.transform.localPosition = Vector3.zero;
		this.DisplayTimer = 0f;
		this.Speed = 0f;
		this.Anomaly.enabled = false;
		this.Binary.enabled = false;
		this.BlackHole3D.enabled = false;
		this.Computer.enabled = false;
		this.Distortion.enabled = false;
		this.FogSmoke.enabled = false;
		this.Ghost.enabled = false;
		this.Inverse.enabled = false;
		this.Matrix.enabled = false;
		this.Mirror3D.enabled = false;
		this.Myst.enabled = false;
		this.ScanScene.enabled = false;
		this.Shield.enabled = false;
		this.Snow.enabled = false;
		this.AAABlood.enabled = false;
		this.AAABloodOnScreen.enabled = false;
		this.AAABloodHit.enabled = false;
		this.AAABloodPlus.enabled = false;
		this.SuperComputer.enabled = false;
		this.SuperHexagon.enabled = false;
		this.WaterDrop.enabled = false;
		this.WaterDropPro.enabled = false;
		this.AlienVision.enabled = false;
		this.FXAA.enabled = false;
		this.Fog.enabled = false;
		this.Rain.enabled = false;
		this.RainPro.enabled = false;
		this.RainPro3D.enabled = false;
		this.Snow8bits.enabled = false;
		this.Blend.enabled = false;
		this.BlueScreen.enabled = false;
		this.Color.enabled = false;
		this.ColorBurn.enabled = false;
		this.ColorDodge.enabled = false;
		this.ColorKey.enabled = false;
		this.Darken.enabled = false;
		this.DarkerColor.enabled = false;
		this.Difference.enabled = false;
		this.Divide.enabled = false;
		this.Exclusion.enabled = false;
		this.GreenScreen.enabled = false;
		this.HardLight.enabled = false;
		this.HardMix.enabled = false;
		this.Blend2CameraHue.enabled = false;
		this.Lighten.enabled = false;
		this.LighterColor.enabled = false;
		this.LinearBurn.enabled = false;
		this.LinearDodge.enabled = false;
		this.LinearLight.enabled = false;
		this.Luminosity.enabled = false;
		this.Multiply.enabled = false;
		this.Overlay.enabled = false;
		this.PhotoshopFilters.enabled = false;
		this.PinLight.enabled = false;
		this.Saturation.enabled = false;
		this.Screen.enabled = false;
		this.SoftLight.enabled = false;
		this.SplitScreen.enabled = false;
		this.SplitScreen3D.enabled = false;
		this.Subtract.enabled = false;
		this.VividLight.enabled = false;
		this.Blizzard.enabled = false;
		this.Bloom.enabled = false;
		this.BlurHole.enabled = false;
		this.Blurry.enabled = false;
		this.Dithering2x2.enabled = false;
		this.DitherOffset.enabled = false;
		this.Focus.enabled = false;
		this.GaussianBlur.enabled = false;
		this.Movie.enabled = false;
		this.BlurNoise.enabled = false;
		this.Radial.enabled = false;
		this.RadialFast.enabled = false;
		this.Regular.enabled = false;
		this.Steam.enabled = false;
		this.TiltShift.enabled = false;
		this.TiltShiftHole.enabled = false;
		this.TiltShiftV.enabled = false;
		this.BrokenScreen.enabled = false;
		this.BrokenSimple.enabled = false;
		this.Spliter.enabled = false;
		this.ThermalVision.enabled = false;
		this.AdjustColorRGB.enabled = false;
		this.AdjustFullColors.enabled = false;
		this.AdjustPreFilters.enabled = false;
		this.BleachBypass.enabled = false;
		this.Brightness.enabled = false;
		this.DarkColor.enabled = false;
		this.HSV.enabled = false;
		this.HUERotate.enabled = false;
		this.NewPosterize.enabled = false;
		this.RgbClamp.enabled = false;
		this.Threshold.enabled = false;
		this.AdjustLevels.enabled = false;
		this.BrightContrastSaturation.enabled = false;
		this.ChromaticAberration.enabled = false;
		this.ChromaticPlus.enabled = false;
		this.Contrast.enabled = false;
		this.GrayScale.enabled = false;
		this.Invert.enabled = false;
		this.ColorNoise.enabled = false;
		this.ColorRGB.enabled = false;
		this.Sepia.enabled = false;
		this.Switching.enabled = false;
		this.YUV.enabled = false;
		this.Normal.enabled = false;
		this.Aspiration.enabled = false;
		this.BigFace.enabled = false;
		this.BlackHole.enabled = false;
		this.Dissipation.enabled = false;
		this.Dream.enabled = false;
		this.Dream2.enabled = false;
		this.FishEye.enabled = false;
		this.Flag.enabled = false;
		this.Flush.enabled = false;
		this.HalfSphere.enabled = false;
		this.Heat.enabled = false;
		this.Lens.enabled = false;
		this.DistortionNoise.enabled = false;
		this.ShockWave.enabled = false;
		this.ShockWaveManual.enabled = false;
		this.Twist.enabled = false;
		this.TwistSquare.enabled = false;
		this.DistortionWaterDrop.enabled = false;
		this.WaveHorizontal.enabled = false;
		this.BluePrint.enabled = false;
		this.CellShading.enabled = false;
		this.CellShading2.enabled = false;
		this.Comics.enabled = false;
		this.Crosshatch.enabled = false;
		this.Curve.enabled = false;
		this.EnhancedComics.enabled = false;
		this.Halftone.enabled = false;
		this.Laplacian.enabled = false;
		this.Lines.enabled = false;
		this.Manga.enabled = false;
		this.Manga2.enabled = false;
		this.Manga3.enabled = false;
		this.Manga4.enabled = false;
		this.Manga5.enabled = false;
		this.MangaColor.enabled = false;
		this.MangaFlash.enabled = false;
		this.MangaFlashWhite.enabled = false;
		this.MangaFlashColor.enabled = false;
		this.NewCellShading.enabled = false;
		this.Paper.enabled = false;
		this.Paper2.enabled = false;
		this.Paper3.enabled = false;
		this.Toon.enabled = false;
		this.BlackLine.enabled = false;
		this.Edgefilter.enabled = false;
		this.Golden.enabled = false;
		this.Neon.enabled = false;
		this.Sigmoid.enabled = false;
		this.Sobel.enabled = false;
		this.Rotation.enabled = false;
		this.SHOWFPS.enabled = false;
		this.EyesVision1.enabled = false;
		this.EyesVision2.enabled = false;
		this.ColorPerfection.enabled = false;
		this.Grain.enabled = false;
		this.FlyVision.enabled = false;
		this.FX8bits.enabled = false;
		this.FX8bitsgb.enabled = false;
		this.Ascii.enabled = false;
		this.DarkMatter.enabled = false;
		this.DigitalMatrix.enabled = false;
		this.DigitalMatrixDistortion.enabled = false;
		this.DotCircle.enabled = false;
		this.Drunk.enabled = false;
		this.Drunk2.enabled = false;
		this.EarthQuake.enabled = false;
		this.Funk.enabled = false;
		this.Glitch1.enabled = false;
		this.Glitch2.enabled = false;
		this.Glitch3.enabled = false;
		this.Grid.enabled = false;
		this.Hexagon.enabled = false;
		this.HexagonBlack.enabled = false;
		this.Hypno.enabled = false;
		this.InverChromiLum.enabled = false;
		this.FXMirror.enabled = false;
		this.FXPlasma.enabled = false;
		this.FXPsycho.enabled = false;
		this.Scan.enabled = false;
		this.Screens.enabled = false;
		this.Spot.enabled = false;
		this.superDot.enabled = false;
		this.ZebraColor.enabled = false;
		this.GlassesOn.enabled = false;
		this.GlassesOn2.enabled = false;
		this.GlassesOn3.enabled = false;
		this.GlassesOn4.enabled = false;
		this.GlassesOn5.enabled = false;
		this.GlassesOn6.enabled = false;
		this.Mozaic.enabled = false;
		this.Glow.enabled = false;
		this.GlowColor.enabled = false;
		this.Ansi.enabled = false;
		this.Desert.enabled = false;
		this.ElectricGradient.enabled = false;
		this.FireGradient.enabled = false;
		this.GradientsHue.enabled = false;
		this.NeonGradient.enabled = false;
		this.GradientsRainbow.enabled = false;
		this.Stripe.enabled = false;
		this.Tech.enabled = false;
		this.Therma.enabled = false;
		this.LightRainbow.enabled = false;
		this.LightRainbow2.enabled = false;
		this.Water.enabled = false;
		this.Water2.enabled = false;
		this.Lut.enabled = false;
		this.LutExtra.enabled = false;
		this.Mask.enabled = false;
		this.PlayWith.enabled = false;
		this.Plus.enabled = false;
		this.LutSimple.enabled = false;
		this.TestMode.enabled = false;
		this.NewGlitch1.enabled = false;
		this.NewGlitch2.enabled = false;
		this.NewGlitch3.enabled = false;
		this.NewGlitch4.enabled = false;
		this.NewGlitch5.enabled = false;
		this.NewGlitch6.enabled = false;
		this.NewGlitch7.enabled = false;
		this.NightVisionFX.enabled = false;
		this.NightVision4.enabled = false;
		this.TV.enabled = false;
		this.TV2.enabled = false;
		this.TV3.enabled = false;
		this.NightVision1.enabled = false;
		this.NightVision2.enabled = false;
		this.NightVision3.enabled = false;
		this.NightVision5.enabled = false;
		this.ThermaVision.enabled = false;
		this.Cutting1.enabled = false;
		this.Cutting2.enabled = false;
		this.DeepOilPaintHQ.enabled = false;
		this.Dot.enabled = false;
		this.OilPaint.enabled = false;
		this.OilPaintHQ.enabled = false;
		this.Sweater.enabled = false;
		this.Pixelisation.enabled = false;
		this.RainFX.enabled = false;
		this.RealVHS.enabled = false;
		this.Loading.enabled = false;
		this.Sharpen.enabled = false;
		this.Bubble.enabled = false;
		this.TV50.enabled = false;
		this.TV80.enabled = false;
		this.ARCADE.enabled = false;
		this.ARCADE2.enabled = false;
		this.ARCADEFast.enabled = false;
		this.Artefact.enabled = false;
		this.BrokenGlass.enabled = false;
		this.BrokenGlass2.enabled = false;
		this.Chromatical.enabled = false;
		this.Chromatical2.enabled = false;
		this.CompressionFX.enabled = false;
		this.Distorted.enabled = false;
		this.Horror.enabled = false;
		this.LED.enabled = false;
		this.MovieNoise.enabled = false;
		this.TVNoise.enabled = false;
		this.Old.enabled = false;
		this.OldMovie.enabled = false;
		this.OldMovie2.enabled = false;
		this.PlanetMars.enabled = false;
		this.Posterize.enabled = false;
		this.TVRgb.enabled = false;
		this.Tiles.enabled = false;
		this.Vcr.enabled = false;
		this.TVVHS.enabled = false;
		this.VHSRewind.enabled = false;
		this.Video3D.enabled = false;
		this.Videoflip.enabled = false;
		this.Vignetting.enabled = false;
		this.Vintage.enabled = false;
		this.WideScreenCircle.enabled = false;
		this.WideScreenHorizontal.enabled = false;
		this.WideScreenHV.enabled = false;
		this.WideScreenVertical.enabled = false;
		this.Tracking.enabled = false;
		this.Aura.enabled = false;
		this.AuraDistortion.enabled = false;
		this.VisionBlood.enabled = false;
		this.VisionBloodFast.enabled = false;
		this.Crystal.enabled = false;
		this.Drost.enabled = false;
		this.VisionHellBlood.enabled = false;
		this.VisionPlasma.enabled = false;
		this.VisionPsycho.enabled = false;
		this.VisionRainbow.enabled = false;
		this.SniperScore.enabled = false;
		this.Tunnel.enabled = false;
		this.Warp.enabled = false;
		this.Warp2.enabled = false;
		if (this.FilterID > this.FilterMax)
		{
			this.FilterID = 0;
		}
		if (this.FilterID < 0)
		{
			this.FilterID = this.FilterMax;
		}
		while (this.FilterSkips[this.FilterID])
		{
			if (Input.GetKeyDown("z"))
			{
				this.FilterID--;
			}
			else
			{
				this.FilterID++;
			}
		}
		this.NameLabel.text = string.Concat(new object[]
		{
			"#",
			this.FilterID,
			" - ",
			this.FilterNames[this.FilterID]
		});
		switch (this.FilterID)
		{
		case 1:
			this.Anomaly.enabled = true;
			break;
		case 2:
			this.Binary.enabled = true;
			break;
		case 3:
			this.BlackHole3D.enabled = true;
			break;
		case 4:
			this.Computer.enabled = true;
			break;
		case 5:
			this.Distortion.enabled = true;
			break;
		case 6:
			this.FogSmoke.enabled = true;
			break;
		case 7:
			this.Ghost.enabled = true;
			break;
		case 8:
			this.Inverse.enabled = true;
			break;
		case 9:
			this.Matrix.enabled = true;
			break;
		case 10:
			this.Mirror3D.enabled = true;
			break;
		case 11:
			this.Myst.enabled = true;
			break;
		case 12:
			this.ScanScene.enabled = true;
			break;
		case 13:
			this.Shield.enabled = true;
			break;
		case 14:
			this.Snow.enabled = true;
			break;
		case 15:
			this.AAABlood.enabled = true;
			break;
		case 16:
			this.AAABloodOnScreen.enabled = true;
			break;
		case 17:
			this.AAABloodHit.enabled = true;
			break;
		case 18:
			this.AAABloodPlus.enabled = true;
			break;
		case 19:
			this.SuperComputer.enabled = true;
			break;
		case 20:
			this.SuperHexagon.enabled = true;
			break;
		case 21:
			this.WaterDrop.enabled = true;
			break;
		case 22:
			this.WaterDropPro.enabled = true;
			break;
		case 23:
			this.AlienVision.enabled = true;
			break;
		case 24:
			this.FXAA.enabled = true;
			break;
		case 25:
			this.Fog.enabled = true;
			break;
		case 26:
			this.Rain.enabled = true;
			break;
		case 27:
			this.RainPro.enabled = true;
			break;
		case 28:
			this.RainPro3D.enabled = true;
			break;
		case 29:
			this.Snow8bits.enabled = true;
			break;
		case 30:
			this.Blend.enabled = true;
			break;
		case 31:
			this.BlueScreen.enabled = true;
			break;
		case 32:
			this.Color.enabled = true;
			break;
		case 33:
			this.ColorBurn.enabled = true;
			break;
		case 34:
			this.ColorDodge.enabled = true;
			break;
		case 35:
			this.ColorKey.enabled = true;
			break;
		case 36:
			this.Darken.enabled = true;
			break;
		case 37:
			this.DarkerColor.enabled = true;
			break;
		case 38:
			this.Difference.enabled = true;
			break;
		case 39:
			this.Divide.enabled = true;
			break;
		case 40:
			this.Exclusion.enabled = true;
			break;
		case 41:
			this.GreenScreen.enabled = true;
			break;
		case 42:
			this.HardLight.enabled = true;
			break;
		case 43:
			this.HardMix.enabled = true;
			break;
		case 44:
			this.Blend2CameraHue.enabled = true;
			break;
		case 45:
			this.Lighten.enabled = true;
			break;
		case 46:
			this.LighterColor.enabled = true;
			break;
		case 47:
			this.LinearBurn.enabled = true;
			break;
		case 48:
			this.LinearDodge.enabled = true;
			break;
		case 49:
			this.LinearLight.enabled = true;
			break;
		case 50:
			this.Luminosity.enabled = true;
			break;
		case 51:
			this.Multiply.enabled = true;
			break;
		case 52:
			this.Overlay.enabled = true;
			break;
		case 53:
			this.PhotoshopFilters.enabled = true;
			break;
		case 54:
			this.PinLight.enabled = true;
			break;
		case 55:
			this.Saturation.enabled = true;
			break;
		case 56:
			this.Screen.enabled = true;
			break;
		case 57:
			this.SoftLight.enabled = true;
			break;
		case 58:
			this.SplitScreen.enabled = true;
			break;
		case 59:
			this.SplitScreen3D.enabled = true;
			break;
		case 60:
			this.Subtract.enabled = true;
			break;
		case 61:
			this.VividLight.enabled = true;
			break;
		case 62:
			this.Blizzard.enabled = true;
			break;
		case 63:
			this.Bloom.enabled = true;
			break;
		case 64:
			this.BlurHole.enabled = true;
			break;
		case 65:
			this.Blurry.enabled = true;
			break;
		case 66:
			this.Dithering2x2.enabled = true;
			break;
		case 67:
			this.DitherOffset.enabled = true;
			break;
		case 68:
			this.Focus.enabled = true;
			break;
		case 69:
			this.GaussianBlur.enabled = true;
			break;
		case 70:
			this.Movie.enabled = true;
			break;
		case 71:
			this.BlurNoise.enabled = true;
			break;
		case 72:
			this.Radial.enabled = true;
			break;
		case 73:
			this.RadialFast.enabled = true;
			break;
		case 74:
			this.Regular.enabled = true;
			break;
		case 75:
			this.Steam.enabled = true;
			break;
		case 76:
			this.TiltShift.enabled = true;
			break;
		case 77:
			this.TiltShiftHole.enabled = true;
			break;
		case 78:
			this.TiltShiftV.enabled = true;
			break;
		case 79:
			this.BrokenScreen.enabled = true;
			break;
		case 80:
			this.BrokenSimple.enabled = true;
			break;
		case 81:
			this.Spliter.enabled = true;
			break;
		case 82:
			this.ThermalVision.enabled = true;
			break;
		case 83:
			this.AdjustColorRGB.enabled = true;
			break;
		case 84:
			this.AdjustFullColors.enabled = true;
			break;
		case 85:
			this.AdjustPreFilters.enabled = true;
			break;
		case 86:
			this.BleachBypass.enabled = true;
			break;
		case 87:
			this.Brightness.enabled = true;
			break;
		case 88:
			this.DarkColor.enabled = true;
			break;
		case 89:
			this.HSV.enabled = true;
			break;
		case 90:
			this.HUERotate.enabled = true;
			break;
		case 91:
			this.NewPosterize.enabled = true;
			break;
		case 92:
			this.RgbClamp.enabled = true;
			break;
		case 93:
			this.Threshold.enabled = true;
			break;
		case 94:
			this.AdjustLevels.enabled = true;
			break;
		case 95:
			this.BrightContrastSaturation.enabled = true;
			break;
		case 96:
			this.ChromaticAberration.enabled = true;
			break;
		case 97:
			this.ChromaticPlus.enabled = true;
			break;
		case 98:
			this.Contrast.enabled = true;
			break;
		case 99:
			this.GrayScale.enabled = true;
			break;
		case 100:
			this.Invert.enabled = true;
			break;
		case 101:
			this.ColorNoise.enabled = true;
			break;
		case 102:
			this.ColorRGB.enabled = true;
			break;
		case 103:
			this.Sepia.enabled = true;
			break;
		case 104:
			this.Switching.enabled = true;
			break;
		case 105:
			this.YUV.enabled = true;
			break;
		case 106:
			this.Normal.enabled = true;
			break;
		case 107:
			this.Aspiration.enabled = true;
			break;
		case 108:
			this.BigFace.enabled = true;
			break;
		case 109:
			this.BlackHole.enabled = true;
			break;
		case 110:
			this.Dissipation.enabled = true;
			break;
		case 111:
			this.Dream.enabled = true;
			break;
		case 112:
			this.Dream2.enabled = true;
			break;
		case 113:
			this.FishEye.enabled = true;
			break;
		case 114:
			this.Flag.enabled = true;
			break;
		case 115:
			this.Flush.enabled = true;
			break;
		case 116:
			this.HalfSphere.enabled = true;
			break;
		case 117:
			this.Heat.enabled = true;
			break;
		case 118:
			this.Lens.enabled = true;
			break;
		case 119:
			this.DistortionNoise.enabled = true;
			break;
		case 120:
			this.ShockWave.enabled = true;
			break;
		case 121:
			this.ShockWaveManual.enabled = true;
			break;
		case 122:
			this.Twist.enabled = true;
			break;
		case 123:
			this.TwistSquare.enabled = true;
			break;
		case 124:
			this.DistortionWaterDrop.enabled = true;
			break;
		case 125:
			this.WaveHorizontal.enabled = true;
			break;
		case 126:
			this.BluePrint.enabled = true;
			break;
		case 127:
			this.CellShading.enabled = true;
			break;
		case 128:
			this.CellShading2.enabled = true;
			break;
		case 129:
			this.Comics.enabled = true;
			break;
		case 130:
			this.Crosshatch.enabled = true;
			break;
		case 131:
			this.Curve.enabled = true;
			break;
		case 132:
			this.EnhancedComics.enabled = true;
			break;
		case 133:
			this.Halftone.enabled = true;
			break;
		case 134:
			this.Laplacian.enabled = true;
			break;
		case 135:
			this.Lines.enabled = true;
			break;
		case 136:
			this.Manga.enabled = true;
			break;
		case 137:
			this.Manga2.enabled = true;
			break;
		case 138:
			this.Manga3.enabled = true;
			break;
		case 139:
			this.Manga4.enabled = true;
			break;
		case 140:
			this.Manga5.enabled = true;
			break;
		case 141:
			this.MangaColor.enabled = true;
			break;
		case 142:
			this.MangaFlash.enabled = true;
			break;
		case 143:
			this.MangaFlashWhite.enabled = true;
			break;
		case 144:
			this.MangaFlashColor.enabled = true;
			break;
		case 145:
			this.NewCellShading.enabled = true;
			break;
		case 146:
			this.Paper.enabled = true;
			break;
		case 147:
			this.Paper2.enabled = true;
			break;
		case 148:
			this.Paper3.enabled = true;
			break;
		case 149:
			this.Toon.enabled = true;
			break;
		case 150:
			this.BlackLine.enabled = true;
			break;
		case 151:
			this.Edgefilter.enabled = true;
			break;
		case 152:
			this.Golden.enabled = true;
			break;
		case 153:
			this.Neon.enabled = true;
			break;
		case 154:
			this.Sigmoid.enabled = true;
			break;
		case 155:
			this.Sobel.enabled = true;
			break;
		case 156:
			this.Rotation.enabled = true;
			break;
		case 157:
			this.SHOWFPS.enabled = true;
			break;
		case 158:
			this.EyesVision1.enabled = true;
			break;
		case 159:
			this.EyesVision2.enabled = true;
			break;
		case 160:
			this.ColorPerfection.enabled = true;
			break;
		case 161:
			this.Grain.enabled = true;
			break;
		case 162:
			this.FlyVision.enabled = true;
			break;
		case 163:
			this.FX8bits.enabled = true;
			break;
		case 164:
			this.FX8bitsgb.enabled = true;
			break;
		case 165:
			this.Ascii.enabled = true;
			break;
		case 166:
			this.DarkMatter.enabled = true;
			break;
		case 167:
			this.DigitalMatrix.enabled = true;
			break;
		case 168:
			this.DigitalMatrixDistortion.enabled = true;
			break;
		case 169:
			this.DotCircle.enabled = true;
			break;
		case 170:
			this.Drunk.enabled = true;
			break;
		case 171:
			this.Drunk2.enabled = true;
			break;
		case 172:
			this.EarthQuake.enabled = true;
			break;
		case 173:
			this.Funk.enabled = true;
			break;
		case 174:
			this.Glitch1.enabled = true;
			break;
		case 175:
			this.Glitch2.enabled = true;
			break;
		case 176:
			this.Glitch3.enabled = true;
			break;
		case 177:
			this.Grid.enabled = true;
			break;
		case 178:
			this.Hexagon.enabled = true;
			break;
		case 179:
			this.HexagonBlack.enabled = true;
			break;
		case 180:
			this.Hypno.enabled = true;
			break;
		case 181:
			this.InverChromiLum.enabled = true;
			break;
		case 182:
			this.FXMirror.enabled = true;
			break;
		case 183:
			this.FXPlasma.enabled = true;
			break;
		case 184:
			this.FXPsycho.enabled = true;
			break;
		case 185:
			this.Scan.enabled = true;
			break;
		case 186:
			this.Screens.enabled = true;
			break;
		case 187:
			this.Spot.enabled = true;
			break;
		case 188:
			this.superDot.enabled = true;
			break;
		case 189:
			this.ZebraColor.enabled = true;
			break;
		case 190:
			this.GlassesOn.enabled = true;
			break;
		case 191:
			this.GlassesOn2.enabled = true;
			break;
		case 192:
			this.GlassesOn3.enabled = true;
			break;
		case 193:
			this.GlassesOn4.enabled = true;
			break;
		case 194:
			this.GlassesOn5.enabled = true;
			break;
		case 195:
			this.GlassesOn6.enabled = true;
			break;
		case 196:
			this.Mozaic.enabled = true;
			break;
		case 197:
			this.Glow.enabled = true;
			break;
		case 198:
			this.GlowColor.enabled = true;
			break;
		case 199:
			this.Ansi.enabled = true;
			break;
		case 200:
			this.Desert.enabled = true;
			break;
		case 201:
			this.ElectricGradient.enabled = true;
			break;
		case 202:
			this.FireGradient.enabled = true;
			break;
		case 203:
			this.GradientsHue.enabled = true;
			break;
		case 204:
			this.NeonGradient.enabled = true;
			break;
		case 205:
			this.GradientsRainbow.enabled = true;
			break;
		case 206:
			this.Stripe.enabled = true;
			break;
		case 207:
			this.Tech.enabled = true;
			break;
		case 208:
			this.Therma.enabled = true;
			break;
		case 209:
			this.LightRainbow.enabled = true;
			break;
		case 210:
			this.LightRainbow2.enabled = true;
			break;
		case 211:
			this.Water.enabled = true;
			break;
		case 212:
			this.Water2.enabled = true;
			break;
		case 213:
			this.Lut.enabled = true;
			break;
		case 214:
			this.LutExtra.enabled = true;
			break;
		case 215:
			this.Mask.enabled = true;
			break;
		case 216:
			this.PlayWith.enabled = true;
			break;
		case 217:
			this.Plus.enabled = true;
			break;
		case 218:
			this.LutSimple.enabled = true;
			break;
		case 219:
			this.TestMode.enabled = true;
			break;
		case 220:
			this.NewGlitch1.enabled = true;
			break;
		case 221:
			this.NewGlitch2.enabled = true;
			break;
		case 222:
			this.NewGlitch3.enabled = true;
			break;
		case 223:
			this.NewGlitch4.enabled = true;
			break;
		case 224:
			this.NewGlitch5.enabled = true;
			break;
		case 225:
			this.NewGlitch6.enabled = true;
			break;
		case 226:
			this.NewGlitch7.enabled = true;
			break;
		case 227:
			this.NightVisionFX.enabled = true;
			break;
		case 228:
			this.NightVision4.enabled = true;
			break;
		case 229:
			this.TV.enabled = true;
			break;
		case 230:
			this.TV2.enabled = true;
			break;
		case 231:
			this.TV3.enabled = true;
			break;
		case 232:
			this.NightVision1.enabled = true;
			break;
		case 233:
			this.NightVision2.enabled = true;
			break;
		case 234:
			this.NightVision3.enabled = true;
			break;
		case 235:
			this.NightVision5.enabled = true;
			break;
		case 236:
			this.ThermaVision.enabled = true;
			break;
		case 237:
			this.Cutting1.enabled = true;
			break;
		case 238:
			this.Cutting2.enabled = true;
			break;
		case 239:
			this.DeepOilPaintHQ.enabled = true;
			break;
		case 240:
			this.Dot.enabled = true;
			break;
		case 241:
			this.OilPaint.enabled = true;
			break;
		case 242:
			this.OilPaintHQ.enabled = true;
			break;
		case 243:
			this.Sweater.enabled = true;
			break;
		case 244:
			this.Pixelisation.enabled = true;
			break;
		case 245:
			this.RainFX.enabled = true;
			break;
		case 246:
			this.RealVHS.enabled = true;
			break;
		case 247:
			this.Loading.enabled = true;
			break;
		case 248:
			this.Sharpen.enabled = true;
			break;
		case 249:
			this.Bubble.enabled = true;
			break;
		case 250:
			this.TV50.enabled = true;
			break;
		case 251:
			this.TV80.enabled = true;
			break;
		case 252:
			this.ARCADE.enabled = true;
			break;
		case 253:
			this.ARCADE2.enabled = true;
			break;
		case 254:
			this.ARCADEFast.enabled = true;
			break;
		case 255:
			this.Artefact.enabled = true;
			break;
		case 256:
			this.BrokenGlass.enabled = true;
			break;
		case 257:
			this.BrokenGlass2.enabled = true;
			break;
		case 258:
			this.Chromatical.enabled = true;
			break;
		case 259:
			this.Chromatical2.enabled = true;
			break;
		case 260:
			this.CompressionFX.enabled = true;
			break;
		case 261:
			this.Distorted.enabled = true;
			break;
		case 262:
			this.Horror.enabled = true;
			break;
		case 263:
			this.LED.enabled = true;
			break;
		case 264:
			this.MovieNoise.enabled = true;
			break;
		case 265:
			this.TVNoise.enabled = true;
			break;
		case 266:
			this.Old.enabled = true;
			break;
		case 267:
			this.OldMovie.enabled = true;
			break;
		case 268:
			this.OldMovie2.enabled = true;
			break;
		case 269:
			this.PlanetMars.enabled = true;
			break;
		case 270:
			this.Posterize.enabled = true;
			break;
		case 271:
			this.TVRgb.enabled = true;
			break;
		case 272:
			this.Tiles.enabled = true;
			break;
		case 273:
			this.Vcr.enabled = true;
			break;
		case 274:
			this.TVVHS.enabled = true;
			break;
		case 275:
			this.VHSRewind.enabled = true;
			break;
		case 276:
			this.Video3D.enabled = true;
			break;
		case 277:
			this.Videoflip.enabled = true;
			break;
		case 278:
			this.Vignetting.enabled = true;
			break;
		case 279:
			this.Vintage.enabled = true;
			break;
		case 280:
			this.WideScreenCircle.enabled = true;
			break;
		case 281:
			this.WideScreenHorizontal.enabled = true;
			break;
		case 282:
			this.WideScreenHV.enabled = true;
			break;
		case 283:
			this.WideScreenVertical.enabled = true;
			break;
		case 284:
			this.Tracking.enabled = true;
			break;
		case 285:
			this.Aura.enabled = true;
			break;
		case 286:
			this.AuraDistortion.enabled = true;
			break;
		case 287:
			this.VisionBlood.enabled = true;
			break;
		case 288:
			this.VisionBloodFast.enabled = true;
			break;
		case 289:
			this.Crystal.enabled = true;
			break;
		case 290:
			this.Drost.enabled = true;
			break;
		case 291:
			this.VisionHellBlood.enabled = true;
			break;
		case 292:
			this.VisionPlasma.enabled = true;
			break;
		case 293:
			this.VisionPsycho.enabled = true;
			break;
		case 294:
			this.VisionRainbow.enabled = true;
			break;
		case 295:
			this.SniperScore.enabled = true;
			break;
		case 296:
			this.Tunnel.enabled = true;
			break;
		case 297:
			this.Warp.enabled = true;
			break;
		case 298:
			this.Warp2.enabled = true;
			break;
		}
	}
}
