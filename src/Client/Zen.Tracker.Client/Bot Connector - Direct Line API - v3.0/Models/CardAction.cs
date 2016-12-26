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
    /// An action on a card
    /// </summary>
    public partial class CardAction
    {
        /// <summary>
        /// Initializes a new instance of the CardAction class.
        /// </summary>
        public CardAction() { }

        /// <summary>
        /// Initializes a new instance of the CardAction class.
        /// </summary>
        public CardAction(string type = default(string), string title = default(string), string image = default(string), string value = default(string))
        {
            Type = type;
            Title = title;
            Image = image;
            Value = value;
        }

        /// <summary>
        /// Defines the type of action implemented by this button.
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        /// <summary>
        /// Text description which appear on the button.
        /// </summary>
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        /// <summary>
        /// URL Picture which will appear on the button, next to text label.
        /// </summary>
        [JsonProperty(PropertyName = "image")]
        public string Image { get; set; }

        /// <summary>
        /// Supplementary parameter for action. Content of this property
        /// depends on the ActionType
        /// </summary>
        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }

    }
}