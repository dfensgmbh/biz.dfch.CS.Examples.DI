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

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using biz.dfch.CS.Commons;

namespace biz.dfch.CS.Examples.DI.StructureMap.Message
{
    // default implementation of IMessageSettings to use with DI
    public class MessageSettings : BaseDto, IMessageSettings
    {
        private const string SERVER_DEFAULT_VALUE = "smtp.example.com";
        private const string SENDER_DEFAULT_VALUE = "sender@example.com";
        private const string RECIPIENT_DEFAULT_VALUE = "recipient@example.com";

        [Required]
        [DefaultValue(SERVER_DEFAULT_VALUE)]
        public string Server { get; set; }

        [Required]
        [EmailAddress]
        [DefaultValue(SENDER_DEFAULT_VALUE)]
        public string Sender { get; set; }

        [Required]
        [EmailAddress]
        [DefaultValue(RECIPIENT_DEFAULT_VALUE)]
        public string Recipient { get; set; }
    }
}
