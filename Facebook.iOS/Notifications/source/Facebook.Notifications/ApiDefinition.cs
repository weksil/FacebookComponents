﻿using System;

using UIKit;
using Foundation;
using ObjCRuntime;
using CoreGraphics;

namespace Facebook.Notifications {
	interface ICardViewControllerDelegate { }

	// @protocol FBNCardViewControllerDelegate <NSObject>
	[Model (AutoGeneratedName = true)]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "FBNCardViewControllerDelegate")]
	interface CardViewControllerDelegate {
		// @optional -(void)pushCardViewController:(FBNCardViewController * _Nonnull)controller willDismissWithOpenURL:(NSURL * _Nonnull)url;
		[Export ("pushCardViewController:willDismissWithOpenURL:")]
		void WillDismiss (CardViewController controller, NSUrl url);

		// @optional -(void)pushCardViewControllerWillDismiss:(FBNCardViewController * _Nonnull)controller;
		[Export ("pushCardViewControllerWillDismiss:")]
		void WillDismiss (CardViewController controller);
	}

	// @interface FBNCardViewController : UIViewController
	[DisableDefaultCtor]
	[BaseType (typeof (UIViewController), Name = "FBNCardViewController")]
	interface CardViewController {
		[NullAllowed]
		[Export ("delegate", ArgumentSemantic.Weak)]
		ICardViewControllerDelegate Delegate { get; set; }
	}

	// typedef void (^FBNCardContentPreparationCompletion)(NSDictionary * _Nullable, NSError * _Nullable);
	delegate void CardContentPreparationCompletionHandler ([NullAllowed] NSDictionary payload, [NullAllowed] NSError error);

	// typedef void (^FBNCardPresentationCompletion)(FBNCardViewController * _Nullable, NSError * _Nullable);
	delegate void CardPresentationCompletionHandler ([NullAllowed] CardViewController viewController, [NullAllowed] NSError error);

	// typedef void (^FBNLocalNotificationCreationCompletion)(UILocalNotification * _Nullable, NSError * _Nullable);
	delegate void LocalNotificationCreationCompletionHandler ([NullAllowed] UILocalNotification notification, [NullAllowed] NSError error);

	// @interface FBNotificationsManager : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FBNotificationsManager")]
	interface NotificationsManager {
		// extern NSString * _Nonnull FBNotificationsErrorDomain;
		[Field ("FBNotificationsErrorDomain", "__Internal")]
		NSString ErrorDomain { get; }

		// extern NSString * _Nonnull FBNotificationsCardFormatVersionString;
		[Field ("FBNotificationsCardFormatVersionString", "__Internal")]
		NSString VersionString { get; }

		// +(instancetype _Nonnull)sharedManager;
		[Static]
		[Export ("sharedManager")]
		NotificationsManager SharedInstance { get; }

		// -(void)preparePushCardContentForRemoteNotificationPayload:(NSDictionary * _Nonnull)payload completion:(FBNCardContentPreparationCompletion _Nullable)completion;
		[Async]
		[Export ("preparePushCardContentForRemoteNotificationPayload:completion:")]
		void PreparePushCardContent (NSDictionary payload, [NullAllowed] CardContentPreparationCompletionHandler completion);

		// -(void)presentPushCardForRemoteNotificationPayload:(NSDictionary * _Nonnull)payload fromViewController:(UIViewController * _Nullable)viewController completion:(FBNCardPresentationCompletion _Nullable)completion;
		[Async]
		[Export ("presentPushCardForRemoteNotificationPayload:fromViewController:completion:")]
		void PresentPushCard (NSDictionary payload, [NullAllowed] UIViewController viewController, [NullAllowed] CardPresentationCompletionHandler completion);

		// -(BOOL)canPresentPushCardFromRemoteNotificationPayload:(NSDictionary * _Nullable)payload;
		[Export ("canPresentPushCardFromRemoteNotificationPayload:")]
		bool CanPresentPushCard ([NullAllowed] NSDictionary payload);

		// -(void)createLocalNotificationFromRemoteNotificationPayload:(NSDictionary * _Nonnull)payload completion:(FBNLocalNotificationCreationCompletion _Nonnull)completion;
		[Async]
		[Export ("createLocalNotificationFromRemoteNotificationPayload:completion:")]
		void CreateLocalNotification (NSDictionary payload, LocalNotificationCreationCompletionHandler completion);

		// -(void)presentPushCardForLocalNotification:(UILocalNotification * _Nonnull)notification fromViewController:(UIViewController * _Nullable)viewController completion:(FBNCardPresentationCompletion _Nullable)completion;
		[Async]
		[Export ("presentPushCardForLocalNotification:fromViewController:completion:")]
		void PresentPushCard (UILocalNotification notification, [NullAllowed] UIViewController viewController, [NullAllowed] CardPresentationCompletionHandler completion);

		// -(BOOL)canPresentPushCardFromLocalNotification:(UILocalNotification * _Nonnull)notification;
		[Export ("canPresentPushCardFromLocalNotification:")]
		bool CanPresentPushCard (UILocalNotification notification);
	}
}