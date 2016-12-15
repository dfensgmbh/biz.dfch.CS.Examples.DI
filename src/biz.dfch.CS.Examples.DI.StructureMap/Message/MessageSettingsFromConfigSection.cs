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

using System.Configuration;

namespace biz.dfch.CS.Examples.DI.StructureMap.Message
{
    public class MessageSettingsFromConfigSection : ConfigurationSection, IMessageSettings
    {
        public const string SECTION_NAME = "MessageSettingsFromConfigSection";

        private const string PROPERTY_SERVER = "server";
        private const string PROPERTY_SERVER_DEFAULT = "smtpFromConfigurationSection.example.com";
        private const string PROPERTY_RECIPIENT = "recipient";
        private const string PROPERTY_RECIPIENT_DEFAULT = "recipientFromConfigurationSection@example.com";
        private const string PROPERTY_SENDER = "sender";
        private const string PROPERTY_SENDER_DEFAULT = "senderFromConfigurationSection@example.com";

        [ConfigurationProperty(PROPERTY_SERVER, DefaultValue = PROPERTY_SERVER_DEFAULT, IsRequired = false)]
        public string Server
        {
            get { return (string) this[PROPERTY_SERVER]; }
            set { this[PROPERTY_SERVER] = value; }
        }

        [ConfigurationProperty(PROPERTY_RECIPIENT, DefaultValue = PROPERTY_RECIPIENT_DEFAULT, IsRequired = true)]
        public string Recipient
        {
            get { return (string) this[PROPERTY_RECIPIENT]; }
            set { this[PROPERTY_RECIPIENT] = value; }
        }

        [ConfigurationProperty(PROPERTY_SENDER, DefaultValue = PROPERTY_SENDER_DEFAULT, IsRequired = true)]
        public string Sender
        {
            get { return (string) this[PROPERTY_SENDER]; }
            set { this[PROPERTY_SENDER] = value; }
        }
    }
}
