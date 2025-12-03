namespace Shared.Mise.Exceptions {
    using System;
    using System.Resources;
    using System.Globalization;

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class ResourceMessagesException {
        
        private static ResourceManager resourceMan;
        private static CultureInfo resourceCulture;

        internal ResourceMessagesException() {
        }

        internal static ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    ResourceManager temp = new ResourceManager("Mise.Exceptions.ResourceMessagesException", typeof(ResourceMessagesException).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }

        internal static CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        public static string NAME_EMPTY {
            get {
                return ResourceManager.GetString("NAME_EMPTY", resourceCulture);
            }
        }

        public static string EMAIL_EMPTY {
            get {
                return ResourceManager.GetString("EMAIL_EMPTY", resourceCulture);
            }
        }

        public static string EMAIL_INVALID {
            get {
                return ResourceManager.GetString("EMAIL_INVALID", resourceCulture);
            }
        }

        public static string EMAIL_ALREADY_REGISTERED {
            get {
                return ResourceManager.GetString("EMAIL_ALREADY_REGISTERED", resourceCulture);
            }
        }

        public static string PASSWORD_EMPTY {
            get {
                return ResourceManager.GetString("PASSWORD_EMPTY", resourceCulture);
            }
        }

        public static string PASSWORD_MIN_LENGTH {
            get {
                return ResourceManager.GetString("PASSWORD_MIN_LENGTH", resourceCulture);
            }
        }

        public static string PASSWORD_MAX_LENGTH {
            get {
                return ResourceManager.GetString("PASSWORD_MAX_LENGTH", resourceCulture);
            }
        }

    }
}