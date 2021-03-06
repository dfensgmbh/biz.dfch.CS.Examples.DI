﻿/**
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

using System.Configuration;
using System.Diagnostics.Contracts;
using biz.dfch.CS.Examples.DI.StructureMap.Message;
using StructureMap;

namespace biz.dfch.CS.Examples.DI.StructureMap.IoC.Registries
{
    public class MessageSettingsFromConfigurationSectionRegistry : Registry
    {
        public MessageSettingsFromConfigurationSectionRegistry()
        {
            // we load the section from app.config

            //For<IMessageSettings>().Use(() => 
            //    (MessageSettingsFromConfigSection) ConfigurationManager
            //    .GetSection(MessageSettingsFromConfigSection.SECTION_NAME)
            //);
            For<IMessageSettings>().Use(() => GetConfigSection());
        }

        public static MessageSettingsFromConfigSection GetConfigSection()
        {
            var result = ConfigurationManager.GetSection(MessageSettingsFromConfigSection.SECTION_NAME)
                as MessageSettingsFromConfigSection;

            Contract.Assert(null != result, MessageSettingsFromConfigSection.SECTION_NAME);

            return result;
        }
    }
}
