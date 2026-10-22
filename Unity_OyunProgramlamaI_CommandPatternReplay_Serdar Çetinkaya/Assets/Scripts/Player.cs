using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Command deseni için ortak komut sözleşmesi.
/// Her komut çalıştırılabilir ve geri alınabilir.
/// </summary>
public interface ICommand
{
    void Execute();
    void Undo();
}

/// <summary>
/// Oyuncuyu tek bir yönde hareket ettiren somut komut.
/// Undo için hareketten önceki konumunu saklar.
/// </summary>
public sealed class MoveCommand : ICommand
{
    private readonly Transform target;
    private readonly Vector3 direction;
    private readonly float distance;
    private Vector3 previousPosition;
    private bool hasExecuted;

    public MoveCommand(Transform target, Vector3 direction, float distance)
    {
        this.target = target;
        this.direction = direction.normalized;
        this.distance = distance;
    }

    public void Execute()
    {
        if (target == null) return;
        previousPosition = target.position;
        target.position += direction * distance;
        hasExecuted = true;
    }

    public void Undo()
    {
        if (!hasExecuted || target == null) return;
        target.position = previousPosition;
        hasExecuted = false;
    }
}

/// <summary>
/// WASD girdilerini komutlara çevirir; undo ve replay geçmişini yönetir.
/// Z: undo, R: kalan komutları yeniden oynat.
/// </summary>
public class Player : MonoBehaviour
{
    [SerializeField] private float stepDistance = 1f;
    [SerializeField] private float replayStepDelay = 0.25f;

    private readonly Stack<ICommand> undoStack = new Stack<ICommand>();
    private readonly List<ICommand> replayCommands = new List<ICommand>();
    private Vector3 gameStartPosition;
    private bool isReplaying;

    private void Awake()
    {
        // Sahne her yeni oyun için yüklendiğinde geçmiş boş başlar.
        gameStartPosition = transform.position;
        undoStack.Clear();
        replayCommands.Clear();
        isReplaying = false;
    }

    private void Update()
    {
        if (isReplaying) return;

        // Her tuş basışı tek bir komut üretir; Undo bu adımı geri alır.
        if (Input.GetKeyDown(KeyCode.W)) ExecuteMove(Vector3.up);
        if (Input.GetKeyDown(KeyCode.A)) ExecuteMove(Vector3.left);
        if (Input.GetKeyDown(KeyCode.D)) ExecuteMove(Vector3.right);
        if (Input.GetKeyDown(KeyCode.S)) ExecuteMove(Vector3.down);

        if (Input.GetKeyDown(KeyCode.Z)) UndoLastCommand();
        if (Input.GetKeyDown(KeyCode.R) && replayCommands.Count > 0)
            StartCoroutine(Replay());
    }

    private void ExecuteMove(Vector3 direction)
    {
        ICommand command = new MoveCommand(transform, direction, stepDistance);
        command.Execute();
        undoStack.Push(command);
        replayCommands.Add(command);
    }

    private void UndoLastCommand()
    {
        if (undoStack.Count == 0) return;

        ICommand command = undoStack.Pop();
        command.Undo();

        // Undo edilen komut replay kaydından da çıkarılır.
        int lastIndex = replayCommands.Count - 1;
        if (lastIndex >= 0) replayCommands.RemoveAt(lastIndex);
    }

    private IEnumerator Replay()
    {
        isReplaying = true;
        transform.position = gameStartPosition;

        // Dizi kopyası replay sırasında geçmiş koleksiyonunun değişmesini önler.
        ICommand[] commandsToReplay = replayCommands.ToArray();
        foreach (ICommand command in commandsToReplay)
        {
            command.Execute();
            yield return new WaitForSeconds(replayStepDelay);
        }

        isReplaying = false;
    }
}
