// ----------------------------------------------------------------------------
// <copyright file="DependencyManager.cs" company="Nicksys">
// Copyright (c) Nicksys Inc. All Rights Reserved.
// http://www.nicksysfoundation.com/
// </copyright>
// <summary></summary>
// ----------------------------------------------------------------------------

using System;

namespace Nicksys.Foundation
{
    public class DependencyManager
    {
        #region Constractor & Instance

        private static volatile DependencyManager _instance;
        private static readonly object SyncLock = new object();

        private DependencyManager()
        {
            Initialized = false;
        }

        public static DependencyManager Current
        {
            get
            {
                if (_instance != null) return _instance;
                
                lock (SyncLock)
                {
                    if (_instance == null)
                    {
                        _instance = new DependencyManager();
                    }
                }

                return _instance;
            }
        }

        #endregion

        #region Properties

        public IResolver Resolver { get; private set; }

        public bool Initialized { get; private set; }

        #endregion

        #region Static Methods

        public static void SetResolver(IResolver resolver)
        {
            Current.InnerSetResolver(resolver);
        }

        #endregion

        #region Methods

        public void InnerSetResolver(IResolver resolver)
        {
            if (resolver == null)
            {
                throw new ArgumentNullException("resolver");
            }

            Resolver = resolver;
        }

        #endregion
    }
}
