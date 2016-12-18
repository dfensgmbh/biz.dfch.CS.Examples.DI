/**
 * Copyright 2016 d-fens GmbH
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using biz.dfch.CS.Examples.DI.StructureMap.IoC.Conventions;
using biz.dfch.CS.Examples.DI.StructureMap.IoC.Registries;
using StructureMap;

namespace biz.dfch.CS.Examples.DI.StructureMap.MefLoader
{
    public class MefLoader
    {
        private static readonly object _lock = new object();
        public static Type Type { get; private set; }

        private static ConcurrentDictionary<Type, Container> _containers = 
            new ConcurrentDictionary<Type, Container>();

        private readonly MefLoaderSettings settings;
        private readonly Registry registry;

        public MefLoader()
            : this(new MefLoaderSettings())
        {
            // N/A
        }

        public MefLoader(MefLoaderSettings settings)
        {
            Contract.Requires(null != settings);

            this.settings = settings;
        }

        public MefLoader(Registry registry)
        {
            Contract.Requires(null != registry);

            this.registry = registry;
        }

        public T GetInstance<T>()
            where T : class
        {
            Contract.Ensures(null != Contract.Result<T>());

            var instance = GetInstances<T>().FirstOrDefault();
            return instance;
        }

        public IEnumerable<T> GetInstances<T>()
            where T : class
        {
            Contract.Ensures(null != Contract.Result<IEnumerable<T>>());

            var addContainerFunc = new Func<Type, Container>(type =>
            {
                if (null != registry)
                {
                    return new Container(registry);
                }

                return new Container(map =>
                {
                    map.Scan(scanner =>
                    {
                        if (settings.IncludeCallingAssembly)
                        {
                            scanner.TheCallingAssembly();
                        }

                        if (settings.IncludeExecutingAssembly)
                        {
                            scanner.Assembly(Assembly.GetExecutingAssembly());
                        }

                        if (null != settings.ExtensionsFolder)
                        {
                            scanner.AssembliesFromPath(settings.ExtensionsFolder.FullName);
                        }

                        scanner.Convention<MefRegistrationConvention>();
                    });
                });
            });

            Container container;
            lock (_lock)
            {
                Type = typeof(T);

                container = _containers.GetOrAdd(typeof(T), addContainerFunc(typeof(T)));
            }

            Trace.WriteLine(container.WhatDoIHave());
            Trace.WriteLine(container.WhatDidIScan());
            try
            {
                container.AssertConfigurationIsValid();
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }

            var instances = container.GetAllInstances<T>();
            return instances;
        }

    }
}
