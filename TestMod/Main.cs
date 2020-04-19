using MelonLoader;

namespace TestMod {

    public static class BuildInfo {
        public const string Name = "TestMod"; // Name of the Mod.  (MUST BE SET)
        public const string Author = null; // Author of the Mod.  (Set as null if none)
        public const string Company = null; // Company that made the Mod.  (Set as null if none)
        public const string Version = "1.0.0"; // Version of the Mod.  (MUST BE SET)
        public const string DownloadLink = null; // Download Link for the Mod.  (Set as null if none)
    }

    public enum LogLevel {
        INFO,
        WARN,
        ERROR,
        DEBUG,
        TRACE
    }

    public class TestMod : MelonMod {
        private LogLevel _logLevel;
        private bool isDebugMode = true;

        public override void OnApplicationStart() {
            _logLevel = LogLevel.DEBUG;
            MelonModLogger.Log("OnApplicationStart");
        }

        public override void OnLevelWasLoaded(int level) {
            Info("OnLevelWasLoaded: " + level.ToString());
        }

        public override void OnLevelWasInitialized(int level) {
            Info("OnLevelWasInitialized: " + level.ToString());
        }

        public override void OnUpdate() {
            Trace("OnUpdate");
        }

        public override void OnFixedUpdate() {
            Trace("OnFixedUpdate");
        }

        public override void OnLateUpdate() {
            Trace("OnLateUpdate");
        }

        public override void OnGUI() {
            Trace("OnGUI");
        }

        public override void OnApplicationQuit() {
            Warn("OnApplicationQuit");
        }

        public override void OnModSettingsApplied() {
            Info("OnModSettingsApplied");
        }

        public override void VRChat_OnUiManagerInit() // Only works in VRChat
        {
            Info("VRChat_OnUiManagerInit");
        }

        public void Info(string message) {
            MelonModLogger.Log($"{message}");
        }

        public void Warn(string message) {
            if (_logLevel >= LogLevel.WARN)
                MelonModLogger.Log($"[WARN] {message}");
        }

        public void Error(string message) {
            if (_logLevel >= LogLevel.ERROR)
                MelonModLogger.LogError($"{message}");
        }

        public void Debug(string message) {
            if (isDebugMode && _logLevel >= LogLevel.DEBUG)
                MelonModLogger.Log($"[DEBUG] {message}");
        }

        public void Trace(string message) {
            if (isDebugMode && _logLevel == LogLevel.TRACE)
                MelonModLogger.Log($"[TRACE] {message}");
        }
    }
}