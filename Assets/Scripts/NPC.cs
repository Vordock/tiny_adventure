using UnityEngine;

namespace tiny_adventure
{
	public enum NPCType
	{
		Sage,
		Inn
	}

	public class NPC : MonoBehaviour, IInteractable
	{
		public NPCType npcType;
		public NPCDialogue dialogue;

		public void StartInteraction()
		{
			DialogueSystem.Instance.StartDialogue(dialogue);

			switch (npcType)
			{
				case NPCType.Sage:
					HandleSage();
					break;

				case NPCType.Inn:
					HandleInn();
					break;
			}
		}

		private void HandleSage()
		{
			string questId = "KillEnemies";
			string keyId = "SageKey";

			// Quest not started
			if (!QuestSystem.Instance.HasQuest(questId) &&
				!QuestSystem.Instance.IsQuestCompleted(questId))
			{
				DialogueSystem.Instance.StartDialogue(dialogue);
				QuestSystem.Instance.StartQuest(questId);
				return;
			}

			// Quest in progress
			if (QuestSystem.Instance.HasQuest(questId) &&
				!QuestSystem.Instance.IsQuestCompleted(questId))
			{
				DialogueSystem.Instance.StartDialogue(dialogue);
				return;
			}

			// Quest completed, key not spawned yet
			if (QuestSystem.Instance.IsQuestCompleted(questId) &&
				!ItemSystem.Instance.HasItem(keyId) &&
				!ItemSystem.Instance.WasItemSpawned(keyId))
			{
				DialogueSystem.Instance.StartDialogue(dialogue);

				// Spawn key on the right side
				ItemSystem.Instance.SpawnItem(keyId, transform.position + Vector3.right);

				return;
			}

			// Player already collected the key
			if (ItemSystem.Instance.HasItem(keyId))
			{
				DialogueSystem.Instance.StartDialogue(dialogue);
			}
		}

		private void HandleInn()
		{
			// Example inn logic
			const int price = 5;
			if (DataManager.coinCount >= price)
			{
				DataManager.coinCount -= price;
				ActionManager.HealPlayer?.Invoke();
			}
			else
			{
				DialogueSystem.Instance.StartSingleLine("You don't have enough gold.");
			}
		}

		public void FinishInteraction() { }
	}
}
