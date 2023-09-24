using System;
using Microsoft.Xna.Framework;

namespace Celeste.Mod.FeatherHelper {
    public class FeatherHelperModule : EverestModule {
        public static FeatherHelperModule Instance { get; private set; }

        public override Type SettingsType => typeof(FeatherHelperModuleSettings);
        public static FeatherHelperModuleSettings Settings => (FeatherHelperModuleSettings) Instance._Settings;

        public override Type SessionType => typeof(FeatherHelperModuleSession);
        public static FeatherHelperModuleSession Session => (FeatherHelperModuleSession) Instance._Session;

        public FeatherHelperModule() {
            Instance = this;
#if DEBUG
            // debug builds use verbose logging
            Logger.SetLogLevel(nameof(FeatherHelperModule), LogLevel.Verbose);
#else
            // release builds use info logging to reduce spam in log files
            Logger.SetLogLevel(nameof(FeatherHelperModule), LogLevel.Info);
#endif
        }

        public override void Load() {
            // TODO: apply any hooks that should always be active
        }

        public override void Unload() {
            // TODO: unapply any hooks applied in Load()
        }
    }
}