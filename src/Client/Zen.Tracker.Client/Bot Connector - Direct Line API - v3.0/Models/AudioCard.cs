﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.16.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Zen.Tracker.Client.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;

    /// <summary>
    /// A audio card
    /// </summary>
    public partial class AudioCard
    {
        /// <summary>
        /// Initializes a new instance of the AudioCard class.
        /// </summary>
        public AudioCard() { }

        /// <summary>
        /// Initializes a new instance of the AudioCard class.
        /// </summary>
        public AudioCard(string aspect = default(string), string title = default(string), string subtitle = default(string), string text = default(string), ThumbnailUrl image = default(ThumbnailUrl), IList<MediaUrl> media = default(IList<MediaUrl>), IList<CardAction> buttons = default(IList<CardAction>), bool? shareable = default(bool?), bool? autoloop = default(bool?), bool? autostart = default(bool?))
        {
            Aspect = aspect;
            Title = title;
            Subtitle = subtitle;
            Text = text;
            Image = image;
            Media = media;
            Buttons = buttons;
            Shareable = shareable;
            Autoloop = autoloop;
            Autostart = autostart;
        }

        /// <summary>
        /// Aspect ratio of thumbnail/media placeholder, allowed values are
        /// "16x9" and "9x16"
        /// </summary>
        [JsonProperty(PropertyName = "aspect")]
        public string Aspect { get; set; }

        /// <summary>
        /// Title of the card
        /// </summary>
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        /// <summary>
        /// Subtitle of the card
        /// </summary>
        [JsonProperty(PropertyName = "subtitle")]
        public string Subtitle { get; set; }

        /// <summary>
        /// Text of the card
        /// </summary>
        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }

        /// <summary>
        /// Thumbnail placeholder
        /// </summary>
        [JsonProperty(PropertyName = "image")]
        public ThumbnailUrl Image { get; set; }

        /// <summary>
        /// Array of media Url objects
        /// </summary>
        [JsonProperty(PropertyName = "media")]
        public IList<MediaUrl> Media { get; set; }

        /// <summary>
        /// Set of actions applicable to the current card
        /// </summary>
        [JsonProperty(PropertyName = "buttons")]
        public IList<CardAction> Buttons { get; set; }

        /// <summary>
        /// Is it OK for this content to be shareable with others
        /// (default:true)
        /// </summary>
        [JsonProperty(PropertyName = "shareable")]
        public bool? Shareable { get; set; }

        /// <summary>
        /// Should the client loop playback at end of content (default:true)
        /// </summary>
        [JsonProperty(PropertyName = "autoloop")]
        public bool? Autoloop { get; set; }

        /// <summary>
        /// Should the client automatically start playback of video in this
        /// card (default:true)
        /// </summary>
        [JsonProperty(PropertyName = "autostart")]
        public bool? Autostart { get; set; }

    }
}
