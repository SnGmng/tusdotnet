﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tusdotnet.Interfaces;

namespace tusdotnet.Stores.FileIdProviders
{
    /// <summary>
    /// Provides file ids using GUIDs
    /// </summary>
    public class TusGuidProvider : ITusFileIdProvider
    {
        private readonly string _guildFormat;

        /// <summary>
        /// Creates a new TusGuildProvider
        /// </summary>
        public TusGuidProvider(string guildFormat = "n")
        {
            _guildFormat = guildFormat;
        }

        /// <inheritdoc />
        public virtual Task<string> CreateId(string metadata)
        {
            return Task.FromResult(Guid.NewGuid().ToString(_guildFormat));
        }

        /// <inheritdoc />
        public virtual Task<bool> ValidateId(string fileId)
        {
            return Task.FromResult(Guid.TryParseExact(fileId, _guildFormat, out var _));
        }
    }
}
