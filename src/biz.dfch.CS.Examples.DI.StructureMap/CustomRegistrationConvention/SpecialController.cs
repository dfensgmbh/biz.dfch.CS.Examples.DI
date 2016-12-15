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
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace biz.dfch.CS.Examples.DI.StructureMap.CustomRegistrationConvention
{
    public class SpecialController : IController
    {
        private readonly ControllerSettings settings;

        public SpecialController(ControllerSettings settings)
        {
            Contract.Requires(null != settings);
            Contract.Requires(settings.IsValid());

            this.settings = settings;
        }
            
        public long TakeControl(string command)
        {
            var message = string.Format(Resouces.ControllerTakeControlTemplate, command, settings.Name, settings.Description);
            for (var c = 0; c < settings.Retries; c++)
            {
                Trace.WriteLine(message);
            }

            var result = settings.Retries;
            return result;
        }
    }
}
