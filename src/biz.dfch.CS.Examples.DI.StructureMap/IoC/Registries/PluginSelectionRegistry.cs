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
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using biz.dfch.CS.Examples.DI.StructureMap.InjectionDependingOnAppConfig;
using biz.dfch.CS.Examples.DI.StructureMap.Message;
using StructureMap;

namespace biz.dfch.CS.Examples.DI.StructureMap.IoC.Registries
{
    public class PluginSelectionRegistry : Registry
    {
        public PluginSelectionRegistry()
        {
            For<IPlugin>().Use(() => GetPluginType());
        }

        // this expr func is only evaluated when an instance for that object actually has to be instantiated
        // so we can safely access the PluginContainer property at that time
        public static IPlugin GetPluginType()
        {
            var settings = ConfigurationManager.GetSection(PluginConfigurationSection.SECTION_NAME)
                as PluginConfigurationSection;
            Contract.Assert(null != settings, PluginConfigurationSection.SECTION_NAME);
            Contract.Assert(!string.IsNullOrWhiteSpace(settings.Type));

            var type = Type.GetType(settings.Type);
            Contract.Assert(null != type, settings.Type);

            var instance = IoC.PluginContainer.GetInstance(type);
            var plugin = instance as IPlugin;
            Contract.Assert(null != plugin, settings.Type);

            return plugin;
        }
    }
}
