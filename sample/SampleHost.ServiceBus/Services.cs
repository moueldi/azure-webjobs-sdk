﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace SampleHostServiceBus
{
    /// <summary>
    /// Sample services used to demonstrate DI capabilities
    /// </summary>
    public interface ISampleServiceA
    {
        void DoIt();
    }

    public class SampleServiceA : ISampleServiceA
    {
        private readonly ILogger _logger;

        public SampleServiceA(ILogger<SampleServiceA> logger)
        {
            _logger = logger;
        }

        public void DoIt()
        {
            _logger.LogInformation("SampleServiceA.DoIt invoked!");
        }
    }

    public interface ISampleServiceB
    {
        void DoIt();
    }

    public class SampleServiceB : ISampleServiceB
    {
        private readonly ILogger _logger;

        public SampleServiceB(ILogger<SampleServiceB> logger)
        {
            _logger = logger;
        }

        public void DoIt()
        {
            _logger.LogInformation("SampleServiceB.DoIt invoked!");
        }
    }

    public class SessionState
    {

        private readonly ConcurrentDictionary<string, long> _state = new ConcurrentDictionary<string, long>();
        public long AddOrUpdate(string session, long newV) {
            return _state.AddOrUpdate(session, newV, (key, oldV)=>  newV);
        }
        public IEnumerable<KeyValuePair<string, long>> Content => _state;
    }
}
