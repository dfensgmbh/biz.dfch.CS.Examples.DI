﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace biz.dfch.CS.Examples.DI.StructureMap {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resouces {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resouces() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("biz.dfch.CS.Examples.DI.StructureMap.Resouces", typeof(Resouces).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Command &apos;{0}&apos;. Name &apos;{1}&apos;. Description &apos;{2}&apos;.
        /// </summary>
        internal static string ControllerTakeControlTemplate {
            get {
                return ResourceManager.GetString("ControllerTakeControlTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Int64 similar to 42.
        /// </summary>
        internal static long FooIs42Comparison {
            get {
                object obj = ResourceManager.GetObject("FooIs42Comparison", resourceCulture);
                return ((long)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to tralala.
        /// </summary>
        internal static string FooIsTralalaComparison {
            get {
                return ResourceManager.GetString("FooIsTralalaComparison", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Server &apos;{0}&apos;. Recipient &apos;{1}&apos;. Sender &apos;{2}&apos;. Subject &apos;{3}&apos;. Message &apos;{4}&apos;..
        /// </summary>
        internal static string MessageSendTemplate {
            get {
                return ResourceManager.GetString("MessageSendTemplate", resourceCulture);
            }
        }
    }
}
