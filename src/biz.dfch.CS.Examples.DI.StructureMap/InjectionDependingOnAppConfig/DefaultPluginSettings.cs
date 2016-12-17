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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace biz.dfch.CS.Examples.DI.StructureMap.InjectionDependingOnAppConfig
{
    public class DefaultPluginSettings : ConfigurationSection
    {
        public const string SECTION_NAME = "DefaultPluginConfigurationSection";

        private const string PROPERTY_MAGIC = "magicValue";
        public const string PROPERTY_MAGIC_DEFAULT = "42";
        private const string PROPERTY_SEP = "sepValue";
        public const string PROPERTY_SEP_DEFAULT = "SEP";

        [ConfigurationProperty(PROPERTY_MAGIC, DefaultValue = PROPERTY_MAGIC_DEFAULT, IsRequired = false)]
        public int Magic
        {
            get { return (int) this[PROPERTY_MAGIC]; }
            set { this[PROPERTY_MAGIC] = value; }
        }

        [ConfigurationProperty(PROPERTY_SEP, DefaultValue = PROPERTY_SEP_DEFAULT, IsRequired = false)]
        public string Sep
        {
            get { return (string) this[PROPERTY_SEP]; }
            set { this[PROPERTY_SEP] = value; }
        }
    }
}
