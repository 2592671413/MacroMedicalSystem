﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.296
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Macro.Web.Client.Silverlight {
    using System;
    
    
    /// <summary>
    ///   一个强类型的资源类，用于查找本地化的字符串等。
    /// </summary>
    // 此类是由 StronglyTypedResourceBuilder
    // 类通过类似于 ResGen 或 Visual Studio 的工具自动生成的。
    // 若要添加或移除成员，请编辑 .ResX 文件，然后重新运行 ResGen
    // (以 /str 作为命令选项)，或重新生成 VS 项目。
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class SR {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal SR() {
        }
        
        /// <summary>
        ///   返回此类使用的缓存的 ResourceManager 实例。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Macro.Web.Client.Silverlight.SR", typeof(SR).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   使用此强类型资源类，为所有资源查找
        ///   重写当前线程的 CurrentUICulture 属性。
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
        ///   查找类似 Clear 的本地化字符串。
        /// </summary>
        internal static string Clear {
            get {
                return ResourceManager.GetString("Clear", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Value must be non-negative. 的本地化字符串。
        /// </summary>
        internal static string ExceptionArgumentNegative {
            get {
                return ResourceManager.GetString("ExceptionArgumentNegative", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Value must be greater than zero. 的本地化字符串。
        /// </summary>
        internal static string ExceptionArgumentNotPositive {
            get {
                return ResourceManager.GetString("ExceptionArgumentNotPositive", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 {3} = {0} is invalid. {3} must be &gt;= {1} and &lt;= {2}. 的本地化字符串。
        /// </summary>
        internal static string ExceptionArgumentOutOfRange {
            get {
                return ResourceManager.GetString("ExceptionArgumentOutOfRange", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Condition is not met :{0} 的本地化字符串。
        /// </summary>
        internal static string ExceptionConditionIsNotMet {
            get {
                return ResourceManager.GetString("ExceptionConditionIsNotMet", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 {0} cannot be empty. 的本地化字符串。
        /// </summary>
        internal static string ExceptionEmptyString {
            get {
                return ResourceManager.GetString("ExceptionEmptyString", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Expected type {0}. 的本地化字符串。
        /// </summary>
        internal static string ExceptionExpectedType {
            get {
                return ResourceManager.GetString("ExceptionExpectedType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 {3}[{0}] is invalid.  Index must be &gt;= {1} and &lt;= {2}. 的本地化字符串。
        /// </summary>
        internal static string ExceptionIndexOutOfRange {
            get {
                return ResourceManager.GetString("ExceptionIndexOutOfRange", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 {0} must be of type {1}. 的本地化字符串。
        /// </summary>
        internal static string ExceptionInvalidCast {
            get {
                return ResourceManager.GetString("ExceptionInvalidCast", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 {0} has not been set.  Object state is invalid. 的本地化字符串。
        /// </summary>
        internal static string ExceptionMemberNotSet {
            get {
                return ResourceManager.GetString("ExceptionMemberNotSet", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 {0} has not been set.  {1} 的本地化字符串。
        /// </summary>
        internal static string ExceptionMemberNotSetVerbose {
            get {
                return ResourceManager.GetString("ExceptionMemberNotSetVerbose", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Exception thrown 的本地化字符串。
        /// </summary>
        internal static string ExceptionThrown {
            get {
                return ResourceManager.GetString("ExceptionThrown", resourceCulture);
            }
        }
    }
}
