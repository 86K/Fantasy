using Fantasy.Async;
using Fantasy.Event;

namespace Fantasy;

public sealed class OnCreateSceneEvent : AsyncEventSystem<OnCreateScene>
{
    protected override async FTask Handler(OnCreateScene self)
    {
        var scene = self.Scene;

        await FTask.CompletedTask;
        
        switch (scene.SceneType)
        {
            case SceneType.Main:
            {
                Log.Debug("Main scene created");
                break;
            }
        }
    }
}