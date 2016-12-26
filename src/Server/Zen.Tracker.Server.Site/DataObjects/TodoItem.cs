﻿using System;
using Microsoft.Azure.Mobile.Server.Tables;

namespace Zen.Tracker.Server.Site.DataObjects
{
    public class TodoItem : ITableData
    {
        public string Id { get; set; }

        public byte[] Version { get; set; }

        public DateTimeOffset? CreatedAt { get; set; }

        public DateTimeOffset? UpdatedAt { get; set; }

        public bool Deleted { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public bool Complete { get; set; }

        public DateTimeOffset? DueAt { get; set; }

        public DateTimeOffset? CompletedAt { get; set; }
    }
}