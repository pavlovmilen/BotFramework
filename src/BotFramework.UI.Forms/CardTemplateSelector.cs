﻿using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace BotFramework.UI
{
	public class CardTemplateSelector : Xamarin.Forms.DataTemplateSelector
	{
		protected DataTemplate defaultTemplate;
		public CardTemplateSelector ()
		{
			defaultTemplate = new DataTemplate (typeof (HeroCardView));
		}
		public static Dictionary<string, DataTemplate> TypeMappings = new Dictionary<string, DataTemplate>
		{
			{HeroCard.ContentType,new DataTemplate (typeof (HeroCardView))},
			{ReceiptCard.ContentType,new DataTemplate (typeof (ReceiptCardView))},
			{SigninCard.ContentType,new DataTemplate (typeof (SignInCardView))},
			{ThumbnailCard.ContentType,new DataTemplate (typeof (ThumbnailCardView))},
            {AdaptiveCard.ContentType,new DataTemplate (typeof (AdaptiveCardView))},
			//{AnimationCard.ContentType,typeof(AnimationCard)},
			//{AudioCard.ContentType,typeof(AudioCard)},
			//{VideoCard.ContentType,typeof(VideoCard)},
		};
		protected override DataTemplate OnSelectTemplate (object item, BindableObject container)
		{
			var messageVm = item as Attachment;
			if (messageVm == null)
				return null;
			DataTemplate template = null;
			TypeMappings.TryGetValue (messageVm.ContentType ?? "", out template);
			return template ?? defaultTemplate;
		}

	}
}
