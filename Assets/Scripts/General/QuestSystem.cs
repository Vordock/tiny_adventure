using System.Collections.Generic;
using UnityEngine;

namespace tiny_adventure
{
    public class QuestSystem : MonoBehaviour
    {
        public static QuestSystem Instance;

        // Stores quest progress
        private HashSet<string> activeQuests = new();
        private HashSet<string> completedQuests = new();

        private Dictionary<string, int> questProgress = new();
        private Dictionary<string, int> questTargets = new();

        private void Awake()
        {
            Instance = this;

            // Setup quest goals
            // "KillEnemies" requires 5 kills
            questTargets["KillEnemies"] = 5;
            questProgress["KillEnemies"] = 0;
        }

        public void StartQuest(string id)
        {
            if (!activeQuests.Contains(id) && !completedQuests.Contains(id))
            {
                activeQuests.Add(id);
                questProgress[id] = 0; // Reset
            }
        }

        public bool HasQuest(string id)
        {
            return activeQuests.Contains(id);
        }

        public bool IsQuestCompleted(string id)
        {
            return completedQuests.Contains(id);
        }

        public void AddProgress(string id, int amount = 1)
        {
            if (!activeQuests.Contains(id)) return;

            questProgress[id] += amount;

            // Check completion
            if (questProgress[id] >= questTargets[id])
            {
                CompleteQuest(id);
            }
        }

        private void CompleteQuest(string id)
        {
            activeQuests.Remove(id);
            completedQuests.Add(id);
        }

        public int GetProgress(string id) => questProgress.ContainsKey(id) ? questProgress[id] : 0;
        public int GetTarget(string id) => questTargets.ContainsKey(id) ? questTargets[id] : 0;
    }
}
