using System;

using ObjCRuntime;
using Foundation;
using UIKit;

namespace NativeLibrary
{
	// @interface Axeptio : NSObject
	//[BaseType(typeof(NSObject))]
	//[DisableDefaultCtor]
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	interface Axeptio
	{
		// @property (copy, nonatomic, class) NSString * _Nonnull token;
		[Static]
		[Export("token")]
		string Token { get; set; }

		// +(void)initializeWithClientId:(NSString * _Nonnull)clientId version:(NSString * _Nonnull)version completionHandler:(void (^ _Nonnull)(NSError * _Nullable))completionHandler;
		[Static]
		[Export("initializeWithClientId:version:completionHandler:")]
		void InitializeWithClientId(string clientId, string version, Action<NSError> completionHandler);

		// +(BOOL)hasUserConsentForVendor:(NSString * _Nonnull)name __attribute__((warn_unused_result("")));
		[Static]
		[Export("hasUserConsentForVendor:")]
		bool HasUserConsentForVendor(string name);

		// +(BOOL)getUserConsentForVendor:(NSString * _Nonnull)name __attribute__((warn_unused_result("")));
		[Static]
		[Export("getUserConsentForVendor:")]
		bool GetUserConsentForVendor(string name);

		// +(void)clearUserConsents;
		[Static]
		[Export("clearUserConsents")]
		void ClearUserConsents();

		// +(void (^ _Nullable)(void))showConsentControllerWithInitialStepIndex:(NSInteger)initialStepIndex onlyFirstTime:(BOOL)onlyFirstTime in:(UIViewController * _Nonnull)viewController animated:(BOOL)animated completionHandler:(void (^ _Nonnull)(NSError * _Nullable))completionHandler;
		[Static]
		[Export("showConsentControllerWithInitialStepIndex:onlyFirstTime:in:animated:completionHandler:")]
		[return: NullAllowed]
		Action ShowConsentControllerWithInitialStepIndex(nint initialStepIndex, bool onlyFirstTime, UIViewController viewController, bool animated, Action<NSError> completionHandler);
	}

}
