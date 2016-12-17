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

using System;
using System.Linq;
using biz.dfch.CS.Examples.DI.StructureMap.IoC.Conventions;
using biz.dfch.CS.Examples.DI.StructureMap.SetterInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace biz.dfch.CS.Examples.DI.StructureMap.Tests.IoC.Conventions
{
    [TestClass]
    public class PropertySetterRegistrationConventionTest
    {
        [TestMethod]
        public void FilterTypeWithObjectReturnsNothing()
        {
            var types = new Type[] { typeof(object) };

            var result = types.Where(PropertySetterRegistrationConvention.TypeFilter);

            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void FilterTypeWithMatchReturnsType()
        {
            var types = new Type[] { typeof(AnotherClassWithSetterProperty) };

            var result = types.Where(PropertySetterRegistrationConvention.TypeFilter);

            Assert.AreEqual(1, result.Count());
        }
    }
}