using System;
using UnityEngine; // Vector2を使用するために必要

namespace Application
{
    // ターゲットクリック時のユースケースを表すインターフェース
    public interface IClickTargetUseCase
    {
        // クリックされたターゲットの処理を実行
        void HandleClick(Guid targetId, Vector2 clickPosition);
    }
} 