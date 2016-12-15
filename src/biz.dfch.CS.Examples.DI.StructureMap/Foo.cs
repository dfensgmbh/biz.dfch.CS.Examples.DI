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
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using biz.dfch.CS.Examples.DI.StructureMap.Message;

namespace biz.dfch.CS.Examples.DI.StructureMap
{
    public class Foo : IFoo
    {
        private readonly IMessage message;

        public string StringProperty { get; set; }
        public long LongProperty { get; set; }

        public Foo(IMessage message)
        {
            Contract.Requires(null != message);

            this.message = message;
        }
            
        public bool IsTralala()
        {
            return Resouces.FooIsTralalaComparison.Equals(StringProperty);
        }

        public bool Is42()
        {
            return Resouces.FooIs42Comparison == LongProperty;
        }

        public void NotifyIfNotEqual()
        {
            var subject = 0 != LongProperty
                ? LongProperty.ToString()
                : Resouces.FooIs42Comparison.ToString();

            var body = !string.IsNullOrWhiteSpace(StringProperty)
                ? StringProperty
                : Resouces.FooIsTralalaComparison;

            message.Send(subject, body);
        }

    }
}
